using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestForge.Core.Entities
{
    public enum ItemType
    {
        Equipment,
        MagicItem,
        MagicWeapon,
        Weapon
    }

    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ItemType Type { get; set; }
        public Character? OwnerCharacter { get; set; }
        public Guid? OwnerCharacterId { get; set; }
        public Campaign? Campaign { get; set; }
        public Guid CampaignId { get; set; }
    }
}
