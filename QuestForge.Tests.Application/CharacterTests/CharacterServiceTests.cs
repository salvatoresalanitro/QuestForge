﻿using Moq;
using QuestForge.Application.Services;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCharacter;
using QuestForge.Tests.Application.TestUtils.Builders;
using QuestForge.Tests.Application.TestUtils.Seeds;

namespace QuestForge.Tests.Application.CharacterTests
{
    public class CharacterServiceTests
    {
        private readonly Mock<ICharacterRepository> _characterRepositoryMock;
        private readonly Mock<ISpeciesRepository> _speciesRepositoryMock;
        private readonly Mock<IClassRepository> _classRepositoryMock;
        private readonly CharacterService _service;
        private readonly CharacterBuilder _builder;

        public CharacterServiceTests()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
            _speciesRepositoryMock = new Mock<ISpeciesRepository>();
            _classRepositoryMock = new Mock<IClassRepository>();
            _service = new CharacterService(_characterRepositoryMock.Object, _speciesRepositoryMock.Object, _classRepositoryMock.Object);
            _builder = new CharacterBuilder();
        }

        [Fact]
        public async Task CreateAsync_should_return_not_null_value()
        {
            // Arrange
            var dto = new CreateCharacterDto()
            {
                Name = "Andor",
                SpeciesId = 8,
                ClassId = 7,
                Level = 1,
                HitPoints = 10,
                ArmorClass = 15,
                Items = []
            };

            SetupMockLookups(8, "Human", 7, "Paladin");

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAsync_should_return_character_created()
        {
            // Arrange
            var dto = new CreateCharacterDto()
            {
                Name = "Andor",
                SpeciesId = 8,
                ClassId = 7,
                Level = 1,
                HitPoints = 10,
                ArmorClass = 15,
                Items = []
            };

            SetupMockLookups(8, "Human", 7, "Paladin");

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Andor", result.Name);
            Assert.Equal(SpeciesIds.Human, result.SpeciesId);
            Assert.Equal(nameof(SpeciesIds.Human), result.SpeciesName);
            Assert.Equal(ClassIds.Paladin, result.ClassId);
            Assert.Equal(nameof(ClassIds.Paladin), result.ClassName);
        }

        [Fact]
        public async Task DeleteAsync_should_true_if_character_is_deleted()
        {
            // Arrange
            var character = _builder
                .WithName("Sarophin")
                .WithSpecies(8, "Human")
                .WithClass(7, "Paladin")
                .WithLevel(1)
                .WithHitPoints(10)
                .WithArmorClass(15)
                .Build();

            SetupMockLookups(8, "Human", 7, "Paladin");

            _characterRepositoryMock.Setup(repo => repo.GetByIdAsync(character.Id)).ReturnsAsync(character);

            // Act
            var result = await _service.DeleteAsync(character.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_should_false_if_character_is_not_found()
        {
            // Arrange
            var character = _builder
                .WithName("Sarophin")
                .WithSpecies(8, "Human")
                .WithClass(7, "Paladin")
                .WithLevel(1)
                .WithHitPoints(10)
                .WithArmorClass(15)
                .Build();

            SetupMockLookups(8, "Human", 7, "Paladin");

            _characterRepositoryMock.Setup(repo => repo.GetByIdAsync(character.Id)).ReturnsAsync(character);

            // Act
            var result = await _service.DeleteAsync(Guid.NewGuid());

            // Assert
            Assert.False(result);
        }

        private void SetupMockLookups(int speciesId, string speciesName, int classId, string className)
        {
            _speciesRepositoryMock
                .Setup(r => r.GetByIdAsync(speciesId))
                .ReturnsAsync(Species.Create(speciesId, speciesName));

            _classRepositoryMock
                .Setup(r => r.GetByIdAsync(classId))
                .ReturnsAsync(Class.Create(classId, className));
        }
    }
}
