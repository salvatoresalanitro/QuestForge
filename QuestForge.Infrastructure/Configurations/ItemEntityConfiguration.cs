using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Description)
                .HasColumnName("Description")
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(i => i.TypeId)
                .HasColumnName("TypeId")
                .IsRequired();

            builder.HasOne(i => i.Type)
                .WithMany(t => t.Items)
                .HasForeignKey(i => i.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Character)
                .WithMany(c => c.Items)
                .HasForeignKey("CharacterId")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Campaign)
                .WithMany(ca => ca.Items)
                .HasForeignKey("CampaignId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
