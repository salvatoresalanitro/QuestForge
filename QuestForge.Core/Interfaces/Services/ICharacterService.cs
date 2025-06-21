using QuestForge.Core.DTOs.DTOsCharacter;

namespace QuestForge.Core.Interfaces.Services
{
    public interface ICharacterService
    {
        Task<CharacterDto?> GetByIdAsync(Guid id);
        Task<CharacterDto> CreateAsync(CreateCharacterDto createCharacterDto);
    }
}
