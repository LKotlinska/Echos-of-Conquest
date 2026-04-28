using EchoesOfConquest.Models.Spells;

namespace EchoesOfConquest.Models.Characters.Classes;

public class Wizard : PlayerClass
{
    public override string Name => "Wizard";
    public override string Description => "Frail of body, but commands arcane forces beyond reckoning.";
    public override int MaxHealth => 70;
    public override int Strength => 10;
    public override int ArmorClass => 12;
    public override int MaxMana => 90;
    public override int Mana => MaxMana;
    public override Weapon StartingWeapon => new Weapon("Staff", 20, 9, "Wizard");
    public override List<Spell> StartingSpells =>
    [
        new("Frostbolt", "Frost", 2, 6,  5, "Wizard", saveDc: 12),
        new("Fireball",  "Fire",  3, 6,  8, "Wizard", saveDc: 14),
    ];
}