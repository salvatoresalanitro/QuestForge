using QuestForge.Domain.Items;
using QuestForge.Domain.ValueObjects;
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

        public static Item ToEntity(ItemDto dto)
        {
            return Item.Create(
                dto.Id,
                dto.Name,
                dto.Description,
                ItemType.Create(dto.TypeId, dto.TypeName)
            );
        }
    }
}
