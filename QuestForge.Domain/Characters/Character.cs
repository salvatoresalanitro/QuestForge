using QuestForge.Domain.Campaigns;
using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;

namespace QuestForge.Domain.Characters
{
    public class Character
    {
        public CharacterId Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public Species Species { get; init; }
        public Class Class { get; init; }
        public int Level { get; init; }
        public int HitPoints { get; init; }
        public int ArmorClass { get; init; }
        public List<Item> Items { get; init; } = [];
        public CampaignId CampaignId { get; init; }

        private Character(
            string name,
            Species species,
            Class @class,
            int level,
            int hitPoints,
            int armorClass
        )
        {
            Id = CharacterId.Create();
            Name = name;
            Species = species;
            Class = @class;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
        }

        public static Character Create(
            string name,
            Species species,
            Class @class,
            int level,
            int hitPoints,
            int armorClass
        )
        {
            return new Character(name, species, @class, level, hitPoints, armorClass);
        }
    }
}
