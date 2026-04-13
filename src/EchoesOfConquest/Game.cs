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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}