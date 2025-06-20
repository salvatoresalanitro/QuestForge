using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Core.DTOs.Character;
using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var character = await _characterRepository.GetByIdAsync(id);

            if(character is null)
            {
                return NotFound();
            }

            var characterDto = _mapper.Map<CharacterDto>(character);

            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDto dto)
        {
            var character = _mapper.Map<Character>(dto);
            await _characterRepository.AddAsync(character);

            var characterDto = _mapper.Map<CharacterDto>(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = characterDto.Id }, characterDto);
        }
    }
}
