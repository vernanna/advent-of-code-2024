using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day13._1;

public class ClawMachine(Button buttonA, Button buttonB, Prize prize)
{
    public Button ButtonA { get; } = buttonA;

    public Button ButtonB { get; } = buttonB;

    public Prize Prize { get; } = prize;

    public int? TokensNeeded()
    {
        for (var a = 0; a <= 100; a++)
        {
            var b1 = (-(((double)a * ButtonA.X - Prize.X) / ButtonB.X)).ToIntOrNull();
            var b2 = (-(((double)a * ButtonA.Y - Prize.Y) / ButtonB.Y)).ToIntOrNull();

            if (b1 != null && b1 == b2)
            {
                return a * ButtonA.Cost + b1 * ButtonB.Cost;
            }
        }

        return null;
    }

    public static ClawMachine Create(string[] input)
    {
        var buttonA = Button.Create(input[0], 3);
        var buttonB = Button.Create(input[1], 1);
        var prize = Prize.Create(input[2]);

        return new ClawMachine(buttonA, buttonB, prize);
    }
}