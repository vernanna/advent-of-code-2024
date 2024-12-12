using AdventOfCode.Shared;

var garden = Input.ReadTable();

var regions = garden.GetConnectedGroups().ToList();

var result = regions
    .Select(region => region.Area * region.Perimeter)
    .Sum();

Console.WriteLine(result);



