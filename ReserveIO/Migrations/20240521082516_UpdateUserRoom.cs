using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoomId",
                table: "UserRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoomId",
                table: "UserRooms");
        }
    }
}
