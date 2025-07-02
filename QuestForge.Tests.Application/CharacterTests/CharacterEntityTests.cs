using QuestForge.Core.Entities;
using QuestForge.Tests.Application.TestUtils.Seeds;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class CharacterEntityTests
    {
        [Fact]
        public void Create_should_initialize_character_correctly()
        {
            // Arrange
            var species = Species.Create(8, "Human");
            var @class = Class.Create(7, "Paladin");

            // Act
            var character = Character.Create("Andor", species, @class, 1, 10, 15);

            // Assert
            Assert.NotEqual(Guid.Empty, character.Id);
            Assert.Equal("Andor", character.Name);
            Assert.Equal(SpeciesIds.Human, character.Species.Id);
            Assert.Equal(ClassIds.Paladin, character.Class.Id);
            Assert.Equal(1, character.Level);
            Assert.Equal(10, character.HitPoints);
            Assert.Equal(15, character.ArmorClass);
            Assert.NotNull(character.Items);
        }

        [Fact]
        public void Update_should_update_character_informations()
        {
            // Arrange
            var species = Species.Create(4, "Elf");
            var @class = Class.Create(10, "Sorcerer");
            var character = Character.Create("Sarophin", species, @class, 1, 8, 14);

            // Act
            var newSpecies = Species.Create(5, "Gnome");
            var newClass = Class.Create(11, "Warlock");

            character.Update("Sar", newSpecies, newClass, 2, 13, 15);

            // Assert
            Assert.Equal("Sar", character.Name);
            Assert.Equal(SpeciesIds.Gnome, character.Species.Id);
            Assert.Equal(ClassIds.Warlock, character.Class.Id);
            Assert.Equal(2, character.Level);
            Assert.Equal(13, character.HitPoints);
            Assert.Equal(15, character.ArmorClass);
        }
    }
}
