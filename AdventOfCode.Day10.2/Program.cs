using AdventOfCode.Day10._2;
using AdventOfCode.Shared;

var map = Input.ReadTable(Position.Create);
var hiker = new Hiker(map);

var trails = hiker.GetTrails();

var result = trails
    .GroupBy(trail => trail.First())
    .Select(trailsByTrailHeads => trailsByTrailHeads.Count())
    .Sum();

Console.WriteLine(result);