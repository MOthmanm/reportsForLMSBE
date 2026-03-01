using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    table_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    time_stamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    emp_serial = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    table_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    changes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    module_no = table.Column<decimal>(type: "numeric(5,0)", precision: 5, scale: 0, nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "blood_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الدفعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blood_type", x => x.id);
                },
                comment: "فصائل الدم");

            migrationBuilder.CreateTable(
                name: "course_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم"),
                    show_in_calendar = table.Column<bool>(type: "boolean", nullable: false, comment: "عرض في التقويم"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_type", x => x.id);
                },
                comment: "جدول أنواع المقررات");

            migrationBuilder.CreateTable(
                name: "guardian",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف ولي الأمر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللقب"),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهاتف"),
                    mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    address = table.Column<string>(type: "text", nullable: true, comment: "العنوان"),
                    occupation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "المهنة"),
                    workplace = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "مكان العمل"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_guardian", x => x.id);
                },
                comment: "جدول أولياء الأمور");

            migrationBuilder.CreateTable(
                name: "icons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_icons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lookup_address_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_address_type", x => x.id);
                },
                comment: "جدول أنواع العناوين");

            migrationBuilder.CreateTable(
                name: "lookup_attachment_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع المرفق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_attachment_type", x => x.id);
                },
                comment: "جدول أنواع المرفقات");

            migrationBuilder.CreateTable(
                name: "lookup_attendance_code",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكود")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    short_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "نوع الحضور"),
                    deduction_points = table.Column<decimal>(type: "numeric", nullable: false),
                    color_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    is_presence = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يعتبر حضور"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_attendance_code", x => x.id);
                },
                comment: "جدول أكواد الحضور");

            migrationBuilder.CreateTable(
                name: "lookup_batch",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الدفعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_batch", x => x.id);
                },
                comment: "جدول الدفعات");

            migrationBuilder.CreateTable(
                name: "lookup_college",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكلية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_college", x => x.id);
                },
                comment: "جدول الكليات");

            migrationBuilder.CreateTable(
                name: "lookup_course_degree_devision",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكلية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_course_degree_devision", x => x.id);
                },
                comment: "جدول الكليات");

            migrationBuilder.CreateTable(
                name: "lookup_discipline_action_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    severity_level = table.Column<int>(type: "integer", nullable: false, comment: "الخطورة (1-5)"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_discipline_action_type", x => x.id);
                },
                comment: "جدول أنواع الإجراءات التأديبية");

            migrationBuilder.CreateTable(
                name: "lookup_enrollment_code",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكود")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "text", nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "text", nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_enrollment_code", x => x.id);
                },
                comment: "جدول أكواد القيد (دخول/خروج)");

            migrationBuilder.CreateTable(
                name: "lookup_ethnicity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العرق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_ethnicity", x => x.id);
                },
                comment: "جدول الأعراق");

            migrationBuilder.CreateTable(
                name: "lookup_fitness_age_stages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "كود المرحلة السنية (فريد)"),
                    title_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المرحلة السنية بالعربية"),
                    title_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم المرحلة السنية بالإنجليزية"),
                    min_age = table.Column<short>(type: "smallint", nullable: false, comment: "العمر الأدنى للمرحلة السنية"),
                    max_age = table.Column<short>(type: "smallint", nullable: false, comment: "العمر الأقصى للمرحلة السنية"),
                    sort_order = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل المرحلة السنية مفعلة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_fitness_age_stages", x => x.id);
                    table.CheckConstraint("ck_lookup_fitness_age_stages_max_age", "max_age >= min_age");
                    table.CheckConstraint("ck_lookup_fitness_age_stages_min_age", "min_age >= 0");
                },
                comment: "جدول تعريف المراحل السنية لاختبارات اللياقة البدنية");

            migrationBuilder.CreateTable(
                name: "lookup_governate",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المحافظة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_governate", x => x.id);
                },
                comment: "جدول المحافظات");

            migrationBuilder.CreateTable(
                name: "lookup_incident_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    severity_level = table.Column<int>(type: "integer", nullable: false, comment: "الخطورة (1-5)"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_incident_type", x => x.id);
                },
                comment: "جدول أنواع حوادث السلوك");

            migrationBuilder.CreateTable(
                name: "lookup_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_language", x => x.id);
                },
                comment: "جدول اللغات");

            migrationBuilder.CreateTable(
                name: "lookup_marking_period_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_marking_period_type", x => x.id);
                },
                comment: "جدول أنواع فترات الرصد");

            migrationBuilder.CreateTable(
                name: "lookup_military_rank",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الرتبة العسكرية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_military_rank", x => x.id);
                },
                comment: "جدول الرتب العسكرية");

            migrationBuilder.CreateTable(
                name: "lookup_nationality",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجنسية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    country_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true, comment: "رمز الدولة"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_nationality", x => x.id);
                },
                comment: "جدول الجنسيات");

            migrationBuilder.CreateTable(
                name: "lookup_phone_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_phone_type", x => x.id);
                },
                comment: "جدول أنواع الهواتف");

            migrationBuilder.CreateTable(
                name: "lookup_qualification",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المؤهل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_qualification", x => x.id);
                },
                comment: "جدول المؤهلات العلمية");

            migrationBuilder.CreateTable(
                name: "lookup_record_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحالة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "الوصف"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_record_status", x => x.id);
                },
                comment: "جدول حالات السجلات العامة");

            migrationBuilder.CreateTable(
                name: "lookup_relationship_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_relationship_type", x => x.id);
                },
                comment: "جدول أنواع العلاقات (ولي الأمر)");

            migrationBuilder.CreateTable(
                name: "lookup_religion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الدين")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_religion", x => x.id);
                },
                comment: "جدول الأديان");

            migrationBuilder.CreateTable(
                name: "lookup_staff_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفئة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    is_academic = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هيئة تدريس"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_staff_category", x => x.id);
                },
                comment: "جدول فئات الموظفين");

            migrationBuilder.CreateTable(
                name: "lookup_subject_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_subject_type", x => x.id);
                },
                comment: "جدول أنواع المواد الدراسية");

            migrationBuilder.CreateTable(
                name: "lookup_weapon",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السلاح")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_weapon", x => x.id);
                },
                comment: "جدول الأسلحة");

            migrationBuilder.CreateTable(
                name: "lookup_weekday",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف اليوم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الاسم بالإنجليزية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض (الأحد=1)"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_weekday", x => x.id);
                },
                comment: "جدول أيام الأسبوع");

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    revoked_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    replaced_by_token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_tokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_en = table.Column<string>(type: "text", nullable: false),
                    name_ar = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    query = table.Column<string>(type: "text", nullable: true),
                    path = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true),
                    has_detail = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    hide = table.Column<bool>(type: "boolean", nullable: false),
                    detail_id = table.Column<int>(type: "integer", nullable: true),
                    detail_column = table.Column<string>(type: "text", nullable: true),
                    report_type = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    default_page_url = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الجامعة بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الجامعة بالإنجليزية"),
                    short_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الاسم المختصر"),
                    icon = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true, comment: "الايقونة"),
                    parent_id = table.Column<int>(type: "integer", nullable: true, comment: "المستوي الاعلي"),
                    level = table.Column<int>(type: "integer", nullable: true, comment: "المستوي"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_university", x => x.id);
                    table.ForeignKey(
                        name: "fk_university_university_parent_id",
                        column: x => x.parent_id,
                        principalTable: "university",
                        principalColumn: "id");
                },
                comment: "جدول الجامعات والمؤسسات الأكاديمية");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    profile_image_url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menu_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    title_en = table.Column<string>(type: "text", nullable: true),
                    title_ar = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    icon_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_menu_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_menu_items_icons_icon_id",
                        column: x => x.icon_id,
                        principalTable: "icons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_menu_items_menu_items_parent_id",
                        column: x => x.parent_id,
                        principalTable: "menu_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lookup_fitness_exercises",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    degree_division_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف سطر تقسيم الدرجات (اختبار اللياقة) من جدول degree-divisions"),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "كود التمرين (فريد داخل نفس سطر تقسيم الدرجات)"),
                    title_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم التمرين بالعربية"),
                    title_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم التمرين بالإنجليزية"),
                    unit_name_ar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "عدة", comment: "وحدة القياس بالعربية (مثال: عدة/ثانية/متر)"),
                    unit_name_en = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "وحدة القياس بالإنجليزية"),
                    max_degree = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true, comment: "الدرجة القصوى للتمرين"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف إضافي للتمرين"),
                    sort_order = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل التمرين مفعل"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_fitness_exercises", x => x.id);
                    table.CheckConstraint("ck_lookup_fitness_exercises_max_degree", "max_degree IS NULL OR max_degree >= 0");
                    table.ForeignKey(
                        name: "fk_lookup_fitness_exercises_degree_division",
                        column: x => x.degree_division_id,
                        principalTable: "lookup_course_degree_devision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول تعريف تمارين اختبار اللياقة البدنية");

            migrationBuilder.CreateTable(
                name: "lookup_district",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحي/المنطقة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    name_ar = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    name_en = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    governate_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المحافظة"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_district", x => x.id);
                    table.ForeignKey(
                        name: "fk_lookup_district_lookup_governate_governate_id",
                        column: x => x.governate_id,
                        principalTable: "lookup_governate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الأحياء/المناطق");

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموظف")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    staff_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز الموظف"),
                    title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللقب"),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    name_suffix = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "اللاحقة"),
                    gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الميلاد"),
                    nationality_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الجنسية"),
                    national_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهوية"),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الهاتف"),
                    mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    address = table.Column<string>(type: "text", nullable: true, comment: "العنوان"),
                    staff_category_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف فئة الموظف"),
                    hire_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ التعيين"),
                    termination_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ إنهاء الخدمة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    photo_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "مسار الصورة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staff", x => x.id);
                    table.ForeignKey(
                        name: "fk_staff_lookup_nationality_nationality_id",
                        column: x => x.nationality_id,
                        principalTable: "lookup_nationality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_staff_lookup_staff_category_staff_category_id",
                        column: x => x.staff_category_id,
                        principalTable: "lookup_staff_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول الموظفين والأساتذة");

            migrationBuilder.CreateTable(
                name: "report_columns",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    field = table.Column<string>(type: "text", nullable: true),
                    header_name = table.Column<string>(type: "text", nullable: true),
                    sortable = table.Column<bool>(type: "boolean", nullable: false),
                    filter = table.Column<string>(type: "text", nullable: true),
                    resizable = table.Column<bool>(type: "boolean", nullable: false),
                    floating_filter = table.Column<bool>(type: "boolean", nullable: false),
                    row_group = table.Column<bool>(type: "boolean", nullable: false),
                    hide = table.Column<bool>(type: "boolean", nullable: false),
                    is_master = table.Column<bool>(type: "boolean", nullable: false),
                    sort = table.Column<int>(type: "integer", nullable: false),
                    report_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_columns", x => x.id);
                    table.ForeignKey(
                        name: "fk_report_columns_reports_report_id",
                        column: x => x.report_id,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    data_type = table.Column<string>(type: "text", nullable: true),
                    parameter_type = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    default_value = table.Column<string>(type: "text", nullable: false),
                    query_for_dropdown = table.Column<string>(type: "text", nullable: true),
                    sort = table.Column<int>(type: "integer", nullable: true),
                    report_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_parameters", x => x.id);
                    table.ForeignKey(
                        name: "fk_report_parameters_reports_report_id",
                        column: x => x.report_id,
                        principalTable: "reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_role",
                columns: table => new
                {
                    permissions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_role", x => new { x.permissions_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_permission_role_permissions_permissions_id",
                        column: x => x.permissions_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_permission_role_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المستوى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم المستوى"),
                    short_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    previous_level_id = table.Column<int>(type: "integer", nullable: true),
                    next_level_id = table.Column<int>(type: "integer", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف المستوى الأب"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_level", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_level_academic_level_next_level_id",
                        column: x => x.next_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_academic_level_academic_level_parent_id",
                        column: x => x.parent_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_academic_level_academic_level_previous_level_id",
                        column: x => x.previous_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_academic_level_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المستويات");

            migrationBuilder.CreateTable(
                name: "academic_year",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان السنة الدراسية"),
                    short_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    is_current = table.Column<bool>(type: "boolean", nullable: false, comment: "هل السنة الحالية"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_year", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_year_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول السنوات الدراسية");

            migrationBuilder.CreateTable(
                name: "battalion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكتيبة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الكتيبة"),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الكتيبة بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الكتيبة بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الكتيبة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_battalion", x => x.id);
                    table.ForeignKey(
                        name: "fk_battalion_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الكتائب العسكرية");

            migrationBuilder.CreateTable(
                name: "building",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المبنى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز المبنى"),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المبنى بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم المبنى بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف المبنى"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المباني");

            migrationBuilder.CreateTable(
                name: "course_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز المقرر"),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_category", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_category_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المقررات الدراسية");

            migrationBuilder.CreateTable(
                name: "hall",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف القاعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز القاعة"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم القاعة"),
                    university_id = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: true, comment: "السعة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hall", x => x.id);
                    table.ForeignKey(
                        name: "fk_hall_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول القاعات والغرف");

            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    university_id = table.Column<int>(type: "integer", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job", x => x.id);
                    table.ForeignKey(
                        name: "fk_job_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "period",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "اسم الفترة"),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false, comment: "وقت البداية"),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false, comment: "وقت النهاية"),
                    length_minutes = table.Column<int>(type: "integer", nullable: false, comment: "المدة بالدقائق"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    period_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "نوع الفترة"),
                    is_attendance_required = table.Column<bool>(type: "boolean", nullable: false, comment: "الحضور مطلوب"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_period", x => x.id);
                    table.ForeignKey(
                        name: "fk_period_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفترات الزمنية اليومية");

            migrationBuilder.CreateTable(
                name: "role_user",
                columns: table => new
                {
                    roles_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_user", x => new { x.roles_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_role_user_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_user_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menu_item_permission",
                columns: table => new
                {
                    menu_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    required_permissions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_menu_item_permission", x => new { x.menu_item_id, x.required_permissions_id });
                    table.ForeignKey(
                        name: "fk_menu_item_permission_menu_items_menu_item_id",
                        column: x => x.menu_item_id,
                        principalTable: "menu_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_menu_item_permission_permissions_required_permissions_id",
                        column: x => x.required_permissions_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشخص")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    national_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "الرقم الوطني - فريد"),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم الأول"),
                    middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "الاسم الأوسط"),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العائلة"),
                    full_name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false, computedColumnSql: "\r\n        (\r\n            \"first_name\" ||\r\n            ' ' ||\r\n            COALESCE(\"middle_name\" || ' ', '') ||\r\n            \"last_name\"\r\n        )\r\n        ", stored: true),
                    gender = table.Column<int>(type: "integer", nullable: true, comment: "الجنس"),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الميلاد"),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "البريد الإلكتروني"),
                    mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رقم الجوال"),
                    address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "العنوان"),
                    military_rank_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الرتبة العسكرية"),
                    batch_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الدفعة"),
                    district_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الحي/المنطقة"),
                    governate_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف المحافظة"),
                    nationality_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الجنسية"),
                    religion_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الدين"),
                    blood_type_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف فصيلة الدم"),
                    weapon_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف السلاح"),
                    is_military = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "هل عسكري"),
                    military_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الرقم العسكري"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_blood_type_blood_type_id",
                        column: x => x.blood_type_id,
                        principalTable: "blood_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "lookup_batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_district_district_id",
                        column: x => x.district_id,
                        principalTable: "lookup_district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_governate_governate_id",
                        column: x => x.governate_id,
                        principalTable: "lookup_governate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_military_rank_military_rank_id",
                        column: x => x.military_rank_id,
                        principalTable: "lookup_military_rank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_nationality_nationality_id",
                        column: x => x.nationality_id,
                        principalTable: "lookup_nationality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_religion_religion_id",
                        column: x => x.religion_id,
                        principalTable: "lookup_religion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_person_lookup_weapon_weapon_id",
                        column: x => x.weapon_id,
                        principalTable: "lookup_weapon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول الأشخاص (موظفين، طلاب، موظفين)");

            migrationBuilder.CreateTable(
                name: "academic_calendar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التقويم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false, comment: "عنوان التقويم"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هو الافتراضي"),
                    recurring_days = table.Column<string>(type: "text", nullable: true, comment: "أيام التكرار (JSON)"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_calendar", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_calendar_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_calendar_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول التقويمات الأكاديمية");

            migrationBuilder.CreateTable(
                name: "academic_level_iteration",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المستوى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    academic_level_id = table.Column<int>(type: "integer", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_level_iteration", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_level_iteration_academic_level_academic_level_id",
                        column: x => x.academic_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_academic_level_iteration_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المستويات");

            migrationBuilder.CreateTable(
                name: "grade_scale",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقياس")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false, comment: "اسم المقياس"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف المقياس"),
                    type = table.Column<int>(type: "integer", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المقياس الافتراضي"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grade_scale", x => x.id);
                    table.ForeignKey(
                        name: "fk_grade_scale_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_grade_scale_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول مقاييس الدرجات");

            migrationBuilder.CreateTable(
                name: "lookup_fitness_exercise_evaluations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف العام الأكاديمي"),
                    age_stage_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف المرحلة السنية"),
                    exercise_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف التمرين"),
                    degree_value = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false, comment: "الدرجة أو عدد العدات المقابل للتقييم"),
                    percentage_value = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, comment: "النسبة المئوية المقابلة للدرجة"),
                    sort_order = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض داخل التمرين"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل التقييم مفعل"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lookup_fitness_exercise_evaluations", x => x.id);
                    table.CheckConstraint("ck_lookup_fitness_exercise_eval_degree", "degree_value >= 0");
                    table.CheckConstraint("ck_lookup_fitness_exercise_eval_percentage", "percentage_value >= 0 AND percentage_value <= 100");
                    table.ForeignKey(
                        name: "fk_fitness_eval_academic_year",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_age_stage",
                        column: x => x.age_stage_id,
                        principalTable: "lookup_fitness_age_stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_exercise",
                        column: x => x.exercise_id,
                        principalTable: "lookup_fitness_exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول ربط تقييم الدرجة/العدة لكل تمرين حسب المرحلة السنية بالنسبة المئوية");

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المادة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز المادة"),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المادة"),
                    short_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "الاسم المختصر"),
                    subject_type_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع المادة"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف المادة"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject", x => x.id);
                    table.ForeignKey(
                        name: "fk_subject_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subject_lookup_subject_type_subject_type_id",
                        column: x => x.subject_type_id,
                        principalTable: "lookup_subject_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_subject_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المواد الدراسية");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السرية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز السرية"),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم السرية بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم السرية بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف السرية"),
                    battalion_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكتيبة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_battalion_battalion_id",
                        column: x => x.battalion_id,
                        principalTable: "battalion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول السرايا العسكرية");

            migrationBuilder.CreateTable(
                name: "floor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطابق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الطابق"),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الطابق بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الطابق بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الطابق"),
                    building_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المبنى"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_floor", x => x.id);
                    table.ForeignKey(
                        name: "fk_floor_building_building_id",
                        column: x => x.building_id,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الطوابق");

            migrationBuilder.CreateTable(
                name: "person_university",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشخص"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    person_type = table.Column<int>(type: "integer", nullable: false, comment: "نوع الشخص في هذه الجامعة (موظف، طالب، موظف)"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "ملاحظات"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_university", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_university_person",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_person_university_university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول العلاقة بين الأشخاص والجامعات (Many-to-Many)");

            migrationBuilder.CreateTable(
                name: "academic_calendar_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف اليوم")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات (مثل: إجازة 6 أكتوبر)"),
                    academic_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "التاريخ"),
                    holiday_type = table.Column<int>(type: "integer", nullable: false),
                    academic_calendar_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التقويم"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_calendar_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_calendar_detail_academic_calendar_academic_calenda",
                        column: x => x.academic_calendar_id,
                        principalTable: "academic_calendar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول أيام التقويم الأكاديمي");

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الشعبة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false, comment: "اسم الشعبة"),
                    capacity = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "السعة القصوى"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    university_id = table.Column<int>(type: "integer", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_iteration_id = table.Column<int>(type: "integer", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_section", x => x.id);
                    table.ForeignKey(
                        name: "fk_section_academic_level_academic_level_id",
                        column: x => x.academic_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_section_academic_level_iteration_academic_level_iteration_id",
                        column: x => x.academic_level_iteration_id,
                        principalTable: "academic_level_iteration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_section_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_section_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصول والشعب الدراسية");

            migrationBuilder.CreateTable(
                name: "semester",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصل الدراسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الفصل"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_iteration_id = table.Column<int>(type: "integer", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_semester", x => x.id);
                    table.ForeignKey(
                        name: "fk_semester_academic_level_academic_level_id",
                        column: x => x.academic_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_semester_academic_level_iteration_academic_level_iteration_",
                        column: x => x.academic_level_iteration_id,
                        principalTable: "academic_level_iteration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_semester_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصول الدراسية");

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز المقرر"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف المقرر"),
                    credit_hours = table.Column<decimal>(type: "numeric", nullable: true, defaultValue: 0m),
                    is_year_fail = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    is_graduation_required = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    include_in_gpa = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "يحسب في المعدل - يتم تضمينه في حساب تقدير الطالب"),
                    maximum_degree = table.Column<decimal>(type: "numeric", nullable: true, defaultValue: 0m, comment: "النهاية العظمى للدرجة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    course_category_id = table.Column<int>(type: "integer", nullable: false),
                    grade_scale_id = table.Column<int>(type: "integer", nullable: true),
                    course_type_id = table.Column<int>(type: "integer", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_course_category_course_category_id",
                        column: x => x.course_category_id,
                        principalTable: "course_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_course_type_course_type_id",
                        column: x => x.course_type_id,
                        principalTable: "course_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_grade_scale_grade_scale_id",
                        column: x => x.grade_scale_id,
                        principalTable: "grade_scale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المقررات الدراسية");

            migrationBuilder.CreateTable(
                name: "grade_scale_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الرمز")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false, comment: "رمز التقدير"),
                    min_percent = table.Column<decimal>(type: "numeric", nullable: false, comment: "الحد الأدنى للنسبة"),
                    max_percent = table.Column<decimal>(type: "numeric", nullable: false, comment: "الحد الأقصى للنسبة"),
                    grade_scale_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقياس"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grade_scale_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_grade_scale_item_grade_scale_grade_scale_id",
                        column: x => x.grade_scale_id,
                        principalTable: "grade_scale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول رموز التقديرات");

            migrationBuilder.CreateTable(
                name: "platoon",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصيل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الفصيل"),
                    name_ar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الفصيل بالعربية"),
                    name_en = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الفصيل بالإنجليزية"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الفصيل"),
                    company_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السرية"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platoon", x => x.id);
                    table.ForeignKey(
                        name: "fk_platoon_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصائل العسكرية");

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العنبر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز العنبر"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم العنبر"),
                    floor_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الطابق"),
                    capacity = table.Column<int>(type: "integer", nullable: true, comment: "السعة"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_floor_floor_id",
                        column: x => x.floor_id,
                        principalTable: "floor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discipline_incident",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    incident_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true, comment: "رمز الحادثة"),
                    incident_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ الحادثة"),
                    incident_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true, comment: "وقت الحادثة"),
                    incident_type_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع الحادثة"),
                    location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "المكان"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف الحادثة"),
                    reporter_person_university_id = table.Column<int>(type: "integer", nullable: true, comment: "المبلغ (علاقة الموظف بالجامعة)"),
                    assigned_to_id = table.Column<int>(type: "integer", nullable: true, comment: "المسند إليه"),
                    status = table.Column<int>(type: "integer", nullable: false, comment: "الحالة"),
                    resolution = table.Column<string>(type: "text", nullable: true, comment: "القرار"),
                    resolved_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحل"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discipline_incident", x => x.id);
                    table.ForeignKey(
                        name: "fk_discipline_incident_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_discipline_incident_lookup_incident_type_incident_type_id",
                        column: x => x.incident_type_id,
                        principalTable: "lookup_incident_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_discipline_incident_person_university_reporter_person_unive",
                        column: x => x.reporter_person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_discipline_incident_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول حوادث السلوك والانضباط");

            migrationBuilder.CreateTable(
                name: "person_university_job",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false),
                    job_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    is_current = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_university_job", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_university_job_job_job_id",
                        column: x => x.job_id,
                        principalTable: "job",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_person_university_job_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "person_university_qualification",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العلاقة بين الشخص والجامعة"),
                    college_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكلية"),
                    qualification_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المؤهل العلمي"),
                    qualification_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الحصول على المؤهل"),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "ملاحظات"),
                    is_current = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_university_qualification", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_university_qualification_lookup_college_college_id",
                        column: x => x.college_id,
                        principalTable: "lookup_college",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_person_university_qualification_lookup_qualification_qualif",
                        column: x => x.qualification_id,
                        principalTable: "lookup_qualification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_person_university_qualification_person_university_person_un",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول مؤهلات الشخص في الجامعة");

            migrationBuilder.CreateTable(
                name: "staff_university_assignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التعيين")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الموظف بالجامعة"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    job_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "المسمى الوظيفي"),
                    department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "القسم"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البدء"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false, comment: "هل التعيين الأساسي"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staff_university_assignment", x => x.id);
                    table.ForeignKey(
                        name: "fk_staff_university_assignment_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staff_university_assignment_person_university_person_univer",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staff_university_assignment_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول تعيينات الموظفين في الجامعات");

            migrationBuilder.CreateTable(
                name: "student_guardian",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العلاقة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    guardian_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف ولي الأمر"),
                    relationship_type_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع العلاقة"),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false, comment: "هل ولي الأمر الأساسي"),
                    is_emergency_contact = table.Column<bool>(type: "boolean", nullable: false, comment: "جهة اتصال للطوارئ"),
                    can_pickup = table.Column<bool>(type: "boolean", nullable: false, comment: "يمكنه استلام الطالب"),
                    has_custody = table.Column<bool>(type: "boolean", nullable: false, comment: "لديه حق الوصاية"),
                    receives_mailing = table.Column<bool>(type: "boolean", nullable: false, comment: "يستلم المراسلات"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_guardian", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_guardian_guardian_guardian_id",
                        column: x => x.guardian_id,
                        principalTable: "guardian",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_guardian_lookup_relationship_type_relationship_type",
                        column: x => x.relationship_type_id,
                        principalTable: "lookup_relationship_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_guardian_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول علاقة الطلاب بأولياء الأمور");

            migrationBuilder.CreateTable(
                name: "transcript",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    university_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف السنة الدراسية"),
                    academic_year_title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "عنوان السنة الدراسية"),
                    academic_level = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "المستوى الأكاديمي"),
                    course_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "رمز المقرر"),
                    course_title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المقرر"),
                    letter_grade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "التقدير"),
                    grade_percent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    gpa_value = table.Column<decimal>(type: "numeric", nullable: true, comment: "قيمة المعدل"),
                    credits_attempted = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المحاولة"),
                    credits_earned = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المكتسبة"),
                    include_in_gpa = table.Column<bool>(type: "boolean", nullable: false, comment: "يحسب في المعدل"),
                    is_transfer = table.Column<bool>(type: "boolean", nullable: false, comment: "منقول"),
                    notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transcript", x => x.id);
                    table.ForeignKey(
                        name: "fk_transcript_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_transcript_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول السجل الأكاديمي (الشهادة الدراسية)");

            migrationBuilder.CreateTable(
                name: "person_university_section",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false),
                    section_id = table.Column<int>(type: "integer", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_university_section", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_university_section_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_person_university_section_person_university_person_universi",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_person_university_section_section_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quarter",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الربع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    semester_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصل الدراسي"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الربع"),
                    short_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    post_start_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ بدء الرصد"),
                    post_end_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ انتهاء الرصد"),
                    does_grades = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يحسب درجات"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quarter", x => x.id);
                    table.ForeignKey(
                        name: "fk_quarter_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الأرباع الدراسية");

            migrationBuilder.CreateTable(
                name: "student_gpa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السنة الدراسية"),
                    semester_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الفصل الدراسي"),
                    gpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل الفصلي"),
                    weighted_gpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل الموزون"),
                    cumulative_gpa = table.Column<decimal>(type: "numeric", nullable: true, comment: "المعدل التراكمي"),
                    total_score = table.Column<decimal>(type: "numeric", nullable: true),
                    total_max_score = table.Column<decimal>(type: "numeric", nullable: true),
                    semester_rank = table.Column<int>(type: "integer", nullable: true),
                    batch_rank = table.Column<int>(type: "integer", nullable: true),
                    class_rank = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب الدفعة"),
                    class_size = table.Column<int>(type: "integer", nullable: true, comment: "عدد الدفعة"),
                    credits_earned = table.Column<decimal>(type: "numeric", nullable: true, comment: "الساعات المكتسبة"),
                    calculated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "تاريخ الحساب"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_gpa", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_gpa_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_gpa_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_gpa_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_student_gpa_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المعدل التراكمي المحسوب للطلاب");

            migrationBuilder.CreateTable(
                name: "academic_level_course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    academic_level_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_level_course", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_level_course_academic_level_academic_level_id",
                        column: x => x.academic_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_academic_level_course_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_degree_devision_course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    lookup_course_degree_devision_id = table.Column<int>(type: "integer", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_degree_devision_course", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_degree_devision_course_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_degree_devision_course_lookup_course_degree_devision",
                        column: x => x.lookup_course_degree_devision_id,
                        principalTable: "lookup_course_degree_devision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "course_instructor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_instructor", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_instructor_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_instructor_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "course_prerequisite",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر"),
                    prerequisite_course_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر السابق المطلوب"),
                    is_mandatory = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المتطلب إجباري"),
                    min_grade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "الحد الأدنى للتقدير المطلوب"),
                    notes = table.Column<string>(type: "text", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_prerequisite", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_prerequisite_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_prerequisite_course_prerequisite_course_id",
                        column: x => x.prerequisite_course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول المتطلبات السابقة للمقررات");

            migrationBuilder.CreateTable(
                name: "course_semesters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    semester_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_iteration_id = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_semesters", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_semesters_academic_level_iteration_academic_level_it",
                        column: x => x.academic_level_iteration_id,
                        principalTable: "academic_level_iteration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_semesters_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_semesters_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_enrollment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_university_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_id = table.Column<int>(type: "integer", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    academic_level_iteration_id = table.Column<int>(type: "integer", nullable: true),
                    section_id = table.Column<int>(type: "integer", nullable: true),
                    is_current = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    building_id = table.Column<int>(type: "integer", nullable: true),
                    floor_id = table.Column<int>(type: "integer", nullable: true),
                    room_id = table.Column<int>(type: "integer", nullable: true),
                    battalion_id = table.Column<int>(type: "integer", nullable: true),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    platoon_id = table.Column<int>(type: "integer", nullable: true),
                    cupboard_number = table.Column<int>(type: "integer", nullable: true),
                    bed_number = table.Column<int>(type: "integer", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_enrollment", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_enrollment_academic_level_academic_level_id",
                        column: x => x.academic_level_id,
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_academic_level_iteration_academic_level_",
                        column: x => x.academic_level_iteration_id,
                        principalTable: "academic_level_iteration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_academic_year_academic_year_id",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_battalion_battalion_id",
                        column: x => x.battalion_id,
                        principalTable: "battalion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_building_building_id",
                        column: x => x.building_id,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_floor_floor_id",
                        column: x => x.floor_id,
                        principalTable: "floor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_platoon_platoon_id",
                        column: x => x.platoon_id,
                        principalTable: "platoon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_enrollment_section_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discipline_action",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الإجراء")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incident_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة"),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    action_type_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع الإجراء"),
                    action_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ الإجراء"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ البدء"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    duration_days = table.Column<int>(type: "integer", nullable: true, comment: "المدة بالأيام"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف الإجراء"),
                    issued_by_person_university_id = table.Column<int>(type: "integer", nullable: true, comment: "صدر بواسطة (علاقة الموظف بالجامعة)"),
                    parent_notified = table.Column<bool>(type: "boolean", nullable: false, comment: "تم إشعار ولي الأمر"),
                    notification_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الإشعار"),
                    status = table.Column<int>(type: "integer", nullable: false, comment: "الحالة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discipline_action", x => x.id);
                    table.ForeignKey(
                        name: "fk_discipline_action_discipline_incident_incident_id",
                        column: x => x.incident_id,
                        principalTable: "discipline_incident",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_discipline_action_lookup_discipline_action_type_action_type",
                        column: x => x.action_type_id,
                        principalTable: "lookup_discipline_action_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_discipline_action_person_university_issued_by_person_univer",
                        column: x => x.issued_by_person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_discipline_action_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الإجراءات التأديبية");

            migrationBuilder.CreateTable(
                name: "discipline_incident_student",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incident_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحادثة"),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    role = table.Column<int>(type: "integer", nullable: false, comment: "دور الطالب"),
                    notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discipline_incident_student", x => x.id);
                    table.ForeignKey(
                        name: "fk_discipline_incident_student_discipline_incident_incident_id",
                        column: x => x.incident_id,
                        principalTable: "discipline_incident",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_discipline_incident_student_person_university_person_univer",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الطلاب المشاركين في حوادث السلوك");

            migrationBuilder.CreateTable(
                name: "progress_period",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quarter_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الربع"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان الفترة"),
                    short_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "الاسم المختصر"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البداية"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ النهاية"),
                    does_grades = table.Column<bool>(type: "boolean", nullable: false, comment: "هل تحسب درجات"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_progress_period", x => x.id);
                    table.ForeignKey(
                        name: "fk_progress_period_quarter_quarter_id",
                        column: x => x.quarter_id,
                        principalTable: "quarter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول فترات التقدم والتقييم المستمر");

            migrationBuilder.CreateTable(
                name: "assignment_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف النوع")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_section_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "عنوان النوع"),
                    weight_percent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    default_points = table.Column<decimal>(type: "numeric", nullable: true, comment: "النقاط الافتراضية"),
                    sort_order = table.Column<int>(type: "integer", nullable: false, comment: "ترتيب العرض"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assignment_type", x => x.id);
                    table.ForeignKey(
                        name: "fk_assignment_type_course_semester_course_section_id",
                        column: x => x.course_section_id,
                        principalTable: "course_semesters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول أنواع التكليفات والواجبات");

            migrationBuilder.CreateTable(
                name: "course_semester_section",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_semester_id = table.Column<int>(type: "integer", nullable: false),
                    section_id = table.Column<int>(type: "integer", nullable: false),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_semester_section", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_semester_section_course_semester_course_semester_id",
                        column: x => x.course_semester_id,
                        principalTable: "course_semesters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_semester_section_section_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التكليف")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_section_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    assignment_type_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف نوع التكليف"),
                    semester_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الفصل الدراسي"),
                    quarter_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف الربع"),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "عنوان التكليف"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "وصف التكليف"),
                    assigned_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ التكليف"),
                    due_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الاستحقاق"),
                    max_points = table.Column<decimal>(type: "numeric", nullable: false, comment: "النقاط القصوى"),
                    is_extra_credit = table.Column<bool>(type: "boolean", nullable: false, comment: "هل هو درجات إضافية"),
                    is_graded = table.Column<bool>(type: "boolean", nullable: false, comment: "هل يتم تقييمه"),
                    created_by = table.Column<int>(type: "integer", nullable: true, comment: "تم الإنشاء بواسطة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assignments", x => x.id);
                    table.ForeignKey(
                        name: "fk_assignments_assignment_type_assignment_type_id",
                        column: x => x.assignment_type_id,
                        principalTable: "assignment_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_assignments_course_semester_course_section_id",
                        column: x => x.course_section_id,
                        principalTable: "course_semesters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assignments_quarter_quarter_id",
                        column: x => x.quarter_id,
                        principalTable: "quarter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_assignments_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "جدول التكليفات والواجبات الدراسية");

            migrationBuilder.CreateTable(
                name: "course_section_meeting",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الموعد")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_semester_section_id = table.Column<int>(type: "integer", nullable: false),
                    period_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفترة الزمنية"),
                    hall_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف القاعة"),
                    course_instructor_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف مدرب المقرر"),
                    meeting_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ المحاضرة"),
                    is_cancelled = table.Column<bool>(type: "boolean", nullable: false, comment: "هل المحاضرة ملغية"),
                    cancel_reason = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "سبب الإلغاء"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_section_meeting", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_section_meeting_course_instructor_course_instructor_",
                        column: x => x.course_instructor_id,
                        principalTable: "course_instructor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_section_meeting_course_semester_section_course_semes",
                        column: x => x.course_semester_section_id,
                        principalTable: "course_semester_section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_section_meeting_hall_hall_id",
                        column: x => x.hall_id,
                        principalTable: "hall",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_course_section_meeting_period_period_id",
                        column: x => x.period_id,
                        principalTable: "period",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول مواعيد انعقاد المحاضرات الفعلية");

            migrationBuilder.CreateTable(
                name: "student_course_enrollment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التسجيل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_semester_section_id = table.Column<int>(type: "integer", nullable: false),
                    person_university_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاريخ البدء"),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الانتهاء"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_course_enrollment", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_course_enrollment_course_semester_section_course_se",
                        column: x => x.course_semester_section_id,
                        principalTable: "course_semester_section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_course_enrollment_person_university_person_universi",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول تسجيل الطلاب في حصص المقررات");

            migrationBuilder.CreateTable(
                name: "assignment_grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    assignment_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف التكليف"),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الطالب بالجامعة"),
                    points_earned = table.Column<decimal>(type: "numeric", nullable: true, comment: "النقاط المكتسبة"),
                    letter_grade = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "التقدير"),
                    is_excused = table.Column<bool>(type: "boolean", nullable: false, comment: "معذور"),
                    is_incomplete = table.Column<bool>(type: "boolean", nullable: false, comment: "غير مكتمل"),
                    is_late = table.Column<bool>(type: "boolean", nullable: false, comment: "متأخر"),
                    comment = table.Column<string>(type: "text", nullable: true, comment: "تعليق"),
                    graded_by = table.Column<int>(type: "integer", nullable: true, comment: "تم التقييم بواسطة"),
                    graded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تم التقييم في"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assignment_grade", x => x.id);
                    table.ForeignKey(
                        name: "fk_assignment_grade_assignments_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assignment_grade_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول درجات التكليفات (دفتر الدرجات)");

            migrationBuilder.CreateTable(
                name: "attendance_completed",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_section_meeting_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف موعد المحاضرة"),
                    person_university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف علاقة الموظف بالجامعة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attendance_completed", x => x.id);
                    table.ForeignKey(
                        name: "fk_attendance_completed_course_section_meeting_course_section_",
                        column: x => x.course_section_meeting_id,
                        principalTable: "course_section_meeting",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attendance_completed_person_university_person_university_id",
                        column: x => x.person_university_id,
                        principalTable: "person_university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول حالة إتمام تسجيل الحضور");

            migrationBuilder.CreateTable(
                name: "attendance_period",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المقرر"),
                    student_course_enrollment_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف تسجيل الطالب في المقرر"),
                    course_section_meeting_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف موعد المحاضرة"),
                    attendance_code_id = table.Column<int>(type: "integer", nullable: true, comment: "معرّف كود الحضور"),
                    reason = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "السبب"),
                    comment = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "ملاحظة"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attendance_period", x => x.id);
                    table.ForeignKey(
                        name: "fk_attendance_period_course_section_meeting_course_section_mee",
                        column: x => x.course_section_meeting_id,
                        principalTable: "course_section_meeting",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attendance_period_lookup_attendance_code_attendance_code_id",
                        column: x => x.attendance_code_id,
                        principalTable: "lookup_attendance_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_attendance_period_student_course_enrollment_student_course_",
                        column: x => x.student_course_enrollment_id,
                        principalTable: "student_course_enrollment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول الحضور بالحصة");

            migrationBuilder.CreateTable(
                name: "final_grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    degree = table.Column<decimal>(type: "numeric", nullable: true),
                    grade_percent = table.Column<decimal>(type: "numeric", nullable: true, comment: "النسبة المئوية"),
                    gpa_value = table.Column<decimal>(type: "numeric", nullable: true, comment: "قيمة المعدل"),
                    letter_grade = table.Column<string>(type: "text", nullable: true, comment: "التقدير"),
                    student_course_enrollment_id = table.Column<int>(type: "integer", nullable: false),
                    course_semester_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف حصة المقرر"),
                    semester_id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصل الدراسي"),
                    grade_scale_item_id = table.Column<int>(type: "integer", nullable: true),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_final_grade", x => x.id);
                    table.ForeignKey(
                        name: "fk_final_grade_course_semester_course_semester_id",
                        column: x => x.course_semester_id,
                        principalTable: "course_semesters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_final_grade_grade_scale_item_grade_scale_item_id",
                        column: x => x.grade_scale_item_id,
                        principalTable: "grade_scale_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_final_grade_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_final_grade_student_course_enrollment_student_course_enroll",
                        column: x => x.student_course_enrollment_id,
                        principalTable: "student_course_enrollment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الدرجات النهائية للمقررات");

            migrationBuilder.CreateTable(
                name: "student_fitness_test_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    university_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف الجامعة"),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف العام الأكاديمي"),
                    course_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف المادة"),
                    course_section_meeting_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف المحاضرة داخل المادة"),
                    student_course_enrollment_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف تسجيل الطالب في مجموعة المادة"),
                    degree_division_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف سطر تقسيم الدرجات الخاص باختبار اللياقة"),
                    exercise_id = table.Column<int>(type: "integer", nullable: false, comment: "معرف التمرين"),
                    age_stage_id = table.Column<int>(type: "integer", nullable: true, comment: "معرف المرحلة السنية المستخدمة في التقييم"),
                    evaluation_id = table.Column<int>(type: "integer", nullable: true, comment: "معرف شريحة التقييم المرجعية (اختياري)"),
                    attempt_no = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1, comment: "رقم المحاولة لنفس التمرين في نفس المحاضرة"),
                    test_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ ووقت تنفيذ الاختبار"),
                    performed_value = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false, comment: "القيمة المنفذة في الاختبار (عدد/زمن/مسافة حسب التمرين)"),
                    achieved_degree = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true, comment: "الدرجة المستحقة من الاختبار"),
                    achieved_percentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true, comment: "النسبة المئوية المستحقة"),
                    is_absent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "هل الطالب غائب في هذا الاختبار"),
                    notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات إضافية على نتيجة الاختبار"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل السجل مفعل"),
                    insert_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    insert_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ الإنشاء"),
                    update_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ التحديث"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    delete_user_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "تاريخ الحذف")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_fitness_test_results", x => x.id);
                    table.CheckConstraint("ck_student_fitness_result_achieved_degree", "achieved_degree IS NULL OR achieved_degree >= 0");
                    table.CheckConstraint("ck_student_fitness_result_achieved_percentage", "achieved_percentage IS NULL OR (achieved_percentage >= 0 AND achieved_percentage <= 100)");
                    table.CheckConstraint("ck_student_fitness_result_attempt_no", "attempt_no > 0");
                    table.CheckConstraint("ck_student_fitness_result_performed_value", "performed_value >= 0");
                    table.ForeignKey(
                        name: "fk_student_fitness_result_academic_year",
                        column: x => x.academic_year_id,
                        principalTable: "academic_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_age_stage",
                        column: x => x.age_stage_id,
                        principalTable: "lookup_fitness_age_stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_course",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_degree_division",
                        column: x => x.degree_division_id,
                        principalTable: "lookup_course_degree_devision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_evaluation",
                        column: x => x.evaluation_id,
                        principalTable: "lookup_fitness_exercise_evaluations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_exercise",
                        column: x => x.exercise_id,
                        principalTable: "lookup_fitness_exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_meeting",
                        column: x => x.course_section_meeting_id,
                        principalTable: "course_section_meeting",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_student_enrollment",
                        column: x => x.student_course_enrollment_id,
                        principalTable: "student_course_enrollment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول تسجيل نتائج اختبارات اللياقة البدنية للطلبة على مستوى المادة والمحاضرة");

            migrationBuilder.InsertData(
                table: "course_type",
                columns: new[] { "id", "delete_date", "delete_user_code", "insert_user_code", "is_deleted", "last_update", "name", "show_in_calendar", "update_user_code" },
                values: new object[,]
                {
                    { 1, null, null, null, false, null, "مادة انضباطيه", false, null },
                    { 2, null, null, null, false, null, "مادة علميه", true, null },
                    { 3, null, null, null, false, null, "طابور", true, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_address_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "HOME", null, null, null, true, false, null, "المنزل", "Home", 1, null },
                    { 2, "WORK", null, null, null, true, false, null, "العمل", "Work", 2, null },
                    { 3, "MAIL", null, null, null, true, false, null, "المراسلات", "Mailing", 3, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_attendance_code",
                columns: new[] { "id", "code", "color_code", "deduction_points", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_default", "is_deleted", "is_presence", "last_update", "name_ar", "name_en", "short_name", "sort_order", "type", "update_user_code" },
                values: new object[,]
                {
                    { 1, "P", "#28a745", 0m, null, null, null, true, true, false, false, null, "حاضر", "Present", "ح", 1, 0, null },
                    { 2, "A", "#dc3545", 5m, null, null, null, true, false, false, false, null, "غائب", "Absent", "غ", 2, 1, null },
                    { 3, "T", "#ffc107", 1m, null, null, null, true, false, false, false, null, "متأخر", "Tardy", "م", 3, 2, null },
                    { 4, "E", "#17a2b8", 0m, null, null, null, true, false, false, false, null, "معذور", "Excused", "ع", 4, 3, null },
                    { 5, "L", "#fd7e14", 2m, null, null, null, true, false, false, false, null, "انصراف مبكر", "Early Leave", "ا", 5, 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_discipline_action_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "severity_level", "sort_order", "update_user_code" },
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
                table: "lookup_enrollment_code",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "NEW", null, null, null, false, null, "تسجيل جديد", "New Enrollment", 1, null },
                    { 3, "GRADUATED", null, null, null, false, null, "تخرج", "Graduated", 2, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_ethnicity",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "ARAB", null, null, null, true, false, null, "عربي", "Arab", 1, null },
                    { 2, "ASIAN", null, null, null, true, false, null, "آسيوي", "Asian", 2, null },
                    { 3, "AFRICAN", null, null, null, true, false, null, "أفريقي", "African", 3, null },
                    { 4, "EUROPEAN", null, null, null, true, false, null, "أوروبي", "European", 4, null },
                    { 5, "OTHER", null, null, null, true, false, null, "أخرى", "Other", 5, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_incident_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "severity_level", "sort_order", "update_user_code" },
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
                table: "lookup_language",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "ar", null, null, null, true, false, null, "العربية", "Arabic", 1, null },
                    { 2, "en", null, null, null, true, false, null, "الإنجليزية", "English", 2, null },
                    { 3, "fr", null, null, null, true, false, null, "الفرنسية", "French", 3, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_marking_period_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "FINAL", null, null, null, true, false, null, "نهائي", "Final", 1, null },
                    { 2, "MIDTERM", null, null, null, true, false, null, "نصفي", "Midterm", 2, null },
                    { 3, "QUARTER", null, null, null, true, false, null, "ربع سنوي", "Quarterly", 3, null },
                    { 4, "MONTHLY", null, null, null, true, false, null, "شهري", "Monthly", 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_military_rank",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
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
                table: "lookup_nationality",
                columns: new[] { "id", "code", "country_code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
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
                table: "lookup_phone_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "MOBILE", null, null, null, true, false, null, "جوال", "Mobile", 1, null },
                    { 2, "HOME", null, null, null, true, false, null, "منزل", "Home", 2, null },
                    { 3, "WORK", null, null, null, true, false, null, "عمل", "Work", 3, null },
                    { 4, "EMERGENCY", null, null, null, true, false, null, "طوارئ", "Emergency", 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_record_status",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "description", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "ACTIVE", null, null, "Active Record", null, true, false, null, "نشط", "Active", 1, null },
                    { 2, "INACTIVE", null, null, "Inactive Record", null, true, false, null, "غير نشط", "Inactive", 2, null },
                    { 3, "DELETED", null, null, "Soft Deleted Record", null, true, false, null, "محذوف", "Deleted", 3, null },
                    { 4, "ARCHIVED", null, null, "Archived Record", null, true, false, null, "مؤرشف", "Archived", 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_relationship_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
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
                table: "lookup_staff_category",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_academic", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "ACADEMIC", null, null, null, true, true, false, null, "هيئة تدريس", "Academic", 1, null },
                    { 2, "ADMIN", null, null, null, false, true, false, null, "اداري", "Administrative", 2, null },
                    { 3, "TECH", null, null, null, false, true, false, null, "فني", "Technician", 3, null },
                    { 4, "WORKER", null, null, null, false, true, false, null, "عامل", "Worker", 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_subject_type",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
                values: new object[,]
                {
                    { 1, "MANDATORY", null, null, null, true, false, null, "إجباري", "Mandatory", 1, null },
                    { 2, "ELECTIVE", null, null, null, true, false, null, "اختياري", "Elective", 2, null },
                    { 3, "ACTIVITY", null, null, null, true, false, null, "نشاط", "Activity", 3, null },
                    { 4, "UNIVERSITY_REQ", null, null, null, true, false, null, "متطلب جامعة", "University Requirement", 4, null }
                });

            migrationBuilder.InsertData(
                table: "lookup_weekday",
                columns: new[] { "id", "code", "delete_date", "delete_user_code", "insert_user_code", "is_active", "is_deleted", "last_update", "name_ar", "name_en", "sort_order", "update_user_code" },
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
                name: "ix_academic_calendar_academic_year_id",
                table: "academic_calendar",
                column: "academic_year_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_academic_calendar_university_id",
                table: "academic_calendar",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_calendar_detail_academic_calendar_id_academic_date",
                table: "academic_calendar_detail",
                columns: new[] { "academic_calendar_id", "academic_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_next_level_id",
                table: "academic_level",
                column: "next_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_parent_id",
                table: "academic_level",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_previous_level_id",
                table: "academic_level",
                column: "previous_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_university_id",
                table: "academic_level",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_course_academic_level_id",
                table: "academic_level_course",
                column: "academic_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_course_course_id",
                table: "academic_level_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_iteration_academic_level_id",
                table: "academic_level_iteration",
                column: "academic_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_level_iteration_academic_year_id",
                table: "academic_level_iteration",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_year_university_id",
                table: "academic_year",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignment_grade_assignment_id_person_university_id",
                table: "assignment_grade",
                columns: new[] { "assignment_id", "person_university_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_assignment_grade_person_university_id",
                table: "assignment_grade",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignment_type_course_section_id",
                table: "assignment_type",
                column: "course_section_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignments_assignment_type_id",
                table: "assignments",
                column: "assignment_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignments_course_section_id",
                table: "assignments",
                column: "course_section_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignments_quarter_id",
                table: "assignments",
                column: "quarter_id");

            migrationBuilder.CreateIndex(
                name: "ix_assignments_semester_id",
                table: "assignments",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_attendance_completed_course_section_meeting_id",
                table: "attendance_completed",
                column: "course_section_meeting_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_attendance_completed_person_university_id",
                table: "attendance_completed",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_attendance_period_attendance_code_id",
                table: "attendance_period",
                column: "attendance_code_id");

            migrationBuilder.CreateIndex(
                name: "ix_attendance_period_course_section_meeting_id",
                table: "attendance_period",
                column: "course_section_meeting_id");

            migrationBuilder.CreateIndex(
                name: "ix_attendance_period_student_course_enrollment_id_course_secti",
                table: "attendance_period",
                columns: new[] { "student_course_enrollment_id", "course_section_meeting_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_battalion_university_id_code",
                table: "battalion",
                columns: new[] { "university_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_building_university_id_code",
                table: "building",
                columns: new[] { "university_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_company_battalion_id",
                table: "company",
                column: "battalion_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_course_category_id",
                table: "course",
                column: "course_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_course_type_id",
                table: "course",
                column: "course_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_grade_scale_id",
                table: "course",
                column: "grade_scale_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_university_id_code",
                table: "course",
                columns: new[] { "university_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_course_category_university_id_code",
                table: "course_category",
                columns: new[] { "university_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_course_degree_devision_course_course_id",
                table: "course_degree_devision_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_degree_devision_course_lookup_course_degree_devision",
                table: "course_degree_devision_course",
                column: "lookup_course_degree_devision_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_instructor_course_id",
                table: "course_instructor",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_instructor_person_university_id",
                table: "course_instructor",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_prerequisite_course_id_prerequisite_course_id",
                table: "course_prerequisite",
                columns: new[] { "course_id", "prerequisite_course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_course_prerequisite_prerequisite_course_id",
                table: "course_prerequisite",
                column: "prerequisite_course_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_section_meeting_course_instructor_id",
                table: "course_section_meeting",
                column: "course_instructor_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_section_meeting_course_semester_section_id_meeting_d",
                table: "course_section_meeting",
                columns: new[] { "course_semester_section_id", "meeting_date", "period_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_course_section_meeting_hall_id",
                table: "course_section_meeting",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_section_meeting_period_id",
                table: "course_section_meeting",
                column: "period_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_semester_section_course_semester_id",
                table: "course_semester_section",
                column: "course_semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_semester_section_section_id",
                table: "course_semester_section",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_semesters_academic_level_iteration_id",
                table: "course_semesters",
                column: "academic_level_iteration_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_semesters_course_id",
                table: "course_semesters",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_semesters_semester_id",
                table: "course_semesters",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_action_action_type_id",
                table: "discipline_action",
                column: "action_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_action_incident_id",
                table: "discipline_action",
                column: "incident_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_action_issued_by_person_university_id",
                table: "discipline_action",
                column: "issued_by_person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_action_person_university_id",
                table: "discipline_action",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_academic_year_id",
                table: "discipline_incident",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_incident_type_id",
                table: "discipline_incident",
                column: "incident_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_reporter_person_university_id",
                table: "discipline_incident",
                column: "reporter_person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_university_id",
                table: "discipline_incident",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_student_incident_id_person_university_i",
                table: "discipline_incident_student",
                columns: new[] { "incident_id", "person_university_id", "role" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_discipline_incident_student_person_university_id",
                table: "discipline_incident_student",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_final_grade_course_semester_id",
                table: "final_grade",
                column: "course_semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_final_grade_grade_scale_item_id",
                table: "final_grade",
                column: "grade_scale_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_final_grade_semester_id",
                table: "final_grade",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_final_grade_student_course_enrollment_id",
                table: "final_grade",
                column: "student_course_enrollment_id");

            migrationBuilder.CreateIndex(
                name: "ix_floor_building_id",
                table: "floor",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "ix_grade_scale_academic_year_id",
                table: "grade_scale",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_grade_scale_university_id",
                table: "grade_scale",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_grade_scale_item_grade_scale_id",
                table: "grade_scale_item",
                column: "grade_scale_id");

            migrationBuilder.CreateIndex(
                name: "ix_hall_university_id",
                table: "hall",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_icons_key",
                table: "icons",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_job_university_id",
                table: "job",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_district_governate_id",
                table: "lookup_district",
                column: "governate_id");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_age_stages_code",
                table: "lookup_fitness_age_stages",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_academic_year",
                table: "lookup_fitness_exercise_evaluations",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_age_stage",
                table: "lookup_fitness_exercise_evaluations",
                column: "age_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_exercise",
                table: "lookup_fitness_exercise_evaluations",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_university",
                table: "lookup_fitness_exercise_evaluations",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_exercise_eval",
                table: "lookup_fitness_exercise_evaluations",
                columns: new[] { "university_id", "academic_year_id", "age_stage_id", "exercise_id", "degree_value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercises_degree_division",
                table: "lookup_fitness_exercises",
                column: "degree_division_id");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_exercises_degree_division_code",
                table: "lookup_fitness_exercises",
                columns: new[] { "degree_division_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_menu_item_permission_required_permissions_id",
                table: "menu_item_permission",
                column: "required_permissions_id");

            migrationBuilder.CreateIndex(
                name: "ix_menu_items_icon_id",
                table: "menu_items",
                column: "icon_id");

            migrationBuilder.CreateIndex(
                name: "ix_menu_items_key",
                table: "menu_items",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_menu_items_parent_id",
                table: "menu_items",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_period_university_id",
                table: "period",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_role_role_id",
                table: "permission_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_code",
                table: "permissions",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_person_batch_id",
                table: "person",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_blood_type_id",
                table: "person",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_district_id",
                table: "person",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_governate_id",
                table: "person",
                column: "governate_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_military_rank_id",
                table: "person",
                column: "military_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_national_id_unique",
                table: "person",
                column: "national_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_person_nationality_id",
                table: "person",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_religion_id",
                table: "person",
                column: "religion_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_weapon_id",
                table: "person",
                column: "weapon_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_person_type_unique",
                table: "person_university",
                columns: new[] { "person_id", "university_id", "person_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_person_university_university_id",
                table: "person_university",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_job_job_id",
                table: "person_university_job",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_job_person_university_id",
                table: "person_university_job",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_qualification_college_id",
                table: "person_university_qualification",
                column: "college_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_qualification_person_university_id_colleg",
                table: "person_university_qualification",
                columns: new[] { "person_university_id", "college_id", "qualification_id" });

            migrationBuilder.CreateIndex(
                name: "ix_person_university_qualification_qualification_id",
                table: "person_university_qualification",
                column: "qualification_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_section_academic_year_id",
                table: "person_university_section",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_section_person_university_id",
                table: "person_university_section",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_person_university_section_section_id",
                table: "person_university_section",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "ix_platoon_company_id",
                table: "platoon",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_progress_period_quarter_id",
                table: "progress_period",
                column: "quarter_id");

            migrationBuilder.CreateIndex(
                name: "ix_quarter_semester_id",
                table: "quarter",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_refresh_tokens_token",
                table: "refresh_tokens",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_report_columns_report_id",
                table: "report_columns",
                column: "report_id");

            migrationBuilder.CreateIndex(
                name: "ix_report_parameters_report_id",
                table: "report_parameters",
                column: "report_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_user_user_id",
                table: "role_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_room_floor_id",
                table: "room",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "ix_section_academic_level_id",
                table: "section",
                column: "academic_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_section_academic_level_iteration_id",
                table: "section",
                column: "academic_level_iteration_id");

            migrationBuilder.CreateIndex(
                name: "ix_section_academic_year_id",
                table: "section",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_section_university_id",
                table: "section",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_semester_academic_level_id",
                table: "semester",
                column: "academic_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_semester_academic_level_iteration_id",
                table: "semester",
                column: "academic_level_iteration_id");

            migrationBuilder.CreateIndex(
                name: "ix_semester_academic_year_id",
                table: "semester",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_staff_nationality_id",
                table: "staff",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "ix_staff_staff_category_id",
                table: "staff",
                column: "staff_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_staff_university_assignment_academic_year_id",
                table: "staff_university_assignment",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_staff_university_assignment_person_university_id_university",
                table: "staff_university_assignment",
                columns: new[] { "person_university_id", "university_id", "academic_year_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_staff_university_assignment_university_id",
                table: "staff_university_assignment",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_course_enrollment_course_semester_section_id",
                table: "student_course_enrollment",
                column: "course_semester_section_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_course_enrollment_person_university_id_course_semes",
                table: "student_course_enrollment",
                columns: new[] { "person_university_id", "course_semester_section_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_academic_level_id",
                table: "student_enrollment",
                column: "academic_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_academic_level_iteration_id",
                table: "student_enrollment",
                column: "academic_level_iteration_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_academic_year_id",
                table: "student_enrollment",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_battalion_id",
                table: "student_enrollment",
                column: "battalion_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_building_id",
                table: "student_enrollment",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_company_id",
                table: "student_enrollment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_floor_id",
                table: "student_enrollment",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_person_university_id",
                table: "student_enrollment",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_platoon_id",
                table: "student_enrollment",
                column: "platoon_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_room_id",
                table: "student_enrollment",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_enrollment_section_id",
                table: "student_enrollment",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_academic_year",
                table: "student_fitness_test_results",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_course",
                table: "student_fitness_test_results",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_exercise",
                table: "student_fitness_test_results",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_meeting",
                table: "student_fitness_test_results",
                column: "course_section_meeting_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_student_enrollment",
                table: "student_fitness_test_results",
                column: "student_course_enrollment_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_university",
                table: "student_fitness_test_results",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_test_results_age_stage_id",
                table: "student_fitness_test_results",
                column: "age_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_test_results_degree_division_id",
                table: "student_fitness_test_results",
                column: "degree_division_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_test_results_evaluation_id",
                table: "student_fitness_test_results",
                column: "evaluation_id");

            migrationBuilder.CreateIndex(
                name: "uq_student_fitness_result_attempt",
                table: "student_fitness_test_results",
                columns: new[] { "student_course_enrollment_id", "course_section_meeting_id", "exercise_id", "attempt_no" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_gpa_academic_year_id",
                table: "student_gpa",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_gpa_person_university_id_academic_year_id_semester_",
                table: "student_gpa",
                columns: new[] { "person_university_id", "academic_year_id", "semester_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_gpa_semester_id",
                table: "student_gpa",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_gpa_university_id",
                table: "student_gpa",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_guardian_guardian_id",
                table: "student_guardian",
                column: "guardian_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_guardian_person_university_id_guardian_id_relations",
                table: "student_guardian",
                columns: new[] { "person_university_id", "guardian_id", "relationship_type_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_guardian_relationship_type_id",
                table: "student_guardian",
                column: "relationship_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_academic_year_id",
                table: "subject",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_subject_type_id",
                table: "subject",
                column: "subject_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_university_id_academic_year_id_code",
                table: "subject",
                columns: new[] { "university_id", "academic_year_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_transcript_person_university_id",
                table: "transcript",
                column: "person_university_id");

            migrationBuilder.CreateIndex(
                name: "ix_transcript_university_id",
                table: "transcript",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_university_parent_id",
                table: "university",
                column: "parent_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academic_calendar_detail");

            migrationBuilder.DropTable(
                name: "academic_level_course");

            migrationBuilder.DropTable(
                name: "assignment_grade");

            migrationBuilder.DropTable(
                name: "attendance_completed");

            migrationBuilder.DropTable(
                name: "attendance_period");

            migrationBuilder.DropTable(
                name: "audit_log");

            migrationBuilder.DropTable(
                name: "course_degree_devision_course");

            migrationBuilder.DropTable(
                name: "course_prerequisite");

            migrationBuilder.DropTable(
                name: "discipline_action");

            migrationBuilder.DropTable(
                name: "discipline_incident_student");

            migrationBuilder.DropTable(
                name: "final_grade");

            migrationBuilder.DropTable(
                name: "lookup_address_type");

            migrationBuilder.DropTable(
                name: "lookup_attachment_type");

            migrationBuilder.DropTable(
                name: "lookup_enrollment_code");

            migrationBuilder.DropTable(
                name: "lookup_ethnicity");

            migrationBuilder.DropTable(
                name: "lookup_language");

            migrationBuilder.DropTable(
                name: "lookup_marking_period_type");

            migrationBuilder.DropTable(
                name: "lookup_phone_type");

            migrationBuilder.DropTable(
                name: "lookup_record_status");

            migrationBuilder.DropTable(
                name: "lookup_weekday");

            migrationBuilder.DropTable(
                name: "menu_item_permission");

            migrationBuilder.DropTable(
                name: "permission_role");

            migrationBuilder.DropTable(
                name: "person_university_job");

            migrationBuilder.DropTable(
                name: "person_university_qualification");

            migrationBuilder.DropTable(
                name: "person_university_section");

            migrationBuilder.DropTable(
                name: "progress_period");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "report_columns");

            migrationBuilder.DropTable(
                name: "report_parameters");

            migrationBuilder.DropTable(
                name: "role_user");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "staff_university_assignment");

            migrationBuilder.DropTable(
                name: "student_enrollment");

            migrationBuilder.DropTable(
                name: "student_fitness_test_results");

            migrationBuilder.DropTable(
                name: "student_gpa");

            migrationBuilder.DropTable(
                name: "student_guardian");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "transcript");

            migrationBuilder.DropTable(
                name: "academic_calendar");

            migrationBuilder.DropTable(
                name: "assignments");

            migrationBuilder.DropTable(
                name: "lookup_attendance_code");

            migrationBuilder.DropTable(
                name: "lookup_discipline_action_type");

            migrationBuilder.DropTable(
                name: "discipline_incident");

            migrationBuilder.DropTable(
                name: "grade_scale_item");

            migrationBuilder.DropTable(
                name: "menu_items");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "lookup_college");

            migrationBuilder.DropTable(
                name: "lookup_qualification");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "lookup_staff_category");

            migrationBuilder.DropTable(
                name: "platoon");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "lookup_fitness_exercise_evaluations");

            migrationBuilder.DropTable(
                name: "course_section_meeting");

            migrationBuilder.DropTable(
                name: "student_course_enrollment");

            migrationBuilder.DropTable(
                name: "guardian");

            migrationBuilder.DropTable(
                name: "lookup_relationship_type");

            migrationBuilder.DropTable(
                name: "lookup_subject_type");

            migrationBuilder.DropTable(
                name: "assignment_type");

            migrationBuilder.DropTable(
                name: "quarter");

            migrationBuilder.DropTable(
                name: "lookup_incident_type");

            migrationBuilder.DropTable(
                name: "icons");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "floor");

            migrationBuilder.DropTable(
                name: "lookup_fitness_age_stages");

            migrationBuilder.DropTable(
                name: "lookup_fitness_exercises");

            migrationBuilder.DropTable(
                name: "course_instructor");

            migrationBuilder.DropTable(
                name: "hall");

            migrationBuilder.DropTable(
                name: "period");

            migrationBuilder.DropTable(
                name: "course_semester_section");

            migrationBuilder.DropTable(
                name: "battalion");

            migrationBuilder.DropTable(
                name: "building");

            migrationBuilder.DropTable(
                name: "lookup_course_degree_devision");

            migrationBuilder.DropTable(
                name: "person_university");

            migrationBuilder.DropTable(
                name: "course_semesters");

            migrationBuilder.DropTable(
                name: "section");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "semester");

            migrationBuilder.DropTable(
                name: "blood_type");

            migrationBuilder.DropTable(
                name: "lookup_batch");

            migrationBuilder.DropTable(
                name: "lookup_district");

            migrationBuilder.DropTable(
                name: "lookup_military_rank");

            migrationBuilder.DropTable(
                name: "lookup_nationality");

            migrationBuilder.DropTable(
                name: "lookup_religion");

            migrationBuilder.DropTable(
                name: "lookup_weapon");

            migrationBuilder.DropTable(
                name: "course_category");

            migrationBuilder.DropTable(
                name: "course_type");

            migrationBuilder.DropTable(
                name: "grade_scale");

            migrationBuilder.DropTable(
                name: "academic_level_iteration");

            migrationBuilder.DropTable(
                name: "lookup_governate");

            migrationBuilder.DropTable(
                name: "academic_level");

            migrationBuilder.DropTable(
                name: "academic_year");

            migrationBuilder.DropTable(
                name: "university");
        }
    }
}
