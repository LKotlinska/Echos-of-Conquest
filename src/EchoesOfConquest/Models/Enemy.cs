namespace EchoesOfConquest.Models;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }

    public Enemy(string name, int health, int maxHealth, int damage)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Damage = damage;
    }

    public void Attack(Player player)
    {
        if (player.Health <= Damage)
        {
            player.Health = 0;
            Console.WriteLine($"{player.Name} has been slain. You lost!");
            return;
        }

        player.Health -= Damage;
        Console.WriteLine($"{player.Name} has been hit! HP left: {player.Health}");

    }
}