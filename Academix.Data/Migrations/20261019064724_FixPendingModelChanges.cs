using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academix.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Exams",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExamDate",
                value: new DateTime(2026, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExamDate",
                value: new DateTime(2026, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Exams",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExamDate",
                value: new DateTime(2026, 11, 18, 18, 11, 32, 910, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExamDate",
                value: new DateTime(2026, 12, 18, 18, 11, 32, 910, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 10, 25, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 10, 28, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "StudyTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2026, 10, 23, 18, 11, 32, 909, DateTimeKind.Utc).AddTicks(7095));
        }
    }
}
