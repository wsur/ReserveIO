using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveIO.Migrations
{
    /// <inheritdoc />
    public partial class newdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryTableSummaryId",
                table: "ServiceInfos",
                type: "integer",
                nullable: true);

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
    }
}
