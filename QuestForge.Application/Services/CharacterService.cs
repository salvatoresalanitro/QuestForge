using QuestForge.Application.Interfaces;
using QuestForge.Application.Mapping;
using QuestForge.Core.Exceptions;
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

            var character = CharacterMapper.ToEntity(createCharacterDto, species, @class);
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
            if (character is null)
            {
                throw new NotFoundException("Character not found");
            }

            return CharacterMapper.ToDto(character);
        }

        public async Task<CharacterDto?> UpdateAsync(Guid id, CreateCharacterDto dto)
        {
            var species = await _speciesRepository.GetByIdAsync(dto.SpeciesId);
            var @class = await _classRepository.GetByIdAsync(dto.ClassId);

            if (species is null || @class is null)
            {
                throw new InvalidOperationException("Species or class not valid");
            }

            var character = await _characterRepository.GetByIdAsync(id);

            if(character is null)
            {
                throw new NotFoundException("Character not found");
            }

            character.Update(dto.Name, species, @class, dto.Level, dto.HitPoints, dto.ArmorClass);

            await _characterRepository.UpdateAsync(character);
            return CharacterMapper.ToDto(character);
        }
    }
}