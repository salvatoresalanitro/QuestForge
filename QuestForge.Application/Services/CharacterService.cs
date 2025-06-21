using AutoMapper;
using QuestForge.Core.DTOs.DTOsCharacter;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Core.Interfaces.Services;

namespace QuestForge.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _repository = characterRepository;
            _mapper = mapper;
        }

        public async Task<CharacterDto> CreateAsync(CreateCharacterDto createCharacterDto)
        {
            //validation draft
            if(createCharacterDto.Level < 1)
            {
                throw new ArgumentException("Cannot create character with level less than 1");
            }

            var character = _mapper.Map<Character>(createCharacterDto);
            await _repository.AddAsync(character);

            return _mapper.Map<CharacterDto>(character);
        }

        public async Task<CharacterDto?> GetByIdAsync(Guid id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character is null ? null : _mapper.Map<CharacterDto>(character);
        }
    }
}