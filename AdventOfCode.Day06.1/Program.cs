using AdventOfCode.Day06._1;
using AdventOfCode.Shared;

var map = Input.ReadTable();
var guard = Guard.Create(map);
guard.Walk();

Console.WriteLine(guard.VisitedCells.Distinct().Count());