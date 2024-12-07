using AdventOfCode.Day07._2;
using AdventOfCode.Shared;

var result = Input
    .ReadEntries(": ", id => id.GetDouble(), TestValueSet.Create)
    .Where(entry => entry.Value.CanHaveResult(entry.Id))
    .Sum(entry => entry.Id);

Console.WriteLine(result);