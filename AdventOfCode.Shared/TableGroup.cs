namespace AdventOfCode.Shared;

public class TableGroup<T>(List<Cell<T>> cells)
{
    public T Value { get; } = cells.First().Value;

    public int Area => cells.Count;

    public int Perimeter => cells
        .Select(cell => 4 - cell.AdjacentCells(false).Count(cells.Contains))
        .Sum();

    public int Sides =>
        cells
            .Sum(
                cell => cell.Corners.Count(
                    corner =>
                        (corner.AdjacentCells.Count(adjacentCell => EqualityComparer<T>.Default.Equals(adjacentCell.Value, cell.Value)) == 2 &&
                         (corner.DiagonalCell == null || !EqualityComparer<T>.Default.Equals(corner.DiagonalCell.Value, cell.Value))) ||
                        corner.AdjacentCells.Count(adjacentCell => EqualityComparer<T>.Default.Equals(adjacentCell.Value, cell.Value)) == 0));

    public bool Contains(Cell<T> cell) => cells.Contains(cell);
}