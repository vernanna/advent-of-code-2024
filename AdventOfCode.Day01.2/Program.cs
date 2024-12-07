using AdventOfCode.Shared;

var lines = Input.ReadLines()
    .Select(line => line.GetInts(" ").ToList())
    .Select(numbersPerLine => (First: numbersPerLine[0], Second: numbersPerLine[1]))
    .ToList();

var firstLocationList = lines.Select(line => line.First).ToList();
var frequenciesOfSecondLocationList = lines
    .Select(line => line.Second)
    .GroupBy(locationId => locationId)
    .ToDictionary(id => id.Key, ids => ids.Count());

var result = firstLocationList.Sum(locationId => locationId * frequenciesOfSecondLocationList.GetValueOrDefault(locationId, 0));

Console.WriteLine(result);