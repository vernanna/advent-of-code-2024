namespace Template;

public class Table<T>
{
    private Cell<T>[,] cells;

    public Table(T[,] values)
    {
        cells = values.Map((value, row, column) => new Cell<T>(value, row, column, this));
        NumberOfRows = cells.GetLength(0);
        NumberOfColumns = cells.GetLength(1);
        Rows = Enumerable.Range(0, NumberOfRows).Select(rowNumber => Enumerable.Range(0, NumberOfColumns).Select(columnNumber => cells[rowNumber, columnNumber])).ToList();
    }

    public int NumberOfRows { get; }

    public int NumberOfColumns { get; }

    public IEnumerable<Cell<T>> Cells => cells.Cast<Cell<T>>();

    public IEnumerable<IEnumerable<Cell<T>>> Rows { get; }

    public IEnumerable<IEnumerable<Cell<T>>> RowWiseGroups(Func<Cell<T>, bool> predicate)
    {
        foreach (var row in Rows)
        {
            var group = new List<Cell<T>>();
            foreach (var cell in row)
            {
                if (predicate(cell))
                {
                    group.Add(cell);
                }
                else
                {
                    if (group.Count > 0)
                    {
                        yield return group;
                    }
                    group.Clear();
                }
            }
            if (group.Count > 0)
            {
                yield return group;
            }
        }
    }

    public Cell<T> this[int row, int column] => cells[row, column];
}
