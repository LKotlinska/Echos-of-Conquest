namespace EchoesOfConquest.Models;

public abstract class Item
{
    public string Name { get; set; }
    public string Rarity { get; set; }

    protected Item(string name, string rarity = "Common")
    {
        Name = name;
        Rarity = rarity;
    }

    // Shared for all items
    public abstract string GetInfo();

}