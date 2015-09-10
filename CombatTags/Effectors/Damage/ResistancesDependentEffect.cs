using System.Collections.Generic;
using System.Linq;
using CombatTags.Models;
using Tags;
using Tags.Extensions;

namespace CombatTags.Effectors.Damage
{
    public class ResistancesDependentEffect : ICombatDependentEffect
    {
        public IEnumerable<TagLink> TagLinks { get; }

        public ResistancesDependentEffect(IEnumerable<TagLink> tagLinks)
        {
            TagLinks = tagLinks;
        }

        public float RunEffect(Attack context)
        {
            var applicableEffects = this.FindApplicableTags(context.Weapon, context.Target);
            return applicableEffects.Sum(x => context.Weapon.Damage * x.Weight);
        }
    }
}