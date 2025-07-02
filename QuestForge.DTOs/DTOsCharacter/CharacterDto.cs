using QuestForge.DTOs.DTOsItem;

namespace QuestForge.DTOs.DTOsCharacter
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public List<ItemDto> Items { get; set; } = [];
    }
}
