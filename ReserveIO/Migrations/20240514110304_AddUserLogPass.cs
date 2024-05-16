using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLogPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogPass_Users_UserId",
                table: "UserLogPass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogPass",
                table: "UserLogPass");

            migrationBuilder.RenameTable(
                name: "UserLogPass",
                newName: "UserLogPasses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogPasses",
                table: "UserLogPasses",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogPasses_Users_UserId",
                table: "UserLogPasses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogPasses_Users_UserId",
                table: "UserLogPasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogPasses",
                table: "UserLogPasses");

            migrationBuilder.RenameTable(
                name: "UserLogPasses",
                newName: "UserLogPass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogPass",
                table: "UserLogPass",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogPass_Users_UserId",
                table: "UserLogPass",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
