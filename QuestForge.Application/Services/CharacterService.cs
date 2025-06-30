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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var character = await _repository.GetByIdAsync(id);
            if(character is null)
            {
                return false;
            }

            await _repository.DeleteAsync(character);
            return true;
        }

        public async Task<CharacterDto?> GetByIdAsync(Guid id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character is null ? null : CharacterMapper.ToDto(character);
        }

        public async Task<CharacterDto?> UpdateAsync(Guid id, CreateCharacterDto dto)
        {
            var character = await _repository.GetByIdAsync(id);

            if(character is null)
            {
                return null;
            }

            character.Update(dto.Name, dto.Species, dto.Class, dto.Level, dto.HitPoints, dto.ArmorClass);

            await _repository.UpdateAsync(character);
            return CharacterMapper.ToDto(character);
        }
    }
}