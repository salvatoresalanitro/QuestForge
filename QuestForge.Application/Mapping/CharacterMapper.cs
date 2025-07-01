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

        public static Character ToEntity(CreateCharacterDto dto, int speciesId, int classId)
        {
            return Character.Create(dto.Name, speciesId, classId, dto.Level, dto.HitPoints, dto.ArmorClass);
        }
    }
}
