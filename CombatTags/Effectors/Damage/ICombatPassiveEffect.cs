using CombatTags.Models;
using Tags.Effectors;

namespace CombatTags.Effectors.Damage
{
    public interface ICombatPassiveEffect : ITagWeightEffect<Weapon, float> {}
}
