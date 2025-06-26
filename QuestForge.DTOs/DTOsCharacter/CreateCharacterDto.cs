using System.ComponentModel.DataAnnotations;
using QuestForge.Core.Entities;

namespace QuestForge.DTOs.DTOsCharacter
{
    public class CreateCharacterDto
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(Species))]
        public Species Species { get; set; }

        [EnumDataType(typeof(Class))]
        public Class Class { get; set; }

        [Required(ErrorMessage = "Minimum level 1 and may not exceed 20")]
        [Range(1, 20)]
        public int Level { get; set; }

        [Required]
        public int HitPoints { get; set; }

        [Required]
        public int ArmorClass { get; set; }

        public List<Item>? Items { get; set; }
    }
}
