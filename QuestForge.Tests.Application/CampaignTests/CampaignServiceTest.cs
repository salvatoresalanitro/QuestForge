using Moq;
using QuestForge.Application.Services;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Tests.Application.CampaignTests
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
        public async Task CreateAsync_should_return_not_null_value()
        {
            // Arrange
            var dto = new CreateCampaignDto() { Name = "Avventure", Description = "Initial description" };

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAsync_should_add_one_campaign()
        {
            // Arrange
            var dto = new CreateCampaignDto() { Name = "Avventure", Description = "Initial description" };

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Campaign>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_should_return_Campaign_with_correct_name_and_description()
        {
            // Arrange
            var dto = new CreateCampaignDto() { Name = "Avventure", Description = "Initial description" };

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Avventure", result.Name);
            Assert.Equal("Initial description", result.Description);
        }

        [Fact]
        public async Task GetByIdAsync_should_return_not_null_value()
        {
            // Arrange
            var campaign = Campaign.Create("Ombre di Arcanath", "La prima avventura di Salvo");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.GetByIdAsync(campaign.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_should_return_campaign_with_correct_name_and_description()
        {
            // Arrange
            var campaign = Campaign.Create("Ombre di Arcanath", "La prima avventura di Salvo");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.GetByIdAsync(campaign.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ombre di Arcanath", result.Name);
            Assert.Equal("La prima avventura di Salvo", result.Description);
        }

        [Fact]
        public async Task GetAllAsync_should_return_all_correct_campaigns()
        {
            // Arrange
            var campaignOne = Campaign.Create("Campaign 1", "Description 1");
            var campaignTwo = Campaign.Create("Campaign 2", "Description 2");
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync([campaignOne, campaignTwo]);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Campaign 1", result.ElementAt(0).Name);
            Assert.Equal("Description 1", result.ElementAt(0).Description);
            Assert.Equal("Campaign 2", result.ElementAt(1).Name);
            Assert.Equal("Description 2", result.ElementAt(1).Description);
        }

        [Fact]
        public async Task UpdateAsync_should_return_an_updated_campaign()
        {
            // Arrange
            var campaign = Campaign.Create("Campaign 1", "Description 1");
            var dto = new CreateCampaignDto() { Name = "Ombre di Arcanath", Description = "Description test" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.UpdateAsync(campaign.Id, dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ombre di Arcanath", result.Name);
            Assert.Equal("Description test", result.Description);
        }

        [Fact]
        public async Task DeleteAsync_should_return_true_if_campaign_was_deleted()
        {
            // Arrange
            var campaign = Campaign.Create("Campaign test", "Description test");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.DeleteAsync(campaign.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_should_return_false_if_campaign_was_not_found()
        {
            // Arrange
            var campaign = Campaign.Create("Campaign test", "Description test");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(campaign.Id)).ReturnsAsync(campaign);

            // Act
            var result = await _service.DeleteAsync(Guid.NewGuid());

            // Assert
            Assert.False(result);
        }
    }
}
