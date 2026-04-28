namespace EchoesOfConquest.Models.Characters.Classes;

public class Fighter : PlayerClass
{
    public override string Name => "Fighter";
    public override string Description => "A wall of steel who hits hard and takes harder.";
    public override int MaxHealth => 120;
    public override int Strength => 16;
    public override int ArmorClass => 16;
    
    public override int MaxMana => 0;
    public override int Mana => MaxMana;
    public override Weapon StartingWeapon => new Weapon("Longsword", 25, 10, "Fighter");
}