using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlagModeServer.Migrations
{
    /// <inheritdoc />
    public partial class addedLocalisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RuNameShihta",
                table: "ChargeCatalogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 1,
                column: "RuNameShihta",
                value: "агломерат а/ф № 2 и 3");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 2,
                column: "RuNameShihta",
                value: "агломерат а/ф № 4");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 3,
                column: "RuNameShihta",
                value: "окатыши ССГПО");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 4,
                column: "RuNameShihta",
                value: "ЛебГОК");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 5,
                column: "RuNameShihta",
                value: "КачГОК");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 6,
                column: "RuNameShihta",
                value: "МихГОК ");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 7,
                column: "RuNameShihta",
                value: "Сварочный шлак");

            migrationBuilder.UpdateData(
                table: "ChargeCatalogs",
                keyColumn: "ComponentID",
                keyValue: 8,
                column: "RuNameShihta",
                value: "Королёк");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RuNameShihta",
                table: "ChargeCatalogs");
        }
    }
}
