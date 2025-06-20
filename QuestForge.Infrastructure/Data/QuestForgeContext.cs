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
        }
    }
}
