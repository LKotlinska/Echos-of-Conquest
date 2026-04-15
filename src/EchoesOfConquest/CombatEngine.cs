namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public class CombatEngine
{
    private readonly string[] _playerMissMessages =
    {
        "Your swing cuts through nothing but air!",
        "You lunge forward, but your opponent sidesteps with ease.",
        "Your weapon glances off their armor harmlessly.",
        "You stumble mid-swing - embarrassing, but survivable.",
        "A wild slash! You hit absolutely nothing.",
        "You overcommit and whiff completely.",
        "Your attack was telegraphed - they saw it coming a mile away.",
        "You strike with conviction... at the empty space beside them.",
        "Your blade finds only shadow where your foe once stood.",
        "A clumsy swing. Even the rats aren't impressed."
    };

    private readonly string[] _enemyMissMessages =
    {
        "{0} lunges at you, but you dodge just in time!",
        "{0} swings wildly and misses by a hair!",
        "{0} strikes at your chest, but your armor deflects the blow.",
        "{0} trips over its own feet mid-attack!",
        "{0} snarls and slashes - but you're already out of reach.",
        "You duck under {0}'s clumsy strike with room to spare.",
        "{0} hurls an attack that sails past your ear. Close one!",
        "{0} winds up a massive blow... and completely whiffs.",
        "You parry {0}'s strike and shove them back.",
        "{0} snaps at you but bites nothing but dust."
    };

    private readonly Random _random = new();

    public bool StartCombat(Player player, Enemy enemy)
    {

        List<(string message, ConsoleColor color)> combatLog = [];
        bool firstTurn = true;

        while (player.IsAlive && enemy.IsAlive)
        {
            Console.Clear();

            // Shows alert on first turn only to reduce clutter.
            if (firstTurn)
            {
                Console.WriteLine();
                WriteCombatBanner($" {enemy.Name.ToUpper()} APPEARS! ");
                Console.WriteLine();
                firstTurn = false;
            }

            Console.WriteLine();
            WriteSectionLine();
            // —————————————————————
            player.DisplayHealthBar();
            Console.WriteLine();
            enemy.DisplayHealthBar();
            // —————————————————————
            WriteSectionLine();
            Console.WriteLine();

            // Fo readability only last 4 combat msgs.
            var recent = combatLog.TakeLast(4).ToList();
            foreach (var (msg, color) in recent)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"  {msg}");
            }

            // Locks combat log to 4 rows height.
            for (int pad = recent.Count; pad < 4; pad++)
            {
                Console.WriteLine();
            }

            Console.ResetColor();
            // —————————————————————
            WriteSectionLine();
            Console.WriteLine("  [A]ttack | [I]tem");
            Console.Write(" > ");
            var choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "A":
                    if (player.RollToHit(enemy.ArmorClass))
                    {
                        int dmg = player.RollDamage();
                        enemy.TakeDamage(dmg);
                        combatLog.Add(($"You hit {enemy.Name} for {dmg} damage!", ConsoleColor.Green));
                    }
                    else
                    {
                        combatLog.Add((_playerMissMessages[_random.Next(_playerMissMessages.Length)], ConsoleColor.DarkYellow));
                    }
                    break;
                case "I":
                    player.ShowInventory();

                    Console.WriteLine("  [B]ack");
                    Console.Write("\n > ");

                    var combatItemInput = Console.ReadLine()?.ToUpper() ?? "";

                    if (combatItemInput != "B" && int.TryParse(combatItemInput, out int idx))
                    {
                        player.UseItem(idx);
                    }
                    break;
                default:
                    combatLog.Add(("Invalid input — try again.", ConsoleColor.DarkGray));
                    continue;
            }

            if (!enemy.IsAlive) break;

            if (enemy.RollToHit(player.ArmorClass))
            {
                int dmg = enemy.RollDamage();
                player.TakeDamage(dmg);
                combatLog.Add(($"{enemy.Name} hits you for {dmg} damage!", ConsoleColor.Red));
            }
            else
            {
                combatLog.Add((string.Format(_enemyMissMessages[_random.Next(_enemyMissMessages.Length)], enemy.Name), ConsoleColor.DarkGray));
            }
        }

        Console.Clear();
        Console.WriteLine();
        // —————————————————————
        WriteSectionLine();
        player.DisplayHealthBar();
        Console.WriteLine();
        enemy.DisplayHealthBar();
        // —————————————————————
        WriteSectionLine();
        Console.WriteLine();

        foreach (var (msg, color) in combatLog.TakeLast(4))
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"  {msg}");
        }
        Console.ResetColor();
        Console.WriteLine();
        // —————————————————————
        WriteSectionLine();

        if (!enemy.IsAlive)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  *** You defeated the {enemy.Name}! ***\n");
            Console.ResetColor();
        }

        return player.IsAlive;
    }

    private static void WriteSectionLine()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  " + new string('─', 70));
        Console.ResetColor();
    }

    private static void WriteCombatBanner(string text)
    {
        // The box must be at least 32 chars wide, but grows if the text is longer
        int innerWidth = Math.Max(text.Length, 32);

        // Centering requires splitting the leftover space into two equal halves.
        // If the gap is odd, nudge the width up by 1 so the division is always clean.
        if ((innerWidth - text.Length) % 2 != 0) innerWidth++;

        // Equal space on each side so the text lands in the middle
        int padding = (innerWidth - text.Length) / 2;
        string paddedText = new string(' ', padding) + text + new string(' ', padding);

        // Top and bottom border matches the inner content width exactly
        string border = new string('═', innerWidth);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  ╔{border}╗");
        Console.WriteLine($"  ║{paddedText}║");
        Console.WriteLine($"  ╚{border}╝");
        Console.ResetColor();
    }
}
