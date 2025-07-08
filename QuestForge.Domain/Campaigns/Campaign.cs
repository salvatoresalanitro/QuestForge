using QuestForge.Domain.Characters;
using QuestForge.Domain.Items;

namespace QuestForge.Domain.Campaigns
{
    public class Campaign
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        private List<Character> _characters = [];
        public IReadOnlyCollection<Character> Characters => _characters;
        private readonly List<Item> _items = [];
        public IReadOnlyCollection<Item> Items => _items;
        //public List<Npc> Npcs { get; init; }
        //public List<Enemy> Enemies { get; init; }
    }
}
