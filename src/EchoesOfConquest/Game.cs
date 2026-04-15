namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public class Game
{
    private readonly CombatEngine _combat = new();

    public void StartGame()
    {
        TitleScreen.Show();

        var player = CharacterCreation.Create();
        var enemies = WorldData.CreateEnemies();
        var shop = WorldData.CreateShop();

        bool quit = false;
        while (!quit && player.IsAlive && enemies.Count > 0)
        {
            PrintMainMenu();
            Console.Write(" > ");
            var choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "S": shop.EnterShop(player); break;
                case "I": RunInventoryMenu(player); break;
                case "F": RunFightSequence(player, enemies); break;
                case "C": player.ShowCharacterSheet(); break;
                case "Q": quit = ConfirmQuit(); break;
            }
        }

        if (!player.IsAlive)
            Console.WriteLine("You have fallen in battle... Game Over.");
    }

    private static void PrintMainMenu()
    {
        Console.WriteLine("\n[S]hop");
        Console.WriteLine("[I]nventory");
        Console.WriteLine("[F]ight");
        Console.WriteLine("[C]haracter");
        Console.WriteLine("[Q]uit");
    }

    private static void RunInventoryMenu(Player player)
    {
        player.ShowInventory();
    }

    private void RunFightSequence(Player player, Queue<Enemy> enemies)
    {
        while (player.IsAlive && enemies.Count > 0)
        {
            Console.Clear();
            var enemy = enemies.Dequeue();
            bool survived = _combat.StartCombat(player, enemy);

            if (!survived) break;

            HandleLoot(player, enemy);

            if (enemies.Count == 0)
            {
                Console.WriteLine("\nYou conquered all foes!");
                break;
            }

            Console.Write("\nDo you want to continue? [Y/N]: ");
            string continueChoice = Console.ReadLine()?.ToUpper() ?? "";
            if (continueChoice != "Y") break;
        }
    }

    private static void HandleLoot(Player player, Enemy enemy)
    {
        var loot = enemy.DropLoot();
        // Not every enemy is guaranteed to drop loot, so guard before adding.
        if (loot != null)
        {
            player.AddToInventory(loot);
            Console.WriteLine($"  {enemy.Name} dropped {loot.Name}!");
        }
        player.AddGold(enemy.DropGold());
    }

    private static bool ConfirmQuit()
    {
        Console.Write("You are about to kill your character, are you sure? [Y/N]: ");
        return Console.ReadLine()?.ToUpper() == "Y";
    }
}
