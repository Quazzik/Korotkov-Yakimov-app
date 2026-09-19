using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class Remove_MMKCoef2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MmkCoefs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MmkCoefs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Al2O3Coef = table.Column<double>(type: "double precision", nullable: false),
                    CaOCoef = table.Column<double>(type: "double precision", nullable: false),
                    FeCoef = table.Column<double>(type: "double precision", nullable: false),
                    MgOCoef = table.Column<double>(type: "double precision", nullable: false),
                    MnOCoef = table.Column<double>(type: "double precision", nullable: false),
                    PCoef = table.Column<double>(type: "double precision", nullable: false),
                    PMPPCoef = table.Column<double>(type: "double precision", nullable: false),
                    SCoef = table.Column<double>(type: "double precision", nullable: false),
                    SiO2Coef = table.Column<double>(type: "double precision", nullable: false),
                    TiO2Coef = table.Column<double>(type: "double precision", nullable: false),
                    ZnCoef = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MmkCoefs", x => x.ID);
                });
        }
    }
}
