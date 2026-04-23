namespace EchoesOfConquest.Models;

public abstract class PlayerClass
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int MaxHealth { get; }
    public abstract int Strength { get; }
    public abstract int ArmorClass { get; }
    public abstract int MaxMana { get; }
    public abstract int Mana { get; }
    public abstract Weapon StartingWeapon { get; }
}