using QuestForge.Core.Entities;

namespace QuestForge.Tests.Application.TestUtils.Builders
{
    public class ItemTypeBuilder
    {
        private int _id = 0;
        private string _name = "Default";

        public ItemTypeBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public ItemTypeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ItemType Build()
        {
            return ItemType.Create(_id, _name);
        }
    }
}
