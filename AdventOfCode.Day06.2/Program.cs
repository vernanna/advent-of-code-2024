using AdventOfCode.Day06._2;
using AdventOfCode.Shared;

var map = Input.ReadTable();
var guard = Guard.Create(map);

guard.Walk();
var cells = guard.VisitedCells.Distinct().ToList();
guard.Reset();

var numberOfLoops = 0;

foreach ((var index, var cell) in cells.Index())
{
    if (cell.Value.Value != '.')
    {
        continue;
    }

    cell.UpdateValue(new Character('#'));

    guard.Reset();
    if (!guard.Walk())
    {
        numberOfLoops++;
    }

    cell.UpdateValue(new Character('.'));

    Console.WriteLine(((double)index + 1) / cells.Count);
}

Console.WriteLine(numberOfLoops);