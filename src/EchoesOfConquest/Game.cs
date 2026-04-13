namespace EchoesOfConquest;
using EchoesOfConquest.Models;
public class Game
{
    private Player _player;
    private PlayerClass playerClass;
    private List<Enemy> _enemies;



    private Player CharacterCreation()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        
        Console.WriteLine("Choose your class: \n" +
                          "[1] Fighter\n" +
                          "[2] Rogue" +
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
        
        Console.WriteLine($"Welcome {name} the {playerClass.Name}");
        return new Player(name, playerClass);
    }

    private List<Enemy> EnemyCreation()
    {
        _enemies = new List<Enemy>();

        HealthPotion smallPotion = new HealthPotion("Small Potion", 15);
        Enemy goblin = new Enemy("Goblin", 30, 2, 4, 10, smallPotion);

        Weapon axe = new Weapon("Axe", 8);
        Enemy orc = new Enemy("Orc", 50, 4, 6, 12, axe);

        HealthPotion largePotion = new HealthPotion("Large Potion", 30);
        Enemy skeleton = new Enemy("Skeleton", 40, 3, 6, 13, largePotion);

        Weapon magicStaff = new Weapon("Magic Staff", 6, "Wizard");
        Enemy darkMage = new Enemy("Dark Mage", 60, 5, 8, 11, magicStaff);

        Weapon rapiers = new Weapon("Rapiers", 7, "Rogue");
        Enemy dragon = new Enemy("Dragon", 100, 7, 10, 15, rapiers);
        
        _enemies.AddRange(new List<Enemy>() {goblin, orc, skeleton, darkMage, dragon});
        return _enemies;
    }
    
    
    
    
    
    
    
    
    
    
    
    
}