namespace EchoesOfConquest.Models;

public class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int ArmorClass { get; }
    public bool IsAlive => Health > 0;

    private int _attackBonus;
    private int _damageSides;
    private int _maxHealth;
    private int _goldDrop;
    private readonly int _saveModifier;
    private Item _loot;

    public Enemy(string name, int health, int attackBonus,
        int damageSides, int armorClass, int goldDrop, Item loot = null, int saveModifier = 0)
    {
        Name = name;
        Health = _maxHealth = health;
        ArmorClass = armorClass;
        _goldDrop = goldDrop;
        _attackBonus = attackBonus;
        _damageSides = damageSides;
        _saveModifier = saveModifier;
        _loot = loot;
    }

    public bool RollSave(int dc)
    {
        return DiceRoller.Roll(20) + _saveModifier >= dc;
    }

    public bool RollToHit(int targetArmor)
    {
        return DiceRoller.Roll(20) + _attackBonus >= targetArmor;
    }

    public int RollDamage()
    {
        return DiceRoller.Roll(_damageSides);
    }

    public void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
    }

    public Item DropLoot()
    {
        return _loot;
    }

    public int DropGold()
    {
        return _goldDrop;
    }

    public void DisplayHealthBar()
    {
        int barWidth = 30;
        int filledWidth = (int)((double)Health / _maxHealth * barWidth);
        int emptyWidth = barWidth - filledWidth;

        ConsoleColor barColor = GetHealthColor();
        ConsoleColor original = Console.ForegroundColor;

        Console.Write($"  {Name,-16} [");
        Console.ForegroundColor = barColor;
        Console.Write(new string('█', filledWidth));
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(new string('░', emptyWidth));
        Console.ForegroundColor = original;
        double pct = (double)Health / _maxHealth * 100;
        Console.WriteLine($"] {Health,4}/{_maxHealth} ({pct:F0}%)");
    }

    private ConsoleColor GetHealthColor()
    {
        // Green above 60%, yellow above 30%, red below. Same as player's health bar.
        double pct = (double)Health / _maxHealth;
        return pct > 0.6 ? ConsoleColor.Green :
            pct > 0.3 ? ConsoleColor.Yellow :
            ConsoleColor.Red;
    }

}