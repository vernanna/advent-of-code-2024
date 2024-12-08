namespace AdventOfCode.Shared;

public class Cell<T>(T value, int row, int column, Table<T> table)
{
    public T Value { get; private set; } = value;

    public int Row { get; } = row;

    public int Column { get; } = column;

    public bool IsInSameRow(Cell<T> other) => Row == other.Row;

    public bool IsInSameColumn(Cell<T> other) => Column == other.Column;

    public IEnumerable<Cell<T>> AdjacentCells(bool includeDiagonals = true)
    {
        return new[]
        {
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

    public bool IsAdjacentToCell(bool includeDiagonals, params T[] valuesOfInterest) =>
        AdjacentCells(includeDiagonals).Any(cell => valuesOfInterest.Contains(cell.Value));

    public bool IsAdjacentToCell(bool includeDiagonals, Func<T, bool> predicate) =>
        AdjacentCells(includeDiagonals).Any(cell => predicate(cell.Value));

    public Cell<T>? CellAbove(int stepSize = 1) => CellWithOffset(-stepSize, 0);

    public IEnumerable<Cell<T>?> CellsAbove(int numberOfCells) => Enumerable.Range(1, numberOfCells).Select(CellAbove);


    public Cell<T>? CellBelow(int stepSize = 1) => CellWithOffset(stepSize, 0);

    public IEnumerable<Cell<T>?> CellsBelow(int numberOfCells) => Enumerable.Range(1, numberOfCells).Select(CellBelow);

    public Cell<T>? CellLeft(int stepSize = 1) => CellWithOffset(0, -stepSize);

    public IEnumerable<Cell<T>?> CellsLeft(int stepSize) =>
        Enumerable.Range(1, stepSize).Select(CellLeft);


    public Cell<T>? CellRight(int stepSize = 1) => CellWithOffset(0, stepSize);

    public IEnumerable<Cell<T>?> CellsRight(int stepSize) =>
        Enumerable.Range(1, stepSize).Select(CellRight);

    public Cell<T>? CellLeftAbove(int stepSize = 1) => CellWithOffset(-stepSize, -stepSize);

    public IEnumerable<Cell<T>?> CellsLeftAbove(int numberOfCells) =>
        Enumerable.Range(1, numberOfCells).Select(CellLeftAbove);

    public Cell<T>? CellRightAbove(int stepSize = 1) => CellWithOffset(-stepSize, stepSize);

    public IEnumerable<Cell<T>?> CellsRightAbove(int numberOfCells) =>
        Enumerable.Range(1, numberOfCells).Select(CellRightAbove);

    public Cell<T>? CellLeftBelow(int stepSize = 1) => CellWithOffset(stepSize, -stepSize);

    public IEnumerable<Cell<T>?> CellsLeftBelow(int numberOfCells) =>
        Enumerable.Range(1, numberOfCells).Select(CellLeftBelow);

    public Cell<T>? CellRightBelow(int stepSize = 1) => CellWithOffset(stepSize, stepSize);

    public IEnumerable<Cell<T>?> CellsRightBelow(int numberOfCells) =>
        Enumerable.Range(1, numberOfCells).Select(CellRightBelow);

    public Cell<T>? CellIn(Direction direction, int stepSize = 1) =>
        direction switch
        {
            Direction.Up => CellAbove(stepSize),
            Direction.Down => CellBelow(stepSize),
            Direction.Left => CellLeft(stepSize),
            Direction.Right => CellRight(stepSize),
            _ => null
        };

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

    public void UpdateValue(T value) => Value = value;
}