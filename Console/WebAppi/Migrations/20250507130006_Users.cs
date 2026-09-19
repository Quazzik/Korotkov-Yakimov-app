using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "DefaultPresets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SuperUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_UsersId",
                table: "DefaultPresets",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets",
                column: "UsersId",
                principalTable: "SuperUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultPresets_SuperUsers_UsersId",
                table: "DefaultPresets");

            migrationBuilder.DropTable(
                name: "SuperUsers");

            migrationBuilder.DropIndex(
                name: "IX_DefaultPresets_UsersId",
                table: "DefaultPresets");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "DefaultPresets");
        }
    }
}
