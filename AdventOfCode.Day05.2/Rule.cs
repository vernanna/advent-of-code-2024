using AdventOfCode.Shared;

namespace AdventOfCode.Day05._2;

public record Rule(int FirstPageNumber, int SecondPageNumber)
{
    public bool IsApplicableTo(Update update) =>
        update.PageNumbers.Contains(FirstPageNumber) &&
        update.PageNumbers.Contains(SecondPageNumber);

    public bool Validate(Update update) => !IsApplicableTo(update) || update.PageNumbers.IndexOf(FirstPageNumber) < update.PageNumbers.IndexOf(SecondPageNumber);

    public static Rule Parse(string input)
    {
        var numbers = input.GetNumbers("|").ToList();

        return new Rule(numbers[0], numbers[1]);
    }
}