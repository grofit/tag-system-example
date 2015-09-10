using System.Collections.Generic;
using CombatTags.Effectors.Damage;
using CombatTags.Models;
using NUnit.Framework;

namespace Tags.Tests.Effects
{
    [TestFixture]
    public class BonusDamageDependentEffectTests
    {
        [Test]
        public void should_correctly_apply_bonus_damage()
        {
            var dummyTagLink1 = new TagLink { SourceTag = "silver", DestinationTag = "werewolf", Weight = 1.0f };
            var dummyTagLink2 = new TagLink { SourceTag = "silver", DestinationTag = "undead", Weight = 0.5f };
            var dummyTagList = new List<TagLink>() { dummyTagLink1, dummyTagLink2 };

            var dummyWeapon = new Weapon { Damage = 1.0f, Tags = { "silver" } };
            var dummyTarget = new GameEntity(new List<string> { "werewolf", "undead" });
            var dummyAttack = new Attack {Weapon = dummyWeapon, Target = dummyTarget};
            
            var bonusDamageWeightEffect = new BonusDamageDependentEffect(dummyTagList);

            var expectedResult = 1.5f;
            var actualResult = bonusDamageWeightEffect.RunEffect(dummyAttack);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void should_only_apply_applicable_tags()
        {
            var dummyTagLink1 = new TagLink { SourceTag = "silver", DestinationTag = "werewolf", Weight = 1.0f };
            var dummyTagLink2 = new TagLink { SourceTag = "silver", DestinationTag = "undead", Weight = 0.5f };
            var dummyTagList = new List<TagLink>() { dummyTagLink1, dummyTagLink2 };

            var dummyWeapon = new Weapon { Damage = 1.0f, Tags = { "silver" } };
            var dummyTarget = new GameEntity(new List<string> { "werewolf" });
            var dummyAttack = new Attack { Weapon = dummyWeapon, Target = dummyTarget };

            var bonusDamageWeightEffect = new BonusDamageDependentEffect(dummyTagList);

            var expectedResult = 1.0f;
            var actualResult = bonusDamageWeightEffect.RunEffect(dummyAttack);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}