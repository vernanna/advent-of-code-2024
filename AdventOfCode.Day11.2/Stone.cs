// using System.Collections.Concurrent;
// using AdventOfCode.Shared;
//
// namespace AdventOfCode.Day11._2;
//
// public class Stone
// {
//     public Stone(long id)
//     {
//         Id = id;
//         NextIterations = new OrderedDictionary<int, List<Stone>>();
//     }
//
//     public long Id { get; private set; }
//
//     public OrderedDictionary<int, List<Stone>> NextIterations { get; }
//
//     public IEnumerable<Stone> Blink(int numberOfTimes)
//     {
//         var stones = new Dictionary<long, Stone>();
//         return Blink(numberOfTimes, stones);
//     }
//
//     public Dictionary<int, List<Stone>> Blink(int numberOfTimes, Dictionary<long, Stone> stones)
//     {
//         if (numberOfTimes == 0)
//         {
//             return new Dictionary<int, List<Stone>> {{0, [this]}};
//         }
//
//         var lastKnownIteration = NextIterations
//             .Keys
//             .LastOrDefault(key => key <= numberOfTimes, 0);
//
//         if (lastKnownIteration == numberOfTimes)
//         {
//             return NextIterations.TakeWhile(keyValuePair => keyValuePair.Key <= numberOfTimes).ToDictionary();
//         }
//
//         var currentStones = lastKnownIteration == 0
//             ? Transform().Select(stoneId => stones.GetOrAdd(stoneId, id => new Stone(id))).ToList()
//             : NextIterations[lastKnownIteration];
//         if (lastKnownIteration == 0)
//         {
//             NextIterations.TryAdd(1, currentStones);
//             lastKnownIteration = 1;
//         }
//
//         for (var iteration = lastKnownIteration + 1; iteration <= numberOfTimes; iteration++)
//         {
//             var x = currentStones.Select(stone => stone.Blink(numberOfTimes - iteration + 1, stones));
//         }
//
//         // var result = lastKnownIteration == 0
//         //     ? Transform()
//         //         .Select(stoneId => stones.GetOrAdd(stoneId, id => new Stone(id)))
//         //         .SelectMany(stone => stone.Blink(numberOfTimes - 1, stones))
//         //         .ToList()
//         //     : NextIterations[lastKnownIteration]
//         //         .SelectMany(stone => stone.Blink(numberOfTimes - lastKnownIteration, stones))
//         //         .ToList();
//
//         // NextIterations.TryAdd(numberOfTimes, result);
//
//         return result;
//     }
//
//     public Dictionary<int, List<Stone>> Iterations(int numberOfIterations, Dictionary<long, Stone> stones)
//     {
//         if (numberOfIterations == 0)
//         {
//             return new Dictionary<int, List<Stone>> {{0, [this]}};
//         }
//
//         if (NextIterations.ContainsKey(numberOfIterations))
//         {
//             return NextIterations.TakeWhile(keyValuePair => keyValuePair.Key <= numberOfIterations).ToDictionary();
//         }
//
//         var lastKnownIteration = NextIterations.Keys.LastOrDefault();
//         var currentStones = lastKnownIteration == 0
//             ? Transform().Select(stoneId => stones.GetOrAdd(stoneId, id => new Stone(id))).ToList()
//             : NextIterations[lastKnownIteration];
//         for (var iteration = lastKnownIteration + 1; iteration <= numberOfIterations; iteration++)
//         {
//             var previousStones = currentStones;
//             currentStones = currentStones
//                 .SelectMany(stone => stone.Transform())
//                 .Select(stoneId => stones.GetOrAdd(stoneId, id => new Stone(id)))
//                 .ToList();
//             NextIterations.TryAdd(iteration, currentStones);
//         }
//     }
//
//     public IEnumerable<long> Transform()
//     {
//         if (Id == 0)
//         {
//             return [1];
//         }
//
//         var idAsString = Id.ToString();
//         if (idAsString.Length % 2 == 0)
//         {
//             return
//             [
//                 long.Parse(idAsString.Substring(0, idAsString.Length / 2)),
//                 long.Parse(idAsString.Substring(idAsString.Length / 2, idAsString.Length / 2))
//             ];
//         }
//
//         return [Id * 2024];
//     }
// }