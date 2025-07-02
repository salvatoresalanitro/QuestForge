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
                SpeciesId = character.Species.Id,
                ClassId = character.Class.Id,
                SpeciesName = character.Species.Name,
                ClassName = character.Class.Name,
                Level = character.Level,
                HitPoints = character.HitPoints,
                ArmorClass = character.ArmorClass,
                Items = character.Items.Select(ItemMapper.ToDto).ToList(),
            };
        }

        public static Character ToEntity(CreateCharacterDto dto, Species species, Class @class)
        {
            return Character.Create(dto.Name, species, @class, dto.Level, dto.HitPoints, dto.ArmorClass);
        }
    }
}
