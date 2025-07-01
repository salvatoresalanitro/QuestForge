using QuestForge.Application.Interfaces;
using QuestForge.Application.Mapping;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IClassRepository _classRepository;

        public CharacterService(ICharacterRepository characterRepository, ISpeciesRepository speciesRepository, IClassRepository classRepository)
        {
            _characterRepository = characterRepository;
            _speciesRepository = speciesRepository;
            _classRepository = classRepository;
        }

        public async Task<CharacterDto> CreateAsync(CreateCharacterDto createCharacterDto)
        {
            var species = await _speciesRepository.GetByIdAsync(createCharacterDto.SpeciesId);
            var @class = await _classRepository.GetByIdAsync(createCharacterDto.ClassId);

            if(species == null || @class == null)
            {
                throw new InvalidOperationException("Species or class not valid");
            }

            var character = CharacterMapper.ToEntity(createCharacterDto, species.Id, @class.Id);
            await _characterRepository.AddAsync(character);

            return CharacterMapper.ToDto(character);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            if(character is null)
            {
                return false;
            }

            await _characterRepository.DeleteAsync(character);
            return true;
        }

        public async Task<CharacterDto?> GetByIdAsync(Guid id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            return character is null ? null : CharacterMapper.ToDto(character);
        }

        public async Task<CharacterDto?> UpdateAsync(Guid id, CreateCharacterDto dto)
        {
            var character = await _characterRepository.GetByIdAsync(id);

            if(character is null)
            {
                return null;
            }

            character.Update(dto.Name, dto.SpeciesId, dto.ClassId, dto.Level, dto.HitPoints, dto.ArmorClass);

            await _characterRepository.UpdateAsync(character);
            return CharacterMapper.ToDto(character);
        }
    }
}