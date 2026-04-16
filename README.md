# Echoes of Conquest

A turn-based combat RPG built in C# (.NET 10), inspired by D&D 5e mechanics. Create a hero, pick a class, and fight through a gauntlet of increasingly dangerous enemies.

## Features

- **Four playable classes** — Fighter, Rogue, Wizard, and Paladin, each with unique stats and a starting weapon
- **D&D-style combat** — attack rolls (d20 + STR modifier vs. Armor Class), weapon dice for damage
- **Defend action** — halves incoming damage for one turn
- **Inventory system** — health potions, weapons with class restrictions, equip/unequip during combat
- **Shop** — buy and sell items between fights; shop filters to class-legal weapons automatically
- **Loot drops** — enemies drop gold and items on defeat
- **Seven enemy encounters** — Goblin Scout, Bandit, Orc Warrior, Skeleton Archer, Dark Mage, Vampire Lord, and Dragon
- **Character sheet** — shows HP, STR modifier, AC, equipped weapon, and gold
- **Health bars** — colour-coded (green / yellow / red) for both player and enemies
- **Scrolling combat log** — last four messages kept on screen per turn

## How to Play

1. Run the game and enter your character's name
2. Choose a class at the character creation screen
3. From the main menu you can:
   - `[F]ight` — enter the fight sequence (encounters queue in order)
   - `[S]hop` — buy or sell items between encounters
   - `[I]nventory` — view and use items outside of combat
   - `[C]haracter` — view your character sheet
   - `[Q]uit` — exit (prompts for confirmation)
4. In combat, choose `[A]ttack`, `[I]tem`, or `[D]efend` each turn
5. Defeat all seven enemies to win

## Playable Classes

| Class   | HP  | STR | AC  | Starting Weapon | Flavour                                         |
| ------- | --- | --- | --- | --------------- | ----------------------------------------------- |
| Fighter | 120 | 16  | 16  | Longsword (d10) | A wall of steel who hits hard and takes harder. |
| Rogue   | 90  | 14  | 14  | Dagger (d8)     | A stealthy, quick-witted opportunist.           |
| Wizard  | 70  | 10  | 12  | Staff (d9)      | Frail of body, commands arcane forces.          |
| Paladin | 110 | 15  | 17  | Warhammer (d10) | A divine champion clad in holy armor.           |

## Project Structure

```
EchoesOfConquest/
├── src/
│   └── EchoesOfConquest/
│       ├── Models/
│       │   ├── Characters/
│       │   │   ├── Classes/         # PlayerClass base + Fighter, Rogue, Wizard, Paladin
│       │   │   ├── Player.cs        # Player state, inventory, equip logic, health bar
│       │   │   └── Enemy.cs         # Enemy stats, loot drop, health bar
│       │   └── Items/
│       │       ├── Item.cs          # Abstract base class (name, price, rarity)
│       │       ├── Weapon.cs        # Damage dice, class restriction, equip behaviour
│       │       └── HealthPotion.cs  # Heal-on-use consumable
│       ├── CombatEngine.cs          # Turn loop, attack resolution, combat log
│       ├── CharacterCreation.cs     # Name input and class selection screen
│       ├── DiceRoller.cs            # Static Roll(sides) and RollDiceModifier helpers
│       ├── Game.cs                  # Main loop, menu routing, loot handling
│       ├── Shop.cs                  # Buy / sell menus with class filtering
│       ├── TitleScreen.cs           # Splash screen
│       ├── WorldData.cs             # Enemy queue and shop item list
│       └── Program.cs               # Entry point
└── README.md
```

## Requirements

- .NET 10 SDK or later

```
dotnet run --project src/EchoesOfConquest
```

---

## Planned Improvements

### Class Skills

Each class should have at least one active skill usable in combat, costing nothing but a turn:

### More D&D Mechanics

- **Ability scores** — add DEX, CON, INT, WIS, CHA to `PlayerClass`; DEX drives AC for light-armour classes (Rogue), CON adds bonus HP
- **Saving throws** — some enemy attacks (poison, fire breath) target a stat instead of AC
- **Spell slots** — Wizard and Paladin track a small slot table (level 1–2 for now) that resets after the shop/rest
- **Conditions** — Poisoned (damage over time), Stunned (skip turn), Frightened (attack at disadvantage)
- **Advantage / Disadvantage** — roll d20 twice and take the higher or lower result, used by skills and conditions
- **Critical hits** — a natural 20 on the attack roll doubles the damage dice

### Better Folder Structure

As the skill system and more item types are added, the following layout keeps things tidy:

```
Models/
├── Characters/
│   ├── Classes/
│   │   ├── Skills/          # ISkill interface + concrete skill classes
│   │   └── ...
│   └── ...
├── Items/
│   ├── Consumables/         # HealthPotion, future: Elixir, Scroll
│   └── Equipment/           # Weapon, future: Armour, Shield, Ring
└── Effects/                 # Condition effects (Poison, Stun, etc.)

UI/                          # Console helper methods (see below)
```

### Centralised UI Helpers

Console colour calls are scattered across `Player`, `Shop`, `CombatEngine`, and `Game`. A small static `UI` class would remove the duplication and make colour conventions consistent.
