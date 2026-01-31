using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingNameAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "REPORTS",
                newName: "NAMEEN");

            migrationBuilder.AddColumn<string>(
                name: "NAMEAR",
                table: "REPORTS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAMEAR",
                table: "REPORTS");

            migrationBuilder.RenameColumn(
                name: "NAMEEN",
                table: "REPORTS",
                newName: "NAME");
        }
    }
}
