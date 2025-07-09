using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class ItemTypeEntityConfiguration : IEntityTypeConfiguration<ItemTypeModel>
    {
        public void Configure(EntityTypeBuilder<ItemTypeModel> builder)
        {
            builder.ToTable("ItemType");

            builder.HasKey(it => it.Id);

            builder.Property(it => it.Id)
               .HasColumnName("Id")
               .ValueGeneratedNever();

            builder.Property(it => it.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.HasMany(it => it.Items)
                .WithOne(i => i.Type)
                .HasForeignKey(i => i.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
