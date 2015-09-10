using System.Collections.Generic;
using Tags;
using UnityEngine;

namespace CombatTags.Models
{
    public class GameEntity : ITagged
    {
        public List<string> Tags { get; }
        public GameObject GameObject { get; set; }

        public GameEntity()
        {
            Tags = new List<string>();
        }

        public GameEntity(List<string> tags)
        {
            Tags = tags;
        }
    }
}