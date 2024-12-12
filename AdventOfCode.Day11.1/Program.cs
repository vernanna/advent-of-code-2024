// See https://aka.ms/new-console-template for more information

using AdventOfCode.Day11._1;
using AdventOfCode.Shared;

var stones = Input.ReadLines()
    .SelectMany(line => line.GetLongs(" "))
    .Select(id => new Stone(id))
    .ToList();

for (int i = 0; i < 25; i++)
{
    stones = stones.SelectMany(stone => stone.Transform()).ToList();
}

Console.WriteLine(stones.Count);