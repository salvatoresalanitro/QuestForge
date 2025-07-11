using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Application.UsesCases.Commands.Campaigns.CreateCampaign;
using QuestForge.Application.UsesCases.Queries.Campaigns.GetAllCampaigns;
using QuestForge.Application.UsesCases.Queries.Campaigns.GetCampaignById;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCampaign{id}")]
        public async Task<IActionResult> GetCampaignById(Guid id, CancellationToken cancellationToken)
        {
            //var campaignDto = await _service.GetByIdAsync(id);
            var request = new GetCampaignByIdQuery(id);

            var campaignDto = await _mediator.Send(request, cancellationToken);

            return Ok(campaignDto);
        }

        [HttpGet("GetAllCampaigns")]
        public async Task<IActionResult> GetAllCampaigns()
        {
            var request = new GetAllCampaignsQuery();

            var campaignsDtos = await _mediator.Send(request);

            return Ok(campaignsDtos);
        }

        [HttpPost("CreateCampaign")]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignDto dto, CancellationToken cancellationToken)
        {
            var request = new CreateCampaignCommand(dto.Name, dto.Description ?? string.Empty);

            var id = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction(nameof(CreateCampaign), new { id }, new {Id = id});
        }

        //[HttpPut("UpdateCampaign")]
        //public async Task<IActionResult> UpdateCampaign(Guid id, [FromBody] CreateCampaignDto dto)
        //{
        //    var updatedCampaign = await _service.UpdateAsync(id, dto);

        //    return updatedCampaign is null ? NotFound() : Ok(updatedCampaign);
        //}

        //[HttpDelete("DeleteCampaign{id}")]
        //public async Task<IActionResult> DeleteCampaign(Guid id)
        //{
        //    var success = await _service.DeleteAsync(id);

        //    return success ? NoContent() : NotFound();
        //}
    }
}
