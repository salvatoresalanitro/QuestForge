using QuestForge.Core.Entities;

namespace QuestForge.Tests.Application.CampaignTests
{
    public class CampaignEntityTest
    {
        [Fact]
        public void Create_should_initialize_campaign_correctly()
        {
            // Act
            var campaign = Campaign.Create("Ombre di Arcanath", "Campagna di Salvo"); 

            // Assert
            Assert.NotEqual(Guid.Empty, campaign.Id);
            Assert.Equal("Ombre di Arcanath", campaign.Name);
            Assert.Equal("Campagna di Salvo", campaign.Description);
            Assert.NotNull(campaign.Characters);
            Assert.NotNull(campaign.Enemies);
            Assert.NotNull(campaign.Npcs);
            Assert.NotNull(campaign.Items);
        }

        [Fact]
        public void Update_should_update_name_and_description()
        {
            // Arrange
            var campaign = Campaign.Create("Ombre di Arcanath", "Campagna di Salvo");

            // Act
            campaign.Update("New name", "New description");

            // Assert
            Assert.Equal("New name", campaign.Name);
            Assert.Equal("New description", campaign.Description);
        }
    }
}
