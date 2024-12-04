// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;

IReadOnlyCollection<char?> mas = ['M', 'A', 'S'];

var result = Input
    .ReadTable()
    .Cells
    .Where(cell => cell.Value.Value == 'X')
    .SelectMany<Cell<Character>, IEnumerable<Cell<Character>?>>(
        cell =>
        [
            cell.CellsAbove(mas.Count),
            cell.CellsBelow(mas.Count),
            cell.CellsLeft(mas.Count),
            cell.CellsRight(mas.Count),
            cell.CellsLeftAbove(mas.Count),
            cell.CellsRightAbove(mas.Count),
            cell.CellsLeftBelow(mas.Count),
            cell.CellsRightBelow(mas.Count)
        ])
    .Count(characters => characters.Select(c => c?.Value.Value).SequenceEqual(mas));

Console.WriteLine(result);
