using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Configurations
{
    public class ClassEntityConfiguration : IEntityTypeConfiguration<ClassModel>
    {
        public void Configure(EntityTypeBuilder<ClassModel> builder)
        {
            builder.ToTable("Class");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .HasColumnName("Id")
               .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.HasMany(c => c.SubClasses)
                .WithOne(s => s.Class)
                .HasForeignKey(s => s.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
