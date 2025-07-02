using QuestForge.Core.Entities;

namespace QuestForge.Tests.Application.TestUtils.Builders
{
    public class CharacterBuilder
    {
        private string _name = "Default name";
        private int _speciesId = 1;
        private int _classId = 1;
        private int _level = 1;
        private int _hitPoints = 8;
        private int _armorClass = 10;
        private readonly List<Item> _items = [];

        public CharacterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CharacterBuilder WithSpeciesId(int speciesId)
        {
            _speciesId = speciesId;
            return this;
        }

        public CharacterBuilder WithClassId(int classId)
        {
            _classId = classId;
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
    }
}
