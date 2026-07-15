using QuestForge.Domain.Campaigns.CampaignVO;

namespace QuestForge.Tests.Application.CampaignTests
{
    public class CampaignIdTest
    {
        [Fact]
        public void Should_not_be_empty_when_is_created()
        {
            var id = CampaignId.Create();

            Assert.NotEqual(Guid.Empty, id.Value);
        }

        [Fact]
        public void Should_be_successfully_created_when_value_is_provided()
        {
            var newGuid = Guid.NewGuid();
            var id = CampaignId.Create(newGuid);

            Assert.Equal(newGuid, id.Value);
        }
    }
}
