namespace AdventOfCode.Shared;

public class CellCorner<T>(Cell<T>? diagonalCell, List<Cell<T>?> adjacentCells)
{
    public Cell<T>? DiagonalCell { get; } = diagonalCell;

    public IReadOnlyCollection<Cell<T>> AdjacentCells { get; } = adjacentCells.WhereNotNull().ToList();

    public static IEnumerable<CellCorner<T>> Create(Cell<T> cell)
    {
        yield return new CellCorner<T>(cell.CellLeftAbove(), [cell.CellLeft(), cell.CellAbove()]);
        yield return new CellCorner<T>(cell.CellRightAbove(), [cell.CellRight(), cell.CellAbove()]);
        yield return new CellCorner<T>(cell.CellLeftBelow(), [cell.CellLeft(), cell.CellBelow()]);
        yield return new CellCorner<T>(cell.CellRightBelow(), [cell.CellRight(), cell.CellBelow()]);
    }
}