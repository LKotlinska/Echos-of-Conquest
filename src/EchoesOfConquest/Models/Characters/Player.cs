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

}
