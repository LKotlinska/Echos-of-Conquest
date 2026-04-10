namespace EchoesOfConquest.Models;

public abstract class Item
{
    public abstract string Name { get;  }
    // Must have a use method
    public abstract void Use(Player player);
}