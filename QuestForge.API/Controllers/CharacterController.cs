using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Core.DTOs.Character;
using QuestForge.Core.Interfaces.Services;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var characterDto = await _characterService.GetByIdAsync(id);

            return characterDto is null ? NotFound() : Ok(characterDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDto dto)
        {
            var characterDto = await _characterService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetCharacterById), new { id = characterDto.Id }, characterDto);
        }
    }
}
