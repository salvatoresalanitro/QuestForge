using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Application.UsesCases.Commands.Characters.CreateCharacter;
using QuestForge.Application.UsesCases.Commands.Characters.DeleteCharacter;
using QuestForge.Application.UsesCases.Commands.Characters.UpdateCharacter;
using QuestForge.Application.UsesCases.Queries.Characters.GetAllCharacters;
using QuestForge.Application.UsesCases.Queries.Characters.GetCharacterById;
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

        [HttpGet("GetCharacter{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetCharacterByIdQuery(id);

            var characterDto = await _mediator.Send(request, cancellationToken);

            return Ok(characterDto);
        }

        [HttpGet("GetAllCharacters")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var request = new GetAllCharactersQuery();

            var charactersDtos = await _mediator.Send(request);

            return Ok(charactersDtos);
        }

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

        [HttpPut("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody] CreateCharacterDto dto, CancellationToken cancellationToken)
        {
            var request = new UpdateCharacterCommand(id, dto);

            var characterDto = await _mediator.Send(request, cancellationToken);

            return Ok(characterDto);
        }

        [HttpDelete("DeleteCharacter{id}")]
        public async Task<IActionResult> DeleteCharacter(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCharacterCommand(id);

            var success = await _mediator.Send(request, cancellationToken);

            return success ? NoContent() : NotFound();
        }
    }
}
