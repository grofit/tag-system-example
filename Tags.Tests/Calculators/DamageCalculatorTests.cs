using CombatTags.Calculators;
using CombatTags.Effectors.Damage;
using CombatTags.Models;
using NSubstitute;
using NUnit.Framework;

namespace Tags.Tests.Calculators
{
    [TestFixture]
    public class DamageCalculatorTests
    {
        [Test]
        public void should_calculate_total_damage()
        {
            var mockBonusDamageEffect = Substitute.For<ICombatDependentEffect>();
            mockBonusDamageEffect.RunEffect(Arg.Any<Attack>()).Returns(2.0f); // 200% situational damage bonus

            var mockResistanceEffect = Substitute.For<ICombatDependentEffect>();
            mockResistanceEffect.RunEffect(Arg.Any<Attack>()).Returns(-1.0f);   // 100% situational resistance

            var mockPassiveEffect = Substitute.For<ICombatPassiveEffect>();
            mockPassiveEffect.RunEffect(Arg.Any<Weapon>()).Returns(0.5f);   // 50% passive damage bonus
            
            var dummyWeapon = new Weapon { Damage = 1.0f };
            var dummyTarget = new GameEntity();
            var dummyAttack = new Attack { Weapon = dummyWeapon, Target = dummyTarget };
            var damageCalculator = new DamageCalculator(new []{ mockBonusDamageEffect, mockResistanceEffect}, new []{ mockPassiveEffect });

            var expectedResult = 2.5f;
            var actualResult = damageCalculator.CalculateAttackDamage(dummyAttack);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}