using Microsoft.AspNetCore.Mvc;
using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(id);

            if(character is null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] Character character)
        {
            await _characterRepository.AddAsync(character);

            return CreatedAtAction(nameof(GetCharacterById), new { id = character.Id }, character);
        }
    }
}
