namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public static class WorldData
{
    public static Queue<Enemy> CreateEnemies()
    {
        return new Queue<Enemy>(
        [
            new Enemy("Goblin Scout",  35,  2,  4, 10,   8,  new HealthPotion("Small Potion", 20, 15)),
            new Enemy("Bandit",        50,  3,  6, 12,  18,  new Weapon("Shortsword", 45, 8, "Rogue")),
            new Enemy("Orc Warrior",   70,  4,  8, 14,  30,  new HealthPotion("Large Potion", 40, 30)),
            new Enemy("Skeleton Archer", 55, 5, 6, 12,  35,  new Weapon("Crossbow", 50, 8, "Rogue")),
            new Enemy("Dark Mage",     75,  4, 10, 10,  50,  new Weapon("Arcane Staff", 50, 9, "Wizard")),
            new Enemy("Vampire Lord",  90,  6,  8, 15,  70,  new Weapon("Blessed Sword", 75, 11, "Paladin")),
            new Enemy("Dragon",       130,  8, 12, 18, 120,  new Weapon("Greatsword", 85, 12, "Fighter")),
        ]);
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
