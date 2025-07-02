using QuestForge.Core.Entities;
using QuestForge.Tests.Application.TestUtils.Seeds;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class CharacterEntityTests
    {
        [Fact]
        public void Create_should_initialize_character_correctly()
        {
            // Act
            var character = Character.Create("Andor", 8, 7, 1, 10, 15);

            // Assert
            Assert.NotEqual(Guid.Empty, character.Id);
            Assert.Equal("Andor", character.Name);
            Assert.Equal(SpeciesIds.Human, character.SpeciesId);
            Assert.Equal(ClassIds.Paladin, character.ClassId);
            Assert.Equal(1, character.Level);
            Assert.Equal(10, character.HitPoints);
            Assert.Equal(15, character.ArmorClass);
            Assert.NotNull(character.Items);
        }

        [Fact]
        public void Update_should_update_character_informations()
        {
            // Arrange
            var character = Character.Create("Sarophin", 4, 10, 1, 8, 14);

            // Act
            character.Update("Sar", 5, 11, 2, 13, 15);

            // Assert
            Assert.Equal("Sar", character.Name);
            Assert.Equal(SpeciesIds.Gnome, character.SpeciesId);
            Assert.Equal(ClassIds.Warlock, character.ClassId);
            Assert.Equal(2, character.Level);
            Assert.Equal(13, character.HitPoints);
            Assert.Equal(15, character.ArmorClass);
        }
    }
}
