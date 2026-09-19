using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class Remove_MMKCoef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_MmkCoefs_MmkCoefId",
                table: "DefaultPresets");

            migrationBuilder.DropIndex(
                name: "IX_DefaultPresets_MmkCoefId",
                table: "DefaultPresets");

            migrationBuilder.DropColumn(
                name: "MmkCoefId",
                table: "DefaultPresets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MmkCoefId",
                table: "DefaultPresets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_MmkCoefId",
                table: "DefaultPresets",
                column: "MmkCoefId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_MmkCoefs_MmkCoefId",
                table: "DefaultPresets",
                column: "MmkCoefId",
                principalTable: "MmkCoefs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
