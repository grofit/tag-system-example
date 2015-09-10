# Tag System Example

This is a quick system to show how you can use tags/keywords with procedural content to apply effects via configuration rather than it all being done in code. It has not been done in any sort of depth and is off top of my head so in real world scenarios you may want to add the notion of `HarmonizedTags` or something where you can have tags which *buff* other tags, such as `magic` may give `frost` an extra `0.1f` damage, or even the opposite where certain tags would have a negative effect on other ones.

There is an awful lot you can do with the system based upon the foundations.

## General Idea

### Basic Concept

So the general idea is that you make procedural objects based upon tags/keywords, so this way you can easily describe your items, creatures, objects, areas, spawns etc in some human readable and logical way. These tags are then processed to see how they effect things given a context and then a result is provided.

The reason we do this via context and not just global links is that tags could effect each other differently in different scenarios/contexts.

The general principal behind how it all works is something like this:

`ContextualObject{ tags } => ContextualEffects{ tags } => ResultingEffects{ values | outcomes }`

So if you have the tag `magic` on an item you may want to do an extra `50%` passive damage, so this could be expressed as:

`Weapon{ magic } => Combat { magic: 0.5f } => BaseDamage + (BaseDamage * 0.5f)`

That describes passive based effects but you could also do dependent style effects, so in combat for example you may want `silver` to do `200%` damage to `werewolves` or `100%` to `undead`, so this whole scenario can be described at a high level as:

`Weapon{ silver } && Target { werewolf } => Combat { werewolf: 2.0f, undead: 1.0f } => BaseDamage + (BaseDamage * 2.0f)`

### Scenario/Context

So now we have gone over the basic concept there is then the notion of context/scenario, so for example the tag `silver` may have a different effect based upon the context of where it is being applied.

So the concepts above were in the context of combat, however if you were to look at the context of crafting you may want silver to have a different effect. So lets say silver provides `50%` extra `value` to the weapon, but it is brittle so it has `-25%` to `durability`.

So this could be expressed as:

`Item {silver} => Crafting { silver: { value: 0.5f, durability: -0.25f } } => OutputItem { value: 1.5f, durability: 0.75 } // Assuming 1.0f default`

So the context can effect things differently based upon the context it is used within, so this is why we have configuration of tags at a context/scenario level.

This also means that you can express most of your links in any way you want and expose them to your own contextual effects.

## Projects

There are 3 projects within the solution:

### Tags

This is the main project which contains all the default interfaces and classes for tag based interactions, it only has a basic implementation so no harmonized tags or anything like that.

### CombatTags

This is an example of a combat context handler for tags, so it contains a few contextual objects (`Weapon`, `GameEntity`) and a few example effects (`DamageBonusPassiveEffect`, `ResistenceDependentEffect` etc). There is also a calculator which shows a high level way to handle all of this configuration and effects in some sane way.

The idea being shown here is that you make your effect objects take the context they need and act upon it, either returning something contextual of value (like damage bonuses) or carrying out an effect (like animating fire on a game object).

You can split up your effects as much as you want but generally in combat it is assumed you will attack with 1 weapon at a time (you may have multiple) and you will have some passive effects (are always going to apply) and some dependent effects (will only apply if target contains linked tags).

This is an overly simple example but it shows how you can wrap all this up via the `DamageCalculator` which takes in all the underlying effects that can be applied and just applies anything that is applicable and returns the result, this makes development simpler as at a high level you can just use this for damage calculations. However as all the effects are driven by tag links it means you do not need to write MASSES of code to drive all this, you can literally just have some json files which have this:

```
// passive-damage-bonus-config.json
{
    "silver": {
        "werewolf": 1.0f,
        "undead": 0.5f,
        "vampires": 0.75f,
        "metallic": -0.5f
    },
    "magic": {
        "humanoid": 0.1f,
        "magic": -0.1f
    },
    "blunt": {
        "metallic": -0.1f,
        "humanoid": 0.1f
    },
    "fire" : {
        "organic": 0.5f,
        "water": -1.0f
    }
    // ...
}
```

This way you can just load in the json file as your configuration to populate the `TagLinks` and then just drop them into your damage bonus section or whatever. This means your game is EASILY changed, so if after play testing you decide that you don't want silver to have a damage bonus against undead, so you just remove the line in the config rather than messing around with your source code. 
 
You ideally want configurations per context, so if you have the notion of combat, crafting, quests, npcs, areas etc you would want one config file per thing. Remember as well these weightings on keywords do not need to be used for just outputting numbers. If you look at the `ImmolationEffect` file, that does not do any damage calculations it just works out if it should apply an immolation effect to the game entity and if so how powerful the effect should be (i.e not so much flame 0.1f, or lots of flame 2.0f etc). So you can use the tags to drive any sort of effects be it numerical alternation effects on calculations or visual/system effects driven by the weighting values.

### Tags.Tests

This is just a place with some unit tests to show that the code works as expected and shows some basic examples of how the data would be setup for use. In the tests were are manually populating the tags and passing the effect config in, but in the real world you would probably use json files or something to contain your tag data as mentioned previously.

## Anything Else?

As mentioned this is a bare bones example knocked together to provide some sort of idea as to how tags could function in a part of game design without needing to move mountains to drive in game effects, there are probably far better ways to handle this sort of thing, and this only scratches the surface of what you can do with a tag/keyword based approach.

Incase you are still a bit unsure of what this is talking about, here are some simple diagrams showing what happens at a high level:

![Example Diagram](https://cloud.githubusercontent.com/assets/927201/9785605/81dc57d8-57ab-11e5-80f5-dd8ff936af29.png)

So in combat you would want to add your output effects from the CombatHandler to your base damage, to give you your tagged benefits/penalty. In the context of Crafting you would apply the output effects to your crafted item, so silver being brittle but of higher value and the other components would yield a default sword but with higher value and damage, but less durability. I am omitting configuration data as its described above but hopefully this at least gets you started.
