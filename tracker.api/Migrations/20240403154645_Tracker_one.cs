using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tracker.api.Migrations
{
    /// <inheritdoc />
    public partial class Tracker_one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInByte = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7001,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4261), new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7002,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4266), new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4265) });

            migrationBuilder.UpdateData(
                table: "dailyTracker",
                keyColumn: "track_id",
                keyValue: 7003,
                columns: new[] { "last_modif", "start_dt" },
                values: new object[] { new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4268), new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1001,
                column: "end_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1002,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "prod_id",
                keyValue: 1003,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5001,
                column: "end_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5002,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5003,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6001,
                column: "end_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6002,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6003,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7001,
                column: "end_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7002,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7003,
                column: "start_dt",
                value: new DateTime(2024, 4, 3, 21, 16, 45, 549, DateTimeKind.Local).AddTicks(4141));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

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

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5002,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 5003,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6001,
                column: "end_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6002,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 6003,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7001,
                column: "end_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7002,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "work",
                keyColumn: "work_id",
                keyValue: 7003,
                column: "start_dt",
                value: new DateTime(2023, 10, 14, 0, 3, 32, 77, DateTimeKind.Local).AddTicks(7763));
        }
    }
}
