using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_University_UniversityId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_UniversityId_Code",
                table: "Room");



            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "GradeScale");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "CourseSectionMeeting",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSectionMeeting_RoomId",
                table: "CourseSectionMeeting",
                newName: "IX_CourseSectionMeeting_HallId");

            migrationBuilder.AlterTable(
                name: "Room",
                oldComment: "جدول القاعات والغرف");

            migrationBuilder.AddColumn<int>(
                name: "BattalionId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BedNumber",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CupboardNumber",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatoonId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Room",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                comment: "اسم العنبر",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldComment: "اسم القاعة");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Room",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                comment: "رمز العنبر",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldComment: "رمز القاعة");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Room",
                type: "integer",
                nullable: false,
                comment: "معرّف العنبر",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف القاعة")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Room",
                type: "integer",
                nullable: true,
                comment: "معرّف الطابق");

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

            migrationBuilder.CreateTable(
                name: "Battalion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكتيبة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الكتيبة"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الكتيبة بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الكتيبة بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الكتيبة"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
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
                    table.PrimaryKey("PK_Battalion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battalion_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الكتائب العسكرية");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المبنى")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز المبنى"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المبنى بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم المبنى بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف المبنى"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "هل نشط"),
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
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول المباني");

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف القاعة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "رمز القاعة"),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "اسم القاعة"),
                    UniversityId = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true, comment: "السعة"),
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
                    table.PrimaryKey("PK_Hall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hall_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "جدول القاعات والغرف");

            // Custom Data Migration: Copy Halls from Room table to Hall table
            migrationBuilder.Sql(@"
                INSERT INTO ""Hall"" (""Id"", ""Code"", ""Title"", ""UniversityId"", ""Capacity"", ""IsActive"", ""InsertDate"", ""IsDeleted"")
                SELECT ""Id"", ""Code"", ""Title"", ""UniversityId"", ""Capacity"", ""IsActive"", ""InsertDate"", ""IsDeleted""
                FROM ""Room""
                WHERE ""UniversityId"" IS NOT NULL;

                -- Delete any CourseSectionMeeting that references a Room that was not copied to Hall (e.g. invalid UniversityId)
                DELETE FROM ""CourseSectionMeeting"" 
                WHERE ""HallId"" NOT IN (SELECT ""Id"" FROM ""Hall"");
            ");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Room");

            migrationBuilder.CreateTable(
                name: "lookup_fitness_age_stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "كود المرحلة السنية (فريد)"),
                    TitleAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم المرحلة السنية بالعربية"),
                    TitleEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم المرحلة السنية بالإنجليزية"),
                    MinAge = table.Column<short>(type: "smallint", nullable: false, comment: "العمر الأدنى للمرحلة السنية"),
                    MaxAge = table.Column<short>(type: "smallint", nullable: false, comment: "العمر الأقصى للمرحلة السنية"),
                    SortOrder = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل المرحلة السنية مفعلة"),
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
                    table.PrimaryKey("PK_lookup_fitness_age_stages", x => x.Id);
                    table.CheckConstraint("ck_lookup_fitness_age_stages_max_age", "\"MaxAge\" >= \"MinAge\"");
                    table.CheckConstraint("ck_lookup_fitness_age_stages_min_age", "\"MinAge\" >= 0");
                },
                comment: "جدول تعريف المراحل السنية لاختبارات اللياقة البدنية");

            migrationBuilder.CreateTable(
                name: "LookupCourseDegreeDevision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكلية")
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
                    table.PrimaryKey("PK_LookupCourseDegreeDevision", x => x.Id);
                },
                comment: "جدول الكليات");

            migrationBuilder.CreateTable(
                name: "PersonUniversityQualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السجل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonUniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف العلاقة بين الشخص والجامعة"),
                    CollegeId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكلية"),
                    QualificationId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المؤهل العلمي"),
                    QualificationDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاريخ الحصول على المؤهل"),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "ملاحظات"),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل نشط"),
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
                    table.PrimaryKey("PK_PersonUniversityQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonUniversityQualification_LookupCollege_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "LookupCollege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonUniversityQualification_LookupQualification_Qualifica~",
                        column: x => x.QualificationId,
                        principalTable: "LookupQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonUniversityQualification_PersonUniversity_PersonUniver~",
                        column: x => x.PersonUniversityId,
                        principalTable: "PersonUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول مؤهلات الشخص في الجامعة");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السرية")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز السرية"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم السرية بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم السرية بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف السرية"),
                    BattalionId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الكتيبة"),
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
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Battalion_BattalionId",
                        column: x => x.BattalionId,
                        principalTable: "Battalion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول السرايا العسكرية");

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الطابق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الطابق"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الطابق بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الطابق بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الطابق"),
                    BuildingId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المبنى"),
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
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الطوابق");

            migrationBuilder.CreateTable(
                name: "CourseDegreeDevisionCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    LookupCourseDegreeDevisionId = table.Column<int>(type: "integer", nullable: false),
                    Percentage = table.Column<decimal>(type: "numeric", nullable: true),
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
                    table.PrimaryKey("PK_CourseDegreeDevisionCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDegreeDevisionCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseDegreeDevisionCourse_LookupCourseDegreeDevision_Looku~",
                        column: x => x.LookupCourseDegreeDevisionId,
                        principalTable: "LookupCourseDegreeDevision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lookup_fitness_exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DegreeDivisionId = table.Column<int>(type: "integer", nullable: false, comment: "معرف سطر تقسيم الدرجات (اختبار اللياقة) من جدول degree-divisions"),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "كود التمرين (فريد داخل نفس سطر تقسيم الدرجات)"),
                    TitleAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم التمرين بالعربية"),
                    TitleEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم التمرين بالإنجليزية"),
                    UnitNameAr = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "عدة", comment: "وحدة القياس بالعربية (مثال: عدة/ثانية/متر)"),
                    UnitNameEn = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "وحدة القياس بالإنجليزية"),
                    MaxDegree = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true, comment: "الدرجة القصوى للتمرين"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "وصف إضافي للتمرين"),
                    SortOrder = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل التمرين مفعل"),
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
                    table.PrimaryKey("PK_lookup_fitness_exercises", x => x.Id);
                    table.CheckConstraint("ck_lookup_fitness_exercises_max_degree", "\"MaxDegree\" IS NULL OR \"MaxDegree\" >= 0");
                    table.ForeignKey(
                        name: "fk_lookup_fitness_exercises_degree_division",
                        column: x => x.DegreeDivisionId,
                        principalTable: "LookupCourseDegreeDevision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول تعريف تمارين اختبار اللياقة البدنية");

            migrationBuilder.CreateTable(
                name: "Platoon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الفصيل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "رمز الفصيل"),
                    NameAr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "اسم الفصيل بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "اسم الفصيل بالإنجليزية"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "وصف الفصيل"),
                    CompanyId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السرية"),
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
                    table.PrimaryKey("PK_Platoon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platoon_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الفصائل العسكرية");

            migrationBuilder.CreateTable(
                name: "lookup_fitness_exercise_evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرف العام الأكاديمي"),
                    AgeStageId = table.Column<int>(type: "integer", nullable: false, comment: "معرف المرحلة السنية"),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false, comment: "معرف التمرين"),
                    DegreeValue = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false, comment: "الدرجة أو عدد العدات المقابل للتقييم"),
                    PercentageValue = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, comment: "النسبة المئوية المقابلة للدرجة"),
                    SortOrder = table.Column<int>(type: "integer", nullable: true, comment: "ترتيب العرض داخل التمرين"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل التقييم مفعل"),
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
                    table.PrimaryKey("PK_lookup_fitness_exercise_evaluations", x => x.Id);
                    table.CheckConstraint("ck_lookup_fitness_exercise_eval_degree", "\"DegreeValue\" >= 0");
                    table.CheckConstraint("ck_lookup_fitness_exercise_eval_percentage", "\"PercentageValue\" >= 0 AND \"PercentageValue\" <= 100");
                    table.ForeignKey(
                        name: "fk_fitness_eval_academic_year",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_age_stage",
                        column: x => x.AgeStageId,
                        principalTable: "lookup_fitness_age_stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_exercise",
                        column: x => x.ExerciseId,
                        principalTable: "lookup_fitness_exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fitness_eval_university",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول ربط تقييم الدرجة/العدة لكل تمرين حسب المرحلة السنية بالنسبة المئوية");

            migrationBuilder.CreateTable(
                name: "student_fitness_test_results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "المعرف الأساسي")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityId = table.Column<int>(type: "integer", nullable: false, comment: "معرف الجامعة"),
                    AcademicYearId = table.Column<int>(type: "integer", nullable: false, comment: "معرف العام الأكاديمي"),
                    CourseId = table.Column<int>(type: "integer", nullable: false, comment: "معرف المادة"),
                    CourseSectionMeetingId = table.Column<int>(type: "integer", nullable: false, comment: "معرف المحاضرة داخل المادة"),
                    StudentCourseEnrollmentId = table.Column<int>(type: "integer", nullable: false, comment: "معرف تسجيل الطالب في مجموعة المادة"),
                    DegreeDivisionId = table.Column<int>(type: "integer", nullable: false, comment: "معرف سطر تقسيم الدرجات الخاص باختبار اللياقة"),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false, comment: "معرف التمرين"),
                    AgeStageId = table.Column<int>(type: "integer", nullable: true, comment: "معرف المرحلة السنية المستخدمة في التقييم"),
                    EvaluationId = table.Column<int>(type: "integer", nullable: true, comment: "معرف شريحة التقييم المرجعية (اختياري)"),
                    AttemptNo = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1, comment: "رقم المحاولة لنفس التمرين في نفس المحاضرة"),
                    TestDatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "تاريخ ووقت تنفيذ الاختبار"),
                    PerformedValue = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false, comment: "القيمة المنفذة في الاختبار (عدد/زمن/مسافة حسب التمرين)"),
                    AchievedDegree = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true, comment: "الدرجة المستحقة من الاختبار"),
                    AchievedPercentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true, comment: "النسبة المئوية المستحقة"),
                    IsAbsent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "هل الطالب غائب في هذا الاختبار"),
                    Notes = table.Column<string>(type: "text", nullable: true, comment: "ملاحظات إضافية على نتيجة الاختبار"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "هل السجل مفعل"),
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
                    table.PrimaryKey("PK_student_fitness_test_results", x => x.Id);
                    table.CheckConstraint("ck_student_fitness_result_achieved_degree", "\"AchievedDegree\" IS NULL OR \"AchievedDegree\" >= 0");
                    table.CheckConstraint("ck_student_fitness_result_achieved_percentage", "\"AchievedPercentage\" IS NULL OR (\"AchievedPercentage\" >= 0 AND \"AchievedPercentage\" <= 100)");
                    table.CheckConstraint("ck_student_fitness_result_attempt_no", "\"AttemptNo\" > 0");
                    table.CheckConstraint("ck_student_fitness_result_performed_value", "\"PerformedValue\" >= 0");
                    table.ForeignKey(
                        name: "fk_student_fitness_result_academic_year",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_age_stage",
                        column: x => x.AgeStageId,
                        principalTable: "lookup_fitness_age_stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_degree_division",
                        column: x => x.DegreeDivisionId,
                        principalTable: "LookupCourseDegreeDevision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_evaluation",
                        column: x => x.EvaluationId,
                        principalTable: "lookup_fitness_exercise_evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_exercise",
                        column: x => x.ExerciseId,
                        principalTable: "lookup_fitness_exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_meeting",
                        column: x => x.CourseSectionMeetingId,
                        principalTable: "CourseSectionMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_student_enrollment",
                        column: x => x.StudentCourseEnrollmentId,
                        principalTable: "StudentCourseEnrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_fitness_result_university",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول تسجيل نتائج اختبارات اللياقة البدنية للطلبة على مستوى المادة والمحاضرة");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_BattalionId",
                table: "StudentEnrollment",
                column: "BattalionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_BuildingId",
                table: "StudentEnrollment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_CompanyId",
                table: "StudentEnrollment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_FloorId",
                table: "StudentEnrollment",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_PlatoonId",
                table: "StudentEnrollment",
                column: "PlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_RoomId",
                table: "StudentEnrollment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorId",
                table: "Room",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Battalion_UniversityId_Code",
                table: "Battalion",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Building_UniversityId_Code",
                table: "Building",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_BattalionId",
                table: "Company",
                column: "BattalionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDegreeDevisionCourse_CourseId",
                table: "CourseDegreeDevisionCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDegreeDevisionCourse_LookupCourseDegreeDevisionId",
                table: "CourseDegreeDevisionCourse",
                column: "LookupCourseDegreeDevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Hall_UniversityId",
                table: "Hall",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_age_stages_code",
                table: "lookup_fitness_age_stages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_academic_year",
                table: "lookup_fitness_exercise_evaluations",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_age_stage",
                table: "lookup_fitness_exercise_evaluations",
                column: "AgeStageId");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_exercise",
                table: "lookup_fitness_exercise_evaluations",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercise_eval_university",
                table: "lookup_fitness_exercise_evaluations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_exercise_eval",
                table: "lookup_fitness_exercise_evaluations",
                columns: new[] { "UniversityId", "AcademicYearId", "AgeStageId", "ExerciseId", "DegreeValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lookup_fitness_exercises_degree_division",
                table: "lookup_fitness_exercises",
                column: "DegreeDivisionId");

            migrationBuilder.CreateIndex(
                name: "uq_lookup_fitness_exercises_degree_division_code",
                table: "lookup_fitness_exercises",
                columns: new[] { "DegreeDivisionId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversityQualification_CollegeId",
                table: "PersonUniversityQualification",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversityQualification_PersonUniversityId_CollegeId_~",
                table: "PersonUniversityQualification",
                columns: new[] { "PersonUniversityId", "CollegeId", "QualificationId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversityQualification_QualificationId",
                table: "PersonUniversityQualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Platoon_CompanyId",
                table: "Platoon",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_academic_year",
                table: "student_fitness_test_results",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_course",
                table: "student_fitness_test_results",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_exercise",
                table: "student_fitness_test_results",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_meeting",
                table: "student_fitness_test_results",
                column: "CourseSectionMeetingId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_student_enrollment",
                table: "student_fitness_test_results",
                column: "StudentCourseEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "ix_student_fitness_result_university",
                table: "student_fitness_test_results",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_student_fitness_test_results_AgeStageId",
                table: "student_fitness_test_results",
                column: "AgeStageId");

            migrationBuilder.CreateIndex(
                name: "IX_student_fitness_test_results_DegreeDivisionId",
                table: "student_fitness_test_results",
                column: "DegreeDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_student_fitness_test_results_EvaluationId",
                table: "student_fitness_test_results",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "uq_student_fitness_result_attempt",
                table: "student_fitness_test_results",
                columns: new[] { "StudentCourseEnrollmentId", "CourseSectionMeetingId", "ExerciseId", "AttemptNo" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course",
                column: "GradeScaleId",
                principalTable: "GradeScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Hall_HallId",
                table: "CourseSectionMeeting",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Battalion_BattalionId",
                table: "StudentEnrollment",
                column: "BattalionId",
                principalTable: "Battalion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Building_BuildingId",
                table: "StudentEnrollment",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Company_CompanyId",
                table: "StudentEnrollment",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Floor_FloorId",
                table: "StudentEnrollment",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Platoon_PlatoonId",
                table: "StudentEnrollment",
                column: "PlatoonId",
                principalTable: "Platoon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_Room_RoomId",
                table: "StudentEnrollment",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Hall_HallId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Battalion_BattalionId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Building_BuildingId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Company_CompanyId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Floor_FloorId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Platoon_PlatoonId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_Room_RoomId",
                table: "StudentEnrollment");

            migrationBuilder.DropTable(
                name: "CourseDegreeDevisionCourse");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "PersonUniversityQualification");

            migrationBuilder.DropTable(
                name: "Platoon");

            migrationBuilder.DropTable(
                name: "student_fitness_test_results");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "lookup_fitness_exercise_evaluations");

            migrationBuilder.DropTable(
                name: "Battalion");

            migrationBuilder.DropTable(
                name: "lookup_fitness_age_stages");

            migrationBuilder.DropTable(
                name: "lookup_fitness_exercises");

            migrationBuilder.DropTable(
                name: "LookupCourseDegreeDevision");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_BattalionId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_BuildingId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_CompanyId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_FloorId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_PlatoonId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_RoomId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_Room_FloorId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BattalionId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "BedNumber",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "CupboardNumber",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "PlatoonId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "CourseSectionMeeting",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSectionMeeting_HallId",
                table: "CourseSectionMeeting",
                newName: "IX_CourseSectionMeeting_RoomId");

            migrationBuilder.AlterTable(
                name: "Room",
                comment: "جدول القاعات والغرف");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Room",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                comment: "اسم القاعة",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldComment: "اسم العنبر");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Room",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                comment: "رمز القاعة",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldComment: "رمز العنبر");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Room",
                type: "integer",
                nullable: false,
                comment: "معرّف القاعة",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف العنبر")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Room",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                comment: "المبنى");

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Room",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                comment: "الطابق");

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Room",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الجامعة");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxValue",
                table: "GradeScale",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.CreateIndex(
                name: "IX_Room_UniversityId_Code",
                table: "Room",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course",
                column: "GradeScaleId",
                principalTable: "GradeScale",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_University_UniversityId",
                table: "Room",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
