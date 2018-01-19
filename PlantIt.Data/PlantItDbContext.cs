namespace PlantIt.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PlantIt.Data.Configuration;
    using PlantIt.Domain;

    public class PlantItDbContext : IdentityDbContext<User>
    {
        public DbSet<AcquisitionType> AcquisitionTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<Genus> Genera { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<Soil> Soils { get; set; }

        public DbSet<Species> Species { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public PlantItDbContext(DbContextOptions<PlantItDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AcquisitionTypeConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new FamilyConfiguration());

            builder.ApplyConfiguration(new GenusConfiguration());

            builder.ApplyConfiguration(new LocationConfiguration());

            builder.ApplyConfiguration(new SoilConfiguration());

            builder.ApplyConfiguration(new PlantConfiguration());

            builder.ApplyConfiguration(new SpeciesConfiguration());

            builder.ApplyConfiguration(new VendorConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
