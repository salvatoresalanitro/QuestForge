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
                TypeId = item.TypeId,
                TypeName = item.Type.Name
            };
        }
    }
}
