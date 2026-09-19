using Microsoft.EntityFrameworkCore;
using WebAppi.Entities;


namespace WebAppi.Sevices
{
    public class SuperDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<CocksickDB> Cocsicks { get; set; }
        public DbSet<FluxAdditionsDB> FluxAdditions { get; set; }
        public DbSet<StartEnterDB> StartEnters { get; set; }
        public DbSet<ZolaOfCocsickDB> ZolaOfCocsicks { get; set; }
        public DbSet<ShihtaComponentsDB> ShihtaComponents { get; set; }
        public DbSet<DefaultPreset> DefaultPresets { get; set; }
        public DbSet<UserDB> SuperUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShihtaComponentsDB>()
                .HasOne(x => x.Preset)
                .WithMany(x => x.ShihtaComponents);

            base.OnModelCreating(modelBuilder);
        }


    }
}
