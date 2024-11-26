using Template;

var result = Input
    .ReadTable()
    .RowWiseGroups(cell => cell.Value.IsDigit)
    .Where(group => group.Any(cell => cell.IsAdjacentToCell(true, character => character.Value != '.' && !character.IsDigit)))
    .Select(group => int.Parse(string.Join("", group.Select(cell => cell.Value.Value.ToString()))))
    .Sum();

Console.WriteLine(result);