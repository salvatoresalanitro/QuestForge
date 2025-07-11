using QuestForge.Domain.Campaigns;

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
            Assert.NotEqual(Guid.Empty, campaign.Id.Value);
            Assert.Equal("Ombre di Arcanath", campaign.Name.Value);
            Assert.Equal("Campagna di Salvo", campaign.Description.Value);
            Assert.NotNull(campaign.Characters);
            Assert.NotNull(campaign.Items);
        }

        //[Fact]
        //public void Update_should_update_name_and_description()
        //{
        //    // Arrange
        //    var campaign = Campaign.Create("Ombre di Arcanath", "Campagna di Salvo");

        //    // Act
        //    campaign.Update("New name", "New description");

        //    // Assert
        //    Assert.Equal("New name", campaign.Name);
        //    Assert.Equal("New description", campaign.Description);
        //}
    }
}
