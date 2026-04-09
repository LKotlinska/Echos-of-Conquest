using EchoesOfConquest.Models;

var enemy = new Enemy("Goblin", 80, 80, 12);
 

Console.WriteLine("Welcome to *** Echoes Of Conquest ***");

Console.Write("Enter your name: ");
var player = new Player(Console.ReadLine());

Console.WriteLine($"{player.Name} (HP: {player.Health}) vs {enemy.Name} (HP: {enemy.Health})");



while (player.Health != 0 || enemy.Health != 0)
{
    player.Attack(enemy);
    enemy.Attack(player);
}