namespace EchoesOfConquest;

using EchoesOfConquest.Models;

public static class CharacterCreation
{
    public static Player Create()
    {
        Console.Clear();
        string? name;
        do
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(name));

        var classes = new PlayerClass[] { new Fighter(), new Rogue(), new Wizard(), new Paladin() };

        Console.WriteLine("\nChoose your class:\n");
        for (int i = 0; i < classes.Length; i++)
        {
            var type = classes[i];
            var weapon = type.StartingWeapon;
            Console.WriteLine($"[{i + 1}] {type.Name} — {type.Description}");
            Console.WriteLine($"    HP: {type.MaxHealth}  |  STR: {type.Strength}  |  AC: {type.ArmorClass}  |  Weapon: {weapon.Name} (d{weapon.DamageSides})");
            Console.WriteLine();
        }

        int classChoice;
        string? input = null;
        while (!int.TryParse(input, out classChoice) || classChoice < 1 || classChoice > 4)
        {
            Console.Write("Your choice: ");
            input = Console.ReadLine();
        }

        PlayerClass playerClass = classChoice switch
        {
            1 => new Fighter(),
            2 => new Rogue(),
            3 => new Wizard(),
            4 => new Paladin(),
            _ => throw new InvalidOperationException("Unreachable"),
        };

        Console.Clear();
        Console.WriteLine($"Welcome to the Echoes of Conquest, {name} the {playerClass.Name}!");
        return new Player(name, playerClass);
    }
}
