namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public static class WorldData
{
    public static Queue<Enemy> CreateEnemies()
    {
        return new Queue<Enemy>(
        [
            new Enemy("Goblin",    40, 2, 4,  10, 10,  new HealthPotion("Small Potion", 20, 15)),
            new Enemy("Orc",       50, 4, 6,  14, 20,  new Weapon("Axe", 30, 8)),
            new Enemy("Skeleton",  60, 3, 6,  13, 25,  new HealthPotion("Large Potion", 40, 30)),
            new Enemy("Dark Mage", 60, 6, 10, 10, 40,  new Weapon("Magic Staff", 50, 6, "Wizard")),
            new Enemy("Dragon",   100, 8, 12, 20, 100, new Weapon("Rapiers", 40, 7, "Rogue")),
        ]);
    }

    public static Shop CreateShop()
    {
        return new Shop(
        [
            new HealthPotion("Small Potion", 20, 15),
            new HealthPotion("Large Potion", 40, 30),
            new Weapon("Battleaxe",   60, 10, "Fighter"),
            new Weapon("Shortsword",  45,  8, "Rogue"),
            new Weapon("Arcane Staff", 50, 9, "Wizard"),
        ]);
    }
}
