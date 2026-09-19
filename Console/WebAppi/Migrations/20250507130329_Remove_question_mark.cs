using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class Remove_question_mark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "DefaultPresets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets",
                column: "UsersId",
                principalTable: "SuperUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "DefaultPresets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets",
                column: "UsersId",
                principalTable: "SuperUsers",
                principalColumn: "Id");
        }
    }
}
