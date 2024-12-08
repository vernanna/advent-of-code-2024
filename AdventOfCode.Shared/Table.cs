using System.Text;

namespace AdventOfCode.Shared;

public class Table<T>
{
    private Cell<T>[,] cells;

    public Table(T[,] values)
    {
        cells = values.Map((value, row, column) => new Cell<T>(value, row, column, this));
        NumberOfRows = cells.GetLength(0);
        NumberOfColumns = cells.GetLength(1);
        Rows = Enumerable.Range(0, NumberOfRows).Select(
                rowNumber => Enumerable.Range(0, NumberOfColumns)
                    .Select(columnNumber => cells[rowNumber, columnNumber]))
            .ToList();
        Columns = Enumerable.Range(0, NumberOfColumns).Select(
                columnNumber => Enumerable.Range(0, NumberOfRows)
                    .Select(rowNumber => cells[rowNumber, columnNumber]))
            .ToList();
    }

    public int NumberOfRows { get; }

    public int NumberOfColumns { get; }

    public IEnumerable<Cell<T>> Cells => cells.Cast<Cell<T>>();

    public IEnumerable<IEnumerable<Cell<T>>> Rows { get; }

    public IEnumerable<Cell<T>> Row(int rowNumber) => Rows.ElementAt(rowNumber);

    public IEnumerable<IEnumerable<Cell<T>>> Columns { get; }

    public IEnumerable<Cell<T>> Column(int columnNumber) => Columns.ElementAt(columnNumber);

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

    public IEnumerable<Cell<T>> CellsInLineWith(Cell<T> first, Cell<T> second)
    {
        if (first.IsInSameRow(second))
        {
            return Row(first.Row);
        }

        if (first.IsInSameColumn(second))
        {
            Column(first.Column);
        }

        List<Cell<T>> cellsInLine = [first, second];

        var rowDifference = first.Row - second.Row;
        var columnDifference = first.Column - second.Column;

        var cell = first.CellWithOffset(rowDifference, columnDifference);
        var step = 1;
        while (cell != null)
        {
            cellsInLine.Add(cell);
            step++;
            cell = first.CellWithOffset(rowDifference * step, columnDifference * step);
        }

        cell = second.CellWithOffset(-rowDifference, -columnDifference);
        step = 1;
        while (cell != null)
        {
            cellsInLine.Add(cell);
            step++;
            cell = second.CellWithOffset(-rowDifference * step, -columnDifference * step);
        }

        return cellsInLine;
    }

    public Cell<T> this[int row, int column] => cells[row, column];

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        for (var row = 0; row < NumberOfRows; row++)
        {
            for (var column = 0; column < NumberOfColumns; column++)
            {
                stringBuilder.Append(cells[row, column].Value);
            }
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }
}