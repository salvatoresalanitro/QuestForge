using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class CharacterEntityConfiguration : IEntityTypeConfiguration<CharacterModel>
    {
        public void Configure(EntityTypeBuilder<CharacterModel> builder)
        {
            builder.ToTable("Characters");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(c => c.Level)
                .HasColumnName("Level")
                .IsRequired();

            builder.Property(c => c.HitPoints)
                .HasColumnName("HitPoints")
                .IsRequired();

            builder.Property(c => c.ArmorClass)
                .HasColumnName("ArmorClass")
                .IsRequired();

            builder.HasOne(c => c.Species)
                .WithMany()
                .HasForeignKey("SpeciesId");

            builder.HasOne(c => c.Class)
                .WithMany()
                .HasForeignKey("ClassId");

            builder.HasMany(c => c.Items)
                .WithOne(i => i.Character)
                .HasForeignKey("CharacterId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Campaign)
                .WithMany(ca => ca.Characters)
                .HasForeignKey("CampaignId");
        }
    }
}

