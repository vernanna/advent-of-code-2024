namespace AdventOfCode.Shared;

public class Cell<T>
{
    private readonly Table<T> table;

    public Cell(T value, int row, int column, Table<T> table)
    {
        Value = value;
        Row = row;
        Column = column;
        this.table = table;
    }

    public T Value { get; }

    public int Row { get; }

    public int Column { get; }

    public IEnumerable<Cell<T>> AdjacentCells(bool includeDiagonals = true)
    {
        return new[]{
            CellAbove(),
            CellBelow(),
            CellLeft(),
            CellRight(),
            includeDiagonals ? CellWithOffset(-1, -1) : null,
            includeDiagonals ? CellWithOffset(-1, 1) : null,
            includeDiagonals ? CellWithOffset(1, -1) : null,
            includeDiagonals ? CellWithOffset(1, 1) : null,
        }.WhereNotNull();
    }

    public bool IsAdjacentToCell(bool includeDiagonals, params T[] valuesOfInterest) => AdjacentCells(includeDiagonals).Any(cell => valuesOfInterest.Contains(cell.Value));

    public bool IsAdjacentToCell(bool includeDiagonals, Func<T, bool> predicate) => AdjacentCells(includeDiagonals).Any(cell => predicate(cell.Value));

    public Cell<T>? CellAbove() => CellWithOffset(-1, 0);

    public Cell<T>? CellBelow() => CellWithOffset(1, 0);

    public Cell<T>? CellLeft() => CellWithOffset(0, -1);

    public Cell<T>? CellRight() => CellWithOffset(0, 1);

    public Cell<T>? CellWithOffset(int rowOffset, int columnOffset)
    {
        int row = Row + rowOffset;
        int column = Column + columnOffset;

        return
            row >= 0 &&
            row < table.NumberOfRows &&
            column >= 0 &&
            column < table.NumberOfColumns
                ? table[row, column]
                : null;
    }
}
