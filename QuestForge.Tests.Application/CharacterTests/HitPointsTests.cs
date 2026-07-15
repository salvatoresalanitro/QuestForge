using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class HitPointsTests
    {
        [Fact]
        public void Should_throw_exception_if_value_provided_is_negative()
        {
            var exception = Assert.Throws<CharacterCreationException>(() => HitPoints.Create(-5));

            Assert.Equal("HitPoints cannot be negative.", exception.Message);
        }

        [Fact]
        public void Should_create_successfully_if_value_provided_has_correct_form()
        {
            var hitPoints = HitPoints.Create(12);

            Assert.Equal(12, hitPoints.Value);
        }

        [Fact]
        public void Should_throw_exception_if_value_provided_for_update_is_negative()
        {
            var hitPoints = HitPoints.Create(12);
            var exception = Assert.Throws<CharacterUpdateException>(() => hitPoints.Update(-5));

            Assert.Equal("HitPoints cannot be negative.", exception.Message);
        }

        [Fact]
        public void Should_update_successfully_if_value_provided_has_correct_form()
        {
            var hitPoints = HitPoints.Create(12);
            hitPoints.Update(15);

            Assert.Equal(15, hitPoints.Value);
        }
    }
}
