using QuestForge.Domain.Campaigns;

namespace QuestForge.Tests.Application.TestUtils.Builders
{
    public class CampaignBuilder
    {
        private string _name = "Default name";
        private string _description = "Default description";

        public CampaignBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CampaignBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public Campaign Build()
        {
            return Campaign.Create(_name, _description);
        }
    }
}
