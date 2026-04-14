namespace EchoesOfConquest.Models;

public class Player
{
    public string Name { get; set; }
    public PlayerClass PlayerClass { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ArmorClass { get; set; }
    public bool IsAlive => Health > 0;
    public int Gold { get; set; }


    private int _strength;
    private bool _isDefending;
    private Weapon? _equippedWeapon;
    private List<Item> _inventory = new();

    public Player(string name, PlayerClass playerClass, int gold = 50)
    {
        Name = name;
        Gold = gold;
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
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void AddToInventory(Item item)
    {
        _inventory.Add(item);
    }

    public List<Item> GetInventory()
    {
        return _inventory;
    }

    public void RemoveFromInventory(int index)
    {
        _inventory.RemoveAt(index);
    }

    public bool SpendGold(int amount)
    {
        if (Gold < amount)
        {
            return false;
        }
        Gold -= amount;
        return true;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        Console.WriteLine($"You received {amount} gold! (Total: {Gold})");
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
        if (choice < 1 || choice > _inventory.Count)
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

    public void DisplayHealthBar()
    {
        int barWidth = 30;
        int filledWidth = (int)((double)Health / MaxHealth * barWidth);
        int emptyWidth = barWidth - filledWidth;

        ConsoleColor barColor = GetHealthColor();
        ConsoleColor original = Console.ForegroundColor;

        Console.Write($"{Name,-13} [");
        Console.ForegroundColor = barColor;
        Console.Write(new string('█', filledWidth));
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(new string('░', emptyWidth));
        Console.ForegroundColor = original;
        double pct = (double)Health / MaxHealth * 100;
        Console.WriteLine($"] {Health}/{MaxHealth} ({pct:F0}%)");
    }

    private ConsoleColor GetHealthColor()
    {
        double pct = (double)Health / MaxHealth;
        return pct > 0.6 ? ConsoleColor.Green :
                pct > 0.3 ? ConsoleColor.Yellow :
                ConsoleColor.Red;
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
}
