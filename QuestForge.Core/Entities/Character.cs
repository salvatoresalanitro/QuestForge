using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestForge.Core.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; }
        public Class Class { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
    }
}
