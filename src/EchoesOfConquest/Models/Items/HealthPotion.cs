namespace EchoesOfConquest.Models;

public class HealthPotion : Item
{
    public int HealAmount { get; set; }

    public HealthPotion(string name, int healAmount) : base(name)
    {
        HealAmount = healAmount;
    }

    public override string GetInfo()
    {
        Console.WriteLine($"{Name} | Heals {HealAmount} HP");
    }
}