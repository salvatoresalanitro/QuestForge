using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;

namespace QuestForge.Infrastructure.Data
{
    public class QuestForgeContext : DbContext
    {
        public QuestForgeContext(DbContextOptions<QuestForgeContext> options) : base(options) { }

        public DbSet<Campaign> Campaigns => Set<Campaign>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Enemy> Enemies => Set<Enemy>();
        public DbSet<Npc> Npcs => Set<Npc>();
        public DbSet<Species> Species => Set<Species>();
        public DbSet<Class> Classes => Set<Class>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>()
                .HasKey(campaign => campaign.Id);
            modelBuilder.Entity<Campaign>()
                .HasMany(campaign => campaign.Characters)
                .WithOne(character => character.Campaign)
                .HasForeignKey(character => character.CampaignId);
            modelBuilder.Entity<Campaign>()
                .HasMany(campaign => campaign.Items)
                .WithOne(item => item.Campaign)
                .HasForeignKey(item => item.CampaignId);
            modelBuilder.Entity<Campaign>()
                .HasMany(campaign => campaign.Npcs)
                .WithOne(npc => npc.Campaign)
                .HasForeignKey(npc => npc.CampaignId);
            modelBuilder.Entity<Campaign>()
                .HasMany(campaign => campaign.Enemies)
                .WithOne(enemy => enemy.Campaign)
                .HasForeignKey(enemy => enemy.CampaignId);

            modelBuilder.Entity<Character>()
                .HasKey(character => character.Id);
            modelBuilder.Entity<Character>()
                .HasOne(character => character.Campaign)
                .WithMany(campaign => campaign.Characters)
                .HasForeignKey(character => character.CampaignId);
            modelBuilder.Entity<Character>()
                .HasMany(character => character.Items)
                .WithOne(item => item.OwnerCharacter)
                .HasForeignKey(item => item.OwnerCharacterId);

            modelBuilder.Entity<Enemy>()
                .HasKey(enemy => enemy.Id);
            modelBuilder.Entity<Enemy>()
                .HasOne(enemy => enemy.Campaign)
                .WithMany(campaign => campaign.Enemies)
                .HasForeignKey(enemy => enemy.CampaignId);

            modelBuilder.Entity<Item>()
                .HasKey(item => item.Id);
            modelBuilder.Entity<Item>()
                .HasOne(item => item.Campaign)
                .WithMany(campaign => campaign.Items)
                .HasForeignKey(item => item.CampaignId);
            modelBuilder.Entity<Item>()
                .HasOne(item => item.OwnerCharacter)
                .WithMany(character => character.Items)
                .HasForeignKey(item => item.OwnerCharacterId);

            modelBuilder.Entity<Npc>()
                .HasKey(npc => npc.Id);
            modelBuilder.Entity<Npc>()
                .HasOne(npc => npc.Campaign)
                .WithMany(campaign => campaign.Npcs)
                .HasForeignKey(npc => npc.CampaignId);

            modelBuilder.Entity<Class>().HasData(
                new Class(1, "Barbarian"),
                new Class(2, "Bard"),
                new Class(3, "Cleric"),
                new Class(4, "Druid"),
                new Class(5, "Fighter"),
                new Class(6, "Monk"),
                new Class(7, "Paladin"),
                new Class(8, "Ranger"),
                new Class(9, "Rogue"),
                new Class(10, "Sorcerer"),
                new Class(11, "Warlock"),
                new Class(12, "Wizard")
            );

            modelBuilder.Entity<Species>().HasData(
                new Species(1, "Aasimar"),
                new Species(2, "Dragonborn"),
                new Species(3, "Dwarf"),
                new Species(4, "Elf"),
                new Species(5, "Gnome"),
                new Species(6, "Goliath"),
                new Species(7, "Halfling"),
                new Species(8, "Human"),
                new Species(9, "Orc"),
                new Species(10, "Tiefling")
            );
        }
    }
}
