using Azure.Core;
using Oracle.ManagedDataAccess.Client;
using StartBack.Domain.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBack.Infrastructure.Helpers
{
    public class OracleSqlExecutor
    {
        private readonly string _connectionString;
        private readonly ConcurrentDictionary<string, List<string>> _columnCache = new ConcurrentDictionary<string, List<string>>();

        public OracleSqlExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }

        // For queries that return results (SELECT)
        //public async Task<List<Dictionary<string, object>>> ExecuteQueryAsync(string sql, params OracleParameter[] parameters)
        //{
        //    var results = new List<Dictionary<string, object>>();

        //    using (var connection = new OracleConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();

        //        using (var command = new OracleCommand(sql, connection))
        //        {
        //            if (parameters != null && parameters.Length > 0)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }

        //            using (var reader = await command.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    var row = new Dictionary<string, object>();
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
        //                    }
        //                    results.Add(row);
        //                }
        //            }
        //        }
        //    }

        //    return results;
        //}

        //    public async Task<PaginatedResult<Dictionary<string, object>>> ExecuteQueryAsync(
        //string sql,
        //OracleParameter[] parameters,
        //FindOptions? findOptions = null)
        //    {
        //        findOptions ??= new FindOptions();

        //        // Build the base query with filters
        //        var (filteredSql, filteredParameters) = ApplyFilters(sql, parameters, findOptions.Filters);

        //        // Apply sorting
        //        var sortedSql = ApplySorting(filteredSql, findOptions.SortBy, findOptions.SortDescending);

        //        // Get total count
        //        var countSql = $"SELECT COUNT(*) FROM ({filteredSql})";
        //        var totalCount = await GetTotalCountAsync(countSql, filteredParameters);

        //        // Apply pagination
        //        var paginatedSql = ApplyPagination(sortedSql, findOptions.PageNumber, findOptions.PageSize);

        //        // Execute the final query
        //        var results = new List<Dictionary<string, object>>();

        //        using (var connection = new OracleConnection(_connectionString))
        //        {
        //            await connection.OpenAsync();

        //            using (var command = new OracleCommand(paginatedSql, connection))
        //            {
        //                if (filteredParameters != null && filteredParameters.Length > 0)
        //                {
        //                    command.Parameters.AddRange(filteredParameters);
        //                }

        //                using (var reader = await command.ExecuteReaderAsync())
        //                {
        //                    while (await reader.ReadAsync())
        //                    {
        //                        var row = new Dictionary<string, object>();
        //                        for (int i = 0; i < reader.FieldCount; i++)
        //                        {
        //                            row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
        //                        }
        //                        results.Add(row);
        //                    }
        //                }
        //            }
        //        }

        //        return new PaginatedResult<Dictionary<string, object>>
        //        {
        //            Items = results,
        //            PageNumber = findOptions.PageNumber,
        //            PageSize = findOptions.PageSize,
        //            TotalCount = totalCount
        //        };
        //    }
        public async Task<PaginatedResult<Dictionary<string, object>>> ExecuteQueryAsync(
    string sql,
    OracleParameter[] parameters,
    FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();

            try
            {
                // If no search or filters, use simple execution
                if (string.IsNullOrWhiteSpace(findOptions.Search) && 
                    (findOptions.Filters == null || !findOptions.Filters.Any()))
                {
                    return await ExecuteSimpleQueryAsync(sql, parameters, findOptions);
                }

                // Use string replacement instead of parameters for search/filters to avoid binding issues
                var modifiedSql = BuildSqlWithStringReplacement(sql, findOptions);

                // Apply sorting
                var sortedSql = ApplySorting(modifiedSql, findOptions.SortBy, findOptions.Desc);

                // Get total count
                var countSql = $"SELECT COUNT(*) FROM ({sortedSql})";
                var totalCount = await GetTotalCountAsync(countSql, parameters);

                // Apply pagination
                var paginatedSql = ApplyPagination(sortedSql, findOptions.Page, findOptions.PageSize);

                // Execute the final query
                var results = await ExecuteFinalQueryAsync(paginatedSql, parameters);

                return new PaginatedResult<Dictionary<string, object>>
                {
                    Items = results,
                    Page = findOptions.Page,
                    PageSize = findOptions.PageSize,
                    Total = totalCount
                };
            }
            catch (OracleException ex) when (ex.Number == 936) // ORA-00936
            {
                throw new InvalidOperationException("Invalid SQL query generated. Please check your filter criteria.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing query: {ex.Message}", ex);
            }
        }

        private string BuildSqlWithStringReplacement(string sql, FindOptions findOptions)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append($"SELECT * FROM ({sql}) base_query");
            
            var whereConditions = new List<string>();

            // Add global search condition using string replacement
            if (!string.IsNullOrWhiteSpace(findOptions.Search))
            {
                var searchCondition = BuildSearchWithStringReplacement(sql, findOptions.Search);
                if (!string.IsNullOrEmpty(searchCondition))
                {
                    whereConditions.Add($"({searchCondition})");
                }
            }

            // Add filter conditions using string replacement
            if (findOptions.Filters != null && findOptions.Filters.Any())
            {
                var filterCondition = BuildFiltersWithStringReplacement(findOptions.Filters);
                if (!string.IsNullOrEmpty(filterCondition))
                {
                    whereConditions.Add($"({filterCondition})");
                }
            }

            // Add WHERE clause if needed
            if (whereConditions.Any())
            {
                queryBuilder.Append(" WHERE ");
                queryBuilder.Append(string.Join(" AND ", whereConditions));
            }

            var finalSql = queryBuilder.ToString();
            
            // Debug: Log the complete generated SQL
            System.Diagnostics.Debug.WriteLine($"Complete generated SQL: {finalSql}");
            
            return finalSql;
        }

        private async Task<PaginatedResult<Dictionary<string, object>>> ExecuteSimpleQueryAsync(
            string sql, 
            OracleParameter[] parameters, 
            FindOptions findOptions)
        {
            // Apply sorting
            var sortedSql = ApplySorting(sql, findOptions.SortBy, findOptions.Desc);

            // Get total count
            var countSql = BuildCountSql(sortedSql);
            var totalCount = await GetTotalCountAsync(countSql, parameters);

            // Apply pagination
            var paginatedSql = ApplyPagination(sortedSql, findOptions.Page, findOptions.PageSize);

            // Execute the final query
            var results = await ExecuteFinalQueryAsync(paginatedSql, parameters);

            return new PaginatedResult<Dictionary<string, object>>
            {
                Items = results,
                Page = findOptions.Page,
                PageSize = findOptions.PageSize,
                Total = totalCount
            };
        }

        private string BuildCountSql(string sql)
        {
            // Simple count query - wrap the original query
            return $"SELECT COUNT(*) FROM ({sql})";
        }

        private async Task<List<Dictionary<string, object>>> ExecuteFinalQueryAsync(string sql, OracleParameter[] parameters)
        {
            var results = new List<Dictionary<string, object>>();

            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new OracleCommand(sql, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        // Clone parameters to avoid conflicts
                        foreach (var param in parameters)
                        {
                            var clonedParam = new OracleParameter(param.ParameterName, param.OracleDbType)
                            {
                                Value = param.Value,
                                Direction = param.Direction,
                                Size = param.Size
                            };
                            command.Parameters.Add(clonedParam);
                        }
                    }

                    try
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                }
                                results.Add(row);
                            }
                        }
                    }
                    catch (OracleException ex)
                    {
                        // Enhanced error logging
                        System.Diagnostics.Debug.WriteLine($"Oracle Error in ExecuteFinalQueryAsync: {ex.Message}");
                        System.Diagnostics.Debug.WriteLine($"SQL: {sql}");
                        System.Diagnostics.Debug.WriteLine($"Parameters: {string.Join(", ", parameters.Select(p => $"{p.ParameterName}={p.Value}"))}");
                        throw;
                    }
                }
            }

            return results;
        }


        private async Task<int> GetTotalCountAsync(string countSql, OracleParameter[] parameters)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new OracleCommand(countSql, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        // Clone parameters to avoid conflicts
                        foreach (var param in parameters)
                        {
                            var clonedParam = new OracleParameter(param.ParameterName, param.OracleDbType)
                            {
                                Value = param.Value,
                                Direction = param.Direction,
                                Size = param.Size
                            };
                            command.Parameters.Add(clonedParam);
                        }
                    }

                    try
                    {
                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                    catch (OracleException ex)
                    {
                        // Enhanced error logging
                        System.Diagnostics.Debug.WriteLine($"Oracle Error in GetTotalCountAsync: {ex.Message}");
                        System.Diagnostics.Debug.WriteLine($"SQL: {countSql}");
                        System.Diagnostics.Debug.WriteLine($"Parameters: {string.Join(", ", parameters.Select(p => $"{p.ParameterName}={p.Value}"))}");
                        throw;
                    }
                }
            }
        }

        //private (string sql, OracleParameter[] parameters) ApplyFilters(
        //    string originalSql,
        //    OracleParameter[] originalParameters,
        //    List<FilterCriteria>? filters)
        //{
        //    if (filters == null || !filters.Any())
        //        return (originalSql, originalParameters);

        //    var whereClauses = new List<string>();
        //    var newParameters = new List<OracleParameter>(originalParameters);
        //    var paramIndex = originalParameters.Length;

        //    foreach (var filter in filters)
        //    {
        //        var paramName = $":filter_{paramIndex}";
        //        var whereClause = BuildWhereClause(filter.ColumnName, filter.Operator, paramName);

        //        whereClauses.Add(whereClause);
        //        newParameters.Add(new OracleParameter(paramName, GetOracleDbType(filter.Value)) { Value = filter.Value });

        //        paramIndex++;
        //    }

        //    var whereClauseString = string.Join(" AND ", whereClauses);
        //    var filteredSql = originalSql.Contains("WHERE", StringComparison.OrdinalIgnoreCase)
        //        ? $"{originalSql} AND {whereClauseString}"
        //        : $"{originalSql} WHERE {whereClauseString}";

        //    return (filteredSql, newParameters.ToArray());
        //}

        //private string BuildWhereClause(string columnName, string operation, string paramName)
        //{
        //    return operation.ToUpper() switch
        //    {
        //        "EQUALS" => $"{columnName} = {paramName}",
        //        "CONTAINS" => $"{columnName} LIKE '%' || {paramName} || '%'",
        //        "STARTSWITH" => $"{columnName} LIKE {paramName} || '%'",
        //        "ENDSWITH" => $"{columnName} LIKE '%' || {paramName}",
        //        "GREATERTHAN" => $"{columnName} > {paramName}",
        //        "LESSTHAN" => $"{columnName} < {paramName}",
        //        "GREATERTHANOREQUAL" => $"{columnName} >= {paramName}",
        //        "LESSTHANOREQUAL" => $"{columnName} <= {paramName}",
        //        "NOTEQUAL" => $"{columnName} != {paramName}",
        //        "IN" => $"{columnName} IN ({paramName})",
        //        "NOTIN" => $"{columnName} NOT IN ({paramName})",
        //        "ISNULL" => $"{columnName} IS NULL",
        //        "ISNOTNULL" => $"{columnName} IS NOT NULL",
        //        _ => $"{columnName} = {paramName}"
        //    };
        //}

        private (string sql, OracleParameter[] parameters) ApplyFilters(
    string originalSql,
    OracleParameter[] originalParameters,
    List<FilterCriteria>? filters)
        {
            if (filters == null || !filters.Any())
                return (originalSql, originalParameters);

            var whereClauses = new List<string>();
            var newParameters = new List<OracleParameter>(originalParameters);
            var paramIndex = originalParameters.Length;

            foreach (var filter in filters)
            {
                // Skip filters with null values (except for NULL/ISNULL operations)
                if (filter.Value == null &&
                    filter.Operator != "ISNULL" &&
                    filter.Operator != "ISNOTNULL")
                {
                    continue;
                }

                var paramName = $":filter_{paramIndex}";
                var whereClause = BuildWhereClause(filter.ColumnName, filter.Operator, paramName, filter.Value);

                whereClauses.Add(whereClause);

                // Only add parameter value for non-NULL operations
                if (filter.Operator != "ISNULL" && filter.Operator != "ISNOTNULL")
                {
                    newParameters.Add(new OracleParameter(paramName, GetOracleDbType(filter.Value)) { Value = filter.Value });
                }

                paramIndex++;
            }

            // If no valid filters remain after processing, return original
            if (!whereClauses.Any())
                return (originalSql, originalParameters);

            var whereClauseString = string.Join(" AND ", whereClauses);

            // Handle WHERE clause insertion properly
            var sqlLower = originalSql.ToLower();
            var hasWhere = sqlLower.Contains(" where ");
            var hasGroupBy = sqlLower.Contains(" group by ");
            var hasOrderBy = sqlLower.Contains(" order by ");
            var hasHaving = sqlLower.Contains(" having ");

            string filteredSql;

            if (hasWhere)
            {
                // Insert before GROUP BY/ORDER BY/HAVING if they exist
                if (hasGroupBy)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" group by "), $" AND {whereClauseString}");
                }
                else if (hasHaving)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" having "), $" AND {whereClauseString}");
                }
                else if (hasOrderBy)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" order by "), $" AND {whereClauseString}");
                }
                else
                {
                    filteredSql = $"{originalSql} AND {whereClauseString}";
                }
            }
            else
            {
                // Add WHERE clause before GROUP BY/ORDER BY/HAVING if they exist
                if (hasGroupBy)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" group by "), $" WHERE {whereClauseString}");
                }
                else if (hasHaving)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" having "), $" WHERE {whereClauseString}");
                }
                else if (hasOrderBy)
                {
                    filteredSql = originalSql.Insert(originalSql.ToLower().IndexOf(" order by "), $" WHERE {whereClauseString}");
                }
                else
                {
                    filteredSql = $"{originalSql} WHERE {whereClauseString}";
                }
            }

            return (filteredSql, newParameters.ToArray());
        }

        private string BuildWhereClause(string columnName, string operation, string paramName, object? value)
        {
            return operation.ToUpper() switch
            {
                "EQUALS" => $"{columnName} = {paramName}",
                "CONTAINS" => $"{columnName} LIKE '%' || {paramName} || '%'",
                "STARTSWITH" => $"{columnName} LIKE {paramName} || '%'",
                "ENDSWITH" => $"{columnName} LIKE '%' || {paramName}",
                "GREATERTHAN" => $"{columnName} > {paramName}",
                "LESSTHAN" => $"{columnName} < {paramName}",
                "GREATERTHANOREQUAL" => $"{columnName} >= {paramName}",
                "LESSTHANOREQUAL" => $"{columnName} <= {paramName}",
                "NOTEQUAL" => $"{columnName} != {paramName}",
                "IN" => HandleInOperator(columnName, value, paramName),
                "NOTIN" => $"{columnName} NOT IN ({paramName})",
                "ISNULL" => $"{columnName} IS NULL",
                "ISNOTNULL" => $"{columnName} IS NOT NULL",
                _ => $"{columnName} = {paramName}"
            };
        }

        private string HandleInOperator(string columnName, object? value, string paramName)
        {
            if (value is IEnumerable<object> enumerable && enumerable.Any())
            {
                return $"{columnName} IN ({paramName})";
            }
            else if (value is string stringValue && !string.IsNullOrEmpty(stringValue))
            {
                return $"{columnName} IN ({paramName})";
            }

            // Return a condition that will always be false for empty IN clauses
            return "1 = 0";
        }

        private string ApplySorting(string sql, string? sortBy, bool sortDescending)
        {
            if (string.IsNullOrEmpty(sortBy))
                return sql;

            // Remove existing ORDER BY clause if present
            var orderByIndex = sql.LastIndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
            if (orderByIndex != -1)
            {
                sql = sql.Substring(0, orderByIndex).Trim();
            }

            return $"{sql} ORDER BY {sortBy} {(sortDescending ? "DESC" : "ASC")}";
        }

        private string ApplyPagination(string sql, int pageNumber, int pageSize)
        {
            if (pageSize <= 0)
                return sql;

            var offset = (pageNumber - 1) * pageSize;

            // Oracle 12c+ syntax for pagination
            return $@"
        SELECT * FROM (
            SELECT t.*, ROWNUM rn FROM (
                {sql}
            ) t WHERE ROWNUM <= {offset + pageSize}
        ) WHERE rn > {offset}";
        }

        //private string ApplyPagination(string sql, int pageNumber, int pageSize)
        //{
        //    if (pageSize <= 0)
        //        return sql;

        //    var offset = (pageNumber - 1) * pageSize;

        //    // Remove any existing ORDER BY clause from inner query for Oracle pagination
        //    var innerSql = sql;
        //    var orderByIndex = innerSql.LastIndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
        //    if (orderByIndex != -1)
        //    {
        //        innerSql = innerSql.Substring(0, orderByIndex).Trim();
        //    }

        //    // Oracle 12c+ syntax for pagination
        //    return $@"
        //SELECT * FROM (
        //    SELECT t.*, ROWNUM rn FROM (
        //        {innerSql}
        //    ) t WHERE ROWNUM <= {offset + pageSize}
        //) WHERE rn > {offset}";
        //}
        private OracleDbType GetOracleDbType(object value)
        {
            return value switch
            {
                int _ => OracleDbType.Int32,
                long _ => OracleDbType.Int64,
                decimal _ => OracleDbType.Decimal,
                double _ => OracleDbType.Double,
                float _ => OracleDbType.Single,
                DateTime _ => OracleDbType.Date,
                string _ => OracleDbType.Varchar2,
                bool _ => OracleDbType.Boolean,
                byte[] _ => OracleDbType.Blob,
                _ => OracleDbType.Varchar2
            };
        }


        private string BuildSearchWithStringReplacement(string sql, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            try
            {
                var columnNames = GetColumnNamesCachedAsync(sql, new OracleParameter[0]).GetAwaiter().GetResult();
                if (!columnNames.Any())
                    return string.Empty;

                var searchConditions = new List<string>();
                var escapedSearchTerm = searchTerm.Replace("'", "''"); // Escape single quotes

                // Search in ALL columns with better handling
                foreach (var columnName in columnNames)
                {
                    if (IsValidColumnName(columnName))
                    {
                        // More robust search condition that handles different data types
                        searchConditions.Add($"(base_query.{columnName} IS NOT NULL AND UPPER(TRIM(TO_CHAR(base_query.{columnName}))) LIKE UPPER('%{escapedSearchTerm}%'))");
                    }
                }

                var finalCondition = searchConditions.Any() ? string.Join(" OR ", searchConditions) : string.Empty;

                // Add debug logging
                System.Diagnostics.Debug.WriteLine($"Search term: '{searchTerm}'");
                System.Diagnostics.Debug.WriteLine($"Escaped term: '{escapedSearchTerm}'");
                System.Diagnostics.Debug.WriteLine($"Columns found: {columnNames.Count}");
                System.Diagnostics.Debug.WriteLine($"Valid columns: {searchConditions.Count}");
                System.Diagnostics.Debug.WriteLine($"Column names: {string.Join(", ", columnNames)}");
                System.Diagnostics.Debug.WriteLine($"Final search condition: {finalCondition}");

                return finalCondition;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in BuildSearchWithStringReplacement: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                return string.Empty;
            }
        }

        private string BuildFiltersWithStringReplacement(List<FilterCriteria> filters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var whereClauses = new List<string>();

            foreach (var filter in filters)
            {
                if (filter.Value == null && filter.Operator != "ISNULL" && filter.Operator != "ISNOTNULL")
                    continue;

                var columnName = $"base_query.{filter.ColumnName}";
                string whereClause;

                if (filter.Operator.ToUpper() == "CONTAINS")
                {
                    var escapedValue = filter.Value?.ToString()?.Replace("'", "''") ?? "";
                    whereClause = $"UPPER({columnName}) LIKE UPPER('%{escapedValue}%')";
                }
                else if (filter.Operator == "ISNULL")
                {
                    whereClause = $"{columnName} IS NULL";
                }
                else if (filter.Operator == "ISNOTNULL")
                {
                    whereClause = $"{columnName} IS NOT NULL";
                }
                else if (filter.Operator.ToUpper() == "EQUALS")
                {
                    var escapedValue = filter.Value?.ToString()?.Replace("'", "''") ?? "";
                    whereClause = $"{columnName} = '{escapedValue}'";
                }
                else
                {
                    var escapedValue = filter.Value?.ToString()?.Replace("'", "''") ?? "";
                    whereClause = $"{columnName} = '{escapedValue}'";
                }

                whereClauses.Add(whereClause);
            }

            return whereClauses.Any() ? string.Join(" AND ", whereClauses) : string.Empty;
        }

        private string BuildSimpleSearchCondition(string sql, string searchTerm, List<OracleParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            try
            {
                var columnNames = GetColumnNamesCachedAsync(sql, new OracleParameter[0]).GetAwaiter().GetResult();
                if (!columnNames.Any())
                    return string.Empty;

                var searchConditions = new List<string>();
                var paramName = $"search_param_{parameters.Count}";
                
                parameters.Add(new OracleParameter(paramName, OracleDbType.Varchar2) 
                { 
                    Value = $"%{searchTerm}%" 
                });

                // Limit columns for performance
                foreach (var columnName in columnNames.Take(10))
                {
                    if (IsValidColumnName(columnName))
                    {
                        searchConditions.Add($"UPPER(TO_CHAR(base_query.{columnName})) LIKE UPPER(:{paramName})");
                    }
                }

                return searchConditions.Any() ? string.Join(" OR ", searchConditions) : string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string BuildSimpleFilterConditions(List<FilterCriteria> filters, List<OracleParameter> parameters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var whereClauses = new List<string>();

            foreach (var filter in filters)
            {
                if (filter.Value == null && filter.Operator != "ISNULL" && filter.Operator != "ISNOTNULL")
                    continue;

                var paramName = $"filter_param_{parameters.Count}";
                var columnName = $"base_query.{filter.ColumnName}";

                string whereClause;
                if (filter.Operator.ToUpper() == "CONTAINS")
                {
                    whereClause = $"UPPER({columnName}) LIKE UPPER(:{paramName})";
                    parameters.Add(new OracleParameter(paramName, OracleDbType.Varchar2) 
                    { 
                        Value = $"%{filter.Value}%" 
                    });
                }
                else if (filter.Operator == "ISNULL")
                {
                    whereClause = $"{columnName} IS NULL";
                }
                else if (filter.Operator == "ISNOTNULL")
                {
                    whereClause = $"{columnName} IS NOT NULL";
                }
                else
                {
                    whereClause = $"{columnName} = :{paramName}";
                    parameters.Add(new OracleParameter(paramName, GetOracleDbType(filter.Value)) 
                    { 
                        Value = filter.Value 
                    });
                }

                whereClauses.Add(whereClause);
            }

            return whereClauses.Any() ? string.Join(" AND ", whereClauses) : string.Empty;
        }

        private string BuildGlobalSearchConditionsNew(string sql, string searchTerm, List<OracleParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            try
            {
                var columnNames = GetColumnNamesCachedAsync(sql, new OracleParameter[0]).GetAwaiter().GetResult();

                if (!columnNames.Any())
                    return string.Empty;

                var searchConditions = new List<string>();
                var paramName = "globalSearch";
                
                var searchParam = new OracleParameter(paramName, OracleDbType.Varchar2)
                {
                    Value = $"%{searchTerm}%"
                };
                parameters.Add(searchParam);

                // Limit to a reasonable number of columns to avoid performance issues
                var columnsToSearch = columnNames.Take(20).ToList();

                foreach (var columnName in columnsToSearch)
                {
                    // Handle potential SQL injection by validating column names
                    if (IsValidColumnName(columnName))
                    {
                        // Reference columns from the base_query alias
                        searchConditions.Add($"LOWER(TO_CHAR(base_query.{columnName})) LIKE LOWER(:{paramName})");
                    }
                }

                return searchConditions.Any() ? string.Join(" OR ", searchConditions) : string.Empty;
            }
            catch
            {
                // If we can't get column names, fall back to empty condition
                return string.Empty;
            }
        }

        private string BuildGlobalSearchConditions(string sql, string searchTerm, ref List<OracleParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            try
            {
                // Use original parameters for getting column names (without search/filter params)
                var originalParams = parameters.Where(p => !p.ParameterName.StartsWith("globalSearch") && 
                                                          !p.ParameterName.StartsWith("filter_")).ToArray();
                var columnNames = GetColumnNamesCachedAsync(sql, originalParams).GetAwaiter().GetResult();

                if (!columnNames.Any())
                    return string.Empty;

                var searchConditions = new List<string>();
                var paramName = "globalSearch";
                
                // Check if parameter already exists
                if (!parameters.Any(p => p.ParameterName == paramName))
                {
                    var searchParam = new OracleParameter(paramName, OracleDbType.Varchar2)
                    {
                        Value = $"%{searchTerm}%"
                    };
                    parameters.Add(searchParam);
                }

                // Limit to a reasonable number of columns to avoid performance issues
                var columnsToSearch = columnNames.Take(20).ToList();

                foreach (var columnName in columnsToSearch)
                {
                    // Handle potential SQL injection by validating column names
                    if (IsValidColumnName(columnName))
                    {
                        // Reference columns from the base_query alias
                        searchConditions.Add($"LOWER(TO_CHAR(base_query.{columnName})) LIKE LOWER(:{paramName})");
                    }
                }

                return searchConditions.Any() ? string.Join(" OR ", searchConditions) : string.Empty;
            }
            catch
            {
                // If we can't get column names, fall back to empty condition
                return string.Empty;
            }
        }

        private string BuildFilterConditionsNew(List<FilterCriteria> filters, List<OracleParameter> parameters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var whereClauses = new List<string>();
            var filterIndex = 0;

            foreach (var filter in filters)
            {
                // Skip filters with null values (except for NULL/ISNULL operations)
                if (filter.Value == null &&
                    filter.Operator != "ISNULL" &&
                    filter.Operator != "ISNOTNULL")
                {
                    continue;
                }

                var paramName = $"filter_{filterIndex}";
                var paramPlaceholder = $":{paramName}";
                
                // Add base_query prefix to column name for consistency
                var columnName = $"base_query.{filter.ColumnName}";
                
                // Handle CONTAINS operator specifically for Oracle
                string whereClause;
                if (filter.Operator.ToUpper() == "CONTAINS")
                {
                    whereClause = $"UPPER({columnName}) LIKE UPPER({paramPlaceholder})";
                    // Add wildcards to the parameter value
                    var containsValue = $"%{filter.Value}%";
                    parameters.Add(new OracleParameter(paramName, OracleDbType.Varchar2) { Value = containsValue });
                }
                else
                {
                    whereClause = BuildWhereClause(columnName, filter.Operator, paramPlaceholder, filter.Value);
                    
                    // Only add parameter value for non-NULL operations
                    if (filter.Operator != "ISNULL" && filter.Operator != "ISNOTNULL")
                    {
                        parameters.Add(new OracleParameter(paramName, GetOracleDbType(filter.Value)) { Value = filter.Value });
                    }
                }

                whereClauses.Add(whereClause);
                filterIndex++;
            }

            return whereClauses.Any() ? string.Join(" AND ", whereClauses) : string.Empty;
        }

        private string BuildFilterConditions(List<FilterCriteria> filters, ref List<OracleParameter> parameters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var whereClauses = new List<string>();
            var filterIndex = 0;

            foreach (var filter in filters)
            {
                // Skip filters with null values (except for NULL/ISNULL operations)
                if (filter.Value == null &&
                    filter.Operator != "ISNULL" &&
                    filter.Operator != "ISNOTNULL")
                {
                    continue;
                }

                var paramName = $"filter_{filterIndex}";
                var paramPlaceholder = $":{paramName}";
                
                // Add base_query prefix to column name for consistency
                var columnName = $"base_query.{filter.ColumnName}";
                var whereClause = BuildWhereClause(columnName, filter.Operator, paramPlaceholder, filter.Value);

                whereClauses.Add(whereClause);

                // Only add parameter value for non-NULL operations
                if (filter.Operator != "ISNULL" && filter.Operator != "ISNOTNULL")
                {
                    // Check if parameter already exists
                    if (!parameters.Any(p => p.ParameterName == paramName))
                    {
                        parameters.Add(new OracleParameter(paramName, GetOracleDbType(filter.Value)) { Value = filter.Value });
                    }
                }

                filterIndex++;
            }

            return whereClauses.Any() ? string.Join(" AND ", whereClauses) : string.Empty;
        }

        private bool IsValidColumnName(string columnName)
        {
            // Simple validation to prevent SQL injection
            return !string.IsNullOrWhiteSpace(columnName) &&
                   columnName.All(c => char.IsLetterOrDigit(c) || c == '_');
        }
        private async Task<List<string>> GetColumnNamesCachedAsync(string sql, OracleParameter[] parameters)
        {
            var cacheKey = $"{sql}_{string.Join("_", parameters?.Select(p => p.ParameterName) ?? Array.Empty<string>())}";

            if (_columnCache.TryGetValue(cacheKey, out var cachedColumns))
                return cachedColumns;

            var columns = await GetColumnNamesAsync(sql, parameters);
            _columnCache.TryAdd(cacheKey, columns);

            return columns;
        }

        private async Task<List<string>> GetColumnNamesAsync(string sql, OracleParameter[] parameters)
        {
            var columnNames = new List<string>();

            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Get just one row to inspect the schema
                var sampleSql = $"SELECT * FROM ({sql}) WHERE ROWNUM <= 1";

                using (var command = new OracleCommand(sampleSql, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SchemaOnly))
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            columnNames.Add(reader.GetName(i));
                        }
                    }
                }
            }

            return columnNames;
        }

        //private void LogGeneratedSql(string method, string sql, OracleParameter[] parameters)
        //{
        //    var debugSql = sql;
        //    foreach (var param in parameters)
        //    {
        //        debugSql = debugSql.Replace(param.ParameterName, $"'{param.Value}'");
        //    }

        //    //_logger.LogDebug("{Method} generated SQL: {Sql}", method, debugSql);
        //}

        // For commands that don't return results (INSERT, UPDATE, DELETE)
        public async Task<int> ExecuteCommandAsync(string sql, params OracleParameter[] parameters)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new OracleCommand(sql, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        // For scalar queries that return a single value
        public async Task<object> ExecuteScalarAsync(string sql, params OracleParameter[] parameters)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new OracleCommand(sql, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return await command.ExecuteScalarAsync();
                }
            }
        }
    }
}
