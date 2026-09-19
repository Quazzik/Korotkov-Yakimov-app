using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class DefaultPreset_CreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DefaultPresets",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DefaultPresets");
        }
    }
}
