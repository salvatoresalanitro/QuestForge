namespace QuestForge.Domain.ValueObjects
{
    public sealed record SubClass
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public Class Class { get; init; }

        private SubClass(int id, string name, Class @class)
        {
            Id = id;
            Name = name;
            Class = @class;
        }

        public static SubClass Create(int id, string name, Class @class)
        {
            return new SubClass(id, name, @class);
        }
    }
}