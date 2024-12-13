using AdventOfCode.Day13._2;
using AdventOfCode.Shared;

var result = Input.ReadLines()
    .Where(line => !string.IsNullOrWhiteSpace(line))
    .Chunk(3)
    .Select(ClawMachine.Create)
    .Sum(clawMachine => clawMachine.TokensNeeded() ?? 0);

Console.WriteLine(result);