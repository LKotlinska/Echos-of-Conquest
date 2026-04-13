namespace EchoesOfConquest.Models;

public class Player
{
    public string Name { get; set; }
    public PlayerClass PlayerClass { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ArmorClass { get; set; }
    public bool IsAlive => Health > 0;


    private int _strength;
    private bool _isDefending;
    private Weapon _equippedWeapon;
    private List<Item> _inventory = new();

    public Player(string name, PlayerClass playerClass)
    {
        Name = name;
        PlayerClass = playerClass;
        MaxHealth = playerClass.MaxHealth;
        Health = playerClass.MaxHealth;
        ArmorClass = playerClass.ArmorClass;
        _strength = playerClass.Strength;
        _equippedWeapon = playerClass.StartingWeapon;
    }

    public bool RollToHit(int targetArmor)
    {
        return DiceRoller.Roll(20) + GetModifier(_strength) >= targetArmor;
    }

    public int RollDamage()
    {
        return _equippedWeapon.RollDamage();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void AddToInventory(Item item)
    {
        _inventory.Add(item);
    }

    private int GetModifier(int score)
    {
        return (score - 10) / 2;
    }

    public void GetStatus()
    {
        Console.WriteLine($"{Name} ({PlayerClass.Name}) — HP: {Health}/{MaxHealth} | AC: {ArmorClass}");
    }

}
