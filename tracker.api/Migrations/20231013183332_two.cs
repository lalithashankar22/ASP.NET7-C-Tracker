using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tracker.api.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7001,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7899), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7898) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7002,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7903), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7003,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7905), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1001,
                column: "end_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1002,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1003,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5001,
                column: "end_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.InsertData(
                table: "work",
                columns: new[] { "work_id", "Department_id", "archv_flag", "end_dt", "start_dt", "work_name" },
                values: new object[,]
                {
                    { 5002, 3001, "N", null, new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7741), "Analysis" },
                    { 5003, 3001, "N", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7742), "testing" },
                    { 6001, 3002, "N", new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7749), new DateTime(2009, 5, 8, 14, 40, 52, 0, DateTimeKind.Unspecified), "Coading" },
                    { 6002, 3002, "N", null, new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7751), "Analysis" },
                    { 6003, 3002, "N", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7754), "testing" },
                    { 7001, 3003, "N", new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7760), new DateTime(2009, 5, 8, 14, 40, 52, 0, DateTimeKind.Unspecified), "Coading" },
                    { 7002, 3003, "N", null, new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7762), "Analysis" },
                    { 7003, 3003, "N", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7763), "testing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5002);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5003);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6001);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6002);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6003);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7001);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7002);

            migrationBuilder.DeleteData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7003);

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

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5001,
                column: "end_dt",
                value: new DateTime(2023, 10, 13, 23, 59, 51, 177, DateTimeKind.Local).AddTicks(4433));
        }
    }
}
