using QuestForge.Core.Entities;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.Mapping
{
    public static class CharacterMapper
    {
        public static CharacterDto ToDto(Character character)
        {
            return new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Species = character.Species,
                Class = character.Class,
                Level = character.Level,
                HitPoints = character.HitPoints,
                ArmorClass = character.ArmorClass,
                Items = character.Items,
            };
        }

        public static Character ToEntity(CreateCharacterDto dto)
        {
            return new Character
            {
                Name = dto.Name,
                Species = dto.Species,
                Class = dto.Class,
                Level = dto.Level,
                HitPoints = dto.HitPoints,
                ArmorClass = dto.ArmorClass,
                Items = dto.Items,
            };
        }
    }
}
