using Microsoft.EntityFrameworkCore;
using QuestForge.Infrastructure.Configurations;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Data
{
    public class QuestForgeContext : DbContext
    {
        public QuestForgeContext(DbContextOptions<QuestForgeContext> options) : base(options) { }

        public DbSet<CampaignModel> Campaigns { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<ItemModel> Items {  get; set; }
        public DbSet<SpeciesModel> AllSpecies { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<SubSpeciesModel> AllSubSpecies { get; set; }
        public DbSet<SubClassModel> SubClasses { get; set; }
        public DbSet<ItemTypeModel> ItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SpeciesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubSpeciesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubClassEntityConfiguration());
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Campaign>()
            //    .HasKey(campaign => campaign.Id);
            //modelBuilder.Entity<Campaign>()
            //    .HasMany(campaign => campaign.Characters)
            //    .WithOne(character => character.Campaign)
            //    .HasForeignKey(character => character.CampaignId);
            //modelBuilder.Entity<Campaign>()
            //    .HasMany(campaign => campaign.Items)
            //    .WithOne(item => item.Campaign)
            //    .HasForeignKey(item => item.CampaignId);
            //modelBuilder.Entity<Campaign>()
            //    .HasMany(campaign => campaign.Npcs)
            //    .WithOne(npc => npc.Campaign)
            //    .HasForeignKey(npc => npc.CampaignId);
            //modelBuilder.Entity<Campaign>()
            //    .HasMany(campaign => campaign.Enemies)
            //    .WithOne(enemy => enemy.Campaign)
            //    .HasForeignKey(enemy => enemy.CampaignId);

            //modelBuilder.Entity<Item>()
            //    .HasKey(item => item.Id);
            //modelBuilder.Entity<Item>()
            //    .HasOne(item => item.Campaign)
            //    .WithMany(campaign => campaign.Items)
            //    .HasForeignKey(item => item.CampaignId);
            //modelBuilder.Entity<Item>()
            //    .HasOne(item => item.OwnerCharacter)
            //    .WithMany(character => character.Items)
            //    .HasForeignKey(item => item.OwnerCharacterId);
            //modelBuilder.Entity<Item>()
            //    .HasOne(item => item.Type)
            //    .WithMany(itemType => itemType.Items)
            //    .HasForeignKey(item => item.TypeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<ItemType>()
            //    .HasKey(itemType => itemType.Id);
            //modelBuilder.Entity<ItemType>()
            //    .HasMany(itemType => itemType.Items)
            //    .WithOne(item => item.Type)
            //    .HasForeignKey(item => item.TypeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassModel>().HasData(
                new ClassModel() { Id = 1, Name = "Barbarian" },
                new ClassModel() { Id = 2, Name = "Bard" },
                new ClassModel() { Id = 3, Name = "Cleric" },
                new ClassModel() { Id = 4, Name = "Druid" },
                new ClassModel() { Id = 5, Name = "Fighter" },
                new ClassModel() { Id = 6, Name = "Monk" },
                new ClassModel() { Id = 7, Name = "Paladin" },
                new ClassModel() { Id = 8, Name = "Ranger" },
                new ClassModel() { Id = 9, Name = "Rogue" },
                new ClassModel() { Id = 10, Name = "Sorcerer" },
                new ClassModel() { Id = 11, Name = "Warlock" },
                new ClassModel() { Id = 12, Name = "Wizard" }
            );

            modelBuilder.Entity<SpeciesModel>().HasData(
                new SpeciesModel() { Id = 1, Name = "Aasimar" },
                new SpeciesModel() { Id = 2, Name = "Dragonborn" },
                new SpeciesModel() { Id = 3, Name = "Dwarf" },
                new SpeciesModel() { Id = 4, Name = "Elf" },
                new SpeciesModel() { Id = 5, Name = "Gnome" },
                new SpeciesModel() { Id = 6, Name = "Goliath" },
                new SpeciesModel() { Id = 7, Name = "Halfling" },
                new SpeciesModel() { Id = 8, Name = "Human" },
                new SpeciesModel() { Id = 9, Name = "Orc" },
                new SpeciesModel() { Id = 10, Name = "Tiefling" }
            );

            modelBuilder.Entity<SubSpeciesModel>().HasData(
                new SubSpeciesModel() { Id = 1, Name = "Black", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 2, Name = "Blue", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 3, Name = "Brass", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 4, Name = "Bronze", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 5, Name = "Copper", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 6, Name = "Gold", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 7, Name = "Green", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 8, Name = "Red", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 9, Name = "Silver", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 10, Name = "White", SpeciesId = 2 },
                new SubSpeciesModel() { Id = 11, Name = "Drow", SpeciesId = 4 },
                new SubSpeciesModel() { Id = 12, Name = "High Elf", SpeciesId = 4 },
                new SubSpeciesModel() { Id = 13, Name = "Wood Elf", SpeciesId = 4 },
                new SubSpeciesModel() { Id = 14, Name = "Forest Gnome", SpeciesId = 5 },
                new SubSpeciesModel() { Id = 15, Name = "Rock Gnome", SpeciesId = 5 },
                new SubSpeciesModel() { Id = 16, Name = "Cloud Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 17, Name = "Fire Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 18, Name = "Frost Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 19, Name = "Hill Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 20, Name = "Stone Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 21, Name = "Storm Giant", SpeciesId = 6 },
                new SubSpeciesModel() { Id = 22, Name = "Abissal", SpeciesId = 10 },
                new SubSpeciesModel() { Id = 23, Name = "Chtonic", SpeciesId = 10 },
                new SubSpeciesModel() { Id = 24, Name = "Infernal", SpeciesId = 10 }
            );

            modelBuilder.Entity<SubClassModel>().HasData(
                new SubClassModel() { Id = 1, Name = "Path of the Berserker", ClassId = 1 },
                new SubClassModel() { Id = 2, Name = "Path of the Wild Heart", ClassId = 1 },
                new SubClassModel() { Id = 3, Name = "Path of the World Tree", ClassId = 1 },
                new SubClassModel() { Id = 4, Name = "Path of the Zealot", ClassId = 1 },
                new SubClassModel() { Id = 5, Name = "College of Dance", ClassId = 2 },
                new SubClassModel() { Id = 6, Name = "College of Glamour", ClassId = 2 },
                new SubClassModel() { Id = 7, Name = "College of Lore", ClassId = 2 },
                new SubClassModel() { Id = 8, Name = "College of Valor", ClassId = 2 },
                new SubClassModel() { Id = 9, Name = "Life Domain", ClassId = 3 },
                new SubClassModel() { Id = 10, Name = "Light Domain", ClassId = 3 },
                new SubClassModel() { Id = 11, Name = "Trickery Domain", ClassId = 3 },
                new SubClassModel() { Id = 12, Name = "War Domain", ClassId = 3 },
                new SubClassModel() { Id = 13, Name = "Circle of the Land", ClassId = 4 },
                new SubClassModel() { Id = 14, Name = "Circle of the Moon", ClassId = 4 },
                new SubClassModel() { Id = 15, Name = "Circle of the Sea", ClassId = 4 },
                new SubClassModel() { Id = 16, Name = "Circle of the Stars", ClassId = 4 },
                new SubClassModel() { Id = 17, Name = "Battle Master", ClassId = 5 },
                new SubClassModel() { Id = 18, Name = "Champion", ClassId = 5 },
                new SubClassModel() { Id = 19, Name = "Eldritch Knight", ClassId = 5 },
                new SubClassModel() { Id = 20, Name = "Psi Warrior", ClassId = 5 },
                new SubClassModel() { Id = 21, Name = "Warrior of Mercy", ClassId = 6 },
                new SubClassModel() { Id = 22, Name = "Warrior of Shadow", ClassId = 6 },
                new SubClassModel() { Id = 23, Name = "Warrior of the Elements", ClassId = 6 },
                new SubClassModel() { Id = 24, Name = "Warrior of of the Open Hand", ClassId = 6 },
                new SubClassModel() { Id = 25, Name = "Oath of Devotion", ClassId = 7 },
                new SubClassModel() { Id = 26, Name = "Oath of Glory", ClassId = 7 },
                new SubClassModel() { Id = 27, Name = "Oath of Ancients", ClassId = 7 },
                new SubClassModel() { Id = 28, Name = "Oath of Vengeans", ClassId = 7 },
                new SubClassModel() { Id = 29, Name = "Beast Master", ClassId = 8 },
                new SubClassModel() { Id = 30, Name = "Fey Wanderer", ClassId = 8 },
                new SubClassModel() { Id = 31, Name = "Gloom Stalker", ClassId = 8 },
                new SubClassModel() { Id = 32, Name = "Hunter", ClassId = 8 },
                new SubClassModel() { Id = 33, Name = "Arcane Trickster", ClassId = 9 },
                new SubClassModel() { Id = 34, Name = "Assassin", ClassId = 9 },
                new SubClassModel() { Id = 35, Name = "Soulknife", ClassId = 9 },
                new SubClassModel() { Id = 36, Name = "Thief", ClassId = 9 },
                new SubClassModel() { Id = 37, Name = "Saboteur", ClassId = 9 },
                new SubClassModel() { Id = 38, Name = "Aberrant Sorcery", ClassId = 10 },
                new SubClassModel() { Id = 39, Name = "Clockwork Sorcery", ClassId = 10 },
                new SubClassModel() { Id = 40, Name = "Draconic Sorcery", ClassId = 10 },
                new SubClassModel() { Id = 41, Name = "Wild Magic Sorcery", ClassId = 10 },
                new SubClassModel() { Id = 42, Name = "Archfey Patron", ClassId = 11 },
                new SubClassModel() { Id = 43, Name = "Celestial Patron", ClassId = 11 },
                new SubClassModel() { Id = 44, Name = "Fiend Patron", ClassId = 11 },
                new SubClassModel() { Id = 45, Name = "Great Old One Patron", ClassId = 11 },
                new SubClassModel() { Id = 46, Name = "Hexblade Patron", ClassId = 11 },
                new SubClassModel() { Id = 47, Name = "Abjurer", ClassId = 12 },
                new SubClassModel() { Id = 48, Name = "Diviner", ClassId = 12 },
                new SubClassModel() { Id = 49, Name = "Evoker", ClassId = 12 },
                new SubClassModel() { Id = 50, Name = "Illusionist", ClassId = 12 }
            );

            modelBuilder.Entity<ItemTypeModel>().HasData(
                new ItemTypeModel() { Id = 1, Name = "Weapon" },
                new ItemTypeModel() { Id = 2, Name = "Magic Weapon" },
                new ItemTypeModel() { Id = 3, Name = "Armor" },
                new ItemTypeModel() { Id = 4, Name = "Magic Armor" },
                new ItemTypeModel() { Id = 5, Name = "Equipment" },
                new ItemTypeModel() { Id = 6, Name = "Magic Equipment" },
                new ItemTypeModel() { Id = 7, Name = "Tool" }
            );
        }
    }
}
