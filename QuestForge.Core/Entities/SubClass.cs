using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestForge.Core.Entities
{
    public class SubClass
    {
        public int Id { get; init; }
        public string Name { get; private set; } = string.Empty;
        public int ClassId { get; private set; }
        public Class Class { get; private set; } = null!;

        public SubClass(int id, string name, int classId)
        {
            Id = id;
            Name = name;
            ClassId = classId;
        }
    }
}
