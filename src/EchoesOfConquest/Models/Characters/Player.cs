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
    private Weapon? _equippedWeapon;
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
        if (_equippedWeapon != null)
        {
            return _equippedWeapon.RollDamage();
        }
        else
        {
            return DiceRoller.Roll(4);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_isDefending)
        {
            Health -= (damage / 2);
        }

        Health -= damage;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
    public void Defend()
    {
        _isDefending = true;
        Console.WriteLine($"{Name} takes a defensive stance (damage halved this turn)!");
    }

    public void ResetDefend()
    {
        _isDefending = false;
    }

    public void AddToInventory(Item item)
    {
        _inventory.Add(item);
    }

    public void ShowInventory()
    {
        if (_inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }
        for (int i = 0; i < _inventory.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {_inventory[i].GetInfo()}");
        }
    }

    public void UseItem(int choice)
    {
        if (choice < 1)
        {
            return;
        }

        if (_inventory[choice - 1] is HealthPotion potion)
        {
            Heal(potion.HealAmount);
            Console.WriteLine($"You drink {potion.Name} and restore {potion.HealAmount} HP!");
            _inventory.RemoveAt(choice - 1);
        }
        else if (_inventory[choice - 1] is Weapon weapon)
        {
            _equippedWeapon = weapon;
            Console.WriteLine($"You equip {weapon.Name}!");
        }
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
