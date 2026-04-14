namespace EchoesOfConquest;

using EchoesOfConquest.Models;
public class Shop
{
    private List<Item> _itemsForSale;

    public Shop(List<Item> itemsForSale)
    {
        _itemsForSale = itemsForSale;
    }

    public void ShowBuyMenu(Player player)
    {
        Console.Clear();
        Console.WriteLine("Welcome, adventurer! What'll it be?");
        var available = _itemsForSale
            .Where(i => i is not Weapon w || w.RequiredClass == "Any" || w.RequiredClass == player.PlayerClass.Name)
            .ToList();
        while (true)
        {
            Console.WriteLine($"Gold: {player.Gold}");
            for (int i = 0; i < available.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {available[i].GetInfo()}");
            }
            Console.WriteLine("[B]ack");

            var input = Console.ReadLine().ToUpper();
            if (input == "B") break;

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= available.Count)
            {
                var item = available[choice - 1];
                if (player.SpendGold(item.BuyPrice))
                {
                    player.AddToInventory(item);
                    Console.WriteLine($"You bought {item.Name}!");
                }
                else
                {
                    Console.WriteLine("You don't have enough gold!");
                }
            }
        }
    }

    public void ShowSellMenu(Player player)
    {
        Console.Clear();
        Console.WriteLine("What would you like to sell?");
        while (true)
        {
            Console.WriteLine($"\nGold: {player.Gold}g");
            var inventory = player.GetInventory();
            if (inventory.Count == 0)
            {
                Console.WriteLine("Nothing to sell!");
                return;
            }

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {inventory[i].Name} | Sell: {inventory[i].SellPrice}g");
            }
            Console.WriteLine("[B]ack");

            var input = Console.ReadLine()?.ToUpper();
            if (input == "B") break;

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= inventory.Count)
            {
                var item = inventory[choice - 1];
                player.RemoveFromInventory(choice - 1);
                player.Gold += item.SellPrice;
                Console.WriteLine($"You sold {item.Name} for {item.SellPrice}g!");
            }
        }
    }
    public void EnterShop(Player player)
    {
        while (true)
        {
            Console.WriteLine("\n[B]uy | [S]ell | [BA]ck");
            var input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "B":
                    ShowBuyMenu(player);
                    break;
                case "S":
                    ShowSellMenu(player);
                    break;
                case "BA":
                    return;
            }
        }
    }

}