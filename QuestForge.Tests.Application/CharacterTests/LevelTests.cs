using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class LevelTests
    {
        [Fact]
        public void Should_throw_exception_if_value_provided_is_less_than_one()
        {
            var exception = Assert.Throws<CharacterCreationException>(() => Level.Create(0));

            Assert.Equal("Level must be at least 1.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_if_value_provided_is_more_than_twenty()
        {
            var exception = Assert.Throws<CharacterCreationException>(() => Level.Create(21));

            Assert.Equal("Level cannot exceed 20.", exception.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(19)]
        public void Should_be_created_successfully_if_value_provided_is_between_one_and_twenty(int value)
        {
            var level = Level.Create(value);

            Assert.Equal(value, level.Value);
        }

        [Fact]
        public void Should_throw_exception_during_update_if_value_provided_is_less_than_one()
        {
            var level = Level.Create(12);

            var exception = Assert.Throws<CharacterUpdateException>(() => level.Update(0));

            Assert.Equal("Level must be at least 1.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_during_update_if_value_provided_is_more_than_twenty()
        {
            var level = Level.Create(12);

            var exception = Assert.Throws<CharacterUpdateException>(() => level.Update(25));

            Assert.Equal("Level cannot exceed 20.", exception.Message);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(16, 17)]
        public void Should_be_updated_successfully_if_value_provided_is_between_one_and_twenty(int initialValue, int newValue)
        {
            var level = Level.Create(initialValue);
            level.Update(newValue);

            Assert.Equal(newValue, level.Value);
        }
    }
}
