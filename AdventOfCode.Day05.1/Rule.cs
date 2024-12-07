using AdventOfCode.Shared;

namespace AdventOfCode.Day05._1;

public record Rule(int FirstPageNumber, int SecondPageNumber)
{
    public bool Validate(Update update) =>
        !update.PageNumbers.Contains(FirstPageNumber) ||
        !update.PageNumbers.Contains(SecondPageNumber) ||
        update.PageNumbers.IndexOf(FirstPageNumber) < update.PageNumbers.IndexOf(SecondPageNumber);

    public static Rule Parse(string input)
    {
        var numbers = input.GetInts("|").ToList();

        return new Rule(numbers[0], numbers[1]);
    }
}