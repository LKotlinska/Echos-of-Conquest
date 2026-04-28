namespace EchoesOfConquest.Models.Spells;

public class Spell(string name, string damageType, int numberOfDice, int damageSides, int manaCost, string requiredClass, int saveDc = 12)
{
    public string Name { get; set; } = name;
    public string DamageType { get; set; } = damageType;
    public int DamageSides { get; set; } = damageSides;
    public int NumberOfDice { get; set; } = numberOfDice;
    public int ManaCost { get; set; } = manaCost;
    public string RequiredClass { get; set; } = requiredClass;
    public int SaveDC { get; set; } = saveDc;

    public int RollDamage()
    {
        return DiceRoller.RollMultiple(DamageSides, NumberOfDice);
    }
}
