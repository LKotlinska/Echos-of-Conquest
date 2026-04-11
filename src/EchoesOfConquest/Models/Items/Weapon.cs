namespace EchoesOfConquest.Models;

public class Weapon : Item
{  
    public int DamageSides { get; set; }
    public string RequiredClass { get; set; }

    // base() will pass arguments to the Item's constructor.
    public Weapon(string name, int damagesides, string requiredClass = "Any", string rarity = "Common") : base(name,
        rarity)
    {
        DamageSides = damagesides;
        RequiredClass = requiredClass;
    }

    public int RollDamage()
    {
        return DiceRoller.Roll(DamageSides);
    }

    public override string GetInto()
    {
        Console.WriteLine($"{Name} | {Rarity} | Dice d{DamageSides} | {RequiredClass}");
    }
}