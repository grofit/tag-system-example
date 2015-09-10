using System.Collections.Generic;
using System.Linq;
using CombatTags.Effectors.Damage;
using CombatTags.Models;

namespace CombatTags.Calculators
{
    public class DamageCalculator
    {
        public IEnumerable<ICombatDependentEffect> CombatLinkEffects { get; }
        public IEnumerable<ICombatPassiveEffect> CombatWeightEffects { get; }

        public DamageCalculator(IEnumerable<ICombatDependentEffect> combatLinkEffects, IEnumerable<ICombatPassiveEffect> combatWeightEffects)
        {
            CombatLinkEffects = combatLinkEffects;
            CombatWeightEffects = combatWeightEffects;
        }

        public float CalculateAttackDamage(Attack attack)
        {
            var baseDamage = attack.Weapon.Damage;
            var targetBonusDamage = CombatLinkEffects.Sum(combatLinkEffect => combatLinkEffect.RunEffect(attack));
            var passiveBonusDamage = CombatWeightEffects.Sum(combatLinkEffect => combatLinkEffect.RunEffect(attack.Weapon));
            return baseDamage + targetBonusDamage + passiveBonusDamage;
        }
    }
}
