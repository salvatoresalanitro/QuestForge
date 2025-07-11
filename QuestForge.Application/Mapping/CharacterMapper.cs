using QuestForge.Domain.Characters;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.Mapping
{
    public static class CharacterMapper
    {
        public static CharacterDto ToDto(Character character)
        {
            return new CharacterDto
            {
                Id = character.Id.Value,
                Name = character.Name.Value,
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

        public static Character ToEntity(CreateCharacterDto dto)
        {
            return Character.Create(dto.Name, dto.species, dto.@class, dto.Level, dto.HitPoints, dto.ArmorClass);
        }
    }
}
