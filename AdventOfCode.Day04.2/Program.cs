// See https://aka.ms/new-console-template for more information

using AdventOfCode.Shared;

var result = Input
    .ReadTable()
    .Cells
    .Count(
        cell =>
        {
            if (cell.Value.Value != 'A')
            {
                return false;
            }
            IReadOnlyCollection<char?> firstDiagonal = [cell.CellLeftAbove()?.Value.Value, cell.CellRightBelow()?.Value.Value];
            IReadOnlyCollection<char?> secondDiagonal = [cell.CellLeftBelow()?.Value.Value, cell.CellRightAbove()?.Value.Value];

            return firstDiagonal.Order().SequenceEqual(['M', 'S']) && secondDiagonal.Order().SequenceEqual(['M', 'S']);
        });

Console.WriteLine(result);