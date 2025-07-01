namespace QuestForge.Core.Entities
{
    public class Character
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public int SpeciesId { get; private set; }
        public Species Species { get; private set; } = null!;
        public int ClassId { get; private set; }
        public Class Class { get; private set; } = null!;
        public int Level { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public List<Item> Items { get; init; } = [];
        public Campaign Campaign { get; private set; } = null!;
        public Guid CampaignId { get; private set; }

        private Character(string name, int speciesId, int classId, int level, int hitPoints, int armorClass)
        {
            Id = Guid.NewGuid();
            Name = name;
            SpeciesId = speciesId;
            ClassId = classId;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Items = [];
        }

        public static Character Create(string name, int speciesId, int classId, int level, int hitPoints, int armorClass)
        {
            return new Character(name, speciesId, classId, level, hitPoints, armorClass);
        }

        public void Update(string name, int speciesId, int classId, int level, int hitPoints, int armorClass)
        {
            Name = name;
            SpeciesId = speciesId;
            ClassId = classId;
            Level = level;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
        }
    }
}