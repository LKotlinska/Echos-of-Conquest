namespace EchoesOfConquest.Models;

public class Wizard : PlayerClass
{
    public override string Name => "Wizard";
    public override int MaxHealth => 70;
    public override int Strength => 10;
    public override int ArmorClass => 12;
    public override Weapon StartingWeapon => new Weapon("Staff", 20, 9, "Wizard");
}