namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public class Game
{
    private Player _player;
    private PlayerClass playerClass;
    private Queue<Enemy> _enemies;
    private Shop _shop;

    public void StartGame()
    {
        _player = CharacterCreation();
        _enemies = EnemyCreation();

        _shop = new Shop(new List<Item>
        {
            new HealthPotion("Small Potion", 20, 15),
            new HealthPotion("Large Potion", 40, 30),
            new Weapon("Battleaxe", 60, 10, "Fighter"),
            new Weapon("Shortsword", 45, 8, "Rogue"),
            new Weapon("Arcane Staff", 50, 9, "Wizard"),
        });

        bool quit = false;
        while (!quit && _player.IsAlive && _enemies.Count > 0)
        {
            Console.WriteLine($"\n[S]hop | [F]ight ({_enemies.Count} enemies remaining) | [Q]uit");
            var choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "S":
                    _shop.EnterShop(_player);
                    break;

                case "F":
                    var enemy = _enemies.Dequeue();
                    bool survived = StartCombat(_player, enemy);

                    if (survived)
                    {
                        var loot = enemy.DropLoot();
                        if (loot != null)
                        {
                            _player.AddToInventory(loot);
                            Console.WriteLine($"{enemy.Name} dropped {loot.Name}!");
                        }
                        _player.AddGold(enemy.DropGold());

                        if (_enemies.Count == 0)
                        {
                            Console.WriteLine("\nYou conquered all foes!");
                            break;
                        }

                        Console.Write("Do you want to continue? [Y/N]: ");
                        Console.ReadLine();
                    }
                    break;

                case "Q":
                    Console.Write("You are about to kill your character, are you sure? [Y/N]: ");
                    if (Console.ReadLine()?.ToUpper() == "Y")
                        quit = true;
                    break;
            }
        }

        if (!_player.IsAlive)
            Console.WriteLine("You have fallen in battle... Game Over.");
    }

    private Player CharacterCreation()
    {
        string? name;
        do
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(name));

        Console.WriteLine("Choose your class: \n" +
                          "[1] Fighter\n" +
                          "[2] Rogue\n" +
                          "[3] Wizard");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                playerClass = new Fighter();
                break;
            case "2":
                playerClass = new Rogue();
                break;
            case "3":
                playerClass = new Wizard();
                break;
            default:
                playerClass = new Fighter();
                break;
        }

        Console.WriteLine($"Welcome to the Echoes of Conquest, {name} the {playerClass.Name}!");
        return new Player(name, playerClass);
    }

    private Queue<Enemy> EnemyCreation()
    {
        HealthPotion smallPotion = new HealthPotion("Small Potion", 20, 15);
        Enemy goblin = new Enemy("Goblin", 40, 2, 4, 10, 10, smallPotion);

        Weapon axe = new Weapon("Axe", 30, 8);
        Enemy orc = new Enemy("Orc", 50, 4, 6, 14, 20, axe);

        HealthPotion largePotion = new HealthPotion("Large Potion", 40, 30);
        Enemy skeleton = new Enemy("Skeleton", 60, 3, 6, 13, 25, largePotion);

        Weapon magicStaff = new Weapon("Magic Staff", 50, 6, "Wizard");
        Enemy darkMage = new Enemy("Dark Mage", 60, 6, 10, 10, 40, magicStaff);

        Weapon rapiers = new Weapon("Rapiers", 40, 7, "Rogue");
        Enemy dragon = new Enemy("Dragon", 100, 8, 12, 20, 100, rapiers);

        return new Queue<Enemy>(new[] { goblin, orc, skeleton, darkMage, dragon });
    }

    private bool StartCombat(Player player, Enemy enemy)
    {
        Console.WriteLine($"**** {enemy.Name} appears! ****");

        while (player.IsAlive && enemy.IsAlive)
        {
            player.DisplayHealthBar();
            Console.WriteLine();
            enemy.DisplayHealthBar();

            Console.WriteLine("[A]ttack | [I]tem");
            var choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "A":
                    if (player.RollToHit(enemy.ArmorClass))
                    {
                        int dmg = player.RollDamage();
                        enemy.TakeDamage(dmg);
                        Console.WriteLine($"You hit {enemy.Name} for {dmg} damage!");
                    }
                    else
                    {
                        Console.WriteLine("Yikes! You missed.");
                    }
                    break;
                case "I":
                    player.ShowInventory();
                    Console.Write("Enter item number to use or [Enter] to cancel: ");
                    if (int.TryParse(Console.ReadLine(), out int i))
                    {
                        player.UseItem(i);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    continue;
            }

            if (!enemy.IsAlive) break;

            if (enemy.RollToHit(player.ArmorClass))
            {
                int dmg = enemy.RollDamage();
                player.TakeDamage(dmg);
                Console.WriteLine($"{enemy.Name} hits you for {dmg} damage!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} misses!");
            }
        }

        if (!enemy.IsAlive)
            Console.WriteLine($"\nYou defeated the {enemy.Name}!");

        return player.IsAlive;
    }
}
