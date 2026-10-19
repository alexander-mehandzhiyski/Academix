using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Academix.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSchemaAndSeedData : Migration
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Algebra, calculus and geometry", "Mathematics", null },
                    { 2, "World and regional history", "History", null }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "ExamDate", "Grade", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 18, 18, 11, 32, 910, DateTimeKind.Utc).AddTicks(7846), null, 1, "Midterm Mathematics" },
                    { 2, new DateTime(2026, 12, 18, 18, 11, 32, 910, DateTimeKind.Utc).AddTicks(9903), null, 2, "Final History" }
                });

            migrationBuilder.InsertData(
                table: "StudyTasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 1, "Introduction to algebra", new DateTime(2026, 10, 25, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(4056), false, 1, "Read Chapter 1" },
                    { 2, "Solve exercises 1-10", new DateTime(2026, 10, 28, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(7081), false, 1, "Practice problems" },
                    { 3, "Focus on timeline and key events", new DateTime(2026, 10, 23, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(7095), false, 2, "Read about WW2" }
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
                name: "IX_Subjects_UserId",
                table: "Subjects",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "StudyTasks");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
