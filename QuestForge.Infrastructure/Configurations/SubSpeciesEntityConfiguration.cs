using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class SubSpeciesEntityConfiguration : IEntityTypeConfiguration<SubSpeciesModel>
    {
        public void Configure(EntityTypeBuilder<SubSpeciesModel> builder)
        {
            builder.ToTable("SubSpecies");

            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.Name)
                .IsRequired();

            builder.HasOne(ss => ss.Species)
                .WithMany(s => s.AllSubSpecies)
                .HasForeignKey(ss => ss.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
