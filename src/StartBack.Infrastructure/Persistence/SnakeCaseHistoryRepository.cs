using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace StartBack.Infrastructure.Persistence;

#pragma warning disable EF1001 // Internal EF Core API usage.
public class SnakeCaseHistoryRepository : NpgsqlHistoryRepository
{
    public SnakeCaseHistoryRepository(HistoryRepositoryDependencies dependencies)
        : base(dependencies)
    {
    }

    protected override string MigrationIdColumnName => "migration_id";
    protected override string ProductVersionColumnName => "product_version";
}
#pragma warning restore EF1001
