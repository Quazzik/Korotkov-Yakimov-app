using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlagModeServer.Migrations
{
    /// <inheritdoc />
    public partial class VariantName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VariantName",
                table: "VariantsParameters",
                type: "text",
                nullable: true);

            /*migrationBuilder.UpdateData(
                table: "VariantsParameters",
                keyColumn: "VariantID",
                keyValue: 1,
                column: "VariantName",
                value: null);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariantName",
                table: "VariantsParameters");
        }
    }
}
