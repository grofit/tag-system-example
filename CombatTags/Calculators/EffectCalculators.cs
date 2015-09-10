using System.Collections.Generic;
using CombatTags.Effectors.Visual;
using CombatTags.Models;

namespace CombatTags.Calculators
{
    public class VisualEffectCalculator
    {
        public IEnumerable<ICombatVisualDependentEffect> VisualEffects { get; }

        public VisualEffectCalculator(IEnumerable<ICombatVisualDependentEffect> visualVisualEffects)
        {
            VisualEffects = visualVisualEffects;
        }

        public void ApplyVisualEffects(Attack attack)
        {
            foreach (var visualEffect in VisualEffects)
            {
                visualEffect.RunEffect(attack);
            }
        }
    }
}
