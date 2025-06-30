using Moq;
using QuestForge.Application.Services;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Tests.Application
{
    public class CampaignServiceTest
    {
        private readonly Mock<ICampaignRepository> _repositoryMock;
        private readonly CampaignService _service;

        public CampaignServiceTest()
        {
            _repositoryMock = new Mock<ICampaignRepository>();
            _service = new CampaignService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_should_return_Campaign_with_correct_name()
        {
            // Arrange
            var dto = new CreateCampaignDto() { Name = "Avventure", Description = "Initial description" };

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Avventure", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_should_return_campaign_with_correct_name()
        {
            // Arrange
            var campaign = Campaign.Create("Ombre di Arcanath", "La prima avventura di Salvo");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.GetByIdAsync(campaign.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ombre di Arcanath", result.Name);
        }

    }
}
