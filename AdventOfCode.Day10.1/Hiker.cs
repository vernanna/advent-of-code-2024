using AdventOfCode.Shared;

namespace AdventOfCode.Day10._1;

public class Hiker(Table<Position> map)
{
    public IEnumerable<IEnumerable<Cell<Position>>> GetTrails()
    {
        return map.Cells
            .Where(cell => cell.Value.Height == 0)
            .AsParallel()
            .SelectMany(GetTrails);
    }

    public IEnumerable<IEnumerable<Cell<Position>>> GetTrails(Cell<Position> cell)
    {
        if (cell.Value.Height == 9)
        {
            return [[cell]];
        }

        return cell
            .AdjacentCells(false)
            .Where(adjacentCell => adjacentCell.Value.Height == cell.Value.Height + 1)
            .SelectMany(GetTrails)
            .Select(trail => trail.Prepend(cell));
    }
}