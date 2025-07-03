namespace QuestForge.Core.Entities
{
    public class Character
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public Species Species { get; private set; } = null!;
        public Class Class { get; private set; } = null!;
        public int Level { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public List<Item> Items { get; init; } = [];
        public Campaign Campaign { get; private set; } = null!;
        public Guid CampaignId { get; private set; }

        private Character(string name, Species species, Class @class, int level, int hitPoints, int armorClass)
        {
            Id = Guid.NewGuid();
            Name = name;
            Species = species;
            Class= @class;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Items = [];
        }

        public static Character Create(string name, Species species, Class @class, int level, int hitPoints, int armorClass)
        {
            return new Character(name, species, @class, level, hitPoints, armorClass);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddItems(IEnumerable<Item> items)
        {
            Items.AddRange(items);
        }

        public void Update(string name, Species species, Class @class, int level, int hitPoints, int armorClass)
        {
            Name = name;
            Species = species;
            Class = @class;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
        }
    }
}