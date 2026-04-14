namespace EchoesOfConquest.Models;

public class HealthPotion : Item
{
    public int HealAmount { get; set; }

    public HealthPotion(string name, int buyPrice, int healAmount) : base(name, buyPrice)
    {
        HealAmount = healAmount;
    }

    public override string GetInfo()
    {
        return ($"{Name} | Heals {HealAmount} HP | Buy: {BuyPrice}g | Sell: {SellPrice}g");
    }
}