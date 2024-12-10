// See https://aka.ms/new-console-template for more information

using AdventOfCode.Day10._1;
using AdventOfCode.Shared;

var map = Input.ReadTable(Position.Create);
var hiker = new Hiker(map);

var trails = hiker.GetTrails();

var result = trails
    .GroupBy(trail => trail.First())
    .Select(
        trailsByTrailHeads => trailsByTrailHeads
            .DistinctBy(trail => trail.Last())
            .Count())
    .Sum();

Console.WriteLine(result);