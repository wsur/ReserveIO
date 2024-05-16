using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class CostHour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostHour_Rooms_CostRoomId",
                table: "CostHour");

            migrationBuilder.DropForeignKey(
                name: "FK_CostHour_Rooms_RoomId",
                table: "CostHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostHour",
                table: "CostHour");

            migrationBuilder.RenameTable(
                name: "CostHour",
                newName: "CostHours");

            migrationBuilder.RenameIndex(
                name: "IX_CostHour_RoomId",
                table: "CostHours",
                newName: "IX_CostHours_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_CostHour_CostRoomId",
                table: "CostHours",
                newName: "IX_CostHours_CostRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostHours",
                table: "CostHours",
                column: "CostId");

            migrationBuilder.UpdateData(
                table: "CostHours",
                keyColumn: "CostId",
                keyValue: 1,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 601, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "CostHours",
                keyColumn: "CostId",
                keyValue: 2,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 601, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "CostHours",
                keyColumn: "CostId",
                keyValue: 3,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 601, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "CostHours",
                keyColumn: "CostId",
                keyValue: 4,
                column: "TimeStampTZ",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 601, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 605, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 605, DateTimeKind.Local).AddTicks(3279));

            migrationBuilder.UpdateData(
                table: "SummaryTables",
                keyColumn: "SummaryId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2024, 5, 16, 11, 47, 34, 605, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.AddForeignKey(
                name: "FK_CostHours_Rooms_CostRoomId",
                table: "CostHours",
                column: "CostRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostHours_Rooms_RoomId",
                table: "CostHours",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostHours_Rooms_CostRoomId",
                table: "CostHours");

            migrationBuilder.DropForeignKey(
                name: "FK_CostHours_Rooms_RoomId",
                table: "CostHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostHours",
                table: "CostHours");

            migrationBuilder.RenameTable(
                name: "CostHours",
                newName: "CostHour");

            migrationBuilder.RenameIndex(
                name: "IX_CostHours_RoomId",
                table: "CostHour",
                newName: "IX_CostHour_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_CostHours_CostRoomId",
                table: "CostHour",
                newName: "IX_CostHour_CostRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostHour",
                table: "CostHour",
                column: "CostId");

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
                name: "FK_CostHour_Rooms_RoomId",
                table: "CostHour",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
