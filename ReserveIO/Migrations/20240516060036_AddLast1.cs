using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class AddLast1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 364, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 364, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 364, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 364, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 369, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 369, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 0, 36, 369, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos",
                column: "ReserveId",
                principalTable: "SummaryTables",
                principalColumn: "SummaryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 317, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 317, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 317, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 317, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 321, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 321, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 10, 30, 56, 321, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos",
                column: "ReserveId",
                principalTable: "SummaryTables",
                principalColumn: "SummaryId");
        }
    }
}
