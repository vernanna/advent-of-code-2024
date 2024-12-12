using AdventOfCode.Shared;

var garden = Input.ReadTable();

var regions = garden.GetConnectedGroups().ToList();

regions
    .ForEach(region => Console.WriteLine($"{region.Value}: {region.Sides}"));

var result = regions
    .Select(region => region.Area * region.Sides)
    .Sum();

Console.WriteLine(result);