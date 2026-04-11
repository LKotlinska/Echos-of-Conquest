namespace EchoesOfConquest.Models;

public abstract class PlayerClass
{
    public abstract string Name { get; }
    public abstract int MaxHealth { get; }
    public abstract int Strength { get; }
    public abstract int ArmorClass { get; }
    public abstract Weapon StartingWeapon { get; }
}