using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlagModeServer.Migrations
{
    /// <inheritdoc />
    public partial class theNewestInitEver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlastFurnaces",
                columns: table => new
                {
                    FurnaceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlastFurnaces", x => x.FurnaceID);
                });

            migrationBuilder.CreateTable(
                name: "ChargeCatalogs",
                columns: table => new
                {
                    ComponentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameShihta = table.Column<string>(type: "text", nullable: false),
                    Fe = table.Column<double>(type: "double precision", nullable: false),
                    FeO = table.Column<double>(type: "double precision", nullable: false),
                    Fe2O3 = table.Column<double>(type: "double precision", nullable: false),
                    SiO2 = table.Column<double>(type: "double precision", nullable: false),
                    Al2O3 = table.Column<double>(type: "double precision", nullable: false),
                    CaO = table.Column<double>(type: "double precision", nullable: false),
                    MgO = table.Column<double>(type: "double precision", nullable: false),
                    S = table.Column<double>(type: "double precision", nullable: false),
                    MnO = table.Column<double>(type: "double precision", nullable: false),
                    Zn = table.Column<double>(type: "double precision", nullable: false),
                    Pmpp = table.Column<double>(type: "double precision", nullable: false),
                    H2O = table.Column<double>(type: "double precision", nullable: false),
                    TiO2 = table.Column<double>(type: "double precision", nullable: false),
                    Cr = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeCatalogs", x => x.ComponentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "VariantsParameters",
                columns: table => new
                {
                    VariantID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    DateVariant = table.Column<string>(type: "text", nullable: false),
                    BlastFurnaceID = table.Column<int>(type: "integer", nullable: false),
                    IronProduction = table.Column<double>(type: "double precision", nullable: false),
                    CokeConsumption = table.Column<double>(type: "double precision", nullable: false),
                    SlagOutput = table.Column<double>(type: "double precision", nullable: false),
                    DustRemoval = table.Column<double>(type: "double precision", nullable: false),
                    BlowPressure = table.Column<double>(type: "double precision", nullable: false),
                    BlowTemperature = table.Column<double>(type: "double precision", nullable: false),
                    BlowMoisture = table.Column<double>(type: "double precision", nullable: false),
                    BlowO2 = table.Column<double>(type: "double precision", nullable: false),
                    NaturalGasConsumption = table.Column<double>(type: "double precision", nullable: false),
                    IronTemperature = table.Column<double>(type: "double precision", nullable: false),
                    IronSi = table.Column<double>(type: "double precision", nullable: false),
                    IronS = table.Column<double>(type: "double precision", nullable: false),
                    IronMn = table.Column<double>(type: "double precision", nullable: false),
                    IronC = table.Column<double>(type: "double precision", nullable: false),
                    IronP = table.Column<double>(type: "double precision", nullable: false),
                    IronTi = table.Column<double>(type: "double precision", nullable: false),
                    SlagSiO2 = table.Column<double>(type: "double precision", nullable: false),
                    SlagCaO = table.Column<double>(type: "double precision", nullable: false),
                    SlagAl2O3 = table.Column<double>(type: "double precision", nullable: false),
                    SlagMgO = table.Column<double>(type: "double precision", nullable: false),
                    SlagS = table.Column<double>(type: "double precision", nullable: false),
                    SlagTiO2 = table.Column<double>(type: "double precision", nullable: false),
                    CokeAsh = table.Column<double>(type: "double precision", nullable: false),
                    CokeS = table.Column<double>(type: "double precision", nullable: false),
                    CokeVolatile = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshFe = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshCaO = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshSiO2 = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshAl2O3 = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshMgO = table.Column<double>(type: "double precision", nullable: false),
                    CokeAshP = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantsParameters", x => x.VariantID);
                    table.ForeignKey(
                        name: "FK_VariantsParameters_BlastFurnaces_BlastFurnaceID",
                        column: x => x.BlastFurnaceID,
                        principalTable: "BlastFurnaces",
                        principalColumn: "FurnaceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantsParameters_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantCharges",
                columns: table => new
                {
                    VariantID = table.Column<int>(type: "integer", nullable: false),
                    ComponentID = table.Column<int>(type: "integer", nullable: false),
                    Consumption = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaType = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaFe = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaFeO = table.Column<double>(type: "double precision", nullable: false),
                    Fe2O3 = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaSiO2 = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaAl2O3 = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaCaO = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaMgO = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaP = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaS = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaMnO = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaZn = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaPmpp = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaH2O = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaTiO2 = table.Column<double>(type: "double precision", nullable: false),
                    ShihtaCr = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantCharges", x => new { x.VariantID, x.ComponentID });
                    table.ForeignKey(
                        name: "FK_VariantCharges_ChargeCatalogs_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "ChargeCatalogs",
                        principalColumn: "ComponentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantCharges_VariantsParameters_VariantID",
                        column: x => x.VariantID,
                        principalTable: "VariantsParameters",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlastFurnaces",
                columns: new[] { "FurnaceID", "Name" },
                values: new object[] { 1, "TestBF" });

            migrationBuilder.InsertData(
                table: "ChargeCatalogs",
                columns: new[] { "ComponentID", "Al2O3", "CaO", "Cr", "Fe", "Fe2O3", "FeO", "H2O", "MgO", "MnO", "NameShihta", "Pmpp", "S", "SiO2", "TiO2", "Zn" },
                values: new object[,]
                {
                    { 1, 1.75, 8.7200000000000006, 0.0, 58.5, 0.0, 0.0, 0.0, 1.6299999999999999, 0.19, "Agglomerate23", 0.0, 0.028000000000000001, 5.8799999999999999, 0.23999999999999999, 0.0 },
                    { 2, 1.76, 8.8599999999999994, 0.0, 58.299999999999997, 0.0, 0.0, 0.0, 1.6399999999999999, 0.19, "Agglomerate4", 0.0, 0.028000000000000001, 5.9500000000000002, 0.23999999999999999, 0.0 },
                    { 3, 1.21, 4.0199999999999996, 0.0, 62.600000000000001, 0.0, 0.0, 0.0, 0.98999999999999999, 0.16, "Ssgpo", 0.0, 0.067000000000000004, 3.7000000000000002, 0.32000000000000001, 0.0 },
                    { 4, 0.25, 0.40000000000000002, 0.0, 65.700000000000003, 0.0, 0.0, 0.0, 0.22, 0.050000000000000003, "Lebedinskiy", 0.0, 0.01, 5.1699999999999999, 0.0, 0.0 },
                    { 5, 2.5899999999999999, 1.28, 0.0, 60.399999999999999, 0.0, 0.0, 0.0, 2.8999999999999999, 0.23000000000000001, "Kachkanarsiy", 0.0, 0.02, 4.3600000000000003, 2.6600000000000001, 0.0 },
                    { 6, 0.23000000000000001, 1.49, 0.0, 63.299999999999997, 0.0, 0.0, 0.0, 0.25, 0.040000000000000001, "Mixailovskiy", 0.0, 0.01, 7.25, 0.0, 0.0 },
                    { 7, 0.73999999999999999, 0.25, 0.0, 69.799999999999997, 0.0, 0.0, 0.0, 0.39000000000000001, 0.83999999999999997, "WeldSlag", 0.0, 0.02, 4.2999999999999998, 0.0, 0.0 },
                    { 8, 2.0, 8.5, 0.0, 68.400000000000006, 0.0, 0.0, 0.0, 3.1000000000000001, 0.97999999999999998, "MinimalIncludes", 0.0, 0.11, 6.7999999999999998, 0.34000000000000002, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Login", "Password" },
                values: new object[] { 1, "Login", "Password" });

            migrationBuilder.InsertData(
                table: "VariantsParameters",
                columns: new[] { "VariantID", "BlastFurnaceID", "BlowMoisture", "BlowO2", "BlowPressure", "BlowTemperature", "CokeAsh", "CokeAshAl2O3", "CokeAshCaO", "CokeAshFe", "CokeAshMgO", "CokeAshP", "CokeAshSiO2", "CokeConsumption", "CokeS", "CokeVolatile", "DateVariant", "DustRemoval", "IronC", "IronMn", "IronP", "IronProduction", "IronS", "IronSi", "IronTemperature", "IronTi", "NaturalGasConsumption", "SlagAl2O3", "SlagCaO", "SlagMgO", "SlagOutput", "SlagS", "SlagSiO2", "SlagTiO2", "UserID" },
                values: new object[] { 1, 1, 0.0, 0.0, 0.0, 0.0, 12.699999999999999, 24.600000000000001, 7.7999999999999998, 0.0, 2.0, 0.0, 48.100000000000001, 419.80000000000001, 0.42799999999999999, 0.0, "2024-07-25 12:07:00", 0.0, 4.702, 0.20000000000000001, 0.0, 0.0, 0.016, 0.51200000000000001, 1450.0, 0.0, 0.0, 11.43, 40.899999999999999, 7.3920000000000003, 0.0, 0.0, 36.560000000000002, 0.01, 1 });

            migrationBuilder.InsertData(
                table: "VariantCharges",
                columns: new[] { "ComponentID", "VariantID", "Consumption", "Fe2O3", "ShihtaAl2O3", "ShihtaCaO", "ShihtaCr", "ShihtaFe", "ShihtaFeO", "ShihtaH2O", "ShihtaMgO", "ShihtaMnO", "ShihtaP", "ShihtaPmpp", "ShihtaS", "ShihtaSiO2", "ShihtaTiO2", "ShihtaType", "ShihtaZn" },
                values: new object[,]
                {
                    { 1, 1, 441.5, 0.0, 1.75, 8.7200000000000006, 0.0, 58.5, 0.0, 0.0, 1.6299999999999999, 0.19, 0.0, 0.0, 0.028000000000000001, 5.8799999999999999, 0.23999999999999999, 0.0, 0.0 },
                    { 2, 1, 485.89999999999998, 0.0, 1.76, 8.8599999999999994, 0.0, 58.299999999999997, 0.0, 0.0, 1.6399999999999999, 0.19, 0.0, 0.0, 0.028000000000000001, 5.9500000000000002, 0.23999999999999999, 0.0, 0.0 },
                    { 3, 1, 568.70000000000005, 0.0, 1.21, 4.0199999999999996, 0.0, 62.600000000000001, 0.0, 0.0, 0.98999999999999999, 0.16, 0.0, 0.0, 0.067000000000000004, 3.7000000000000002, 0.32000000000000001, 0.0, 0.0 },
                    { 4, 1, 54.700000000000003, 0.0, 0.25, 0.40000000000000002, 0.0, 65.700000000000003, 0.0, 0.0, 0.22, 0.050000000000000003, 0.0, 0.0, 0.01, 5.1699999999999999, 0.0, 0.0, 0.0 },
                    { 5, 1, 54.100000000000001, 0.0, 2.5899999999999999, 1.28, 0.0, 60.399999999999999, 0.0, 0.0, 2.8999999999999999, 0.23000000000000001, 0.0, 0.0, 0.02, 4.3600000000000003, 2.6600000000000001, 0.0, 0.0 },
                    { 6, 1, 48.5, 0.0, 0.23000000000000001, 1.49, 0.0, 63.299999999999997, 0.0, 0.0, 0.25, 0.040000000000000001, 0.0, 0.0, 0.01, 7.25, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariantCharges_ComponentID",
                table: "VariantCharges",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_VariantCharges_VariantID_ComponentID",
                table: "VariantCharges",
                columns: new[] { "VariantID", "ComponentID" });

            migrationBuilder.CreateIndex(
                name: "IX_VariantsParameters_BlastFurnaceID",
                table: "VariantsParameters",
                column: "BlastFurnaceID");

            migrationBuilder.CreateIndex(
                name: "IX_VariantsParameters_UserID_BlastFurnaceID",
                table: "VariantsParameters",
                columns: new[] { "UserID", "BlastFurnaceID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariantCharges");

            migrationBuilder.DropTable(
                name: "ChargeCatalogs");

            migrationBuilder.DropTable(
                name: "VariantsParameters");

            migrationBuilder.DropTable(
                name: "BlastFurnaces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
