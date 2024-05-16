using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfo_Services_ServiceId",
                table: "ServiceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfo_SummaryTables_ReserveId",
                table: "ServiceInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfo",
                table: "ServiceInfo");

            migrationBuilder.RenameTable(
                name: "ServiceInfo",
                newName: "ServiceInfos");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfo_ServiceId",
                table: "ServiceInfos",
                newName: "IX_ServiceInfos_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfo_ReserveId",
                table: "ServiceInfos",
                newName: "IX_ServiceInfos_ReserveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_Services_ServiceId",
                table: "ServiceInfos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos",
                column: "ReserveId",
                principalTable: "SummaryTables",
                principalColumn: "SummaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_Services_ServiceId",
                table: "ServiceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfos_SummaryTables_ReserveId",
                table: "ServiceInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos");

            migrationBuilder.RenameTable(
                name: "ServiceInfos",
                newName: "ServiceInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfos_ServiceId",
                table: "ServiceInfo",
                newName: "IX_ServiceInfo_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfos_ReserveId",
                table: "ServiceInfo",
                newName: "IX_ServiceInfo_ReserveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfo",
                table: "ServiceInfo",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfo_Services_ServiceId",
                table: "ServiceInfo",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfo_SummaryTables_ReserveId",
                table: "ServiceInfo",
                column: "ReserveId",
                principalTable: "SummaryTables",
                principalColumn: "SummaryId");
        }
    }
}
