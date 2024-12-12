namespace AdventOfCode.Day11._1;

public class Stone(long id)
{
    public long Id { get; private set; } = id;

    public IEnumerable<Stone> Transform()
    {
        if (Id == 0)
        {
            Id = 1;
            return [this];
        }

        var idAsString = Id.ToString();
        if (idAsString.Length % 2 == 0)
        {
            Id = long.Parse(idAsString.Substring(0, idAsString.Length / 2));
            var newStone = new Stone(long.Parse(idAsString.Substring(idAsString.Length / 2, idAsString.Length / 2)));

            return [this, newStone];
        }

        Id *= 2024;
        return [this];
    }
}