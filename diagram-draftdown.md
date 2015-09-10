
# Generic Overview
``` diagrams
graph LR
subgraph Tags
    Tags("InputTags")
    Optional(DependentTags)
end
subgraph Context/Scenario
    Tags  --> Context(ContextualHandler)
    Optional  -.-> Context
end
subgraph Effects
    Context --> Output(OutputEffects)
end
```

# Combat Scenario
``` diagrams
graph LR
subgraph Weapon & Target
    Tags("silver, magic, sharp")
    Optional("werewolf, undead, frail")
end
subgraph Combat Scenario
    CombatHandler("CombatHandler")

    Tags --> CombatHandler
    Optional  -.-> CombatHandler
    CombatHandler  --> Damage(DamageCalculator)
    CombatHandler --> Visual(VisualEffectHandler)

end
subgraph Effects
    Damage --> Output("Bonus Damage")
    Visual --> Output2("Set On Fire")
end
```

# Crafting Scenario
``` diagrams
graph LR
subgraph Mats & Blueprint
    Tags("silver, magic, sharp")
    Optional("metal, sword")
end
subgraph Crafting Scenario
    CraftingHandler("CraftingHandler")

    Tags --> CraftingHandler
    Optional  -.-> CraftingHandler
    CraftingHandler  --> Durability(DurabilityCalculator)
    CraftingHandler --> Damage(DamageCalculator)
    CraftingHandler --> Value(ValueCalculator)

end
subgraph Effects
    Durability --> Output("Lower Durability")
    Damage --> Output2("Higher Damage")
    Value --> Output3("Higher Value")
end
```
