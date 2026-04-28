namespace EchoesOfConquest.Models;

public static class DiceRoller
{

    private static readonly Random _random = new();

    public static int Roll(int sides)
    {
        return _random.Next(1, sides + 1);
    }

    public static int RollDiceModifier(int sides, int modifier)
    {
        return Roll(sides) + modifier;
    }
    public static int RollMultiple(int sides, int numberOfDice)
    {
        int total = 0;
        for (int i = 0; i < numberOfDice; i++)
        {
            total += Roll(sides);
        }
        return total;
    }
}
