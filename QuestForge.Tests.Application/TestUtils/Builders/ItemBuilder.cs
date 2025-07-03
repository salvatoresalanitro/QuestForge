using QuestForge.Core.Entities;

namespace QuestForge.Tests.Application.TestUtils.Builders
{
    public class ItemBuilder
    {
        private string _name = "Default";
        private string _description = "Default";
        private ItemType _itemType = ItemType.Create(0, "Default");

        public ItemBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ItemBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ItemBuilder WithItemType(ItemType ItemType)
        {
            _itemType = ItemType;
            return this;
        }

        public Item Build()
        {
            return Item.Create(_name, _description, _itemType);
        }  
    }
}
