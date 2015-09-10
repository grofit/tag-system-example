using Tags;

namespace CombatTags.Models
{
    public class Attack
    {
        public Weapon Weapon { get; set; }
        public GameEntity Target { get; set; }
    }
}