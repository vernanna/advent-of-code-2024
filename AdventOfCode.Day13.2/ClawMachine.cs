using AdventOfCode.Shared.Equation;

namespace AdventOfCode.Day13._2;

public class ClawMachine(Button buttonA, Button buttonB, Prize prize)
{
    public Button ButtonA { get; } = buttonA;

    public Button ButtonB { get; } = buttonB;

    public Prize Prize { get; } = prize;

    public decimal? TokensNeeded()
    {
        var solution = Equation.SolveLinearSystem(ButtonA.X, ButtonB.X, Prize.X, ButtonA.Y, ButtonB.Y, Prize.Y);

        if (!solution.IsIntegralSolution() || solution.X < 0 || solution.Y < 0)
        {
            return null;
        }

        var a = Math.Round(solution.X);
        var b = Math.Round(solution.Y);

        return a * ButtonA.Cost + b * ButtonB.Cost;
    }

    public static ClawMachine Create(string[] input)
    {
        var buttonA = Button.Create(input[0], 3);
        var buttonB = Button.Create(input[1], 1);
        var prize = Prize.Create(input[2]);

        return new ClawMachine(buttonA, buttonB, prize);
    }
}