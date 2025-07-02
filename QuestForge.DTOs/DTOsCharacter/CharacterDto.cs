using QuestForge.Core.Entities;

namespace QuestForge.DTOs.DTOsCharacter
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public List<Item>? Items { get; set; }
    }
}
