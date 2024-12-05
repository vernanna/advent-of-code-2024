using AdventOfCode.Day05._1;
using AdventOfCode.Shared;

var lines = Input.ReadLines().ToList();

var rules = lines
    .TakeWhile(line => line != "")
    .Select(Rule.Parse)
    .ToList();
var updates = lines
    .SkipWhile(line => line != "")
    .Skip(1)
    .Select(Update.Parse)
    .ToList();

var result = updates
    .Where(update => rules.All(rule => rule.Validate(update)))
    .Select(update => update.MiddlePageNumber)
    .Sum();

Console.WriteLine(result);