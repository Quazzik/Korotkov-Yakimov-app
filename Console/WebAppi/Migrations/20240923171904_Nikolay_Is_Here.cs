using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAppi.Migrations
{
    /// <inheritdoc />
    public partial class Nikolay_Is_Here : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Cocsicks",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Weight = table.Column<double>(type: "double precision", nullable: false),
            //        PercentZola = table.Column<double>(type: "double precision", nullable: false),
            //        PercentSera = table.Column<double>(type: "double precision", nullable: false),
            //        PercentValotiles = table.Column<double>(type: "double precision", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cocsicks", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FluxAdditions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        IzvestnyakCaO = table.Column<double>(type: "double precision", nullable: false),
            //        IzvestnyakSiO2 = table.Column<double>(type: "double precision", nullable: false),
            //        IzvestnyakAl2O3 = table.Column<double>(type: "double precision", nullable: false),
            //        IzvestnyakMgO = table.Column<double>(type: "double precision", nullable: false),
            //        DolomyteCaO = table.Column<double>(type: "double precision", nullable: false),
            //        DolomyteSiO2 = table.Column<double>(type: "double precision", nullable: false),
            //        DolomyteAl2O3 = table.Column<double>(type: "double precision", nullable: false),
            //        DolomyteMgO = table.Column<double>(type: "double precision", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FluxAdditions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MmkCoefs",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        FeCoef = table.Column<double>(type: "double precision", nullable: false),
            //        SCoef = table.Column<double>(type: "double precision", nullable: false),
            //        PCoef = table.Column<double>(type: "double precision", nullable: false),
            //        CaOCoef = table.Column<double>(type: "double precision", nullable: false),
            //        SiO2Coef = table.Column<double>(type: "double precision", nullable: false),
            //        Al2O3Coef = table.Column<double>(type: "double precision", nullable: false),
            //        MgOCoef = table.Column<double>(type: "double precision", nullable: false),
            //        MnOCoef = table.Column<double>(type: "double precision", nullable: false),
            //        TiO2Coef = table.Column<double>(type: "double precision", nullable: false),
            //        ZnCoef = table.Column<double>(type: "double precision", nullable: false),
            //        PMPPCoef = table.Column<double>(type: "double precision", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MmkCoefs", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StartEnters",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        osnovnost = table.Column<double>(type: "double precision", nullable: false),
            //        FeOinAgl = table.Column<double>(type: "double precision", nullable: false),
            //        DolomyteInAgl = table.Column<double>(type: "double precision", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StartEnters", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ZolaOfCocsicks",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Fe = table.Column<double>(type: "double precision", nullable: false),
            //        CaO = table.Column<double>(type: "double precision", nullable: false),
            //        SiO2 = table.Column<double>(type: "double precision", nullable: false),
            //        Al2O3 = table.Column<double>(type: "double precision", nullable: false),
            //        MgO = table.Column<double>(type: "double precision", nullable: false),
            //        P = table.Column<double>(type: "double precision", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ZolaOfCocsicks", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DefaultPresets",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        ZolaOfCocsickId = table.Column<int>(type: "integer", nullable: false),
            //        CocksickId = table.Column<int>(type: "integer", nullable: false),
            //        FluxAdditionsId = table.Column<int>(type: "integer", nullable: false),
            //        MmkCoefId = table.Column<int>(type: "integer", nullable: false),
            //        StartEnterId = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DefaultPresets", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DefaultPresets_Cocsicks_CocksickId",
            //            column: x => x.CocksickId,
            //            principalTable: "Cocsicks",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DefaultPresets_FluxAdditions_FluxAdditionsId",
            //            column: x => x.FluxAdditionsId,
            //            principalTable: "FluxAdditions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DefaultPresets_MmkCoefs_MmkCoefId",
            //            column: x => x.MmkCoefId,
            //            principalTable: "MmkCoefs",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DefaultPresets_StartEnters_StartEnterId",
            //            column: x => x.StartEnterId,
            //            principalTable: "StartEnters",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DefaultPresets_ZolaOfCocsicks_ZolaOfCocsickId",
            //            column: x => x.ZolaOfCocsickId,
            //            principalTable: "ZolaOfCocsicks",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "ShihtaComponents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PresetId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Wet = table.Column<double>(type: "double precision", nullable: false),
                    PMPP = table.Column<double>(type: "double precision", nullable: false),
                    Fe = table.Column<double>(type: "double precision", nullable: false),
                    FeO = table.Column<double>(type: "double precision", nullable: false),
                    CaO = table.Column<double>(type: "double precision", nullable: false),
                    SiO2 = table.Column<double>(type: "double precision", nullable: false),
                    MgO = table.Column<double>(type: "double precision", nullable: false),
                    Al2O3 = table.Column<double>(type: "double precision", nullable: false),
                    TiO2 = table.Column<double>(type: "double precision", nullable: false),
                    S = table.Column<double>(type: "double precision", nullable: false),
                    P = table.Column<double>(type: "double precision", nullable: false),
                    Cr = table.Column<double>(type: "double precision", nullable: false),
                    Zn = table.Column<double>(type: "double precision", nullable: false),
                    MnO = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShihtaComponents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShihtaComponents_DefaultPresets_PresetId",
                        column: x => x.PresetId,
                        principalTable: "DefaultPresets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_CocksickId",
                table: "DefaultPresets",
                column: "CocksickId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_FluxAdditionsId",
                table: "DefaultPresets",
                column: "FluxAdditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_MmkCoefId",
                table: "DefaultPresets",
                column: "MmkCoefId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_StartEnterId",
                table: "DefaultPresets",
                column: "StartEnterId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPresets_ZolaOfCocsickId",
                table: "DefaultPresets",
                column: "ZolaOfCocsickId");

            migrationBuilder.CreateIndex(
                name: "IX_ShihtaComponents_PresetId",
                table: "ShihtaComponents",
                column: "PresetId");
        }

/*        / <inheritdoc />*/
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShihtaComponents");

            migrationBuilder.DropTable(
                name: "DefaultPresets");

            migrationBuilder.DropTable(
                name: "Cocsicks");

            migrationBuilder.DropTable(
                name: "FluxAdditions");

            migrationBuilder.DropTable(
                name: "MmkCoefs");

            migrationBuilder.DropTable(
                name: "StartEnters");

            migrationBuilder.DropTable(
                name: "ZolaOfCocsicks");
        }
    }
}
