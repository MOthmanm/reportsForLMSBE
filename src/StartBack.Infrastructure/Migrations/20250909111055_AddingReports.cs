using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REPORTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QUERY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PATH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HASDETAIL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HIDE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DETAILID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DETAILCOLUMN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CREATEDBY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UPDATEDBY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ISDELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DELETEDBY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REPORTCOLUMNS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FIELD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HEADERNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SORTABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FILTER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RESIZABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FLOATINGFILTER = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ROWGROUP = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HIDE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ISMASTER = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SORT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REPORTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTCOLUMNS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REPORTCOLUMNS_REPORTS_REPORTID",
                        column: x => x.REPORTID,
                        principalTable: "REPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPORTPARAMETERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DISPLAYNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATATYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PARAMETERTYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ISREQUIRED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEFAULTVALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QUERYFORDROPDOWN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SORT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    REPORTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTPARAMETERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REPORTPARAMETERS_REPORTS_REPORTID",
                        column: x => x.REPORTID,
                        principalTable: "REPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_REPORTCOLUMNS_REPORTID",
                table: "REPORTCOLUMNS",
                column: "REPORTID");

            migrationBuilder.CreateIndex(
                name: "IX_REPORTPARAMETERS_REPORTID",
                table: "REPORTPARAMETERS",
                column: "REPORTID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REPORTCOLUMNS");

            migrationBuilder.DropTable(
                name: "REPORTPARAMETERS");

            migrationBuilder.DropTable(
                name: "REPORTS");
        }
    }
}
