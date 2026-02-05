using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adjustreportforcrosstabedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportType",
                table: "Reports",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ModuleNo",
                table: "AuditLog",
                type: "numeric(5)",
                precision: 5,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,0)",
                oldPrecision: 5,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Reports");

            migrationBuilder.AlterColumn<decimal>(
                name: "ModuleNo",
                table: "AuditLog",
                type: "numeric(5,0)",
                precision: 5,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5)",
                oldPrecision: 5,
                oldNullable: true);
        }
    }
}
