using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInfos_ServiceId",
                table: "ServiceInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServiceInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos",
                columns: new[] { "ServiceId", "ReserveId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServiceInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfos",
                table: "ServiceInfos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_ServiceId",
                table: "ServiceInfos",
                column: "ServiceId");
        }
    }
}
