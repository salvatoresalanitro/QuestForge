using QuestForge.Domain.Campaigns;
using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;
using QuestForge.Domain.ValueObjects.CharacterVO;

namespace QuestForge.Domain.Characters
{
    public class Character
    {
        public CharacterId Id { get; }
        public CharacterName Name { get; }
        public Species Species { get; }
        public Class Class { get; }
        public Level Level { get; }
        public HitPoints HitPoints { get; }
        public ArmorClass ArmorClass { get; }
        private readonly List<Item> _items = [];
        public IReadOnlyCollection<Item> Items => _items;
        public CampaignId CampaignId { get; init; } = null!;

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
            Name = CharacterName.Create(name);
            Species = species;
            Class = @class;
            Level = Level.Create(level);
            HitPoints = HitPoints.Create(hitPoints);
            ArmorClass = ArmorClass.Create(armorClass);
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
