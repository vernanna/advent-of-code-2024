using AdventOfCode.Day05._2;
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
    .Select(update => rules.All(rule => rule.Validate(update)) ? 0 : update.WithSortedPages(rules).MiddlePageNumber)
    .Sum();

Console.WriteLine(result);