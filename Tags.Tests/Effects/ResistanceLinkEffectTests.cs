using System.Collections.Generic;
using CombatTags.Effectors.Damage;
using CombatTags.Models;
using NUnit.Framework;

namespace Tags.Tests.Effects
{
    [TestFixture]
    public class ResistanceLinkEffectTests
    {
        [Test]
        public void should_correctly_apply_damage_mitigation()
        {
            var dummyTagLink1 = new TagLink { SourceTag = "magic", DestinationTag = "magic", Weight = -0.5f };
            var dummyTagLink2 = new TagLink { SourceTag = "physical", DestinationTag = "stalwart", Weight = -0.3f };
            var dummyTagList = new List<TagLink>() { dummyTagLink1, dummyTagLink2 };

            var dummyWeapon = new Weapon { Damage = 1.0f, Tags = { "magic", "physical" } };
            var dummyTarget = new GameEntity(new List<string> { "magic", "stalwart" });
            var dummyAttack = new Attack { Weapon = dummyWeapon, Target = dummyTarget };

            var resistancesLinkEffect = new ResistancesDependentEffect(dummyTagList);

            var expectedResult = -0.8f;
            var actualResult = resistancesLinkEffect.RunEffect(dummyAttack);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void should_only_apply_applicable_tags()
        {
            var dummyTagLink1 = new TagLink { SourceTag = "magic", DestinationTag = "magic", Weight = -0.5f };
            var dummyTagLink2 = new TagLink { SourceTag = "physical", DestinationTag = "stalwart", Weight = -0.3f };
            var dummyTagList = new List<TagLink>() { dummyTagLink1, dummyTagLink2 };

            var dummyWeapon = new Weapon { Damage = 1.0f, Tags = { "magic" } };
            var dummyTarget = new GameEntity(new List<string> { "magic" });
            var dummyAttack = new Attack { Weapon = dummyWeapon, Target = dummyTarget };

            var resistancesLinkEffect = new ResistancesDependentEffect(dummyTagList);

            var expectedResult =-0.5f;
            var actualResult = resistancesLinkEffect.RunEffect(dummyAttack);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}