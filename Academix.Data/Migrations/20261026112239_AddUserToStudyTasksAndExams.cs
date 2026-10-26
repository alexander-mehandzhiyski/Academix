using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Academix.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToStudyTasksAndExams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudyTasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTasks_UserId",
                table: "StudyTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserId",
                table: "Exams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyTasks_AspNetUsers_UserId",
                table: "StudyTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyTasks_AspNetUsers_UserId",
                table: "StudyTasks");

            migrationBuilder.DropIndex(
                name: "IX_StudyTasks_UserId",
                table: "StudyTasks");

            migrationBuilder.DropIndex(
                name: "IX_Exams_UserId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudyTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Exams");

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
        }
    }
}
