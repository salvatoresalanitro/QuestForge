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
        public DbSet<SubSpecies> SubSpecies => Set<SubSpecies>();
        public DbSet<SubClass> SubSubClasses => Set<SubClass>();
        public DbSet<ItemType> ItemTypes => Set<ItemType>();

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
            modelBuilder.Entity<Item>()
                .HasOne(item => item.ItemType)
                .WithMany(itemType => itemType.Items)
                .HasForeignKey(item => item.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Npc>()
                .HasKey(npc => npc.Id);
            modelBuilder.Entity<Npc>()
                .HasOne(npc => npc.Campaign)
                .WithMany(campaign => campaign.Npcs)
                .HasForeignKey(npc => npc.CampaignId);

            modelBuilder.Entity<Species>()
                .HasKey(species => species.Id);
            modelBuilder.Entity<Species>()
                .HasMany(species => species.SubSpecies)
                .WithOne(subSpecies => subSpecies.Species)
                .HasForeignKey(subSpecies => subSpecies.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasKey(@class => @class.Id);
            modelBuilder.Entity<Class>()
                .HasMany(@class => @class.SubClasses)
                .WithOne(subClass => subClass.Class)
                .HasForeignKey(subClass => subClass.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubSpecies>()
                .HasKey(subSpecies => subSpecies.Id);
            modelBuilder.Entity<SubSpecies>()
                .HasOne(subSpecies => subSpecies.Species)
                .WithMany(species => species.SubSpecies)
                .HasForeignKey(subSpecies => subSpecies.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubClass>()
                .HasKey(subClass => subClass.Id);
            modelBuilder.Entity<SubClass>()
                .HasOne(subClass => subClass.Class)
                .WithMany(@class => @class.SubClasses)
                .HasForeignKey(subClass => subClass.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemType>()
                .HasKey(itemType => itemType.Id);
            modelBuilder.Entity<ItemType>()
                .HasMany(itemType => itemType.Items)
                .WithOne(item => item.ItemType)
                .HasForeignKey(item => item.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<SubSpecies>().HasData(
                new SubSpecies(1, "Black", 2),
                new SubSpecies(2, "Blue", 2),
                new SubSpecies(3, "Brass", 2),
                new SubSpecies(4, "Bronze", 2),
                new SubSpecies(5, "Copper", 2),
                new SubSpecies(6, "Gold", 2),
                new SubSpecies(7, "Green", 2),
                new SubSpecies(8, "Red", 2),
                new SubSpecies(9, "Silver", 2),
                new SubSpecies(10, "White", 2),
                new SubSpecies(11, "Drow", 4),
                new SubSpecies(12, "High Elf", 4),
                new SubSpecies(13, "Wood Elf", 4),
                new SubSpecies(14, "Forest Gnome", 5),
                new SubSpecies(14, "Rock Gnome", 5),
                new SubSpecies(15, "Cloud Giant", 6),
                new SubSpecies(16, "Fire Giant", 6),
                new SubSpecies(17, "Frost Giant", 6),
                new SubSpecies(18, "Hill Giant", 6),
                new SubSpecies(19, "Stone Giant", 6),
                new SubSpecies(20, "Storm Giant", 6),
                new SubSpecies(21, "Cloud Giant", 6),
                new SubSpecies(22, "Abissal", 10),
                new SubSpecies(23, "Chthonic", 10),
                new SubSpecies(24, "Infernal", 10)
            );

            modelBuilder.Entity<SubClass>().HasData(
                new SubClass(1, "Path of the Berserker", 1),
                new SubClass(2, "Path of the Wild Heart", 1),
                new SubClass(3, "Path of the World Tree", 1),
                new SubClass(4, "Path of the Zealot", 1),
                new SubClass(5, "College of Dance", 2),
                new SubClass(6, "College of Glamour", 2),
                new SubClass(7, "College of Lore", 2),
                new SubClass(8, "College of Valor", 2),
                new SubClass(9, "Life Domain", 3),
                new SubClass(10, "Light Domain", 3),
                new SubClass(11, "Trickery Domain", 3),
                new SubClass(12, "War Domain", 3),
                new SubClass(13, "Circle of the Land", 4),
                new SubClass(14, "Circle of the Moon", 4),
                new SubClass(15, "Circle of the Sea", 4),
                new SubClass(16, "Circle of the Stars", 4),
                new SubClass(17, "Battle Master", 5),
                new SubClass(18, "Champion", 5),
                new SubClass(19, "Eldritch Knight", 5),
                new SubClass(20, "Psi Warrior", 5),
                new SubClass(21, "Warrior of Mercy", 6),
                new SubClass(22, "Warrior of Shadow", 6),
                new SubClass(23, "Warrior of the Elements", 6),
                new SubClass(24, "Warrior of the Open Hand", 6),
                new SubClass(25, "Oath of Devotion", 7),
                new SubClass(26, "Oath of Glory", 7),
                new SubClass(27, "Oath of Ancients", 7),
                new SubClass(28, "Oath of Vengeans", 7),
                new SubClass(29, "Beast Master", 8),
                new SubClass(30, "Fey Wanderer", 8),
                new SubClass(31, "Gloom Stalker", 8),
                new SubClass(32, "Hunter", 8),
                new SubClass(33, "Arcane Trickster", 9),
                new SubClass(34, "Assassin", 9),
                new SubClass(35, "Soulknife", 9),
                new SubClass(36, "Thief", 9),
                new SubClass(37, "Saboteur", 9),
                new SubClass(38, "Aberrant Sorcery", 10),
                new SubClass(39, "Clockwork Sorcery", 10),
                new SubClass(40, "Draconic Sorcery", 10),
                new SubClass(41, "Wild Magic Sorcery", 10),
                new SubClass(42, "Archfey Patron", 11),
                new SubClass(43, "Celestial Patron", 11),
                new SubClass(44, "Fiend Patron", 11),
                new SubClass(45, "Great Old One Patron", 11),
                new SubClass(46, "Hexblade", 11),
                new SubClass(47, "Abjurer", 12),
                new SubClass(48, "Diviner", 12),
                new SubClass(49, "Evoker", 12),
                new SubClass(50, "Illusionist", 12)
            );

            modelBuilder.Entity<ItemType>()
                .HasData(
                    new ItemType(1, "Weapon"),
                    new ItemType(2, "Magic Weapon"),
                    new ItemType(3, "Armor"),
                    new ItemType(4, "Magic Armor"),
                    new ItemType(5, "Equipment"),
                    new ItemType(6, "Magic Equipment"),
                    new ItemType(7, "Tool")
                );
        }
    }
}
