using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserRolesController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 699, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 699, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 699, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 699, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 705, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 705, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 10, 19, 23, 705, DateTimeKind.Local).AddTicks(4905));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 121, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 121, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 121, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 121, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 126, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 126, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 16, 3, 4, 126, DateTimeKind.Local).AddTicks(8472));
        }
    }
}
