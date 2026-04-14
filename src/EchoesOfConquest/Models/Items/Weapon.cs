namespace EchoesOfConquest.Models;

public class Weapon : Item
{
    public int DamageSides { get; set; }
    public string RequiredClass { get; set; }

    // base() will pass arguments to the Item's constructor.
    public Weapon(string name, int buyPrice, int damagesides, string requiredClass = "Any", string rarity = "Common") : base(name, buyPrice,
        rarity)
    {
        DamageSides = damagesides;
        RequiredClass = requiredClass;
    }

    public int RollDamage()
    {
        return DiceRoller.Roll(DamageSides);
    }

    public override string GetInfo()
    {
        return ($"{Name} | {Rarity} | Dice d{DamageSides} | {RequiredClass} | Buy: {BuyPrice}g | Sell: {SellPrice}g");
    }
}