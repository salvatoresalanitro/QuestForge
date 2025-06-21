using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<CharacterDto?> GetByIdAsync(Guid id);
        Task<CharacterDto> CreateAsync(CreateCharacterDto createCharacterDto);
    }
}
