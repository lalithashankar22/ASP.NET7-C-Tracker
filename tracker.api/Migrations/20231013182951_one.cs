using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tracker.api.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_work_department_Department_iddept_id",
                table: "work");

            migrationBuilder.RenameColumn(
                name: "Department_iddept_id",
                table: "work",
                newName: "Department_id");

            migrationBuilder.RenameIndex(
                name: "IX_work_Department_iddept_id",
                table: "work",
                newName: "IX_work_Department_id");

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7001,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4594), new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7002,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7003,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4603), new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1001,
                column: "end_dt",
                value: new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1002,
                column: "start_dt",
                value: new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1003,
                column: "start_dt",
                value: new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.InsertData(
                table: "work",
                columns: new[] { "work_id", "Department_id", "archv_flag", "end_dt", "start_dt", "work_name" },
                values: new object[] { 5001, 3001, "N", new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4433), new DateTime(2009, 5, 8, 14, 40, 52, 0, DateTimeKind.Unspecified), "Coading" });

            migrationBuilder.AddForeignKey(
                name: "FK_work_department_Department_id",
                table: "work",
                column: "Department_id",
                principalTable: "department",
                principalColumn: "dept_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_work_department_Department_id",
                table: "work");

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5001);

            migrationBuilder.RenameColumn(
                name: "Department_id",
                table: "work",
                newName: "Department_iddept_id");

            migrationBuilder.RenameIndex(
                name: "IX_work_Department_id",
                table: "work",
                newName: "IX_work_Department_iddept_id");

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7001,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2913), new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7002,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2917), new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7003,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2919), new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2919) });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1001,
                column: "end_dt",
                value: new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1002,
                column: "start_dt",
                value: new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1003,
                column: "start_dt",
                value: new DateTime(2023, 10, 13, 23, 42, 25, 663, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.AddForeignKey(
                name: "FK_work_department_Department_iddept_id",
                table: "work",
                column: "Department_iddept_id",
                principalTable: "department",
                principalColumn: "dept_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
