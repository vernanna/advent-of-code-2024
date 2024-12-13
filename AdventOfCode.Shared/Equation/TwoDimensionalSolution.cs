namespace AdventOfCode.Shared.Equation;

public record TwoDimensionalSolution(decimal X, decimal Y)
{
    public bool IsIntegralSolution() => X == Math.Round(X) && Y == Math.Round(Y);
}