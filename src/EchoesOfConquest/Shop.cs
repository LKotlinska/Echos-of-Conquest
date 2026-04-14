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
        // Filter once before the loop — no point rechecking class on every iteration.
        // Non-weapons pass through; weapons only show if they're unrestricted or match the player's class.
        var available = _itemsForSale
            .Where(i => i is not Weapon w || w.RequiredClass == "Any" || w.RequiredClass == player.PlayerClass.Name)
            .ToList();

        while (true)
        {
            Console.WriteLine($"\nGold: {player.Gold}g");

            for (int i = 0; i < available.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {available[i].GetInfo()}");
            }

            Console.WriteLine("[B]ack");
            Console.Write("\n > ");

            var input = Console.ReadLine()?.ToUpper();
            if (input == "B") break;

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > available.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("- I don't follow you. Buy? Sell? Or get out of my shop.");
                Console.ResetColor();
                continue;
            }

            var item = available[choice - 1]; // menu is 1-based, list is 0-based

            // SpendGold does the balance check and deduction atomically. No separate "can afford?" check needed
            if (player.SpendGold(item.BuyPrice))
            {
                player.AddToInventory(item);
                Console.WriteLine($"You bought {item.Name}!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Come back when you've got the coin, friend.");
                Console.ResetColor();
            }
        }
    }

    public void ShowSellMenu(Player player)
    {
        Console.WriteLine("- What would you like to sell?");
        while (true)
        {
            // Re-fetch inventory each iteration so the list stays accurate after each sale
            var inventory = player.GetInventory();

            if (inventory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("- You've got nothing worth trading, traveler.");
                Console.ResetColor();
                Console.WriteLine("[B]ack");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nGold: {player.Gold}g");

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {inventory[i].Name} | Sell: {inventory[i].SellPrice}g");
            }

            Console.WriteLine("[B]ack");
            Console.Write("\n > ");

            var input = Console.ReadLine()?.ToUpper();
            if (input == "B") break;

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > inventory.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("- Didn't catch that. Try again.");
                Console.ResetColor();
            }
            continue;

            var item = inventory[choice - 1];
            player.RemoveFromInventory(choice - 1);
            player.Gold += item.SellPrice;
            Console.WriteLine($"You sold {item.Name} for {item.SellPrice}g!");
        }
    }

    public void EnterShop(Player player)
    {
        Console.WriteLine("- Welcome, adventurer! What'll it be?");
        while (true)
        {
            Console.WriteLine("\n[P]urchase\n[S]ell\n[B]ack");
            Console.Write("\n > ");
            var input = Console.ReadLine()?.ToUpper();

            switch (input)
            {
                case "P": ShowBuyMenu(player); break;
                case "S": ShowSellMenu(player); break;
                case "B": return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
