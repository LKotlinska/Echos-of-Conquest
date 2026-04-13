namespace EchoesOfConquest.Models;

public static class DiceRoller
{

    private static readonly Random _random = new();

    public static int Roll(int sides)
    {
        return _random.Next(sides);
    }

    public static int RollDiceModifier(int sides, int modifier)
    {
        
        return Roll(sides) + modifier;

    }
}