namespace EchoesOfConquest;

using EchoesOfConquest.Models;
public class Game
{
    private Player _player;
    private PlayerClass playerClass;
    private List<Enemy> _enemies;


    public void StartGame()
    {
        _player = CharacterCreation();
        _enemies = EnemyCreation();

        _player.AddToInventory(new HealthPotion("Potion", 40, 30));
        _player.AddToInventory(new HealthPotion("da", 40, 30));
        _player.AddToInventory(new HealthPotion("Potisdasdon", 40, 30));

        foreach (var enemy in _enemies)
        {
            StartCombat(_player, enemy);
        }
    }

    private Player CharacterCreation()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

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

    private List<Enemy> EnemyCreation()
    {
        List<Enemy> enemies = new List<Enemy>();

        HealthPotion smallPotion = new HealthPotion("Small Potion", 20, 15);
        Enemy goblin = new Enemy("Goblin", 40, 2, 4, 10, 10, smallPotion);

        Weapon axe = new Weapon("Axe", 30, 8);
        Enemy orc = new Enemy("Orc", 50, 4, 6, 14, 12, axe);

        HealthPotion largePotion = new HealthPotion("Large Potion", 40, 30);
        Enemy skeleton = new Enemy("Skeleton", 60, 3, 6, 13, 13, largePotion);

        Weapon magicStaff = new Weapon("Magic Staff", 50, 6, "Wizard");
        Enemy darkMage = new Enemy("Dark Mage", 60, 6, 10, 10, 18, magicStaff);

        Weapon rapiers = new Weapon("Rapiers", 40, 7, "Rogue");
        Enemy dragon = new Enemy("Dragon", 100, 8, 12, 20, 25, rapiers);

        enemies.AddRange(new List<Enemy>() { goblin, orc, skeleton, darkMage, dragon });
        return enemies;
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
            var choice = Console.ReadLine().ToUpper();

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

            if (enemy.IsAlive == false)
            {
                break;
            }

            if (enemy.RollToHit(player.ArmorClass))
            {
                int dmg = enemy.RollDamage();
                player.TakeDamage(dmg);
                Console.WriteLine($"{enemy.Name} hits your for {dmg} damage!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} misses!");
            }
        }

        if (enemy.IsAlive == false)
        {
            Console.WriteLine($"\nYou defeated the {enemy.Name}!");
            player.AddGold(enemy.DropGold());
            player.AddToInventory(enemy.DropLoot());
        }

        return player.IsAlive;
    }
}

