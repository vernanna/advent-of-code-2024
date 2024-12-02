// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;

var result = Input
    .ReadLines()
    .Select(line => line.GetNumbers(" ").ToList())
    .Count(levels => levels.IsOrdered() && !levels.ContainsDuplicates() && levels.Pairwise().All(pair => Math.Abs(pair.Next - pair.Previous) <= 3));

Console.WriteLine(result);