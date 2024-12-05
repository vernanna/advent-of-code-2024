﻿using AdventOfCode.Shared;

namespace AdventOfCode.Day05._1;

public record Update(IReadOnlyCollection<int> PageNumbers)
{
    public int MiddlePageNumber => PageNumbers.ElementAt(PageNumbers.Count / 2);

    public static Update Parse(string input)
    {
        var numbers = input.GetNumbers(",").ToList();

        return new Update(numbers);
    }
}