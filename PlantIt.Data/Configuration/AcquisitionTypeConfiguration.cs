namespace PlantIt.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlantIt.Domain;

    public class AcquisitionTypeConfiguration : IEntityTypeConfiguration<AcquisitionType>
    {
        public void Configure(EntityTypeBuilder<AcquisitionType> builder)
        {
            builder.HasAlternateKey(e => e.Name);
        }
    }
}
