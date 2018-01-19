using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantIt.Domain;

namespace PlantIt.Data.Configuration
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasOne(s => s.Category).WithMany(c => c.Species).HasForeignKey(s => s.CategoryId);

            builder.HasOne(s => s.Family).WithMany(f => f.Species).HasForeignKey(s => s.FamilyId);

            builder.HasOne(s => s.Genus).WithMany(g => g.Species).HasForeignKey(s => s.GenusId);

            builder.HasAlternateKey(e => new { e.Name, e.Distribution});
        }
    }
}
