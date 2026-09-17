using Microsoft.EntityFrameworkCore;
using SlagModeServer.entities.NewStructure;
using SlagModeServer.enums;

namespace SlagModeServer.Services
{
    public class SlagSolverDbContext : DbContext
    {
        public SlagSolverDbContext(DbContextOptions opt) : base(opt) { }
        #region SlagMode
        public DbSet<Users> Users { get; set; }
        public DbSet<BlastFurnaces> BlastFurnaces{ get; set; }
        public DbSet<VariantsParameter> VariantsParameters{ get; set; }
        public DbSet<ShihtaCatalog> ChargeCatalogs { get; set; }
        public DbSet<VariantCharges> VariantCharges { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().Property(x => x.UserID).ValueGeneratedOnAdd();
            modelBuilder.Entity<BlastFurnaces>().Property(x => x.FurnaceID).ValueGeneratedOnAdd();
            modelBuilder.Entity<VariantsParameter>().Property(x => x.VariantID).ValueGeneratedOnAdd();
            modelBuilder.Entity<VariantCharges>().HasKey(x => new { x.VariantID, x.ComponentID });
            modelBuilder.Entity<ShihtaCatalog>().Property(x => x.ComponentID).ValueGeneratedOnAdd();
            modelBuilder.Entity<VariantCharges>().HasIndex(x => new {x.VariantID, x.ComponentID});
            modelBuilder.Entity<VariantsParameter>().HasIndex(x => new {x.UserID, x.BlastFurnaceID});

            modelBuilder.Entity<VariantCharges>().HasData(
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 1,
                    Consumption = 441.5,
                    ShihtaFe = 58.5,
                    ShihtaSiO2 = 5.88,
                    ShihtaAl2O3 = 1.75,
                    ShihtaCaO = 8.72,
                    ShihtaMgO = 1.63,
                    ShihtaS = 0.028,
                    ShihtaMnO = 0.19,
                    ShihtaTiO2 = 0.24
                },
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 2,
                    Consumption = 485.9,
                    ShihtaFe = 58.3,
                    ShihtaSiO2 = 5.95,
                    ShihtaAl2O3 = 1.76,
                    ShihtaCaO = 8.86,
                    ShihtaMgO = 1.64,
                    ShihtaS = 0.028,
                    ShihtaMnO = 0.19,
                    ShihtaTiO2 = 0.24
                },
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 3,
                    Consumption = 568.7,
                    ShihtaFe = 62.6,
                    ShihtaSiO2 = 3.7,
                    ShihtaAl2O3 = 1.21,
                    ShihtaCaO = 4.02,
                    ShihtaMgO = 0.99,
                    ShihtaS = 0.067,
                    ShihtaMnO = 0.16,
                    ShihtaTiO2 = 0.32
                },
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 4,
                    Consumption = 54.7,
                    ShihtaFe = 65.7,
                    ShihtaSiO2 = 5.17,
                    ShihtaAl2O3 = 0.25,
                    ShihtaCaO = 0.4,
                    ShihtaMgO = 0.22,
                    ShihtaS = 0.01,
                    ShihtaMnO = 0.05,
                    ShihtaTiO2 = 0
                },
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 5,
                    Consumption = 54.1,
                    ShihtaFe = 60.40,
                    ShihtaSiO2 = 4.36,
                    ShihtaAl2O3 = 2.59,
                    ShihtaCaO = 1.28,
                    ShihtaMgO = 2.9,
                    ShihtaS = 0.02,
                    ShihtaMnO = 0.23,
                    ShihtaTiO2 = 2.66,
                },
                new VariantCharges
                {
                    VariantID = 1,
                    ComponentID = 6,
                    Consumption = 48.5,
                    ShihtaFe = 63.3,
                    ShihtaSiO2 = 7.25,
                    ShihtaAl2O3 = 0.23,
                    ShihtaCaO = 1.49,
                    ShihtaMgO = 0.25,
                    ShihtaS = 0.01,
                    ShihtaMnO = 0.04,
                    ShihtaTiO2 = 0
                }
                );

            modelBuilder.Entity<BlastFurnaces>().HasData(
                new BlastFurnaces
                {
                    FurnaceID = 1,
                    Name = "TestBF"
                });

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserID = 1,
                    Login = "Login",
                    Password = "Password"
                });

            modelBuilder.Entity<VariantsParameter>().HasData(
                new VariantsParameter
                {
                    VariantID = 1,
                    UserID = 1,
                    DateVariant = "2024-07-25 12:07:00",
                    BlastFurnaceID = 1,
                    IronSi = 0.512,
                    IronS = 0.016,
                    IronMn = 0.2,
                    IronC = 4.702,
                    IronTi = 0,
                    SlagCaO = 40.9,
                    SlagSiO2 = 36.56,
                    SlagTiO2 = 0.01,
                    CokeConsumption = 419.8,
                    CokeS = 0.428,
                    CokeAsh = 12.7,
                    CokeAshCaO = 7.8,
                    CokeAshSiO2 = 48.1,
                    CokeAshAl2O3 = 24.6,
                    CokeAshMgO = 2,
                    IronTemperature = 1450,
                    SlagAl2O3 = 11.43,
                    SlagMgO = 7.392,
                }
                );

            modelBuilder.Entity<ShihtaCatalog>().HasData(
                new ShihtaCatalog
                {
                    ComponentID = 1,
                    NameShihta = MaterialTypes.Agglomerate23.ToString(),
                    Fe = 58.5,
                    SiO2 = 5.88,
                    Al2O3 = 1.75,
                    CaO = 8.72,
                    MgO = 1.63,
                    S = 0.028,
                    MnO = 0.19,
                    TiO2 = 0.24,
                    RuNameShihta = "агломерат а/ф № 2 и 3"
                },
                new ShihtaCatalog
                {
                    ComponentID = 2,
                    NameShihta = MaterialTypes.Agglomerate4.ToString(),
                    Fe = 58.3,
                    SiO2 = 5.95,
                    Al2O3 = 1.76,
                    CaO = 8.86,
                    MgO = 1.64,
                    S = 0.028,
                    MnO = 0.19,
                    TiO2 = 0.24,
                    RuNameShihta = "агломерат а/ф № 4"
                },
                new ShihtaCatalog
                {
                    ComponentID = 3,
                    NameShihta = MaterialTypes.Ssgpo.ToString(),
                    Fe = 62.6,
                    SiO2 = 3.7,
                    Al2O3 = 1.21,
                    CaO = 4.02,
                    MgO = 0.99,
                    S = 0.067,
                    MnO = 0.16,
                    TiO2 = 0.32,
                    RuNameShihta = "окатыши ССГПО"
                },
                new ShihtaCatalog
                {
                    ComponentID = 4,
                    NameShihta = MaterialTypes.Lebedinskiy.ToString(),
                    Fe = 65.7,
                    SiO2 = 5.17,
                    Al2O3 = 0.25,
                    CaO = 0.4,
                    MgO = 0.22,
                    S = 0.01,
                    MnO = 0.05,
                    RuNameShihta = "ЛебГОК"
                },
                new ShihtaCatalog
                {
                    ComponentID = 5,
                    NameShihta = MaterialTypes.Kachkanarsiy.ToString(),
                    Fe = 60.40,
                    SiO2 = 4.36,
                    Al2O3 = 2.59,
                    CaO = 1.28,
                    MgO = 2.9,
                    S = 0.02,
                    MnO = 0.23,
                    TiO2 = 2.66,
                    RuNameShihta = "КачГОК"
                },
                new ShihtaCatalog
                {
                    ComponentID = 6,
                    NameShihta = MaterialTypes.Mixailovskiy.ToString(),
                    Fe = 63.3,
                    SiO2 = 7.25,
                    Al2O3 = 0.23,
                    CaO = 1.49,
                    MgO = 0.25,
                    S = 0.01,
                    MnO = 0.04,
                    RuNameShihta = "МихГОК "
                },
                new ShihtaCatalog
                {
                    ComponentID = 7,
                    NameShihta = MaterialTypes.WeldSlag.ToString(),
                    Fe = 69.8,
                    SiO2 = 4.3,
                    Al2O3 = 0.74,
                    CaO = 0.25,
                    MgO = 0.39,
                    S = 0.02,
                    MnO = 0.84,
                    RuNameShihta = "Сварочный шлак"
                },
                new ShihtaCatalog
                {
                    ComponentID = 8,
                    NameShihta = MaterialTypes.MinimalIncludes.ToString(),
                    Fe = 68.4,
                    SiO2 = 6.8,
                    Al2O3 = 2,
                    CaO = 8.5,
                    MgO = 3.1,
                    S = 0.11,
                    MnO = 0.98,
                    TiO2 = 0.34,
                    RuNameShihta = "Королёк"
                }
                );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
