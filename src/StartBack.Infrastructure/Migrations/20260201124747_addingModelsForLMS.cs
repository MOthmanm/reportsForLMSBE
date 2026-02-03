using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingModelsForLMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmpSerial = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    TableName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Changes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ModuleNo = table.Column<decimal>(type: "numeric(5)", precision: 5, nullable: true),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "فصيلة الدم"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodType", x => x.Id);
                },
                comment: "فصائل الدم");

            migrationBuilder.CreateTable(
                name: "Guardian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف ولي الأمر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللقب"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    Gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهاتف"),
                    Mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    Address = table.Column<string>(type: "text", nullable: true, comment: "العنوان"),
                    Occupation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "المهنة"),
                    Workplace = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "مكان العمل"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardian", x => x.Id);
                },
                comment: "جدول أولياء الأمور");

            migrationBuilder.CreateTable(
                name: "LookupAddressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupAddressType", x => x.Id);
                },
                comment: "جدول أنواع العناوين");

            migrationBuilder.CreateTable(
                name: "LookupAttendanceCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكود")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    ShortName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false, comment: "نوع الحضور"),
                    DeductionPoints = table.Column<decimal>(type: "numeric", nullable: false),
                    ColorCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsPresence = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يعتبر حضور"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupAttendanceCode", x => x.Id);
                },
                comment: "جدول أكواد الحضور");

            migrationBuilder.CreateTable(
                name: "LookupDisciplineActionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: false, comment: "الخطورة (1-5)"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupDisciplineActionType", x => x.Id);
                },
                comment: "جدول أنواع الإجراءات التأديبية");

            migrationBuilder.CreateTable(
                name: "LookupEnrollmentCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكود")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "text", nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "text", nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupEnrollmentCode", x => x.Id);
                },
                comment: "جدول أكواد القيد (دخول/خروج)");

            migrationBuilder.CreateTable(
                name: "LookupEthnicity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العرق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupEthnicity", x => x.Id);
                },
                comment: "جدول الأعراق");

            migrationBuilder.CreateTable(
                name: "LookupIncidentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: false, comment: "الخطورة (1-5)"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupIncidentType", x => x.Id);
                },
                comment: "جدول أنواع حوادث السلوك");

            migrationBuilder.CreateTable(
                name: "LookupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupLanguage", x => x.Id);
                },
                comment: "جدول اللغات");

            migrationBuilder.CreateTable(
                name: "LookupMarkingPeriodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupMarkingPeriodType", x => x.Id);
                },
                comment: "جدول أنواع فترات الرصد");

            migrationBuilder.CreateTable(
                name: "LookupMilitaryRank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الرتبة العسكرية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupMilitaryRank", x => x.Id);
                },
                comment: "جدول الرتب العسكرية");

            migrationBuilder.CreateTable(
                name: "LookupNationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجنسية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    CountryCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true, comment: "رمز الدولة"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupNationality", x => x.Id);
                },
                comment: "جدول الجنسيات");

            migrationBuilder.CreateTable(
                name: "LookupPhoneType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupPhoneType", x => x.Id);
                },
                comment: "جدول أنواع الهواتف");

            migrationBuilder.CreateTable(
                name: "LookupRecordStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحالة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "الوصف"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupRecordStatus", x => x.Id);
                },
                comment: "جدول حالات السجلات العامة");

            migrationBuilder.CreateTable(
                name: "LookupRelationshipType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupRelationshipType", x => x.Id);
                },
                comment: "جدول أنواع العلاقات (ولي الأمر)");

            migrationBuilder.CreateTable(
                name: "LookupStaffCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفئة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    IsAcademic = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هيئة تدريس"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupStaffCategory", x => x.Id);
                },
                comment: "جدول فئات الموظفين");

            migrationBuilder.CreateTable(
                name: "LookupSubjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupSubjectType", x => x.Id);
                },
                comment: "جدول أنواع المواد الدراسية");

            migrationBuilder.CreateTable(
                name: "LookupWeekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف اليوم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الاسم بالإنجليزية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض (الأحد=1)"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupWeekday", x => x.Id);
                },
                comment: "جدول أيام الأسبوع");

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الجامعة بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الجامعة بالإنجليزية"),
                    ShortName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الاسم المختصر"),
                    Icon = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true, comment: "الايقونة"),
                    ParentId = table.Column<int>(type: "integer", nullable: true, comment: "المستوي الاعلي"),
                    Level = table.Column<int>(type: "integer", nullable: true, comment: "المستوي"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                    table.ForeignKey(
                        name: "FK_University_University_ParentId",
                        column: x => x.ParentId,
                        principalTable: "University",
                        principalColumn: "Id");
                },
                comment: "جدول الجامعات والمؤسسات الأكاديمية");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشخص")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الرقم الوطني - فريد"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    FullName = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false, computedColumnSql: "\r\n        (\r\n            \"FirstName\" ||\r\n            ' ' ||\r\n            COALESCE(\"MiddleName\" || ' ', '') ||\r\n            \"LastName\"\r\n        )\r\n        ", stored: true),
                    Gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الميلاد"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    Mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "العنوان"),
                    MilitaryRankId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الرتبة العسكرية"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_LookupMilitaryRank_MilitaryRankId",
                        column: x => x.MilitaryRankId,
                        principalTable: "LookupMilitaryRank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول الأشخاص (موظفين، طلاب، موظفين)");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموظف")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StaffCode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز الموظف"),
                    Title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللقب"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    NameSuffix = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللاحقة"),
                    Gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الميلاد"),
                    NationalityId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الجنسية"),
                    NationalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهوية"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهاتف"),
                    Mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    Address = table.Column<string>(type: "text", nullable: true, comment: "العنوان"),
                    StaffCategoryId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف فئة الموظف"),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ التعيين"),
                    TerminationDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ إنهاء الخدمة"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    PhotoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "مسار الصورة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_LookupNationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LookupNationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Staff_LookupStaffCategory_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalTable: "LookupStaffCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول الموظفين والأساتذة");

            migrationBuilder.CreateTable(
                name: "AcademicLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المستوى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم المستوى"),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    PreviousLevelId = table.Column<int>(type: "integer", nullable: true),
                    NextLevelId = table.Column<int>(type: "integer", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف المستوى الأب"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_AcademicLevel_NextLevelId",
                        column: x => x.NextLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_AcademicLevel_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_AcademicLevel_PreviousLevelId",
                        column: x => x.PreviousLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المستويات");

            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان السنة الدراسية"),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false, comment: "هل السنة الحالية"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYear_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول السنوات الدراسية");

            migrationBuilder.CreateTable(
                name: "CourseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز المقرر"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCategory_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المقررات الدراسية");

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "اسم الفترة"),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false, comment: "وقت البداية"),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false, comment: "وقت النهاية"),
                    LengthMinutes = table.Column<int>(type: "integer", nullable: false, comment: "المدة بالدقائق"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsAttendanceRequired = table.Column<bool>(type: "boolean", nullable: false, comment: "الحضور مطلوب"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفترات الزمنية اليومية");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف القاعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز القاعة"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم القاعة"),
                    Building = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "المبنى"),
                    Floor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "الطابق"),
                    Capacity = table.Column<int>(type: "integer", nullable: true, comment: "السعة"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول القاعات والغرف");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentCode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز الطالب"),
                    CurrentUniversityId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الجامعة الحالية"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    NameSuffix = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللاحقة"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "الاسم الكامل بالعربية"),
                    Gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الميلاد"),
                    NationalityId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الجنسية"),
                    NationalId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهوية"),
                    MilitaryNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الرقم العسكري"),
                    HighSchoolGraduationDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الحصول على شهادة الثانوية العامة"),
                    HighSchoolScore = table.Column<decimal>(type: "numeric", nullable: true, comment: "مجموع الثانوية العامة"),
                    HighSchoolPercentage = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية في الثانوية العامة"),
                    BatchNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "رقم الدفعة"),
                    EthnicityId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف العرق"),
                    LanguageId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف اللغة"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهاتف"),
                    Mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    Address = table.Column<string>(type: "text", nullable: true, comment: "العنوان"),
                    HousingBuilding = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "المبنى"),
                    HousingFloor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "الطابق/العمارة"),
                    HousingRoom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "رقم الغرفة"),
                    HousingLocker = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "رقم الدوالب"),
                    HousingWeapon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "السلاح (مشاة، مدرعات، الخ)"),
                    HousingCompany = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "السرية العسكرية"),
                    HousingPlatoon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الفصيلة العسكرية"),
                    HousingSquad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الجماعة العسكرية"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    PhotoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "مسار الصورة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_LookupEthnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "LookupEthnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Student_LookupLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LookupLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Student_LookupNationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LookupNationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Student_University_CurrentUniversityId",
                        column: x => x.CurrentUniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول بيانات الطلاب");

            migrationBuilder.CreateTable(
                name: "PersonUniversity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشخص"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    PersonType = table.Column<int>(type: "integer", nullable: false, comment: "نوع الشخص في هذه الجامعة (موظف، طالب، موظف)"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ البدء"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "ملاحظات"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonUniversity", x => x.Id);
                    table.ForeignKey(
                        name: "fk_person_university_person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_person_university_university",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول العلاقة بين الأشخاص والجامعات (Many-to-Many)");

            migrationBuilder.CreateTable(
                name: "AcademicCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التقويم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false, comment: "عنوان التقويم"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هو الافتراضي"),
                    RecurringDays = table.Column<string>(type: "text", nullable: true, comment: "أيام التكرار (JSON)"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicCalendar_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicCalendar_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول التقويمات الأكاديمية");

            migrationBuilder.CreateTable(
                name: "AcademicLevelIteration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المستوى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    AcademicLevelId = table.Column<int>(type: "integer", nullable: false),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevelIteration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicLevelIteration_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevelIteration_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المستويات");

            migrationBuilder.CreateTable(
                name: "DisciplineIncident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    IncidentCode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true, comment: "رمز الحادثة"),
                    IncidentDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ الحادثة"),
                    IncidentTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true, comment: "وقت الحادثة"),
                    IncidentTypeId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع الحادثة"),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "المكان"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف الحادثة"),
                    ReporterId = table.Column<int>(type: "integer", nullable: true, comment: "المبلغ"),
                    AssignedToId = table.Column<int>(type: "integer", nullable: true, comment: "المسند إليه"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "الحالة"),
                    Resolution = table.Column<string>(type: "text", nullable: true, comment: "القرار"),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحل"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineIncident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineIncident_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineIncident_LookupIncidentType_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "LookupIncidentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DisciplineIncident_Staff_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DisciplineIncident_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول حوادث السلوك والانضباط");

            migrationBuilder.CreateTable(
                name: "GradeScale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقياس")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false, comment: "اسم المقياس"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف المقياس"),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    MaxValue = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المقياس الافتراضي"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeScale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeScale_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeScale_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول مقاييس الدرجات");

            migrationBuilder.CreateTable(
                name: "StaffUniversityAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التعيين")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StaffId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموظف"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    JobTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "المسمى الوظيفي"),
                    Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "القسم"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البدء"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false, comment: "هل التعيين الأساسي"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffUniversityAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffUniversityAssignment_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffUniversityAssignment_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffUniversityAssignment_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول تعيينات الموظفين في الجامعات");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المادة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز المادة"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المادة"),
                    ShortName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الاسم المختصر"),
                    SubjectTypeId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع المادة"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف المادة"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_LookupSubjectType_SubjectTypeId",
                        column: x => x.SubjectTypeId,
                        principalTable: "LookupSubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Subject_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المواد الدراسية");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز المقرر"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف المقرر"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    CourseCategoryId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_CourseCategory_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المقررات الدراسية");

            migrationBuilder.CreateTable(
                name: "StudentGuardian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العلاقة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    GuardianId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف ولي الأمر"),
                    RelationshipTypeId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع العلاقة"),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false, comment: "هل ولي الأمر الأساسي"),
                    IsEmergencyContact = table.Column<bool>(type: "boolean", nullable: false, comment: "جهة اتصال للطوارئ"),
                    CanPickup = table.Column<bool>(type: "boolean", nullable: false, comment: "يمكنه استلام الطالب"),
                    HasCustody = table.Column<bool>(type: "boolean", nullable: false, comment: "لديه حق الوصاية"),
                    ReceivesMailing = table.Column<bool>(type: "boolean", nullable: false, comment: "يستلم المراسلات"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGuardian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGuardian_Guardian_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "Guardian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGuardian_LookupRelationshipType_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalTable: "LookupRelationshipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentGuardian_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول علاقة الطلاب بأولياء الأمور");

            migrationBuilder.CreateTable(
                name: "Transcript",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    UniversityName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف السنة الدراسية"),
                    AcademicYearTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "عنوان السنة الدراسية"),
                    AcademicLevel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "المستوى الأكاديمي"),
                    CourseCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رمز المقرر"),
                    CourseTitle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    LetterGrade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "التقدير"),
                    GradePercent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    GpaValue = table.Column<decimal>(type: "numeric", nullable: true, comment: "قيمة المعدل"),
                    CreditsAttempted = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المحاولة"),
                    CreditsEarned = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المكتسبة"),
                    IncludeInGpa = table.Column<bool>(type: "boolean", nullable: false, comment: "يحسب في المعدل"),
                    IsTransfer = table.Column<bool>(type: "boolean", nullable: false, comment: "منقول"),
                    Notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcript_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcript_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول السجل الأكاديمي (الشهادة الدراسية)");

            migrationBuilder.CreateTable(
                name: "AcademicCalendarDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف اليوم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات (مثل: إجازة 6 أكتوبر)"),
                    AcademicDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "التاريخ"),
                    HolidayType = table.Column<int>(type: "integer", nullable: false),
                    AcademicCalendarId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التقويم"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCalendarDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicCalendarDetail_AcademicCalendar_AcademicCalendarId",
                        column: x => x.AcademicCalendarId,
                        principalTable: "AcademicCalendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول أيام التقويم الأكاديمي");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشعبة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "اسم الشعبة"),
                    Capacity = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "السعة القصوى"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelIterationId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_AcademicLevelIteration_AcademicLevelIterationId",
                        column: x => x.AcademicLevelIterationId,
                        principalTable: "AcademicLevelIteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصول والشعب الدراسية");

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصل الدراسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الفصل"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelIterationId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_AcademicLevelIteration_AcademicLevelIterationId",
                        column: x => x.AcademicLevelIterationId,
                        principalTable: "AcademicLevelIteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Semester_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Semester_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصول الدراسية");

            migrationBuilder.CreateTable(
                name: "DisciplineAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الإجراء")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncidentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة"),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع الإجراء"),
                    ActionDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ الإجراء"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ البدء"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    DurationDays = table.Column<int>(type: "integer", nullable: true, comment: "المدة بالأيام"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف الإجراء"),
                    IssuedBy = table.Column<int>(type: "integer", nullable: true, comment: "صدر بواسطة"),
                    ParentNotified = table.Column<bool>(type: "boolean", nullable: false, comment: "تم إشعار ولي الأمر"),
                    NotificationDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الإشعار"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "الحالة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineAction_DisciplineIncident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "DisciplineIncident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineAction_LookupDisciplineActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "LookupDisciplineActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplineAction_Staff_IssuedBy",
                        column: x => x.IssuedBy,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DisciplineAction_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الإجراءات التأديبية");

            migrationBuilder.CreateTable(
                name: "DisciplineIncidentStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncidentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة"),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    Role = table.Column<int>(type: "integer", nullable: false, comment: "دور الطالب"),
                    Notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineIncidentStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineIncidentStudent_DisciplineIncident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "DisciplineIncident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineIncidentStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الطلاب المشاركين في حوادث السلوك");

            migrationBuilder.CreateTable(
                name: "GradeScaleItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الرمز")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false, comment: "رمز التقدير"),
                    MinPercent = table.Column<decimal>(type: "numeric", nullable: false, comment: "الحد الأدنى للنسبة"),
                    MaxPercent = table.Column<decimal>(type: "numeric", nullable: false, comment: "الحد الأقصى للنسبة"),
                    GradeScaleId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقياس"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeScaleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeScaleItem_GradeScale_GradeScaleId",
                        column: x => x.GradeScaleId,
                        principalTable: "GradeScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول رموز التقديرات");

            migrationBuilder.CreateTable(
                name: "AcademicLevelCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicLevelId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevelCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicLevelCourse_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevelCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر"),
                    PrerequisiteCourseId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر السابق المطلوب"),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المتطلب إجباري"),
                    MinGrade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "الحد الأدنى للتقدير المطلوب"),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrerequisite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_PrerequisiteCourseId",
                        column: x => x.PrerequisiteCourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المتطلبات السابقة للمقررات");

            migrationBuilder.CreateTable(
                name: "StudentEnrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف القيد")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonUniversityId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الشعبة"),
                    LookupEnrollmentCodeId = table.Column<int>(type: "integer", nullable: false),
                    EntryDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ الدخول"),
                    ExitDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الخروج"),
                    Notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_LookupEnrollmentCode_LookupEnrollmentCode~",
                        column: x => x.LookupEnrollmentCodeId,
                        principalTable: "LookupEnrollmentCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_PersonUniversity_PersonUniversityId",
                        column: x => x.PersonUniversityId,
                        principalTable: "PersonUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول سجل قيد الطلاب وتاريخ التسجيل");

            migrationBuilder.CreateTable(
                name: "CourseSemester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    SemesterId = table.Column<int>(type: "integer", nullable: false),
                    AcademicLevelIterationId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSemester_AcademicLevelIteration_AcademicLevelIteratio~",
                        column: x => x.AcademicLevelIterationId,
                        principalTable: "AcademicLevelIteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSemester_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSemester_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quarter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الربع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SemesterId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصل الدراسي"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الربع"),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    PostStartDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ بدء الرصد"),
                    PostEndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ انتهاء الرصد"),
                    DoesGrades = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يحسب درجات"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quarter_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الأرباع الدراسية");

            migrationBuilder.CreateTable(
                name: "StudentGpa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    SemesterId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الفصل الدراسي"),
                    Gpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل الفصلي"),
                    WeightedGpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل الموزون"),
                    CumulativeGpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل التراكمي"),
                    ClassRank = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب الدفعة"),
                    ClassSize = table.Column<int>(type: "integer", nullable: true, comment: "عدد الدفعة"),
                    CreditsEarned = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المكتسبة"),
                    CalculatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "تاريخ الحساب"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGpa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGpa_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGpa_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentGpa_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGpa_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المعدل التراكمي المحسوب للطلاب");

            migrationBuilder.CreateTable(
                name: "AssignmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseSectionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان النوع"),
                    WeightPercent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    DefaultPoints = table.Column<decimal>(type: "numeric", nullable: true, comment: "النقاط الافتراضية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentType_CourseSemester_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول أنواع التكليفات والواجبات");

            migrationBuilder.CreateTable(
                name: "CourseSectionMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموعد")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseSectionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    MeetingDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ المحاضرة"),
                    PeriodId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة الزمنية"),
                    RoomId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف القاعة"),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المحاضرة ملغية"),
                    CancelReason = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "سبب الإلغاء"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSectionMeeting_CourseSemester_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSectionMeeting_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSectionMeeting_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول مواعيد انعقاد المحاضرات الفعلية");

            migrationBuilder.CreateTable(
                name: "CourseSemesterSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseSemesterId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemesterSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSemesterSection_CourseSemester_CourseSemesterId",
                        column: x => x.CourseSemesterId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSemesterSection_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseEnrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التسجيل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    CourseSectionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البدء"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    IsDropped = table.Column<bool>(type: "boolean", nullable: false, comment: "هل تم الانسحاب"),
                    DropDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانسحاب"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseEnrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourseEnrollment_CourseSemester_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول تسجيل الطلاب في حصص المقررات");

            migrationBuilder.CreateTable(
                name: "FinalGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    CourseSectionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    SemesterId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الفصل الدراسي"),
                    QuarterId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الربع"),
                    GradePercent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    LetterGrade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "التقدير"),
                    GpaValue = table.Column<decimal>(type: "numeric", nullable: true, comment: "قيمة المعدل"),
                    CreditsAttempted = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المحاولة"),
                    CreditsEarned = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المكتسبة"),
                    IncludeInGpa = table.Column<bool>(type: "boolean", nullable: false, comment: "يحسب في المعدل"),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نهائي"),
                    Comment = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    PostedBy = table.Column<int>(type: "integer", nullable: true, comment: "نشر بواسطة"),
                    PostedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ النشر"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalGrade_CourseSemester_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalGrade_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FinalGrade_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FinalGrade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الدرجات النهائية للمقررات");

            migrationBuilder.CreateTable(
                name: "ProgressPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuarterId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الربع"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الفترة"),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    DoesGrades = table.Column<bool>(type: "boolean", nullable: false, comment: "هل تحسب درجات"),
                    SortOrder = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressPeriod_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول فترات التقدم والتقييم المستمر");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التكليف")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseSectionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    AssignmentTypeId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع التكليف"),
                    SemesterId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الفصل الدراسي"),
                    QuarterId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الربع"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "عنوان التكليف"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف التكليف"),
                    AssignedDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ التكليف"),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الاستحقاق"),
                    MaxPoints = table.Column<decimal>(type: "numeric", nullable: false, comment: "النقاط القصوى"),
                    IsExtraCredit = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هو درجات إضافية"),
                    IsGraded = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يتم تقييمه"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true, comment: "تم الإنشاء بواسطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentType_AssignmentTypeId",
                        column: x => x.AssignmentTypeId,
                        principalTable: "AssignmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Assignments_CourseSemester_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Assignments_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول التكليفات والواجبات الدراسية");

            migrationBuilder.CreateTable(
                name: "AttendanceCompleted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseSectionMeetingId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف موعد المحاضرة"),
                    StaffId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموظف"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceCompleted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceCompleted_CourseSectionMeeting_CourseSectionMeeti~",
                        column: x => x.CourseSectionMeetingId,
                        principalTable: "CourseSectionMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceCompleted_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول حالة إتمام تسجيل الحضور");

            migrationBuilder.CreateTable(
                name: "AttendancePeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    CourseSectionMeetingId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف موعد المحاضرة"),
                    AttendanceCodeId = table.Column<int>(type: "integer", nullable: true, comment: "معرّف كود الحضور"),
                    Reason = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "السبب"),
                    Comment = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "ملاحظة"),
                    RecordedBy = table.Column<int>(type: "integer", nullable: true, comment: "تم التسجيل بواسطة"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePeriod_CourseSectionMeeting_CourseSectionMeetingId",
                        column: x => x.CourseSectionMeetingId,
                        principalTable: "CourseSectionMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendancePeriod_LookupAttendanceCode_AttendanceCodeId",
                        column: x => x.AttendanceCodeId,
                        principalTable: "LookupAttendanceCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AttendancePeriod_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الحضور بالحصة");

            migrationBuilder.CreateTable(
                name: "AssignmentGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignmentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التكليف"),
                    StudentId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطالب"),
                    PointsEarned = table.Column<decimal>(type: "numeric", nullable: true, comment: "النقاط المكتسبة"),
                    LetterGrade = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "التقدير"),
                    IsExcused = table.Column<bool>(type: "boolean", nullable: false, comment: "معذور"),
                    IsIncomplete = table.Column<bool>(type: "boolean", nullable: false, comment: "غير مكتمل"),
                    IsLate = table.Column<bool>(type: "boolean", nullable: false, comment: "متأخر"),
                    Comment = table.Column<string>(type: "text", nullable: true, comment: "تعليق"),
                    GradedBy = table.Column<int>(type: "integer", nullable: true, comment: "تم التقييم بواسطة"),
                    GradedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تم التقييم في"),
                    InsertUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    UpdateUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteUserCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentGrade_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentGrade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول درجات التكليفات (دفتر الدرجات)");

            migrationBuilder.InsertData(
                table: "LookupAddressType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "HOME", null, null, null, true, false, null, "المنزل", "Home", 1, null },
                    { 2, "WORK", null, null, null, true, false, null, "العمل", "Work", 2, null },
                    { 3, "MAIL", null, null, null, true, false, null, "المراسلات", "Mailing", 3, null }
                });

            migrationBuilder.InsertData(
                table: "LookupAttendanceCode",
                columns: new[] { "Id", "Code", "ColorCode", "DeductionPoints", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDefault", "IsDeleted", "IsPresence", "LastUpdate", "NameAr", "NameEn", "ShortName", "SortOrder", "Type", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "P", "#28a745", 0m, null, null, null, true, true, false, false, null, "حاضر", "Present", "ح", 1, 0, null },
                    { 2, "A", "#dc3545", 5m, null, null, null, true, false, false, false, null, "غائب", "Absent", "غ", 2, 1, null },
                    { 3, "T", "#ffc107", 1m, null, null, null, true, false, false, false, null, "متأخر", "Tardy", "م", 3, 2, null },
                    { 4, "E", "#17a2b8", 0m, null, null, null, true, false, false, false, null, "معذور", "Excused", "ع", 4, 3, null },
                    { 5, "L", "#fd7e14", 2m, null, null, null, true, false, false, false, null, "انصراف مبكر", "Early Leave", "ا", 5, 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupDisciplineActionType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SeverityLevel", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "WARNING", null, null, null, true, false, null, "إنذار", "Warning", 0, 1, null },
                    { 2, "DETENTION", null, null, null, true, false, null, "احتجاز", "Detention", 0, 2, null },
                    { 3, "PARENT_MEETING", null, null, null, true, false, null, "اجتماع مع ولي الأمر", "Parent Meeting", 0, 3, null },
                    { 4, "IN_UNIVERSITY_SUSP", null, null, null, true, false, null, "إيقاف داخلي", "In-University Suspension", 0, 4, null },
                    { 5, "OUT_UNIVERSITY_SUSP", null, null, null, true, false, null, "إيقاف خارجي", "Out-of-University Suspension", 0, 5, null },
                    { 6, "EXPULSION", null, null, null, true, false, null, "فصل", "Expulsion", 0, 6, null }
                });

            migrationBuilder.InsertData(
                table: "LookupEnrollmentCode",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "NEW", null, null, null, false, null, "تسجيل جديد", "New Enrollment", 1, null },
                    { 3, "GRADUATED", null, null, null, false, null, "تخرج", "Graduated", 2, null }
                });

            migrationBuilder.InsertData(
                table: "LookupEthnicity",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "ARAB", null, null, null, true, false, null, "عربي", "Arab", 1, null },
                    { 2, "ASIAN", null, null, null, true, false, null, "آسيوي", "Asian", 2, null },
                    { 3, "AFRICAN", null, null, null, true, false, null, "أفريقي", "African", 3, null },
                    { 4, "EUROPEAN", null, null, null, true, false, null, "أوروبي", "European", 4, null },
                    { 5, "OTHER", null, null, null, true, false, null, "أخرى", "Other", 5, null }
                });

            migrationBuilder.InsertData(
                table: "LookupIncidentType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SeverityLevel", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "TARDINESS", null, null, null, true, false, null, "التأخر", "Tardiness", 1, 1, null },
                    { 2, "DISRUPTIVE", null, null, null, true, false, null, "السلوك التخريبي", "Disruptive Behavior", 2, 2, null },
                    { 3, "VERBAL_ABUSE", null, null, null, true, false, null, "الإساءة اللفظية", "Verbal Abuse", 3, 3, null },
                    { 4, "BULLYING", null, null, null, true, false, null, "التنمر", "Bullying", 4, 4, null },
                    { 5, "PHYSICAL", null, null, null, true, false, null, "العنف الجسدي", "Physical Violence", 5, 5, null },
                    { 6, "CHEATING", null, null, null, true, false, null, "الغش", "Cheating", 3, 6, null }
                });

            migrationBuilder.InsertData(
                table: "LookupLanguage",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "ar", null, null, null, true, false, null, "العربية", "Arabic", 1, null },
                    { 2, "en", null, null, null, true, false, null, "الإنجليزية", "English", 2, null },
                    { 3, "fr", null, null, null, true, false, null, "الفرنسية", "French", 3, null }
                });

            migrationBuilder.InsertData(
                table: "LookupMarkingPeriodType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "FINAL", null, null, null, true, false, null, "نهائي", "Final", 1, null },
                    { 2, "MIDTERM", null, null, null, true, false, null, "نصفي", "Midterm", 2, null },
                    { 3, "QUARTER", null, null, null, true, false, null, "ربع سنوي", "Quarterly", 3, null },
                    { 4, "MONTHLY", null, null, null, true, false, null, "شهري", "Monthly", 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupMilitaryRank",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "PVT", null, null, null, true, false, null, "جندي", "Private", 2, null },
                    { 2, "CPL", null, null, null, true, false, null, "عريف", "Corporal", 3, null },
                    { 3, "SGT", null, null, null, true, false, null, "رقيب", "Sergeant", 4, null },
                    { 4, "SSGT", null, null, null, true, false, null, "رقيب أول", "Staff Sergeant", 5, null },
                    { 5, "SFC", null, null, null, true, false, null, "مساعد", "Sergeant First Class", 6, null },
                    { 6, "MSG", null, null, null, true, false, null, "مساعد أول", "Master Sergeant", 7, null },
                    { 10, "LT", null, null, null, true, false, null, "ملازم", "Lieutenant", 10, null },
                    { 11, "1LT", null, null, null, true, false, null, "ملازم أول", "First Lieutenant", 11, null },
                    { 12, "CPT", null, null, null, true, false, null, "نقيب", "Captain", 12, null },
                    { 13, "MAJ", null, null, null, true, false, null, "رائد", "Major", 13, null },
                    { 14, "LTC", null, null, null, true, false, null, "مقدم", "Lieutenant Colonel", 14, null },
                    { 15, "COL", null, null, null, true, false, null, "عقيد", "Colonel", 15, null },
                    { 16, "BG", null, null, null, true, false, null, "عميد", "Brigadier General", 16, null },
                    { 17, "MG", null, null, null, true, false, null, "لواء", "Major General", 17, null },
                    { 18, "LTG", null, null, null, true, false, null, "فريق", "Lieutenant General", 18, null },
                    { 19, "GEN", null, null, null, true, false, null, "فريق أول", "General", 19, null },
                    { 20, "FM", null, null, null, true, false, null, "مشير", "Field Marshal", 20, null },
                    { 21, "STD", null, null, null, true, false, null, "طالب", "Student", 1, null }
                });

            migrationBuilder.InsertData(
                table: "LookupNationality",
                columns: new[] { "Id", "Code", "CountryCode", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "SA", "SA", null, null, null, true, false, null, "سعودي", "Saudi", 1, null },
                    { 2, "EG", "EG", null, null, null, true, false, null, "مصري", "Egyptian", 2, null },
                    { 3, "YE", "YE", null, null, null, true, false, null, "يمني", "Yemeni", 3, null },
                    { 4, "SY", "SY", null, null, null, true, false, null, "سوري", "Syrian", 4, null },
                    { 5, "JO", "JO", null, null, null, true, false, null, "أردني", "Jordanian", 5, null },
                    { 99, "OTH", "OTH", null, null, null, true, false, null, "أخرى", "Other", 99, null }
                });

            migrationBuilder.InsertData(
                table: "LookupPhoneType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "MOBILE", null, null, null, true, false, null, "جوال", "Mobile", 1, null },
                    { 2, "HOME", null, null, null, true, false, null, "منزل", "Home", 2, null },
                    { 3, "WORK", null, null, null, true, false, null, "عمل", "Work", 3, null },
                    { 4, "EMERGENCY", null, null, null, true, false, null, "طوارئ", "Emergency", 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupRecordStatus",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "Description", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "ACTIVE", null, null, "Active Record", null, true, false, null, "نشط", "Active", 1, null },
                    { 2, "INACTIVE", null, null, "Inactive Record", null, true, false, null, "غير نشط", "Inactive", 2, null },
                    { 3, "DELETED", null, null, "Soft Deleted Record", null, true, false, null, "محذوف", "Deleted", 3, null },
                    { 4, "ARCHIVED", null, null, "Archived Record", null, true, false, null, "مؤرشف", "Archived", 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupRelationshipType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "FATHER", null, null, null, true, false, null, "الأب", "Father", 1, null },
                    { 2, "MOTHER", null, null, null, true, false, null, "الأم", "Mother", 2, null },
                    { 3, "GUARDIAN", null, null, null, true, false, null, "ولي الأمر", "Guardian", 3, null },
                    { 4, "GRANDPARENT", null, null, null, true, false, null, "الجد/الجدة", "Grandparent", 4, null },
                    { 5, "SIBLING", null, null, null, true, false, null, "الأخ/الأخت", "Sibling", 5, null },
                    { 6, "OTHER", null, null, null, true, false, null, "أخرى", "Other", 6, null }
                });

            migrationBuilder.InsertData(
                table: "LookupStaffCategory",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsAcademic", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "ACADEMIC", null, null, null, true, true, false, null, "هيئة تدريس", "Academic", 1, null },
                    { 2, "ADMIN", null, null, null, false, true, false, null, "اداري", "Administrative", 2, null },
                    { 3, "TECH", null, null, null, false, true, false, null, "فني", "Technician", 3, null },
                    { 4, "WORKER", null, null, null, false, true, false, null, "عامل", "Worker", 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupSubjectType",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "MANDATORY", null, null, null, true, false, null, "إجباري", "Mandatory", 1, null },
                    { 2, "ELECTIVE", null, null, null, true, false, null, "اختياري", "Elective", 2, null },
                    { 3, "ACTIVITY", null, null, null, true, false, null, "نشاط", "Activity", 3, null },
                    { 4, "UNIVERSITY_REQ", null, null, null, true, false, null, "متطلب جامعة", "University Requirement", 4, null }
                });

            migrationBuilder.InsertData(
                table: "LookupWeekday",
                columns: new[] { "Id", "Code", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsActive", "IsDeleted", "LastUpdate", "NameAr", "NameEn", "SortOrder", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, "SUN", null, null, null, true, false, null, "الأحد", "Sunday", 1, null },
                    { 2, "MON", null, null, null, true, false, null, "الاثنين", "Monday", 2, null },
                    { 3, "TUE", null, null, null, true, false, null, "الثلاثاء", "Tuesday", 3, null },
                    { 4, "WED", null, null, null, true, false, null, "الأربعاء", "Wednesday", 4, null },
                    { 5, "THU", null, null, null, true, false, null, "الخميس", "Thursday", 5, null },
                    { 6, "FRI", null, null, null, true, false, null, "الجمعة", "Friday", 6, null },
                    { 7, "SAT", null, null, null, true, false, null, "السبت", "Saturday", 7, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendar_AcademicYearId",
                table: "AcademicCalendar",
                column: "AcademicYearId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendar_UniversityId",
                table: "AcademicCalendar",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendarDetail_AcademicCalendarId_AcademicDate",
                table: "AcademicCalendarDetail",
                columns: new[] { "AcademicCalendarId", "AcademicDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_NextLevelId",
                table: "AcademicLevel",
                column: "NextLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_ParentId",
                table: "AcademicLevel",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_PreviousLevelId",
                table: "AcademicLevel",
                column: "PreviousLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_UniversityId",
                table: "AcademicLevel",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevelCourse_AcademicLevelId",
                table: "AcademicLevelCourse",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevelCourse_CourseId",
                table: "AcademicLevelCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevelIteration_AcademicLevelId",
                table: "AcademicLevelIteration",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevelIteration_AcademicYearId",
                table: "AcademicLevelIteration",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_UniversityId",
                table: "AcademicYear",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_AssignmentId_StudentId",
                table: "AssignmentGrade",
                columns: new[] { "AssignmentId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_StudentId",
                table: "AssignmentGrade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentTypeId",
                table: "Assignments",
                column: "AssignmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseSectionId",
                table: "Assignments",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_QuarterId",
                table: "Assignments",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SemesterId",
                table: "Assignments",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentType_CourseSectionId",
                table: "AssignmentType",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCompleted_CourseSectionMeetingId",
                table: "AttendanceCompleted",
                column: "CourseSectionMeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCompleted_StaffId",
                table: "AttendanceCompleted",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeriod_AttendanceCodeId",
                table: "AttendancePeriod",
                column: "AttendanceCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeriod_CourseSectionMeetingId",
                table: "AttendancePeriod",
                column: "CourseSectionMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeriod_StudentId_CourseSectionMeetingId",
                table: "AttendancePeriod",
                columns: new[] { "StudentId", "CourseSectionMeetingId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCategoryId",
                table: "Course",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UniversityId_Code",
                table: "Course",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategory_UniversityId_Code",
                table: "CourseCategory",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisite_CourseId_PrerequisiteCourseId",
                table: "CoursePrerequisite",
                columns: new[] { "CourseId", "PrerequisiteCourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisite_PrerequisiteCourseId",
                table: "CoursePrerequisite",
                column: "PrerequisiteCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_CourseSectionId_MeetingDate_PeriodId",
                table: "CourseSectionMeeting",
                columns: new[] { "CourseSectionId", "MeetingDate", "PeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_PeriodId",
                table: "CourseSectionMeeting",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_RoomId",
                table: "CourseSectionMeeting",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_AcademicLevelIterationId",
                table: "CourseSemester",
                column: "AcademicLevelIterationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_CourseId",
                table: "CourseSemester",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_SemesterId",
                table: "CourseSemester",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterSection_CourseSemesterId",
                table: "CourseSemesterSection",
                column: "CourseSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterSection_SectionId",
                table: "CourseSemesterSection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_ActionTypeId",
                table: "DisciplineAction",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_IncidentId",
                table: "DisciplineAction",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_IssuedBy",
                table: "DisciplineAction",
                column: "IssuedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_StudentId",
                table: "DisciplineAction",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncident_AcademicYearId",
                table: "DisciplineIncident",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncident_IncidentTypeId",
                table: "DisciplineIncident",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncident_ReporterId",
                table: "DisciplineIncident",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncident_UniversityId",
                table: "DisciplineIncident",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncidentStudent_IncidentId_StudentId_Role",
                table: "DisciplineIncidentStudent",
                columns: new[] { "IncidentId", "StudentId", "Role" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncidentStudent_StudentId",
                table: "DisciplineIncidentStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_CourseSectionId",
                table: "FinalGrade",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_QuarterId",
                table: "FinalGrade",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_SemesterId",
                table: "FinalGrade",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_StudentId",
                table: "FinalGrade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeScale_AcademicYearId",
                table: "GradeScale",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeScale_UniversityId",
                table: "GradeScale",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeScaleItem_GradeScaleId",
                table: "GradeScaleItem",
                column: "GradeScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_UniversityId",
                table: "Period",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MilitaryRankId",
                table: "Person",
                column: "MilitaryRankId");

            migrationBuilder.CreateIndex(
                name: "ix_person_national_id_unique",
                table: "Person",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_person_university_person_type_unique",
                table: "PersonUniversity",
                columns: new[] { "PersonId", "UniversityId", "PersonType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversity_UniversityId",
                table: "PersonUniversity",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressPeriod_QuarterId",
                table: "ProgressPeriod",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quarter_SemesterId",
                table: "Quarter",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UniversityId_Code",
                table: "Room",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_AcademicLevelId",
                table: "Section",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_AcademicLevelIterationId",
                table: "Section",
                column: "AcademicLevelIterationId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_AcademicYearId",
                table: "Section",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_UniversityId",
                table: "Section",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_AcademicLevelId",
                table: "Semester",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_AcademicLevelIterationId",
                table: "Semester",
                column: "AcademicLevelIterationId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_AcademicYearId",
                table: "Semester",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_NationalityId",
                table: "Staff",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffCategoryId",
                table: "Staff",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffUniversityAssignment_AcademicYearId",
                table: "StaffUniversityAssignment",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffUniversityAssignment_StaffId_UniversityId_AcademicYear~",
                table: "StaffUniversityAssignment",
                columns: new[] { "StaffId", "UniversityId", "AcademicYearId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffUniversityAssignment_UniversityId",
                table: "StaffUniversityAssignment",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurrentUniversityId",
                table: "Student",
                column: "CurrentUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_EthnicityId",
                table: "Student",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_LanguageId",
                table: "Student",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_NationalityId",
                table: "Student",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEnrollment_CourseSectionId",
                table: "StudentCourseEnrollment",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEnrollment_StudentId_CourseSectionId",
                table: "StudentCourseEnrollment",
                columns: new[] { "StudentId", "CourseSectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_LookupEnrollmentCodeId",
                table: "StudentEnrollment",
                column: "LookupEnrollmentCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_PersonUniversityId",
                table: "StudentEnrollment",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_SectionId",
                table: "StudentEnrollment",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_AcademicYearId",
                table: "StudentGpa",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_SemesterId",
                table: "StudentGpa",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_StudentId_AcademicYearId_SemesterId",
                table: "StudentGpa",
                columns: new[] { "StudentId", "AcademicYearId", "SemesterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_UniversityId",
                table: "StudentGpa",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardian_GuardianId",
                table: "StudentGuardian",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardian_RelationshipTypeId",
                table: "StudentGuardian",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardian_StudentId_GuardianId_RelationshipTypeId",
                table: "StudentGuardian",
                columns: new[] { "StudentId", "GuardianId", "RelationshipTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_AcademicYearId",
                table: "Subject",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectTypeId",
                table: "Subject",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UniversityId_AcademicYearId_Code",
                table: "Subject",
                columns: new[] { "UniversityId", "AcademicYearId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_StudentId",
                table: "Transcript",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_UniversityId",
                table: "Transcript",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_University_ParentId",
                table: "University",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicCalendarDetail");

            migrationBuilder.DropTable(
                name: "AcademicLevelCourse");

            migrationBuilder.DropTable(
                name: "AssignmentGrade");

            migrationBuilder.DropTable(
                name: "AttendanceCompleted");

            migrationBuilder.DropTable(
                name: "AttendancePeriod");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "BloodType");

            migrationBuilder.DropTable(
                name: "CoursePrerequisite");

            migrationBuilder.DropTable(
                name: "CourseSemesterSection");

            migrationBuilder.DropTable(
                name: "DisciplineAction");

            migrationBuilder.DropTable(
                name: "DisciplineIncidentStudent");

            migrationBuilder.DropTable(
                name: "FinalGrade");

            migrationBuilder.DropTable(
                name: "GradeScaleItem");

            migrationBuilder.DropTable(
                name: "LookupAddressType");

            migrationBuilder.DropTable(
                name: "LookupMarkingPeriodType");

            migrationBuilder.DropTable(
                name: "LookupPhoneType");

            migrationBuilder.DropTable(
                name: "LookupRecordStatus");

            migrationBuilder.DropTable(
                name: "LookupWeekday");

            migrationBuilder.DropTable(
                name: "ProgressPeriod");

            migrationBuilder.DropTable(
                name: "StaffUniversityAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourseEnrollment");

            migrationBuilder.DropTable(
                name: "StudentEnrollment");

            migrationBuilder.DropTable(
                name: "StudentGpa");

            migrationBuilder.DropTable(
                name: "StudentGuardian");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Transcript");

            migrationBuilder.DropTable(
                name: "AcademicCalendar");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "CourseSectionMeeting");

            migrationBuilder.DropTable(
                name: "LookupAttendanceCode");

            migrationBuilder.DropTable(
                name: "LookupDisciplineActionType");

            migrationBuilder.DropTable(
                name: "DisciplineIncident");

            migrationBuilder.DropTable(
                name: "GradeScale");

            migrationBuilder.DropTable(
                name: "LookupEnrollmentCode");

            migrationBuilder.DropTable(
                name: "PersonUniversity");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Guardian");

            migrationBuilder.DropTable(
                name: "LookupRelationshipType");

            migrationBuilder.DropTable(
                name: "LookupSubjectType");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AssignmentType");

            migrationBuilder.DropTable(
                name: "Quarter");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "LookupIncidentType");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "LookupEthnicity");

            migrationBuilder.DropTable(
                name: "LookupLanguage");

            migrationBuilder.DropTable(
                name: "CourseSemester");

            migrationBuilder.DropTable(
                name: "LookupNationality");

            migrationBuilder.DropTable(
                name: "LookupStaffCategory");

            migrationBuilder.DropTable(
                name: "LookupMilitaryRank");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "CourseCategory");

            migrationBuilder.DropTable(
                name: "AcademicLevelIteration");

            migrationBuilder.DropTable(
                name: "AcademicLevel");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
