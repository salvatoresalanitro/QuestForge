using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Application.UsesCases.Commands.Characters.CreateCharacter;
using QuestForge.DTOs.DTOsCharacter;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("GetCharacter{id}")]
        //public async Task<IActionResult> GetCharacterById(Guid id)
        //{
        //    var characterDto = await _service.GetByIdAsync(id);

        //    return characterDto is null ? NotFound() : Ok(characterDto);
        //}

        [HttpPost("CreateCharacter")]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDto dto, CancellationToken cancellationToken)
        {
            var request = new CreateCharacterCommand(
                dto.Name,
                dto.SpeciesId,
                dto.ClassId,
                dto.Level,
                dto.HitPoints,
                dto.ArmorClass
            );

            var id = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction(nameof(CreateCharacter), new { id }, new { Id = id });
        }

        //[HttpPut("UpdateCharacter")]
        //public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody] CreateCharacterDto dto)
        //{
        //    var updatedCharacter = await _service.UpdateAsync(id, dto);

        //    return updatedCharacter is null ? NotFound() : Ok(updatedCharacter);
        //}

        //[HttpDelete("DeleteCharacter")]
        //public async Task<IActionResult> DeleteCharacter(Guid id)
        //{
        //    var success = await _service.DeleteAsync(id);

        //    return success ? NoContent() : NotFound();
        //}
    }
}
