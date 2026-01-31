using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ICONS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    KEY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DISPLAYNAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CODE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REFRESHTOKENS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    USERID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TOKEN = table.Column<string>(type: "NVARCHAR2(512)", maxLength: 512, nullable: false),
                    CREATEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EXPIRESAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    REVOKEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    REPLACEDBYTOKEN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFRESHTOKENS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DEFAULTPAGEURL = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DISPLAYNAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    PASSWORDHASH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PROFILEIMAGEURL = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MENUITEMS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    KEY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TITLEEN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TITLEAR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    URL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PARENTID = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    ORDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ICONID = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENUITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENUITEMS_ICONS_ICONID",
                        column: x => x.ICONID,
                        principalTable: "ICONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MENUITEMS_MENUITEMS_PARENTID",
                        column: x => x.PARENTID,
                        principalTable: "MENUITEMS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RoleId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_PERMISSIONS_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "PERMISSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    UserId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_ROLES_RolesId",
                        column: x => x.RolesId,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemPermission",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RequiredPermissionsId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemPermission", x => new { x.MenuItemId, x.RequiredPermissionsId });
                    table.ForeignKey(
                        name: "FK_MenuItemPermission_MENUITEMS_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MENUITEMS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemPermission_PERMISSIONS_RequiredPermissionsId",
                        column: x => x.RequiredPermissionsId,
                        principalTable: "PERMISSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ICONS_KEY",
                table: "ICONS",
                column: "KEY",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemPermission_RequiredPermissionsId",
                table: "MenuItemPermission",
                column: "RequiredPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MENUITEMS_ICONID",
                table: "MENUITEMS",
                column: "ICONID");

            migrationBuilder.CreateIndex(
                name: "IX_MENUITEMS_KEY",
                table: "MENUITEMS",
                column: "KEY",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENUITEMS_PARENTID",
                table: "MENUITEMS",
                column: "PARENTID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RoleId",
                table: "PermissionRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSIONS_CODE",
                table: "PERMISSIONS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REFRESHTOKENS_TOKEN",
                table: "REFRESHTOKENS",
                column: "TOKEN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REFRESHTOKENS_USERID",
                table: "REFRESHTOKENS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemPermission");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "REFRESHTOKENS");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "MENUITEMS");

            migrationBuilder.DropTable(
                name: "PERMISSIONS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "ICONS");
        }
    }
}
