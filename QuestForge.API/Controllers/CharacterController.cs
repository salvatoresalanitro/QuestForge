using Microsoft.AspNetCore.Mvc;
using QuestForge.Application.Interfaces;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService characterService)
        {
            _service = characterService;
        }

        [HttpGet("GetCharacter{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var characterDto = await _service.GetByIdAsync(id);

            return characterDto is null ? NotFound() : Ok(characterDto);
        }

        [HttpPost("CreateCharacter")]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDto dto)
        {
            var characterDto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetCharacterById), new { id = characterDto.Id }, characterDto);
        }

        [HttpPut("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody] CreateCharacterDto dto)
        {
            var updatedCharacter = await _service.UpdateAsync(id, dto);

            return updatedCharacter is null ? NotFound() : Ok(updatedCharacter);
        }

        [HttpDelete("DeleteCharacter")]
        public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            var success = await _service.DeleteAsync(id);

            return success ? NoContent() : NotFound();
        }
    }
}
