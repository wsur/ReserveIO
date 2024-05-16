using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostHour_Rooms_CostRoomId",
                table: "CostHour");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryTables_Rooms_RoomId",
                table: "SummaryTables");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryTables_Users_LesseeId",
                table: "SummaryTables");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 222, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 222, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 222, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 222, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 226, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 226, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 35, 37, 226, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.AddForeignKey(
                name: "FK_CostHour_Rooms_CostRoomId",
                table: "CostHour",
                column: "CostRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryTables_Rooms_RoomId",
                table: "SummaryTables",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryTables_Users_LesseeId",
                table: "SummaryTables",
                column: "LesseeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostHour_Rooms_CostRoomId",
                table: "CostHour");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryTables_Rooms_RoomId",
                table: "SummaryTables");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryTables_Users_LesseeId",
                table: "SummaryTables");

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 400, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 400, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 400, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "CostHour",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 400, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 404, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 404, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 18, 30, 404, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.AddForeignKey(
                name: "FK_CostHour_Rooms_CostRoomId",
                table: "CostHour",
                column: "CostRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryTables_Rooms_RoomId",
                table: "SummaryTables",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryTables_Users_LesseeId",
                table: "SummaryTables",
                column: "LesseeId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
