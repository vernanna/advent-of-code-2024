using System.Collections.Concurrent;
using AdventOfCode.Day11._2;
using AdventOfCode.Shared;

var stones = Input.ReadLines()
    .SelectMany(line => line.GetLongs(" "))
    .Select(id => new Stone(id))
    .ToList();

stones = stones
    .SelectMany(stone => stone.Blink(25))
    .ToList();

// for (int i = 0; i < 75; i++)
// {
//     Console.WriteLine((double)i / 75);
//     stones = stones
//         .SelectMany<Stone, Stone>(
//             stone =>
//             {
//                 var stoneId = stone.Id;
//                 if (knownSequences.TryGetValue(stoneId, out var ids))
//                 {
//                     return ids.Select(id => new Stone(id));
//                 }
//
//                 var result = stone.Transform().ToList();
//                 knownSequences.Add(stoneId, result.Select(s => s.Id).ToList());
//                 return result;
//             })
//         .ToList();
// }

Console.WriteLine(stones.Count);