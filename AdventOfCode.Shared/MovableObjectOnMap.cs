namespace AdventOfCode.Shared;

public abstract class MovableObjectOnMap<T>(Cell<T> currentCell, Direction currentDirection)
{
    private readonly Cell<T> startCell = currentCell;
    protected readonly Direction startDirection = currentDirection;

    protected readonly List<(Cell<T>, Direction)> path = [(currentCell, currentDirection)];

    public Cell<T> CurrentCell { get; private set; } = currentCell;

    public Cell<T>? NextCell => CurrentCell.CellIn(CurrentDirection);

    public IEnumerable<Cell<T>> VisitedCells => path.Select(tuple => tuple.Item1);

    public Direction CurrentDirection { get; private set; } = currentDirection;

    public int NumberOfSteps => VisitedCells.Count() - 1;

    protected void TurnRight() => CurrentDirection = (Direction)(((int)CurrentDirection + 1) % 4);

    protected void TurnLeft() => CurrentDirection = (Direction)Math.Abs(((int)CurrentDirection - 1) % 4);

    protected void Move()
    {
        var nextCell = NextCell;
        if (nextCell != null)
        {
            CurrentCell = nextCell;
            path.Add((CurrentCell, CurrentDirection));
        }
    }

    public void Reset()
    {
        path.Clear();
        CurrentCell = startCell;
        CurrentDirection = startDirection;
    }
}