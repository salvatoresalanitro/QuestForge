namespace QuestForge.Core.Entities
{
    public class Character
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public Species Species { get; private set; }
        public Class Class { get; private set; }
        public int Level { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public List<Item> Items { get; init; } = [];
        public Campaign Campaign { get; private set; }
        public Guid CampaignId { get; private set; }

        private Character(string name, Species species, Class characterClass, int level, int hitPoint, int armorClass)
        {
            Id = Guid.NewGuid();
            Name = name;
            Species = species;
            Class = characterClass;
            Level = level;
            HitPoints = hitPoint;
            ArmorClass = armorClass;
            Items = [];
        }

        public static Character Create(string name, Species species, Class characterClass, int level, int hitPoint, int armorClass)
        {
            return new Character(name, species, characterClass, level, hitPoint, armorClass);
        }

        public void Update(string name, Species species, Class characterClass, int level, int hitPoint, int armorClass)
        {
            Name = name;
            Species = species;
            Class = characterClass;
            Level = level;
            HitPoints = hitPoint;
            ArmorClass = armorClass;
        }
    }
}