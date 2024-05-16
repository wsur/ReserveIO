using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class EditSemmaryServiceInfokey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryTableSummaryId",
                table: "ServiceInfos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 990, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 990, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 990, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 990, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "ServiceInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "SummaryTableSummaryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "SummaryTableSummaryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceInfos",
                keyColumn: "Id",
                keyValue: 3,
                column: "SummaryTableSummaryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 994, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 994, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 14, 41, 43, 994, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_SummaryTableSummaryId",
                table: "ServiceInfos",
                column: "SummaryTableSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_SummaryTables_SummaryTableSummaryId",
                table: "ServiceInfos",
                column: "SummaryTableSummaryId",
                principalTable: "SummaryTables",
                principalColumn: "SummaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_SummaryTables_SummaryTableSummaryId",
                table: "ServiceInfos");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInfos_SummaryTableSummaryId",
                table: "ServiceInfos");

            migrationBuilder.DropColumn(
                name: "SummaryTableSummaryId",
                table: "ServiceInfos");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 280, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 280, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 280, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 280, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 284, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 284, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 15, 13, 13, 13, 284, DateTimeKind.Local).AddTicks(8120));
        }
    }
}
