using QuestForge.Domain.Campaigns.CampaignVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CampaignTests
{
    public class CampaignNameTest
    {
        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_null()
        {
#pragma warning disable CS8625 // Use null for testing purpose
            Assert.Throws<CampaignCreationException>(() => CampaignName.Create(null));
#pragma warning restore CS8625
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_should_throw_exception_if_value_provided_is_empty_or_white_space(string value)
        {
            var exception = Assert.Throws<CampaignCreationException>(()=> CampaignName.Create(value));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_less_than_five_characters_long()
        {
            var value = "Camp";
            var exception = Assert.Throws<CampaignCreationException>(() => CampaignName.Create(value));
            Assert.Equal("Name cannot be less than 5 characters", exception.Message);
        }

        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_more_than_one_hundred_characters_long()
        {
            var value = new string('x', 120);
            var exception = Assert.Throws<CampaignCreationException>(() => CampaignName.Create(value));
            Assert.Equal("Name cannot exceed 100 characters", exception.Message);
        }

        [Fact]
        public void Should_be_created_successfully_if_value_has_correct_form()
        {
            var value = "Ombre di Arcanath";
            var result = CampaignName.Create(value);

            Assert.Equal("Ombre di Arcanath", result.Value);
        }

        [Theory]
        [InlineData("Ombre di Arcanath ")]
        [InlineData(" Ombre di Arcanath")]
        [InlineData(" Ombre di Arcanath ")]
        public void Should_be_created_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string value)
        {
            var result = CampaignName.Create(value);

            Assert.Equal("Ombre di Arcanath", result.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Update_should_throw_exception_if_value_provided_is_empty_or_white_space(string newValue)
        {
            var value = "Ombre di Aracanath";
            var campaignName = CampaignName.Create(value);

            var exception = Assert.Throws<CampaignUpdateException>(() => campaignName.Update(newValue));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_less_than_five_characters_long()
        {
            var value = "Ombre di Aracanath";
            var campaignName = CampaignName.Create(value);

            var newValue = "Ombr";

            var exception = Assert.Throws<CampaignUpdateException>(() => campaignName.Update(newValue));
            Assert.Equal("Name cannot be less than 5 characters", exception.Message);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_more_than_one_hundred_characters_long()
        {
            var value = "Ombre di Aracanath";
            var campaignName = CampaignName.Create(value);

            var newValue = new string('x', 110);
            var exception = Assert.Throws<CampaignUpdateException>(() => campaignName.Update(newValue));
            Assert.Equal("Name cannot exceed 100 characters", exception.Message);
        }

        [Fact]
        public void Should_be_updated_successfully_if_value_has_correct_form()
        {
            var value = "Ombre di Aracanath";
            var campaignName = CampaignName.Create(value);

            var newValue = "I Risolutori";
            campaignName.Update(newValue);

            Assert.Equal("I Risolutori", campaignName.Value);
        }

        [Theory]
        [InlineData("I Risolutori ")]
        [InlineData(" I Risolutori")]
        [InlineData(" I Risolutori ")]
        public void Should_be_updated_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string newValue)
        {
            var value = "Ombre di Aracanath";
            var campaignName = CampaignName.Create(value);

            campaignName.Update(newValue);

            Assert.Equal("I Risolutori", campaignName.Value);
        }
    }
}
