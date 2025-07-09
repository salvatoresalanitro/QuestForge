using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class ItemTypeMapping
    {
        public static ItemType MapToDomain(this ItemTypeModel model)
        {
            return ItemType.Create(
                model.Id,
                model.Name
            );
        }

        public static ItemTypeModel MapToModel(this ItemType itemType)
        {
            var model = new ItemTypeModel()
            {
                Id = itemType.Id,
                Name = itemType.Name
            };

            model.Items.AddRange(itemType.Items.Select(i => i.MapToModel()));

            return model;
        }
    }
}
