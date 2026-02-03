using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StartBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lmsEnitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentGrade_Student_StudentId",
                table: "AssignmentGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_CourseSemester_CourseSectionId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentType_CourseSemester_CourseSectionId",
                table: "AssignmentType");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceCompleted_Staff_StaffId",
                table: "AttendanceCompleted");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendancePeriod_Student_StudentId",
                table: "AttendancePeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_CourseSemester_CourseSectionId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Period_PeriodId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemester_AcademicLevelIteration_AcademicLevelIteratio~",
                table: "CourseSemester");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemester_Course_CourseId",
                table: "CourseSemester");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemester_Semester_SemesterId",
                table: "CourseSemester");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterSection_CourseSemester_CourseSemesterId",
                table: "CourseSemesterSection");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineAction_Staff_IssuedBy",
                table: "DisciplineAction");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineAction_Student_StudentId",
                table: "DisciplineAction");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineIncident_Staff_ReporterId",
                table: "DisciplineIncident");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineIncidentStudent_Student_StudentId",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_CourseSemester_CourseSectionId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_Quarter_QuarterId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_Semester_SemesterId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_Student_StudentId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffUniversityAssignment_Staff_StaffId",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEnrollment_CourseSemester_CourseSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEnrollment_Student_StudentId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_LookupEnrollmentCode_LookupEnrollmentCode~",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGpa_Student_StudentId",
                table: "StudentGpa");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGuardian_Student_StudentId",
                table: "StudentGuardian");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcript_Student_StudentId",
                table: "Transcript");

            migrationBuilder.DropIndex(
                name: "IX_Transcript_StudentId",
                table: "Transcript");

            migrationBuilder.DropIndex(
                name: "IX_StudentGuardian_StudentId_GuardianId_RelationshipTypeId",
                table: "StudentGuardian");

            migrationBuilder.DropIndex(
                name: "IX_StudentGpa_StudentId_AcademicYearId_SemesterId",
                table: "StudentGpa");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_CourseSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_StudentId_CourseSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StaffUniversityAssignment_StaffId_UniversityId_AcademicYear~",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropIndex(
                name: "IX_FinalGrade_QuarterId",
                table: "FinalGrade");

            migrationBuilder.DropIndex(
                name: "IX_FinalGrade_StudentId",
                table: "FinalGrade");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncidentStudent_IncidentId_StudentId_Role",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncidentStudent_StudentId",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncident_ReporterId",
                table: "DisciplineIncident");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineAction_IssuedBy",
                table: "DisciplineAction");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineAction_StudentId",
                table: "DisciplineAction");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionMeeting_CourseSectionId_MeetingDate_PeriodId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropIndex(
                name: "IX_AttendancePeriod_StudentId_CourseSectionMeetingId",
                table: "AttendancePeriod");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceCompleted_StaffId",
                table: "AttendanceCompleted");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGrade_AssignmentId_StudentId",
                table: "AssignmentGrade");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGrade_StudentId",
                table: "AssignmentGrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSemester",
                table: "CourseSemester");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Transcript");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentGuardian");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "DropDate",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "IsDropped",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "PersonUniversity");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "PersonUniversity");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "CreditsAttempted",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "CreditsEarned",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "IncludeInGpa",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "IsFinal",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "QuarterId",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "DisciplineIncident");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "DisciplineAction");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "DisciplineAction");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "RecordedBy",
                table: "AttendancePeriod");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AttendancePeriod");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "AttendanceCompleted");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AssignmentGrade");

            migrationBuilder.RenameTable(
                name: "CourseSemester",
                newName: "course_semesters");

            migrationBuilder.RenameColumn(
                name: "LookupEnrollmentCodeId",
                table: "StudentEnrollment",
                newName: "AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollment_LookupEnrollmentCodeId",
                table: "StudentEnrollment",
                newName: "IX_StudentEnrollment_AcademicYearId");

            migrationBuilder.RenameColumn(
                name: "CourseSectionId",
                table: "FinalGrade",
                newName: "CourseSemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_FinalGrade_CourseSectionId",
                table: "FinalGrade",
                newName: "IX_FinalGrade_CourseSemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemester_SemesterId",
                table: "course_semesters",
                newName: "IX_course_semesters_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemester_CourseId",
                table: "course_semesters",
                newName: "IX_course_semesters_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemester_AcademicLevelIterationId",
                table: "course_semesters",
                newName: "IX_course_semesters_AcademicLevelIterationId");

            migrationBuilder.AlterTable(
                name: "StudentEnrollment",
                oldComment: "جدول سجل قيد الطلاب وتاريخ التسجيل");

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "Transcript",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "StudentGuardian",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "BatchRank",
                table: "StudentGpa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "StudentGpa",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "SemesterRank",
                table: "StudentGpa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMaxScore",
                table: "StudentGpa",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalScore",
                table: "StudentGpa",
                type: "numeric",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "معرّف الشعبة");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentEnrollment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف القيد")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AcademicLevelId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicLevelIterationId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "StudentEnrollment",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CourseSemesterSectionId",
                table: "StudentCourseEnrollment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "StudentCourseEnrollment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "StaffUniversityAssignment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الموظف بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف الدفعة");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف فصيلة الدم");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف الحي/المنطقة");

            migrationBuilder.AddColumn<int>(
                name: "GovernateId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف المحافظة");

            migrationBuilder.AddColumn<bool>(
                name: "IsMilitary",
                table: "Person",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "هل عسكري");

            migrationBuilder.AddColumn<string>(
                name: "MilitaryNumber",
                table: "Person",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                comment: "الرقم العسكري");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف الجنسية");

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف الدين");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Person",
                type: "integer",
                nullable: true,
                comment: "معرّف السلاح");

            migrationBuilder.AddColumn<int>(
                name: "PeriodType",
                table: "Period",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                comment: "نوع الفترة");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "FinalGrade",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الفصل الدراسي",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "معرّف الفصل الدراسي");

            migrationBuilder.AlterColumn<string>(
                name: "LetterGrade",
                table: "FinalGrade",
                type: "text",
                nullable: true,
                comment: "التقدير",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "التقدير");

            migrationBuilder.AddColumn<decimal>(
                name: "Degree",
                table: "FinalGrade",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeScaleItemId",
                table: "FinalGrade",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseEnrollmentId",
                table: "FinalGrade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "DisciplineIncidentStudent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "ReporterPersonUniversityId",
                table: "DisciplineIncident",
                type: "integer",
                nullable: true,
                comment: "المبلغ (علاقة الموظف بالجامعة)");

            migrationBuilder.AddColumn<int>(
                name: "IssuedByPersonUniversityId",
                table: "DisciplineAction",
                type: "integer",
                nullable: true,
                comment: "صدر بواسطة (علاقة الموظف بالجامعة)");

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "DisciplineAction",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "CourseSectionMeeting",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف القاعة",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "معرّف القاعة");

            migrationBuilder.AddColumn<int>(
                name: "CourseInstructorId",
                table: "CourseSectionMeeting",
                type: "integer",
                nullable: true,
                comment: "معرّف مدرب المقرر");

            migrationBuilder.AddColumn<int>(
                name: "CourseSemesterSectionId",
                table: "CourseSectionMeeting",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseTypeId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CreditHours",
                table: "Course",
                type: "numeric",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GradeScaleId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInGpa",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "يحسب في المعدل - يتم تضمينه في حساب تقدير الطالب");

            migrationBuilder.AddColumn<bool>(
                name: "IsGraduationRequired",
                table: "Course",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsYearFail",
                table: "Course",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumDegree",
                table: "Course",
                type: "numeric",
                nullable: true,
                defaultValue: 0m,
                comment: "النهاية العظمى للدرجة");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BloodType",
                type: "integer",
                nullable: false,
                comment: "معرّف الدفعة",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BloodType",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "الرمز");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BloodType",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "هل نشطة");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "BloodType",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "الاسم بالعربية");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "BloodType",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "الاسم بالإنجليزية");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BloodType",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ترتيب العرض");

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

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AttendancePeriod",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف المقرر");

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseEnrollmentId",
                table: "AttendancePeriod",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف تسجيل الطالب في المقرر");

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "AttendanceCompleted",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الموظف بالجامعة");

            migrationBuilder.AddColumn<int>(
                name: "PersonUniversityId",
                table: "AssignmentGrade",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف علاقة الطالب بالجامعة");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AcademicLevelIteration",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_semesters",
                table: "course_semesters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonUniversityId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_CourseInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_PersonUniversity_PersonUniversityId",
                        column: x => x.PersonUniversityId,
                        principalTable: "PersonUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع المقرر")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم"),
                    ShowInCalendar = table.Column<bool>(type: "boolean", nullable: false, comment: "عرض في التقويم"),
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
                    table.PrimaryKey("PK_CourseType", x => x.Id);
                },
                comment: "جدول أنواع المقررات");

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UniversityId = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LookupAttachmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف نوع المرفق")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
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
                    table.PrimaryKey("PK_LookupAttachmentType", x => x.Id);
                },
                comment: "جدول أنواع المرفقات");

            migrationBuilder.CreateTable(
                name: "LookupBatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الدفعة")
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
                    table.PrimaryKey("PK_LookupBatch", x => x.Id);
                },
                comment: "جدول الدفعات");

            migrationBuilder.CreateTable(
                name: "LookupCollege",
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
                    table.PrimaryKey("PK_LookupCollege", x => x.Id);
                },
                comment: "جدول الكليات");

            migrationBuilder.CreateTable(
                name: "LookupGovernate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المحافظة")
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
                    table.PrimaryKey("PK_LookupGovernate", x => x.Id);
                },
                comment: "جدول المحافظات");

            migrationBuilder.CreateTable(
                name: "LookupQualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المؤهل")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
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
                    table.PrimaryKey("PK_LookupQualification", x => x.Id);
                },
                comment: "جدول المؤهلات العلمية");

            migrationBuilder.CreateTable(
                name: "LookupReligion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الدين")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
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
                    table.PrimaryKey("PK_LookupReligion", x => x.Id);
                },
                comment: "جدول الأديان");

            migrationBuilder.CreateTable(
                name: "LookupWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف السلاح")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
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
                    table.PrimaryKey("PK_LookupWeapon", x => x.Id);
                },
                comment: "جدول الأسلحة");

            migrationBuilder.CreateTable(
                name: "PersonUniversitySection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonUniversityId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_PersonUniversitySection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonUniversitySection_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonUniversitySection_PersonUniversity_PersonUniversityId",
                        column: x => x.PersonUniversityId,
                        principalTable: "PersonUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonUniversitySection_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonUniversityJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonUniversityId = table.Column<int>(type: "integer", nullable: false),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
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
                    table.PrimaryKey("PK_PersonUniversityJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonUniversityJob_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonUniversityJob_PersonUniversity_PersonUniversityId",
                        column: x => x.PersonUniversityId,
                        principalTable: "PersonUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookupDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "معرّف الحي/المنطقة")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "الرمز"),
                    NameAr = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالعربية"),
                    NameEn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "الاسم بالإنجليزية"),
                    GovernateId = table.Column<int>(type: "integer", nullable: false, comment: "معرّف المحافظة"),
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
                    table.PrimaryKey("PK_LookupDistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupDistrict_LookupGovernate_GovernateId",
                        column: x => x.GovernateId,
                        principalTable: "LookupGovernate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "جدول الأحياء/المناطق");

            migrationBuilder.InsertData(
                table: "CourseType",
                columns: new[] { "Id", "DeleteDate", "DeleteUserCode", "InsertUserCode", "IsDeleted", "LastUpdate", "Name", "ShowInCalendar", "UpdateUserCode" },
                values: new object[,]
                {
                    { 1, null, null, null, false, null, "مادة انضباطيه", false, null },
                    { 2, null, null, null, false, null, "مادة علميه", true, null },
                    { 3, null, null, null, false, null, "طابور", true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_PersonUniversityId",
                table: "Transcript",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardian_PersonUniversityId_GuardianId_RelationshipT~",
                table: "StudentGuardian",
                columns: new[] { "PersonUniversityId", "GuardianId", "RelationshipTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_PersonUniversityId_AcademicYearId_SemesterId",
                table: "StudentGpa",
                columns: new[] { "PersonUniversityId", "AcademicYearId", "SemesterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_AcademicLevelId",
                table: "StudentEnrollment",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_AcademicLevelIterationId",
                table: "StudentEnrollment",
                column: "AcademicLevelIterationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEnrollment_CourseSemesterSectionId",
                table: "StudentCourseEnrollment",
                column: "CourseSemesterSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEnrollment_PersonUniversityId_CourseSemesterSe~",
                table: "StudentCourseEnrollment",
                columns: new[] { "PersonUniversityId", "CourseSemesterSectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffUniversityAssignment_PersonUniversityId_UniversityId_A~",
                table: "StaffUniversityAssignment",
                columns: new[] { "PersonUniversityId", "UniversityId", "AcademicYearId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_BatchId",
                table: "Person",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BloodTypeId",
                table: "Person",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DistrictId",
                table: "Person",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GovernateId",
                table: "Person",
                column: "GovernateId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalityId",
                table: "Person",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ReligionId",
                table: "Person",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_WeaponId",
                table: "Person",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_GradeScaleItemId",
                table: "FinalGrade",
                column: "GradeScaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_StudentCourseEnrollmentId",
                table: "FinalGrade",
                column: "StudentCourseEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncidentStudent_IncidentId_PersonUniversityId_Role",
                table: "DisciplineIncidentStudent",
                columns: new[] { "IncidentId", "PersonUniversityId", "Role" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncidentStudent_PersonUniversityId",
                table: "DisciplineIncidentStudent",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineIncident_ReporterPersonUniversityId",
                table: "DisciplineIncident",
                column: "ReporterPersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_IssuedByPersonUniversityId",
                table: "DisciplineAction",
                column: "IssuedByPersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_PersonUniversityId",
                table: "DisciplineAction",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_CourseInstructorId",
                table: "CourseSectionMeeting",
                column: "CourseInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_CourseSemesterSectionId_MeetingDate_Pe~",
                table: "CourseSectionMeeting",
                columns: new[] { "CourseSemesterSectionId", "MeetingDate", "PeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_GradeScaleId",
                table: "Course",
                column: "GradeScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeriod_StudentCourseEnrollmentId_CourseSectionMee~",
                table: "AttendancePeriod",
                columns: new[] { "StudentCourseEnrollmentId", "CourseSectionMeetingId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCompleted_PersonUniversityId",
                table: "AttendanceCompleted",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_AssignmentId_PersonUniversityId",
                table: "AssignmentGrade",
                columns: new[] { "AssignmentId", "PersonUniversityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_PersonUniversityId",
                table: "AssignmentGrade",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_CourseId",
                table: "CourseInstructor",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_PersonUniversityId",
                table: "CourseInstructor",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UniversityId",
                table: "Job",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupDistrict_GovernateId",
                table: "LookupDistrict",
                column: "GovernateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversityJob_JobId",
                table: "PersonUniversityJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversityJob_PersonUniversityId",
                table: "PersonUniversityJob",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversitySection_AcademicYearId",
                table: "PersonUniversitySection",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversitySection_PersonUniversityId",
                table: "PersonUniversitySection",
                column: "PersonUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonUniversitySection_SectionId",
                table: "PersonUniversitySection",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentGrade_PersonUniversity_PersonUniversityId",
                table: "AssignmentGrade",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_course_semesters_CourseSectionId",
                table: "Assignments",
                column: "CourseSectionId",
                principalTable: "course_semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentType_course_semesters_CourseSectionId",
                table: "AssignmentType",
                column: "CourseSectionId",
                principalTable: "course_semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceCompleted_PersonUniversity_PersonUniversityId",
                table: "AttendanceCompleted",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendancePeriod_StudentCourseEnrollment_StudentCourseEnrol~",
                table: "AttendancePeriod",
                column: "StudentCourseEnrollmentId",
                principalTable: "StudentCourseEnrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseType_CourseTypeId",
                table: "Course",
                column: "CourseTypeId",
                principalTable: "CourseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course",
                column: "GradeScaleId",
                principalTable: "GradeScale",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_semesters_AcademicLevelIteration_AcademicLevelIterat~",
                table: "course_semesters",
                column: "AcademicLevelIterationId",
                principalTable: "AcademicLevelIteration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_course_semesters_Course_CourseId",
                table: "course_semesters",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_course_semesters_Semester_SemesterId",
                table: "course_semesters",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_CourseInstructor_CourseInstructorId",
                table: "CourseSectionMeeting",
                column: "CourseInstructorId",
                principalTable: "CourseInstructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_CourseSemesterSection_CourseSemesterSe~",
                table: "CourseSectionMeeting",
                column: "CourseSemesterSectionId",
                principalTable: "CourseSemesterSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Period_PeriodId",
                table: "CourseSectionMeeting",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterSection_course_semesters_CourseSemesterId",
                table: "CourseSemesterSection",
                column: "CourseSemesterId",
                principalTable: "course_semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineAction_PersonUniversity_IssuedByPersonUniversityId",
                table: "DisciplineAction",
                column: "IssuedByPersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineAction_PersonUniversity_PersonUniversityId",
                table: "DisciplineAction",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineIncident_PersonUniversity_ReporterPersonUniversit~",
                table: "DisciplineIncident",
                column: "ReporterPersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineIncidentStudent_PersonUniversity_PersonUniversity~",
                table: "DisciplineIncidentStudent",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_GradeScaleItem_GradeScaleItemId",
                table: "FinalGrade",
                column: "GradeScaleItemId",
                principalTable: "GradeScaleItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_Semester_SemesterId",
                table: "FinalGrade",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_StudentCourseEnrollment_StudentCourseEnrollmentId",
                table: "FinalGrade",
                column: "StudentCourseEnrollmentId",
                principalTable: "StudentCourseEnrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_course_semesters_CourseSemesterId",
                table: "FinalGrade",
                column: "CourseSemesterId",
                principalTable: "course_semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_BloodType_BloodTypeId",
                table: "Person",
                column: "BloodTypeId",
                principalTable: "BloodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupBatch_BatchId",
                table: "Person",
                column: "BatchId",
                principalTable: "LookupBatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupDistrict_DistrictId",
                table: "Person",
                column: "DistrictId",
                principalTable: "LookupDistrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupGovernate_GovernateId",
                table: "Person",
                column: "GovernateId",
                principalTable: "LookupGovernate",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupNationality_NationalityId",
                table: "Person",
                column: "NationalityId",
                principalTable: "LookupNationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupReligion_ReligionId",
                table: "Person",
                column: "ReligionId",
                principalTable: "LookupReligion",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LookupWeapon_WeaponId",
                table: "Person",
                column: "WeaponId",
                principalTable: "LookupWeapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffUniversityAssignment_PersonUniversity_PersonUniversity~",
                table: "StaffUniversityAssignment",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEnrollment_CourseSemesterSection_CourseSemeste~",
                table: "StudentCourseEnrollment",
                column: "CourseSemesterSectionId",
                principalTable: "CourseSemesterSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEnrollment_PersonUniversity_PersonUniversityId",
                table: "StudentCourseEnrollment",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AcademicLevelIteration_AcademicLevelItera~",
                table: "StudentEnrollment",
                column: "AcademicLevelIterationId",
                principalTable: "AcademicLevelIteration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AcademicLevel_AcademicLevelId",
                table: "StudentEnrollment",
                column: "AcademicLevelId",
                principalTable: "AcademicLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AcademicYear_AcademicYearId",
                table: "StudentEnrollment",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGpa_PersonUniversity_PersonUniversityId",
                table: "StudentGpa",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGuardian_PersonUniversity_PersonUniversityId",
                table: "StudentGuardian",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcript_PersonUniversity_PersonUniversityId",
                table: "Transcript",
                column: "PersonUniversityId",
                principalTable: "PersonUniversity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentGrade_PersonUniversity_PersonUniversityId",
                table: "AssignmentGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_course_semesters_CourseSectionId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentType_course_semesters_CourseSectionId",
                table: "AssignmentType");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceCompleted_PersonUniversity_PersonUniversityId",
                table: "AttendanceCompleted");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendancePeriod_StudentCourseEnrollment_StudentCourseEnrol~",
                table: "AttendancePeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseType_CourseTypeId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_GradeScale_GradeScaleId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_semesters_AcademicLevelIteration_AcademicLevelIterat~",
                table: "course_semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_course_semesters_Course_CourseId",
                table: "course_semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_course_semesters_Semester_SemesterId",
                table: "course_semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_CourseInstructor_CourseInstructorId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_CourseSemesterSection_CourseSemesterSe~",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Period_PeriodId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterSection_course_semesters_CourseSemesterId",
                table: "CourseSemesterSection");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineAction_PersonUniversity_IssuedByPersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineAction_PersonUniversity_PersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineIncident_PersonUniversity_ReporterPersonUniversit~",
                table: "DisciplineIncident");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineIncidentStudent_PersonUniversity_PersonUniversity~",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_GradeScaleItem_GradeScaleItemId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_Semester_SemesterId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_StudentCourseEnrollment_StudentCourseEnrollmentId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalGrade_course_semesters_CourseSemesterId",
                table: "FinalGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_BloodType_BloodTypeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupBatch_BatchId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupDistrict_DistrictId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupGovernate_GovernateId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupNationality_NationalityId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupReligion_ReligionId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LookupWeapon_WeaponId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffUniversityAssignment_PersonUniversity_PersonUniversity~",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEnrollment_CourseSemesterSection_CourseSemeste~",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseEnrollment_PersonUniversity_PersonUniversityId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AcademicLevelIteration_AcademicLevelItera~",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AcademicLevel_AcademicLevelId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AcademicYear_AcademicYearId",
                table: "StudentEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGpa_PersonUniversity_PersonUniversityId",
                table: "StudentGpa");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGuardian_PersonUniversity_PersonUniversityId",
                table: "StudentGuardian");

            migrationBuilder.DropForeignKey(
                name: "FK_Transcript_PersonUniversity_PersonUniversityId",
                table: "Transcript");

            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "CourseType");

            migrationBuilder.DropTable(
                name: "LookupAttachmentType");

            migrationBuilder.DropTable(
                name: "LookupBatch");

            migrationBuilder.DropTable(
                name: "LookupCollege");

            migrationBuilder.DropTable(
                name: "LookupDistrict");

            migrationBuilder.DropTable(
                name: "LookupQualification");

            migrationBuilder.DropTable(
                name: "LookupReligion");

            migrationBuilder.DropTable(
                name: "LookupWeapon");

            migrationBuilder.DropTable(
                name: "PersonUniversityJob");

            migrationBuilder.DropTable(
                name: "PersonUniversitySection");

            migrationBuilder.DropTable(
                name: "LookupGovernate");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Transcript_PersonUniversityId",
                table: "Transcript");

            migrationBuilder.DropIndex(
                name: "IX_StudentGuardian_PersonUniversityId_GuardianId_RelationshipT~",
                table: "StudentGuardian");

            migrationBuilder.DropIndex(
                name: "IX_StudentGpa_PersonUniversityId_AcademicYearId_SemesterId",
                table: "StudentGpa");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_AcademicLevelId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_AcademicLevelIterationId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_CourseSemesterSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_PersonUniversityId_CourseSemesterSe~",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StaffUniversityAssignment_PersonUniversityId_UniversityId_A~",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropIndex(
                name: "IX_Person_BatchId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_BloodTypeId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_DistrictId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_GovernateId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_NationalityId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ReligionId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_WeaponId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_FinalGrade_GradeScaleItemId",
                table: "FinalGrade");

            migrationBuilder.DropIndex(
                name: "IX_FinalGrade_StudentCourseEnrollmentId",
                table: "FinalGrade");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncidentStudent_IncidentId_PersonUniversityId_Role",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncidentStudent_PersonUniversityId",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineIncident_ReporterPersonUniversityId",
                table: "DisciplineIncident");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineAction_IssuedByPersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineAction_PersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionMeeting_CourseInstructorId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionMeeting_CourseSemesterSectionId_MeetingDate_Pe~",
                table: "CourseSectionMeeting");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_GradeScaleId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_AttendancePeriod_StudentCourseEnrollmentId_CourseSectionMee~",
                table: "AttendancePeriod");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceCompleted_PersonUniversityId",
                table: "AttendanceCompleted");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGrade_AssignmentId_PersonUniversityId",
                table: "AssignmentGrade");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGrade_PersonUniversityId",
                table: "AssignmentGrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_semesters",
                table: "course_semesters");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "Transcript");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "StudentGuardian");

            migrationBuilder.DropColumn(
                name: "BatchRank",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "SemesterRank",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "TotalMaxScore",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "StudentGpa");

            migrationBuilder.DropColumn(
                name: "AcademicLevelId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "AcademicLevelIterationId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "CourseSemesterSectionId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "StaffUniversityAssignment");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GovernateId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsMilitary",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MilitaryNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PeriodType",
                table: "Period");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "GradeScaleItemId",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "StudentCourseEnrollmentId",
                table: "FinalGrade");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "DisciplineIncidentStudent");

            migrationBuilder.DropColumn(
                name: "ReporterPersonUniversityId",
                table: "DisciplineIncident");

            migrationBuilder.DropColumn(
                name: "IssuedByPersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "DisciplineAction");

            migrationBuilder.DropColumn(
                name: "CourseInstructorId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropColumn(
                name: "CourseSemesterSectionId",
                table: "CourseSectionMeeting");

            migrationBuilder.DropColumn(
                name: "CourseTypeId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "GradeScaleId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IncludeInGpa",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsGraduationRequired",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsYearFail",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "MaximumDegree",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BloodType");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AttendancePeriod");

            migrationBuilder.DropColumn(
                name: "StudentCourseEnrollmentId",
                table: "AttendancePeriod");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "AttendanceCompleted");

            migrationBuilder.DropColumn(
                name: "PersonUniversityId",
                table: "AssignmentGrade");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AcademicLevelIteration");

            migrationBuilder.RenameTable(
                name: "course_semesters",
                newName: "CourseSemester");

            migrationBuilder.RenameColumn(
                name: "AcademicYearId",
                table: "StudentEnrollment",
                newName: "LookupEnrollmentCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollment_AcademicYearId",
                table: "StudentEnrollment",
                newName: "IX_StudentEnrollment_LookupEnrollmentCodeId");

            migrationBuilder.RenameColumn(
                name: "CourseSemesterId",
                table: "FinalGrade",
                newName: "CourseSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FinalGrade_CourseSemesterId",
                table: "FinalGrade",
                newName: "IX_FinalGrade_CourseSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_course_semesters_SemesterId",
                table: "CourseSemester",
                newName: "IX_CourseSemester_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_course_semesters_CourseId",
                table: "CourseSemester",
                newName: "IX_CourseSemester_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_course_semesters_AcademicLevelIterationId",
                table: "CourseSemester",
                newName: "IX_CourseSemester_AcademicLevelIterationId");

            migrationBuilder.AlterTable(
                name: "StudentEnrollment",
                comment: "جدول سجل قيد الطلاب وتاريخ التسجيل");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Transcript",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentGuardian",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentGpa",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "StudentEnrollment",
                type: "integer",
                nullable: true,
                comment: "معرّف الشعبة",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentEnrollment",
                type: "integer",
                nullable: false,
                comment: "معرّف القيد",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateOnly>(
                name: "EntryDate",
                table: "StudentEnrollment",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                comment: "تاريخ الدخول");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExitDate",
                table: "StudentEnrollment",
                type: "date",
                nullable: true,
                comment: "تاريخ الخروج");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "StudentEnrollment",
                type: "text",
                nullable: true,
                comment: "ملاحظات");

            migrationBuilder.AddColumn<int>(
                name: "CourseSectionId",
                table: "StudentCourseEnrollment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف حصة المقرر");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DropDate",
                table: "StudentCourseEnrollment",
                type: "date",
                nullable: true,
                comment: "تاريخ الانسحاب");

            migrationBuilder.AddColumn<bool>(
                name: "IsDropped",
                table: "StudentCourseEnrollment",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "هل تم الانسحاب");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentCourseEnrollment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "StaffUniversityAssignment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الموظف");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "PersonUniversity",
                type: "date",
                nullable: true,
                comment: "تاريخ الانتهاء");

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "PersonUniversity",
                type: "date",
                nullable: true,
                comment: "تاريخ البدء");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "FinalGrade",
                type: "integer",
                nullable: true,
                comment: "معرّف الفصل الدراسي",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف الفصل الدراسي");

            migrationBuilder.AlterColumn<string>(
                name: "LetterGrade",
                table: "FinalGrade",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                comment: "التقدير",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "التقدير");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "FinalGrade",
                type: "text",
                nullable: true,
                comment: "ملاحظات");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditsAttempted",
                table: "FinalGrade",
                type: "numeric",
                nullable: true,
                comment: "الساعات المحاولة");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditsEarned",
                table: "FinalGrade",
                type: "numeric",
                nullable: true,
                comment: "الساعات المكتسبة");

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInGpa",
                table: "FinalGrade",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "يحسب في المعدل");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinal",
                table: "FinalGrade",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "هل نهائي");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "FinalGrade",
                type: "timestamp with time zone",
                nullable: true,
                comment: "تاريخ النشر");

            migrationBuilder.AddColumn<int>(
                name: "PostedBy",
                table: "FinalGrade",
                type: "integer",
                nullable: true,
                comment: "نشر بواسطة");

            migrationBuilder.AddColumn<int>(
                name: "QuarterId",
                table: "FinalGrade",
                type: "integer",
                nullable: true,
                comment: "معرّف الربع");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "FinalGrade",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "DisciplineIncidentStudent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "ReporterId",
                table: "DisciplineIncident",
                type: "integer",
                nullable: true,
                comment: "المبلغ");

            migrationBuilder.AddColumn<int>(
                name: "IssuedBy",
                table: "DisciplineAction",
                type: "integer",
                nullable: true,
                comment: "صدر بواسطة");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "DisciplineAction",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "CourseSectionMeeting",
                type: "integer",
                nullable: true,
                comment: "معرّف القاعة",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف القاعة");

            migrationBuilder.AddColumn<int>(
                name: "CourseSectionId",
                table: "CourseSectionMeeting",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف حصة المقرر");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BloodType",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "معرّف الدفعة")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BloodType",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "فصيلة الدم");

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

            migrationBuilder.AddColumn<int>(
                name: "RecordedBy",
                table: "AttendancePeriod",
                type: "integer",
                nullable: true,
                comment: "تم التسجيل بواسطة");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AttendancePeriod",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "AttendanceCompleted",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الموظف");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AssignmentGrade",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "معرّف الطالب");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSemester",
                table: "CourseSemester",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transcript_StudentId",
                table: "Transcript",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardian_StudentId_GuardianId_RelationshipTypeId",
                table: "StudentGuardian",
                columns: new[] { "StudentId", "GuardianId", "RelationshipTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGpa_StudentId_AcademicYearId_SemesterId",
                table: "StudentGpa",
                columns: new[] { "StudentId", "AcademicYearId", "SemesterId" },
                unique: true);

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
                name: "IX_StaffUniversityAssignment_StaffId_UniversityId_AcademicYear~",
                table: "StaffUniversityAssignment",
                columns: new[] { "StaffId", "UniversityId", "AcademicYearId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_QuarterId",
                table: "FinalGrade",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalGrade_StudentId",
                table: "FinalGrade",
                column: "StudentId");

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
                name: "IX_DisciplineIncident_ReporterId",
                table: "DisciplineIncident",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_IssuedBy",
                table: "DisciplineAction",
                column: "IssuedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineAction_StudentId",
                table: "DisciplineAction",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionMeeting_CourseSectionId_MeetingDate_PeriodId",
                table: "CourseSectionMeeting",
                columns: new[] { "CourseSectionId", "MeetingDate", "PeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeriod_StudentId_CourseSectionMeetingId",
                table: "AttendancePeriod",
                columns: new[] { "StudentId", "CourseSectionMeetingId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCompleted_StaffId",
                table: "AttendanceCompleted",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_AssignmentId_StudentId",
                table: "AssignmentGrade",
                columns: new[] { "AssignmentId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrade_StudentId",
                table: "AssignmentGrade",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentGrade_Student_StudentId",
                table: "AssignmentGrade",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_CourseSemester_CourseSectionId",
                table: "Assignments",
                column: "CourseSectionId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentType_CourseSemester_CourseSectionId",
                table: "AssignmentType",
                column: "CourseSectionId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceCompleted_Staff_StaffId",
                table: "AttendanceCompleted",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendancePeriod_Student_StudentId",
                table: "AttendancePeriod",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_CourseSemester_CourseSectionId",
                table: "CourseSectionMeeting",
                column: "CourseSectionId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Period_PeriodId",
                table: "CourseSectionMeeting",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionMeeting_Room_RoomId",
                table: "CourseSectionMeeting",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemester_AcademicLevelIteration_AcademicLevelIteratio~",
                table: "CourseSemester",
                column: "AcademicLevelIterationId",
                principalTable: "AcademicLevelIteration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemester_Course_CourseId",
                table: "CourseSemester",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemester_Semester_SemesterId",
                table: "CourseSemester",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterSection_CourseSemester_CourseSemesterId",
                table: "CourseSemesterSection",
                column: "CourseSemesterId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineAction_Staff_IssuedBy",
                table: "DisciplineAction",
                column: "IssuedBy",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineAction_Student_StudentId",
                table: "DisciplineAction",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineIncident_Staff_ReporterId",
                table: "DisciplineIncident",
                column: "ReporterId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineIncidentStudent_Student_StudentId",
                table: "DisciplineIncidentStudent",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_CourseSemester_CourseSectionId",
                table: "FinalGrade",
                column: "CourseSectionId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_Quarter_QuarterId",
                table: "FinalGrade",
                column: "QuarterId",
                principalTable: "Quarter",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_Semester_SemesterId",
                table: "FinalGrade",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalGrade_Student_StudentId",
                table: "FinalGrade",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffUniversityAssignment_Staff_StaffId",
                table: "StaffUniversityAssignment",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEnrollment_CourseSemester_CourseSectionId",
                table: "StudentCourseEnrollment",
                column: "CourseSectionId",
                principalTable: "CourseSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseEnrollment_Student_StudentId",
                table: "StudentCourseEnrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_LookupEnrollmentCode_LookupEnrollmentCode~",
                table: "StudentEnrollment",
                column: "LookupEnrollmentCodeId",
                principalTable: "LookupEnrollmentCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGpa_Student_StudentId",
                table: "StudentGpa",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGuardian_Student_StudentId",
                table: "StudentGuardian",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transcript_Student_StudentId",
                table: "Transcript",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
