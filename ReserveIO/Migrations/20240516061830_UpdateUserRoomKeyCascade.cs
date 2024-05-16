using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoomKeyCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Users_UserId",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom");

            migrationBuilder.RenameTable(
                name: "UserRoom",
                newName: "UserRooms");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_RoomId",
                table: "UserRooms",
                newName: "IX_UserRooms_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                columns: new[] { "UserId", "RoomId" });

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
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.RenameTable(
                name: "UserRooms",
                newName: "UserRoom");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_RoomId",
                table: "UserRoom",
                newName: "IX_UserRoom_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom",
                columns: new[] { "UserId", "RoomId" });

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
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Users_UserId",
                table: "UserRoom",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
