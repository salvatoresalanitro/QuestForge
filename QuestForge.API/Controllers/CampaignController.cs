using Microsoft.AspNetCore.Mvc;
using QuestForge.Application.Interfaces;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _service;

        public CampaignController(ICampaignService service)
        {
            _service = service;
        }

        [HttpGet("GetCampaign{id}")]
        public async Task<IActionResult> GetCampaignById(Guid id)
        {
            var campaignDto = await _service.GetByIdAsync(id);

            return campaignDto is null ? NotFound() : Ok(campaignDto);
        }

        [HttpGet("GetAllCampaigns")]
        public async Task<IActionResult> GetAllCampaigns()
        {
            var campaignsDtos = await _service.GetAllAsync();

            return campaignsDtos is null ? NotFound() : Ok(campaignsDtos);
        }

        [HttpPost("CreateCampaign")]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignDto dto)
        {
            var campaignDto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetCampaignById), new { id = campaignDto.Id }, campaignDto);
        }

        [HttpPut("UpdateCampaign")]
        public async Task<IActionResult> UpdateCampaign(Guid id, [FromBody] CreateCampaignDto dto)
        {
            var updatedCampaign = await _service.UpdateAsync(id, dto);

            return updatedCampaign is null ? NotFound() : Ok(updatedCampaign);
        }

        [HttpDelete("DeleteCampaign{id}")]
        public async Task<IActionResult> DeleteCampaign(Guid id)
        {
            var success = await _service.DeleteAsync(id);

            return success ? NoContent() : NotFound();
        }
    }
}
