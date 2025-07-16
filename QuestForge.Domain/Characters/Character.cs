using QuestForge.Domain.Campaigns.CampaignVO;
using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;

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
            Guid id,
            string name,
            Species species,
            Class @class,
            int level,
            int hitPoints,
            int armorClass,
            List<Item> items
        )
        {
            Id = CharacterId.Create(id);
            Name = CharacterName.Create(name);
            Species = species;
            Class = @class;
            Level = Level.Create(level);
            HitPoints = HitPoints.Create(hitPoints);
            ArmorClass = ArmorClass.Create(armorClass);
            _items = items;
        }

        public static Character Create(
            Guid id,
            string name,
            Species species,
            Class @class,
            int level,
            int hitPoints,
            int armorClass,
            List<Item> items
        )
        {
            return new Character(id, name, species, @class, level, hitPoints, armorClass, items);
        }
    }
}
