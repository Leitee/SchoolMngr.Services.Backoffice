using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMngr.BackOffice.DAL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BO");

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                schema: "BO",
                columns: table => new
                {
                    ClassRoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Capacity = table.Column<short>(nullable: false),
                    HasNetworkConexion = table.Column<bool>(nullable: true),
                    HasScreenProjector = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassRoomID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "BO",
                columns: table => new
                {
                    GradeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "BO",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    IsTemporary = table.Column<bool>(nullable: false),
                    Obs = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "BO",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeName = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    RequiredId = table.Column<int>(nullable: true),
                    GradeId = table.Column<int>(nullable: false),
                    MaxAbsencesAllowed = table.Column<short>(nullable: false, defaultValue: (short)3),
                    MinExamScoreRequired = table.Column<short>(nullable: false, defaultValue: (short)6)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_Grades_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "BO",
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_RequiredId",
                        column: x => x.RequiredId,
                        principalSchema: "BO",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assingments",
                schema: "BO",
                columns: table => new
                {
                    AssingmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    StartsTime = table.Column<DateTime>(nullable: false),
                    EndsTime = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assingments", x => x.AssingmentID);
                    table.ForeignKey(
                        name: "FK_Assingments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "BO",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assingments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "BO",
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "BO",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Shift = table.Column<int>(nullable: false),
                    StartsDate = table.Column<DateTime>(nullable: false),
                    ClosesDate = table.Column<DateTime>(nullable: false),
                    EnrolledQty = table.Column<short>(nullable: false),
                    AssingmentId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_Assingments_AssingmentId",
                        column: x => x.AssingmentId,
                        principalSchema: "BO",
                        principalTable: "Assingments",
                        principalColumn: "AssingmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_ClassRooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "BO",
                        principalTable: "ClassRooms",
                        principalColumn: "ClassRoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assingments_SubjectId",
                schema: "BO",
                table: "Assingments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assingments_TeacherId",
                schema: "BO",
                table: "Assingments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_AssingmentId",
                schema: "BO",
                table: "Classes",
                column: "AssingmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_RoomId",
                schema: "BO",
                table: "Classes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeId",
                schema: "BO",
                table: "Subjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_RequiredId",
                schema: "BO",
                table: "Subjects",
                column: "RequiredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes",
                schema: "BO");

            migrationBuilder.DropTable(
                name: "Assingments",
                schema: "BO");

            migrationBuilder.DropTable(
                name: "ClassRooms",
                schema: "BO");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "BO");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "BO");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "BO");
        }
    }
}
