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
    private Item _loot;

    public Enemy(string name, int health, int attackBonus,
        int damageSides, int armorClass, Item loot = null)
    {
        Name = name;
        Health = _maxHealth = health;
        ArmorClass = armorClass;
        _attackBonus = attackBonus;
        _damageSides = damageSides;
        _loot = loot;
    }


    public bool RollToHit(int targetArmor)
    {
        return DiceRoller.Roll(20) + GetModifier(_attackBonus) >= targetArmor;
    }

    public int RollDamage()
    {
        return DiceRoller.Roll(_damageSides);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    private int GetModifier(int score)
    {
        return (score - 10) / 2;
    }
}