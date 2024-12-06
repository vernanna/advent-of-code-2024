using AdventOfCode.Shared;

namespace AdventOfCode.Day06._1;

public class Guard(Cell<Character> currentCell, Direction currentDirection)
    : MovableObjectOnMap<Character>(currentCell, currentDirection)
{
    public static Guard Create(Table<Character> table)
    {
        var currentCell = table.Cells.Single(cell => cell.Value.Value is '<' or '>' or 'v' or '^');
        var currentDirection = currentCell.Value.Value switch
        {
            '^' => Direction.Up,
            '>' => Direction.Left,
            '<' => Direction.Right,
            'V' => Direction.Down,
            _ => throw new ArgumentOutOfRangeException()
        };

        return new Guard(currentCell, currentDirection);
    }

    public void Walk()
    {
        while (NextCell != null)
        {
            if (NextCell.Value.Value == '#')
            {
                TurnRight();
            }
            else
            {
                Move();
            }
        }
    }
}