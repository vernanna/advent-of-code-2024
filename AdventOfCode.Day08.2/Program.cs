using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

var map = Input.ReadTable();

var result = map.Cells
    .Where(cell => cell.Value.Value != '.')
    .GroupBy(cell => cell.Value.Value)
    .SelectMany(
        antennas => antennas
            .UniquePairs()
            .SelectMany(pair => map.CellsInLineWith(pair.First, pair.Second)))
    .WhereNotNull()
    .Distinct()
    .Count();

Console.WriteLine(result);