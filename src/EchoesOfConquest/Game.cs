namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public class Game
{
    private Player _player;
    private Queue<Enemy> _enemies;
    private Shop _shop;
    private readonly CombatEngine _combat = new();

    public void StartGame()
    {
        TitleScreen.Show();
        _player = CharacterCreation.Create();
        _enemies = WorldData.CreateEnemies();
        _shop = WorldData.CreateShop();

        bool quit = false;
        while (!quit && _player.IsAlive && _enemies.Count > 0)
        {
            Console.WriteLine($"\n[S]hop\n[I]nventory\n[F]ight ({_enemies.Count} enemies remaining)\n[C]haracter\n[Q]uit");
            var choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "S":
                    _shop.EnterShop(_player);
                    break;

                case "I":
                    while (true)
                    {
                        _player.ShowInventory();
                        Console.WriteLine("[B]ack");
                        var itemInput = Console.ReadLine()?.ToUpper() ?? "";
                        if (itemInput == "B") break;
                        if (int.TryParse(itemInput, out int itemChoice))
                            _player.UseItem(itemChoice);
                    }
                    break;

                case "F":
                    bool keepFighting = true;
                    while (keepFighting && _player.IsAlive && _enemies.Count > 0)
                    {
                        var enemy = _enemies.Dequeue();
                        bool survived = _combat.StartCombat(_player, enemy);

                        if (!survived) break;

                        var loot = enemy.DropLoot();
                        if (loot != null)
                        {
                            _player.AddToInventory(loot);
                            Console.WriteLine($"  {enemy.Name} dropped {loot.Name}!");
                        }
                        _player.AddGold(enemy.DropGold());

                        if (_enemies.Count == 0)
                        {
                            Console.WriteLine("\nYou conquered all foes!");
                            break;
                        }

                        Console.Write("Do you want to continue? [Y/N]: ");
                        string continueChoice = Console.ReadLine()?.ToUpper() ?? "";
                        keepFighting = continueChoice == "Y";
                    }
                    break;

                case "C":
                    _player.ShowCharacterSheet();
                    break;

                case "Q":
                    Console.Write("You are about to kill your character, are you sure? [Y/N]: ");
                    if (Console.ReadLine()?.ToUpper() == "Y")
                        quit = true;
                    break;
            }
        }

        if (!_player.IsAlive)
            Console.WriteLine("You have fallen in battle... Game Over.");
    }
}
