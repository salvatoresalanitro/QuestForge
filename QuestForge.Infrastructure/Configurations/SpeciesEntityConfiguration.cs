using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class SpeciesEntityConfiguration : IEntityTypeConfiguration<SpeciesModel>
    {
        public void Configure(EntityTypeBuilder<SpeciesModel> builder)
        {
            builder.ToTable("Species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired();

            builder.HasMany(s => s.AllSubSpecies)
                   .WithOne(ss => ss.Species)
                   .HasForeignKey(ss => ss.SpeciesId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
