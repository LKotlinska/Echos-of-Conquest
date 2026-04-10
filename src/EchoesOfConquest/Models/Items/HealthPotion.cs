namespace EchoesOfConquest.Models;

public class HealthPotion : Item
{
    public override string Name { get; } = "Health Potion";

    public int Vitality { get; } = 20;

    public override void Use(Player player)
    {
        player.Health += Vitality;
        Console.WriteLine($"{player.Name} drank a {Name}. Restored {Vitality} points.");
    }
}