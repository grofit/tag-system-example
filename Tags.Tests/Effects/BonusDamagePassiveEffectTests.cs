using System.Collections.Generic;
using CombatTags.Effectors.Damage;
using CombatTags.Models;
using NUnit.Framework;

namespace Tags.Tests.Effects
{
    [TestFixture]
    public class BonusDamagePassiveEffectTests
    {
        [Test]
        public void should_correctly_apply_bonus_damage()
        {
            var dummyTagWeight1 = new TagWeight {SourceTag = "magic", Weight = 0.5f};
            var dummyTagWeight2 = new TagWeight {SourceTag = "tough", Weight = 0.2f};
            var dummyTagList = new List<TagWeight>() { dummyTagWeight1, dummyTagWeight2 };

            var dummyWeapon = new Weapon {Damage = 1.0f, Tags = {"magic", "tough"}};
            var bonusDamageWeightEffect = new BonusDamagePassiveEffect(dummyTagList);

            var expectedResult = 0.70f;
            var actualResult = bonusDamageWeightEffect.RunEffect(dummyWeapon);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void should_only_apply_applicable_tags()
        {
            var dummyTagWeight1 = new TagWeight { SourceTag = "magic", Weight = 0.5f };
            var dummyTagWeight2 = new TagWeight { SourceTag = "tough", Weight = 0.2f };
            var dummyTagList = new List<TagWeight>() { dummyTagWeight1, dummyTagWeight2 };

            var dummyWeapon = new Weapon { Damage = 1.0f, Tags = { "magic" } };
            var bonusDamageWeightEffect = new BonusDamagePassiveEffect(dummyTagList);

            var expectedResult = 0.50f;
            var actualResult = bonusDamageWeightEffect.RunEffect(dummyWeapon);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
