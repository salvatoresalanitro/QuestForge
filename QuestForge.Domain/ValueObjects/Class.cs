namespace QuestForge.Domain.ValueObjects
{
    public sealed record Class
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public List<SubClass> SubClasses { get; init; } = [];

        private Class(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Class Create(int id, string name)
        {
            return new Class(id, name);
        }
    }
}
