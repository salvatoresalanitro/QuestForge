using QuestForge.Core.Entities;
using QuestForge.DTOs.DTOsItem;

namespace QuestForge.Application.Mapping
{
    public static class ItemMapper
    {
        public static ItemDto ToDto(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                TypeId = item.Type.Id,
                TypeName = item.Type.Name
            };
        }
    }
}
