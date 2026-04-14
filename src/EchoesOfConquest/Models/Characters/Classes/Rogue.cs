namespace EchoesOfConquest.Models;

public class Rogue : PlayerClass
{
    public override string Name => "Rogue";
    public override string Description => "A stealthy, quick-witted opportunist.";
    public override int MaxHealth => 90;
    public override int Strength => 14;
    public override int ArmorClass => 14;
    public override Weapon StartingWeapon => new Weapon("Dagger", 15, 8, "Rogue");
}
