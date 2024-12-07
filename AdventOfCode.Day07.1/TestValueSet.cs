using AdventOfCode.Shared;

namespace AdventOfCode.Day07._1;

public class TestValueSet(List<double> values)
{
    private static readonly IReadOnlyCollection<char> Operators = ['+', '*'];

    public bool CanHaveResult(double expectedResult)
    {
        var operatorPermutations = Operators.GetPermutations(values.Count - 1);

        foreach (var permutation in operatorPermutations)
        {
            var result = values[0];
            foreach (var (index, @operator) in permutation.Index())
            {
                var secondNumber = values[index + 1];
                result = @operator == '+' ? result + secondNumber : result * secondNumber;
            }

            if (Math.Abs(result - expectedResult) < 0.1)
            {
                return true;
            }
        }

        return false;
    }

    public static TestValueSet Create(string input)
    {
        var values = input.GetDoubles(" ").ToList();

        return new TestValueSet(values);
    }
}