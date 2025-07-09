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

        public static ItemTypeModel MapToModel(this ItemType domain)
        {
            var model = new ItemTypeModel()
            {
                Id = domain.Id,
                Name = domain.Name
            };

            model.Items.AddRange(domain.Items.Select(i => i.MapToModel()));

            return model;
        }
    }
}
