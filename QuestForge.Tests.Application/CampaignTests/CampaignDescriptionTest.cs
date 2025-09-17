using QuestForge.Domain.Campaigns.CampaignVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CampaignTests
{
    public class CampaignDescriptionTest
    {
        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_null()
        {
#pragma warning disable CS8625 // Use null for testing purpose
            var exception = Assert.Throws<CampaignCreationException>(() => CampaignDescription.Create(null));
            Assert.Equal("Null value on description.", exception.Message);
#pragma warning restore CS8625
        }

        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_more_than_one_hundred_characters_long()
        {
            var value = new string('x', 550);
            var exception = Assert.Throws<CampaignCreationException>(() => CampaignDescription.Create(value));
            Assert.Equal("Description cannot exceed 500 characters.", exception.Message);
        }

        [Fact]
        public void Should_be_created_successfully_if_value_has_correct_form()
        {
            var value = "Prima campagna ufficiale di Salanitro Salvatore";
            var result = CampaignDescription.Create(value);

            Assert.Equal("Prima campagna ufficiale di Salanitro Salvatore", result.Value);
        }

        [Theory]
        [InlineData("Prima campagna ufficiale di Salanitro Salvatore ")]
        [InlineData(" Prima campagna ufficiale di Salanitro Salvatore")]
        [InlineData(" Prima campagna ufficiale di Salanitro Salvatore ")]
        public void Should_be_created_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string value)
        {
            var result = CampaignDescription.Create(value);

            Assert.Equal("Prima campagna ufficiale di Salanitro Salvatore", result.Value);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_null()
        {
            var value = "Prima campagna ufficiale di Salanitro Salvatore";
            var campaignDescription = CampaignDescription.Create(value);

#pragma warning disable CS8625 // Use null for testing purpose
            var exception = Assert.Throws<CampaignUpdateException>(() => campaignDescription.Update(null));
#pragma warning restore CS8625
            Assert.Equal("Null value on description.", exception.Message);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_more_than_one_hundred_characters_long()
        {
            var value = "Prima campagna ufficiale di Salanitro Salvatore";
            var campaignDescription = CampaignDescription.Create(value);

            var newValue = new string('x', 501);
            var exception = Assert.Throws<CampaignUpdateException>(() => campaignDescription.Update(newValue));
            Assert.Equal("Description cannot exceed 500 characters.", exception.Message);
        }

        [Fact]
        public void Should_be_updated_successfully_if_value_has_correct_form()
        {
            var value = "Prima campagna ufficiale di Salanitro Salvatore";
            var campaignDescription = CampaignDescription.Create(value);

            var newValue = "Campagna steampunk ufficiale di Salanitro Salvatore";
            campaignDescription.Update(newValue);

            Assert.Equal("Campagna steampunk ufficiale di Salanitro Salvatore", campaignDescription.Value);
        }

        [Theory]
        [InlineData("Campagna steampunk ufficiale di Salanitro Salvatore ")]
        [InlineData(" Campagna steampunk ufficiale di Salanitro Salvatore")]
        [InlineData(" Campagna steampunk ufficiale di Salanitro Salvatore ")]
        public void Should_be_updated_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string newValue)
        {
            var value = "Prima campagna ufficiale di Salanitro Salvatore";
            var campaignDescription = CampaignDescription.Create(value);

            campaignDescription.Update(newValue);

            Assert.Equal("Campagna steampunk ufficiale di Salanitro Salvatore", campaignDescription.Value);
        }
    }
}
