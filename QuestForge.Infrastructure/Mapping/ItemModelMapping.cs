using QuestForge.Domain.Items;
using QuestForge.Domain.Items.ItemVO;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class ItemModelMapping
    {
        public static Item MapToDomain(this ItemModel model)
        {
            return Item.Reconstitute(
                ItemId.Create(model.Id),
                ItemName.Create(model.Name),
                ItemDescription.Create(model.Description),
                model.Type.MapToDomain()
            );
        }

        public static ItemModel MapToModel(this Item item)
        {
            return new ItemModel()
            {
                Id = item.Id.Value,
                Name = item.Name.Value,
                Description = item.Description.Value,
                Type = item.Type.MapToModel()
            };
        }
    }
}
