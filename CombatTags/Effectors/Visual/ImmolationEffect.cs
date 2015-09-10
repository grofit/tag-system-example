using System.Collections.Generic;
using System.Linq;
using CombatTags.Models;
using Tags;
using Tags.Extensions;
using UnityEngine;

namespace CombatTags.Effectors.Visual
{
    public class ImmolationEffect: ICombatVisualDependentEffect
    {
        public IEnumerable<TagLink> TagLinks { get; }

        private void ApplyImmolationEffect(GameObject target, float strength)
        {
            // Do something here like adding a temporary fire effect
        }

        public bool RunEffect(Attack context)
        {
            var applicableTags = this.FindApplicableTags(context.Weapon, context.Target);
            if(!applicableTags.Any()) { return false; }

            var immolationStrenth = applicableTags.Sum(x => x.Weight);
            ApplyImmolationEffect(context.Target.GameObject, immolationStrenth);

            return true;
        }
    }
}