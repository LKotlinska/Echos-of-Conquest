using EchoesOfConquest.Models;

var gameOver = false;
var healthPotion = new HealthPotion();
Console.WriteLine();
var enemy = new Enemy("Goblin", 80, 80, 12);

Console.WriteLine("Welcome to *** Echoes Of Conquest ***");

Console.Write("Enter your name: ");
var player = new Player(Console.ReadLine());
Console.Clear();
Console.WriteLine($"{player.Name} (HP: {player.Health}) vs {enemy.Name} (HP: {enemy.Health})");

while (!gameOver)
{
    Console.WriteLine("Choose your action:\n" +
                      "1. Attack\n" +
                      "2. Use Health Potion\n" +
                      "3. Check health\n" +
                      "4. Check inventory\n" +
                      "5. Buy Health Potion"
                      
                      );
    
    var action = Console.ReadLine();
    
    switch (action)
    {
        case "1":
            Console.Clear();
            player.Attack(enemy);
            
            if (enemy.Health == 0)
            {
                Console.WriteLine("Game Over!");
                return;
            }
            enemy.Attack(player);
            break;
        case "2":
            Console.Clear();
            healthPotion.Use(player);
            // MUST SUBTRACT POTIONS FROM INVENTORY
            // CANNOT HEAL MORE THAN MAXHEALTH
            break;
        case "3":
            Console.Clear();
            Console.WriteLine($"{player.Name} has {player.Health} health left.");
            break;
        case "4":
            Console.Clear();
            if (player.Inventory.Count < 1)
            {
                Console.WriteLine("You don't have any items in your inventory.");
                break;
            }
            foreach (var item in player.Inventory)
            {
                Console.WriteLine("Inventory item: " + item.Name);
            }

            break;
        case "5":
            Console.Clear();
            player.AddToInventory(healthPotion);
            Console.WriteLine($"{healthPotion.Name} has been added to your inventory");
            break;
        case "6": 
            Console.Clear();
            DiceRoller.
            
    }
}
