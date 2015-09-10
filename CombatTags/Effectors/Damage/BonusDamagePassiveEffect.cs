using System.Collections.Generic;
using System.Linq;
using CombatTags.Models;
using Tags;
using Tags.Extensions;

namespace CombatTags.Effectors.Damage
{
    public class BonusDamagePassiveEffect : ICombatPassiveEffect
    {
        public IEnumerable<TagWeight> TagWeights { get; }

        public BonusDamagePassiveEffect(IEnumerable<TagWeight> tagWeights)
        {
            TagWeights = tagWeights;
        }

        public float RunEffect(Weapon context)
        {
            var applicableEffects = this.FindApplicableTags(context);
            return applicableEffects.Sum(x => context.Damage*x.Weight);
        }
    }
}