// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;

var result = Input
    .ReadLines()
    .Select(line => line.GetInts(" ").ToList())
    .Count(
        levels => levels.Select(
                (_, index) =>
                {
                    var updatedList = levels.ToList();
                    updatedList.RemoveAt(index);

                    return updatedList.IsOrdered() && !updatedList.ContainsDuplicates() &&
                           updatedList.Pairwise().All(pair => Math.Abs(pair.Next - pair.Previous) <= 3);
                })
            .Any(isValid => isValid));

Console.WriteLine(result);