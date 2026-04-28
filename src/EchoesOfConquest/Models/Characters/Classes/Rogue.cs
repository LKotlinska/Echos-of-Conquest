using EchoesOfConquest.Models.Spells;

namespace EchoesOfConquest.Models.Characters.Classes;

public class Rogue : PlayerClass
{
    public override string Name => "Rogue";
    public override string Description => "A stealthy, quick-witted opportunist.";
    public override int MaxHealth => 90;
    public override int Strength => 14;
    public override int ArmorClass => 14;
    
    public override int MaxMana => 30;
    public override int Mana => MaxMana;
    public override Weapon StartingWeapon => new Weapon("Dagger", 15, 8, "Rogue");
    public override List<Spell> StartingSpells =>
    [
        new("Smoke Bomb",  "Shadow", 1, 6,  5,  "Rogue",  saveDc: 11),
        new("Poison Dart", "Poison", 2, 4,  8,  "Rogue",  saveDc: 12),
        new("Shadow Step", "Shadow", 2, 6,  12, "Rogue",  saveDc: 13),
    ];
}
