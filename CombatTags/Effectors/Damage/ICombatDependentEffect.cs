using CombatTags.Models;
using Tags.Effectors;

namespace CombatTags.Effectors.Damage
{
    public interface ICombatDependentEffect : ITagLinkEffect<Attack, float> {}
}
