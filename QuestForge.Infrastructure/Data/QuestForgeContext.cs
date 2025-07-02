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
        public DbSet<Species> AllSpecies => Set<Species>();
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<SubSpecies> AllSubSpecies => Set<SubSpecies>();
        public DbSet<SubClass> SubClasses => Set<SubClass>();
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
                .HasOne(item => item.Type)
                .WithMany(itemType => itemType.Items)
                .HasForeignKey(item => item.TypeId)
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
                .WithOne(item => item.Type)
                .HasForeignKey(item => item.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>().HasData(
                Class.Create(1, "Barbarian"),
                Class.Create(2, "Bard"),
                Class.Create(3, "Cleric"),
                Class.Create(4, "Druid"),
                Class.Create(5, "Fighter"),
                Class.Create(6, "Monk"),
                Class.Create(7, "Paladin"),
                Class.Create(8, "Ranger"),
                Class.Create(9, "Rogue"),
                Class.Create(10, "Sorcerer"),
                Class.Create(11, "Warlock"),
                Class.Create(12, "Wizard")
            );

            modelBuilder.Entity<Species>().HasData(
                Species.Create(1, "Aasimar"),
                Species.Create(2, "Dragonborn"),
                Species.Create(3, "Dwarf"),
                Species.Create(4, "Elf"),
                Species.Create(5, "Gnome"),
                Species.Create(6, "Goliath"),
                Species.Create(7, "Halfling"),
                Species.Create(8, "Human"),
                Species.Create(9, "Orc"),
                Species.Create(10, "Tiefling")
            );

            modelBuilder.Entity<SubSpecies>().HasData(
                SubSpecies.Create(1, "Black", 2),
                SubSpecies.Create(2, "Blue", 2),
                SubSpecies.Create(3, "Brass", 2),
                SubSpecies.Create(4, "Bronze", 2),
                SubSpecies.Create(5, "Copper", 2),
                SubSpecies.Create(6, "Gold", 2),
                SubSpecies.Create(7, "Green", 2),
                SubSpecies.Create(8, "Red", 2),
                SubSpecies.Create(9, "Silver", 2),
                SubSpecies.Create(10, "White", 2),
                SubSpecies.Create(11, "Drow", 4),
                SubSpecies.Create(12, "High Elf", 4),
                SubSpecies.Create(13, "Wood Elf", 4),
                SubSpecies.Create(14, "Forest Gnome", 5),
                SubSpecies.Create(15, "Rock Gnome", 5),
                SubSpecies.Create(16, "Cloud Giant", 6),
                SubSpecies.Create(17, "Fire Giant", 6),
                SubSpecies.Create(18, "Frost Giant", 6),
                SubSpecies.Create(19, "Hill Giant", 6),
                SubSpecies.Create(20, "Stone Giant", 6),
                SubSpecies.Create(21, "Storm Giant", 6),
                SubSpecies.Create(22, "Cloud Giant", 6),
                SubSpecies.Create(23, "Abissal", 10),
                SubSpecies.Create(24, "Chthonic", 10),
                SubSpecies.Create(25, "Infernal", 10)
            );

            modelBuilder.Entity<SubClass>().HasData(
                SubClass.Create(1, "Path of the Berserker", 1),
                SubClass.Create(2, "Path of the Wild Heart", 1),
                SubClass.Create(3, "Path of the World Tree", 1),
                SubClass.Create(4, "Path of the Zealot", 1),
                SubClass.Create(5, "College of Dance", 2),
                SubClass.Create(6, "College of Glamour", 2),
                SubClass.Create(7, "College of Lore", 2),
                SubClass.Create(8, "College of Valor", 2),
                SubClass.Create(9, "Life Domain", 3),
                SubClass.Create(10, "Light Domain", 3),
                SubClass.Create(11, "Trickery Domain", 3),
                SubClass.Create(12, "War Domain", 3),
                SubClass.Create(13, "Circle of the Land", 4),
                SubClass.Create(14, "Circle of the Moon", 4),
                SubClass.Create(15, "Circle of the Sea", 4),
                SubClass.Create(16, "Circle of the Stars", 4),
                SubClass.Create(17, "Battle Master", 5),
                SubClass.Create(18, "Champion", 5),
                SubClass.Create(19, "Eldritch Knight", 5),
                SubClass.Create(20, "Psi Warrior", 5),
                SubClass.Create(21, "Warrior of Mercy", 6),
                SubClass.Create(22, "Warrior of Shadow", 6),
                SubClass.Create(23, "Warrior of the Elements", 6),
                SubClass.Create(24, "Warrior of the Open Hand", 6),
                SubClass.Create(25, "Oath of Devotion", 7),
                SubClass.Create(26, "Oath of Glory", 7),
                SubClass.Create(27, "Oath of Ancients", 7),
                SubClass.Create(28, "Oath of Vengeans", 7),
                SubClass.Create(29, "Beast Master", 8),
                SubClass.Create(30, "Fey Wanderer", 8),
                SubClass.Create(31, "Gloom Stalker", 8),
                SubClass.Create(32, "Hunter", 8),
                SubClass.Create(33, "Arcane Trickster", 9),
                SubClass.Create(34, "Assassin", 9),
                SubClass.Create(35, "Soulknife", 9),
                SubClass.Create(36, "Thief", 9),
                SubClass.Create(37, "Saboteur", 9),
                SubClass.Create(38, "Aberrant Sorcery", 10),
                SubClass.Create(39, "Clockwork Sorcery", 10),
                SubClass.Create(40, "Draconic Sorcery", 10),
                SubClass.Create(41, "Wild Magic Sorcery", 10),
                SubClass.Create(42, "Archfey Patron", 11),
                SubClass.Create(43, "Celestial Patron", 11),
                SubClass.Create(44, "Fiend Patron", 11),
                SubClass.Create(45, "Great Old One Patron", 11),
                SubClass.Create(46, "Hexblade", 11),
                SubClass.Create(47, "Abjurer", 12),
                SubClass.Create(48, "Diviner", 12),
                SubClass.Create(49, "Evoker", 12),
                SubClass.Create(50, "Illusionist", 12)
            );

            modelBuilder.Entity<ItemType>()
                .HasData(
                    ItemType.Create(1, "Weapon"),
                    ItemType.Create(2, "Magic Weapon"),
                    ItemType.Create(3, "Armor"),
                    ItemType.Create(4, "Magic Armor"),
                    ItemType.Create(5, "Equipment"),
                    ItemType.Create(6, "Magic Equipment"),
                    ItemType.Create(7, "Tool")
                );
        }
    }
}
