namespace EchoesOfConquest.Models;

public class Fighter : PlayerClass
{
    public override string Name => "Fighter";
    public override int MaxHealth => 120;
    public override int Strength => 16;
    public override int ArmorClass => 16;
    public override Weapon StartingWeapon => new Weapon("Longsword", 25, 10, "Fighter");
}