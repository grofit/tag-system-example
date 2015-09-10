using System.Collections.Generic;
using Tags;

namespace CombatTags.Models
{
    public class Weapon : ITagged
    {
        public float Damage { get; set; }
        public List<string> Tags { get; }

        public Weapon()
        {
            Tags = new List<string>();
        }
    }
}