using QuestForge.Core.Entities;

namespace QuestForge.Tests.Application.TestUtils.Builders
{
    public class CharacterBuilder
    {
        private string _name = "Default name";
        private Species _species = Species.Create(0, "Default species");
        private Class _class = Class.Create(0, "Default class");
        private int _level = 1;
        private int _hitPoints = 8;
        private int _armorClass = 10;
        private readonly List<Item> _items = [];

        public CharacterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CharacterBuilder WithSpecies(int id, string name)
        {
            _species = Species.Create(id, name);
            return this;
        }

        public CharacterBuilder WithClass(int id, string name)
        {
            _class = Class.Create(id, name);
            return this;
        }

        public CharacterBuilder WithLevel(int level)
        {
            _level = level;
            return this;
        }

        public CharacterBuilder WithHitPoints(int hitpoints)
        {
            _hitPoints = hitpoints;
            return this;
        }

        public CharacterBuilder WithArmorClass(int armorClass)
        {
            _armorClass = armorClass;
            return this;
        }

        public CharacterBuilder AddItem(string name, string description, int typeId)
        {
            _items.Add(Item.Create(name, description, typeId));
            return this;
        }

        public Character Build()
        {
            return Character.Create(_name, _species, _class, _level, _hitPoints, _armorClass);
        }
    }
}
