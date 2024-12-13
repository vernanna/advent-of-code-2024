// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

var result = Input
    .ReadLines()
    .Select(line => line.GetInts().ToList())
    .Count(levels => levels.IsOrdered() && !levels.ContainsDuplicates() && levels.Pairwise().All(pair => Math.Abs(pair.Next - pair.Previous) <= 3));

Console.WriteLine(result);