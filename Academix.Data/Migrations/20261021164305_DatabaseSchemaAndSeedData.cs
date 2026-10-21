using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Academix.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSchemaAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyTasks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersSubjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSubjects", x => new { x.UserId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_UsersSubjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Algebra, calculus and geometry", "Mathematics" },
                    { 2, "World and regional history", "History" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "ExamDate", "Grade", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Midterm Mathematics" },
                    { 2, new DateTime(2026, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Final History" }
                });

            migrationBuilder.InsertData(
                table: "StudyTasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 1, "Introduction to algebra", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "Read Chapter 1" },
                    { 2, "Solve exercises 1-10", new DateTime(2026, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "Practice problems" },
                    { 3, "Focus on timeline and key events", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "Read about WW2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectId",
                table: "Exams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTasks_SubjectId",
                table: "StudyTasks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSubjects_SubjectId",
                table: "UsersSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "StudyTasks");

            migrationBuilder.DropTable(
                name: "UsersSubjects");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
