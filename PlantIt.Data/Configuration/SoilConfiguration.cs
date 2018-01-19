namespace PlantIt.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlantIt.Domain;

    public class SoilConfiguration : IEntityTypeConfiguration<Soil>
    {
        public void Configure(EntityTypeBuilder<Soil> builder)
        {
            builder.HasAlternateKey(e => e.Name);
        }
    }
}
