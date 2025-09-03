using QuestForge.Domain.Characters.CharacterVO;
using QuestForge.Domain.Common.Exceptions;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class AmorClassTests
    {
        [Fact]
        public void Should_throw_exception_if_value_provided_is_negative()
        {
            var exception = Assert.Throws<CharacterCreationException>(() => ArmorClass.Create(-5));
            Assert.Equal("Armor class cannot be negative.", exception.Message);
        }

        [Fact]
        public void Should_create_successfully_if_value_provided_has_correct_form()
        {
            var armorClass = ArmorClass.Create(15);

            Assert.Equal(15, armorClass.Value);
        }

        [Fact]
        public void Should_throw_exception_if_value_provided_for_update_is_negative()
        {
            var armorClass = ArmorClass.Create(15);
            var exception = Assert.Throws<CharacterUpdateException>(() => armorClass.Update(-5));

            Assert.Equal("Armor class cannot be negative.", exception.Message);
        }

        [Fact]
        public void Should_update_successfully_if_value_provided_has_correct_form()
        {
            var armorClass = ArmorClass.Create(12);
            armorClass.Update(15);

            Assert.Equal(15, armorClass.Value);
        }
    }
}
