using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class CampaignEntityConfiguration : IEntityTypeConfiguration<CampaignModel>
    {
        public void Configure(EntityTypeBuilder<CampaignModel> builder)
        {
            builder.ToTable("Campaign");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasColumnName("Description")
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasMany(c => c.Characters)
                .WithOne(ch => ch.Campaign)
                .HasForeignKey("CampaignId")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Items)
                .WithOne(i => i.Campaign)
                .HasForeignKey("CampaignId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
