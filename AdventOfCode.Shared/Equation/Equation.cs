namespace AdventOfCode.Shared.Equation;

public static class Equation
{
    public static TwoDimensionalSolution SolveLinearSystem(decimal a1, decimal b1, decimal c1, decimal a2, decimal b2, decimal c2)
    {
        var determinant = a1 * b2 - a2 * b1;

        if (Math.Abs(determinant) < 1e-10m)
        {
            throw new ArgumentException("Non unique solution found");
        }

        var x = (c1 * b2 - c2 * b1) / determinant;
        var y = (a1 * c2 - a2 * c1) / determinant;

        return new TwoDimensionalSolution(x, y);
    }
}