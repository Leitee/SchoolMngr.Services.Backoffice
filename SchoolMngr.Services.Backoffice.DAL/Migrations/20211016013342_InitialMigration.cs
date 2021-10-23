using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMngr.Services.Backoffice.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DOMAIN");

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                schema: "DOMAIN",
                columns: table => new
                {
                    ClassRoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxCapacity = table.Column<short>(type: "smallint", nullable: false),
                    HasNetworkConexion = table.Column<bool>(type: "bit", nullable: true),
                    HasScreenProjector = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassRoomID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "DOMAIN",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "DOMAIN",
                columns: table => new
                {
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsTemporary = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "DOMAIN",
                columns: table => new
                {
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxAbsencesAllowed = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)3),
                    MinExamScoreRequired = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)6),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    NextAvailableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_Grades_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "DOMAIN",
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_NextAvailableId",
                        column: x => x.NextAvailableId,
                        principalSchema: "DOMAIN",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "DOMAIN",
                columns: table => new
                {
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shift = table.Column<int>(type: "int", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    EnrolledQty = table.Column<short>(type: "smallint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalSchema: "DOMAIN",
                        principalTable: "ClassRooms",
                        principalColumn: "ClassRoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "DOMAIN",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                schema: "DOMAIN",
                columns: table => new
                {
                    AssignmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "DOMAIN",
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "DOMAIN",
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "DOMAIN",
                columns: table => new
                {
                    EnrollmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentProfileId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StudentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "DOMAIN",
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                schema: "DOMAIN",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherId",
                schema: "DOMAIN",
                table: "Assignments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassRoomId",
                schema: "DOMAIN",
                table: "Classes",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SubjectId",
                schema: "DOMAIN",
                table: "Classes",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassId",
                schema: "DOMAIN",
                table: "Enrollments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CodeName",
                schema: "DOMAIN",
                table: "Subjects",
                column: "CodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeId",
                schema: "DOMAIN",
                table: "Subjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_NextAvailableId",
                schema: "DOMAIN",
                table: "Subjects",
                column: "NextAvailableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Classes",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "ClassRooms",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "DOMAIN");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "DOMAIN");
        }
    }
}
