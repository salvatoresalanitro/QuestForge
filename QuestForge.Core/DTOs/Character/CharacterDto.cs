using QuestForge.Core.Entities;

namespace QuestForge.Core.DTOs.Character
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; }
        public Class Class { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
    }
}
