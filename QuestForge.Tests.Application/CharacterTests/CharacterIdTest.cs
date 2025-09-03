using QuestForge.Domain.Characters.CharacterVO;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class CharacterIdTest
    {
        [Fact]
        public void Should_be_not_empty_when_is_created()
        {
            var id = CharacterId.Create();

            Assert.NotEqual(Guid.Empty, id.Value);
        }

        [Fact]
        public void Should_be_successfully_created_when_value_is_provided()
        {
            var newGuid = Guid.NewGuid();
            var id = CharacterId.Create(newGuid);

            Assert.Equal(newGuid, id.Value);
        }
    }
}
