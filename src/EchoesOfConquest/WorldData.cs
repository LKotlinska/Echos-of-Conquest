namespace EchoesOfConquest;

using EchoesOfConquest.Models;
using EchoesOfConquest.Models.Spells;

public static class WorldData
{
    public static Queue<Enemy> CreateEnemies()
    {
        return new Queue<Enemy>(
        [
            new Enemy("Goblin Scout",   35,  2,  4, 10,   8, new HealthPotion("Small Potion", 20, 15), saveModifier:  0),
            new Enemy("Bandit",         50,  3,  6, 12,  18, new Weapon("Shortsword", 45, 8, "Rogue"),  saveModifier:  1),
            new Enemy("Orc Warrior",    70,  4,  8, 14,  30, new HealthPotion("Large Potion", 40, 30),  saveModifier:  2),
            new Enemy("Skeleton Archer",55,  5,  6, 12,  35, new Weapon("Crossbow", 50, 8, "Rogue"),    saveModifier:  1),
            new Enemy("Dark Mage",      75,  4, 10, 10,  50, new Weapon("Arcane Staff", 50, 9, "Wizard"),saveModifier: 4),
            new Enemy("Vampire Lord",   90,  6,  8, 15,  70, new Weapon("Blessed Sword", 75, 11, "Paladin"),saveModifier:3),
            new Enemy("Dragon",        130,  8, 12, 18, 120, new Weapon("Greatsword", 85, 12, "Fighter"), saveModifier: 5),
        ]);
    }

    public static List<Spell> CreateSpells()
    {
        return
        [
            // Wizard spells — arcane/elemental, high mana pool (90)
            new Spell("Magic Missile",   "Arcane",    1,  6,  5,  "Wizard", saveDc: 11),
            new Spell("Frostbolt",        "Frost",     1,  8,  8,  "Wizard", saveDc: 12),
            new Spell("Fireball",         "Fire",      2,  6,  15, "Wizard", saveDc: 14),
            new Spell("Chain Lightning",  "Lightning", 2,  8,  20, "Wizard", saveDc: 14),
            new Spell("Arcane Surge",     "Arcane",    3,  8,  30, "Wizard", saveDc: 16),

            // Rogue spells — shadow/poison, small mana pool (30)
            new Spell("Smoke Bomb",       "Shadow",    1,  4,  5,  "Rogue",  saveDc: 11),
            new Spell("Poison Dart",      "Poison",    1,  6,  8,  "Rogue",  saveDc: 12),
            new Spell("Shadow Step",      "Shadow",    1,  8,  12, "Rogue",  saveDc: 13),
        ];
    }

    public static Shop CreateShop()
    {
        return new Shop(
        [
            new HealthPotion("Small Potion",  20,  15),
            new HealthPotion("Medium Potion", 35,  28),
            new HealthPotion("Large Potion",  55,  45),
            new Weapon("Battleaxe",    60, 10, "Fighter"),
            new Weapon("Greatsword",   85, 12, "Fighter"),
            new Weapon("Shortsword",   45,  8, "Rogue"),
            new Weapon("Twin Blades",  65, 10, "Rogue"),
            new Weapon("Crossbow",     50,  8, "Rogue"),
            new Weapon("Arcane Staff", 50,  9, "Wizard"),
            new Weapon("Frost Wand",   70, 10, "Wizard"),
            new Weapon("Spellbook",    40,  8, "Wizard"),
            new Weapon("Holy Mace",    55, 10, "Paladin"),
            new Weapon("Blessed Sword", 75, 11, "Paladin"),
        ]);
    }
}
