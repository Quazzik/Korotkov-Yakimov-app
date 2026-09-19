using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class User_is_not_USERs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "DefaultPresets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultPresets_UsersId",
                table: "DefaultPresets",
                newName: "IX_DefaultPresets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UserId",
                table: "DefaultPresets",
                column: "UserId",
                principalTable: "SuperUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UserId",
                table: "DefaultPresets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DefaultPresets",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultPresets_UserId",
                table: "DefaultPresets",
                newName: "IX_DefaultPresets_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets",
                column: "UsersId",
                principalTable: "SuperUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
