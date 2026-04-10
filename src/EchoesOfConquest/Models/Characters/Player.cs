namespace EchoesOfConquest.Models;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;
    public int Damage { get; set; } = 15;
    public List<Item> Inventory = new List<Item>();

    public Player(string name)
    {
        Name = name;
    }

    public void Attack(Enemy enemy)
    {
        if (enemy.Health <= Damage)
        {
            enemy.Health = 0;
            Console.WriteLine($"{enemy.Name} has been slain. You won!");
            return;
        }

        enemy.Health -= Damage;
        Console.WriteLine($"{enemy.Name} has been hit! HP left: {enemy.Health}");
    }

    public void AddToInventory(Item item)
    {
        Inventory.Add(item);
    }
}