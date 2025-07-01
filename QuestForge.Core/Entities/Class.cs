namespace QuestForge.Core.Entities
{
    public class Class
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public List<SubClass> SubClasses { get; private set; } = [];

        public Class(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
