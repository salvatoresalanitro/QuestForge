using QuestForge.Application.Interfaces;
using QuestForge.Application.Mapping;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _repository = characterRepository;
        }

        public async Task<CharacterDto> CreateAsync(CreateCharacterDto createCharacterDto)
        {
            var character = CharacterMapper.ToEntity(createCharacterDto);
            await _repository.AddAsync(character);

            return CharacterMapper.ToDto(character);
        }

        public async Task<CharacterDto?> GetByIdAsync(Guid id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character is null ? null : CharacterMapper.ToDto(character);
        }
    }
}