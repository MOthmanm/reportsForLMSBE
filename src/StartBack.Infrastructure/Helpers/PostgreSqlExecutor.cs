using Npgsql;
using StartBack.Domain.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace StartBack.Infrastructure.Helpers
{
    public class PostgreSqlExecutor
    {
        private readonly string _connectionString;
        private readonly ConcurrentDictionary<string, List<string>> _columnCache = new ConcurrentDictionary<string, List<string>>();

        public PostgreSqlExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<PaginatedResult<Dictionary<string, object>>> ExecuteQueryAsync(
            string sql,
            NpgsqlParameter[] parameters,
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

                // Use a subquery to wrap the original SQL and apply filtering
                var modifiedSql = BuildSqlWithSubquery(sql, findOptions);

                // Apply sorting
                var sortedSql = ApplySorting(modifiedSql, findOptions.SortBy, findOptions.Desc);

                // Get total count
                var countSql = $"SELECT COUNT(*) FROM ({sortedSql}) AS count_query";
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
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing PostgreSQL query: {ex.Message}", ex);
            }
        }

        private string BuildSqlWithSubquery(string sql, FindOptions findOptions)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append($"SELECT * FROM ({sql}) AS base_query");
            
            var whereConditions = new List<string>();

            // Global Search (Placeholder - in PostgreSQL we might use ILIKE)
            if (!string.IsNullOrWhiteSpace(findOptions.Search))
            {
                // Note: Column discovery for the subquery would be needed for a perfect global search.
                // For now, we'll follow a similar pattern if we had the columns.
            }

            if (findOptions.Filters != null && findOptions.Filters.Any())
            {
                foreach (var filter in findOptions.Filters)
                {
                    var condition = BuildFilterCondition(filter);
                    if (!string.IsNullOrEmpty(condition))
                    {
                        whereConditions.Add(condition);
                    }
                }
            }

            if (whereConditions.Any())
            {
                queryBuilder.Append(" WHERE ");
                queryBuilder.Append(string.Join(" AND ", whereConditions));
            }

            return queryBuilder.ToString();
        }

        private string BuildFilterCondition(FilterCriteria filter)
        {
            var columnName = $"\"base_query\".\"{filter.ColumnName}\"";
            var escapedValue = filter.Value?.ToString()?.Replace("'", "''") ?? "";

            return filter.Operator.ToUpper() switch
            {
                "EQUALS" => $"{columnName} = '{escapedValue}'",
                "CONTAINS" => $"{columnName}::text ILIKE '%{escapedValue}%'",
                "STARTSWITH" => $"{columnName}::text ILIKE '{escapedValue}%'",
                "ENDSWITH" => $"{columnName}::text ILIKE '%{escapedValue}'",
                "GREATERTHAN" => $"{columnName} > '{escapedValue}'",
                "LESSTHAN" => $"{columnName} < '{escapedValue}'",
                "NOTEQUAL" => $"{columnName} != '{escapedValue}'",
                "ISNULL" => $"{columnName} IS NULL",
                "ISNOTNULL" => $"{columnName} IS NOT NULL",
                _ => $"{columnName} = '{escapedValue}'"
            };
        }

        private async Task<PaginatedResult<Dictionary<string, object>>> ExecuteSimpleQueryAsync(
            string sql, 
            NpgsqlParameter[] parameters, 
            FindOptions findOptions)
        {
            var sortedSql = ApplySorting(sql, findOptions.SortBy, findOptions.Desc);
            var countSql = $"SELECT COUNT(*) FROM ({sql}) AS count_query";
            var totalCount = await GetTotalCountAsync(countSql, parameters);
            var paginatedSql = ApplyPagination(sortedSql, findOptions.Page, findOptions.PageSize);
            var results = await ExecuteFinalQueryAsync(paginatedSql, parameters);

            return new PaginatedResult<Dictionary<string, object>>
            {
                Items = results,
                Page = findOptions.Page,
                PageSize = findOptions.PageSize,
                Total = totalCount
            };
        }

        private string ApplySorting(string sql, string? sortBy, bool desc)
        {
            if (string.IsNullOrEmpty(sortBy)) return sql;
            // Wrap the original query as a subquery to avoid conflicts with existing ORDER BY
            // and ensure column references work correctly
            return $"SELECT * FROM ({sql}) AS sorted_query ORDER BY \"{sortBy}\" {(desc ? "DESC" : "ASC")}";
        }

        private string ApplyPagination(string sql, int page, int pageSize)
        {
            if (pageSize <= 0) return sql;
            var offset = (page - 1) * pageSize;
            return $"{sql} LIMIT {pageSize} OFFSET {offset}";
        }

        private async Task<int> GetTotalCountAsync(string sql, NpgsqlParameter[] parameters)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand(sql, conn);
            foreach (var p in parameters) cmd.Parameters.Add(p.Clone());
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task<object?> ExecuteScalarAsync(string sql, NpgsqlParameter[] parameters)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand(sql, conn);
            foreach (var p in parameters) cmd.Parameters.Add(p.Clone());
            return await cmd.ExecuteScalarAsync();
        }

        private async Task<List<Dictionary<string, object>>> ExecuteFinalQueryAsync(string sql, NpgsqlParameter[] parameters)
        {
            var results = new List<Dictionary<string, object>>();
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand(sql, conn);
            foreach (var p in parameters) cmd.Parameters.Add(p.Clone());

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                }
                results.Add(row);
            }
            return results;
        }
    }
}
