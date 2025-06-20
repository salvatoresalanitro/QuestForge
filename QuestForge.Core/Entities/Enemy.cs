using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestForge.Core.Entities
{
    public class Enemy
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double ChallengeRating { get; set; }
        public string Type { get; set; } = string.Empty;
        public Campaign? Campaign { get; set; }
        public Guid CampaignId { get; set; }
    }
}
