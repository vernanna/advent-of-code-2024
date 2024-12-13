using AdventOfCode.Day07._1;
using AdventOfCode.Shared;
using StringExtensions = AdventOfCode.Shared.Extensions.StringExtensions;

var result = Input
    .ReadEntries(": ", id => StringExtensions.GetDouble(id), TestValueSet.Create)
    .Where(entry => entry.Value.CanHaveResult(entry.Id))
    .Sum(entry => entry.Id);

Console.WriteLine(result);