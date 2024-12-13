// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

var lines = Input.ReadLines()
    .Select(line => line.GetInts().ToList())
    .Select(numbersPerLine => (First: numbersPerLine[0], Second: numbersPerLine[1]))
    .ToList();

var firstLocationList = lines.Select(line => line.First).Order().ToList();
var secondLocationList = lines.Select(line => line.Second).Order().ToList();

var result = firstLocationList.Zip(secondLocationList, (first, second) => Math.Abs(first - second)).Sum();

Console.WriteLine(result);

