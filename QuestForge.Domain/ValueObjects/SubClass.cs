namespace QuestForge.Domain.ValueObjects
{
    public sealed record SubClass
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;

        private SubClass(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static SubClass Create(int id, string name)
        {
            return new SubClass(id, name);
        }
    }
}