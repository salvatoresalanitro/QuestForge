using QuestForge.Domain.Items;
using QuestForge.Infrastructure.Models;

namespace QuestForge.Infrastructure.Mapping
{
    public static class ItemModelMapping
    {
        public static Item MapToDomain(this ItemModel model)
        {
            return Item.Create(
                model.Id,
                model.Name,
                model.Description,
                model.Type.MapToDomain()
            );
        }

        public static ItemModel MapToModel(this Item domain)
        {
            return new ItemModel()
            {
                Id = domain.Id.Value,
                Name = domain.Name.Value,
                Description = domain.Description.Value,
                Type = domain.Type.MapToModel()
            };
        }
    }
}
