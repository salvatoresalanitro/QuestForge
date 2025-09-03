using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class CharacterNameTest
    {
        [Fact]
        public void Create_should_throw_exception_if_valaue_provided_is_null()
        {
#pragma warning disable CS8625 // Use null for testing purpose
            Assert.Throws<CharacterCreationException>(() => CharacterName.Create(null));
#pragma warning restore CS8625
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_should_throw_exception_if_value_provided_is_empty_or_white_space(string value)
        {
            var exception = Assert.Throws<CharacterCreationException>(() => CharacterName.Create(value));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_less_than_three_characters_long()
        {
            var value = "sa";
            var exception = Assert.Throws<CharacterCreationException>(() => CharacterName.Create(value));
            Assert.Equal("Name cannot be less than 3 character", exception.Message);
        }

        [Fact]
        public void Create_should_throw_exception_if_value_provided_is_more_than_twentyfive_characters_long()
        {
            var value = "alsofjkemcnanxkjansjkdnasjdnkadadsa";
            var exception = Assert.Throws<CharacterCreationException>(() => CharacterName.Create(value));

            Assert.Equal("Name cannot exceed 25 characters", exception.Message);
        }

        [Fact]
        public void Should_be_created_successfully_if_value_has_correct_form()
        {
            var value = "Andor";
            var result = CharacterName.Create(value);

            Assert.Equal("Andor", result.Value);
        }

        [Theory]
        [InlineData("Andor ")]
        [InlineData(" Andor")]
        [InlineData(" Andor ")]
        public void Should_be_created_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string value)
        {
            var result = CharacterName.Create(value);

            Assert.Equal("Andor", result.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Update_should_throw_exception_if_value_provided_is_empty_or_white_space(string newValue)
        {
            var value = "Andor";
            var characterName = CharacterName.Create(value);

            var exception = Assert.Throws<CharacterUpdateException>(() => characterName.Update(newValue));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_less_than_three_characters_long()
        {
            var value = "Andor";
            var characterName = CharacterName.Create(value);

            var newValue = "la";
            var exception = Assert.Throws<CharacterUpdateException>(() => characterName.Update(newValue));

            Assert.Equal("Name cannot be less than 3 character", exception.Message);
        }

        [Fact]
        public void Update_should_throw_exception_if_value_provided_is_more_than_twentyfive_characters_long()
        {
            var value = "Andor";
            var characterName = CharacterName.Create(value);

            var newValue = "alsofjkemcnanxkjansjkdnasjdnkadadsa";
            var exception = Assert.Throws<CharacterUpdateException>(() => characterName.Update(newValue));

            Assert.Equal("Name cannot exceed 25 characters", exception.Message);
        }

        [Fact]
        public void Should_be_updated_successfully_if_value_has_correct_form()
        {
            var value = "Andor";
            var characterName = CharacterName.Create(value);

            var newValue = "Sarophin";
            characterName.Update(newValue);

            Assert.Equal("Sarophin", characterName.Value);
        }

        [Theory]
        [InlineData("Sarophin ")]
        [InlineData(" Sarophin")]
        [InlineData(" Sarophin ")]
        public void Should_be_updated_successfully_if_value_has_correct_form_with_white_space_on_leading_or_trailing(string newValue)
        {
            var value = "Andor";
            var characterName = CharacterName.Create(value);

            characterName.Update(newValue);

            Assert.Equal("Sarophin", characterName.Value);
        }
    }
}
