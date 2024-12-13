using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

var map = Input.ReadTable();

var result = map.Cells
    .Where(cell => cell.Value.Value != '.')
    .GroupBy(cell => cell.Value.Value)
    .SelectMany(
        antennas => antennas
            .UniquePairs()
            .SelectMany<(Cell<Character> First, Cell<Character> Second), Cell<Character>?>(
                pair =>
                {
                    var rowDifference = pair.First.Row - pair.Second.Row;
                    var columnDifference = pair.First.Column - pair.Second.Column;

                    return
                    [
                        pair.First.CellWithOffset(rowDifference, columnDifference),
                        pair.Second.CellWithOffset(-rowDifference, -columnDifference)
                    ];
                }))
    .WhereNotNull()
    .Distinct()
    .Count();

Console.WriteLine(result);