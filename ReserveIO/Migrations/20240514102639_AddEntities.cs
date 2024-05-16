using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnOff = table.Column<bool>(type: "bit", nullable: false),
                    ServiceOn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostHour",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostRoomId = table.Column<int>(type: "int", nullable: false),
                    TimeStampTZ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostHour", x => x.CostId);
                    table.ForeignKey(
                        name: "FK_CostHour_Rooms_CostRoomId",
                        column: x => x.CostRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_CostHour_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCost = table.Column<float>(type: "real", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SummaryTables",
                columns: table => new
                {
                    SummaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LesseeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryTables", x => x.SummaryId);
                    table.ForeignKey(
                        name: "FK_SummaryTables_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_SummaryTables_Users_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SummaryTables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogPass",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogPass", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserLogPass_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoom",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoom", x => new { x.UserId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_UserRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_UserRoom_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ReserveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInfo_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                    table.ForeignKey(
                        name: "FK_ServiceInfo_SummaryTables_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "SummaryTables",
                        principalColumn: "SummaryId");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Delete", "RoleName" },
                values: new object[,]
                {
                    { 1, false, "Lessee" },
                    { 2, false, "Lessor" },
                    { 3, false, "App_Owner" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "OnOff", "RoomName", "ServiceOn" },
                values: new object[,]
                {
                    { 1, true, "Plank", true },
                    { 2, true, "Newtone", true },
                    { 3, true, "Einstein", true },
                    { 4, true, "Gilbert", true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Delete", "Name" },
                values: new object[,]
                {
                    { 1, 23, false, "Tom" },
                    { 2, 26, false, "Alice" },
                    { 3, 28, false, "Sam" },
                    { 4, 24, false, "Eugene" }
                });

            migrationBuilder.InsertData(
                table: "CostHour",
                columns: new[] { "CostId", "Cost", "CostRoomId", "RoomId", "TimeStampTZ" },
                values: new object[,]
                {
                    { 1, 2500, 1, null, new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9852) },
                    { 2, 2500, 1, null, new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9862) },
                    { 3, 2500, 2, null, new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9863) },
                    { 4, 2500, 3, null, new DateTime(2024, 5, 14, 15, 26, 39, 595, DateTimeKind.Local).AddTicks(9864) }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "ServiceCost", "ServiceName", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, 3000f, "аренда офисного помещения 30 кв под митапы", 2, null },
                    { 2, 10000f, "Аренда магазинной площади под городское мероприятие 400 кв", 2, null },
                    { 3, 10000f, "тест моего помещения", 3, null }
                });

            migrationBuilder.InsertData(
                table: "SummaryTables",
                columns: new[] { "SummaryId", "Datetime", "EndTime", "LesseeId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8069), new DateTime(2024, 5, 13, 16, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, null },
                    { 2, new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8150), new DateTime(2024, 5, 13, 16, 40, 0, 0, DateTimeKind.Unspecified), 2, 1, null },
                    { 3, new DateTime(2024, 5, 14, 15, 26, 39, 601, DateTimeKind.Local).AddTicks(8158), new DateTime(2024, 5, 13, 16, 50, 0, 0, DateTimeKind.Unspecified), 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "UserLogPass",
                columns: new[] { "UserId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Tom1", "123" },
                    { 2, "Alice1", "123" },
                    { 3, "Sam1", "123" },
                    { 4, "Eugene1", "123" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoom",
                columns: new[] { "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ServiceInfo",
                columns: new[] { "Id", "ReserveId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostHour_CostRoomId",
                table: "CostHour",
                column: "CostRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CostHour_RoomId",
                table: "CostHour",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfo_ReserveId",
                table: "ServiceInfo",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfo_ServiceId",
                table: "ServiceInfo",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId1",
                table: "Services",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryTables_LesseeId",
                table: "SummaryTables",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryTables_RoomId",
                table: "SummaryTables",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryTables_UserId",
                table: "SummaryTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoom_RoomId",
                table: "UserRoom",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostHour");

            migrationBuilder.DropTable(
                name: "ServiceInfo");

            migrationBuilder.DropTable(
                name: "UserLogPass");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserRoom");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SummaryTables");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
