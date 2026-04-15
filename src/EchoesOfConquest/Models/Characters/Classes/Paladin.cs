namespace EchoesOfConquest.Models;

public class Paladin : PlayerClass
{
    public override string Name => "Paladin";
    public override string Description => "A divine champion clad in holy armor, shielding allies and smiting evil.";
    public override int MaxHealth => 110;
    public override int Strength => 15;
    public override int ArmorClass => 17;
    public override Weapon StartingWeapon => new Weapon("Warhammer", 25, 10, "Paladin");
}
