namespace QuestForge.DTOs.DTOsItem
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string ItemTypeName { get; set; } = string.Empty;
    }
}
