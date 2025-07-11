using QuestForge.Domain.Items;
using QuestForge.DTOs.DTOsItem;

namespace QuestForge.Application.Mapping
{
    public static class ItemMapper
    {
        public static ItemDto ToDto(Item item)
        {
            return new ItemDto
            {
                Id = item.Id.Value,
                Name = item.Name.Value,
                Description = item.Description.Value,
                TypeId = item.Type.Id,
                TypeName = item.Type.Name
            };
        }
    }
}
