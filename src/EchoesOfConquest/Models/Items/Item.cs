namespace EchoesOfConquest.Models;

public abstract class Item
{
    public string Name { get; set; }
    public string Rarity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice => BuyPrice / 2;

    protected Item(string name, int buyPrice, string rarity = "Common")
    {
        Name = name;
        BuyPrice = buyPrice;
        Rarity = rarity;
    }

    // Shared for all items
    public abstract string GetInfo();

}