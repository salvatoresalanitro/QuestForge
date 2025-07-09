using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class SubClassEntityConfiguration : IEntityTypeConfiguration<SubClassModel>
    {
        public void Configure(EntityTypeBuilder<SubClassModel> builder)
        {
            builder.ToTable("SubClass");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
               .HasColumnName("Id")
               .ValueGeneratedNever();

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.HasOne(s => s.Class)
                .WithMany(c => c.SubClasses)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
