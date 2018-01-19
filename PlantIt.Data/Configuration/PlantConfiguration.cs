namespace PlantIt.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlantIt.Domain;

    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasOne(p => p.Species).WithMany(s => s.Plants).HasForeignKey(p => p.SpeciesId);

            builder.HasOne(p => p.AcquisitionType).WithMany(a => a.Plants).HasForeignKey(p => p.AcquisitionTypeId);

            builder.HasOne(p => p.Location).WithMany(l => l.Plants).HasForeignKey(p => p.LocationId);

            builder.HasOne(p => p.Soil).WithMany(s => s.Plants).HasForeignKey(p => p.SoilId);

            builder.HasOne(p => p.Vendor).WithMany(v => v.Plants).HasForeignKey(p => p.VendorId);
        }
    }
}
