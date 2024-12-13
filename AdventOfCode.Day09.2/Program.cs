using AdventOfCode.Day09._2;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

var input = Input.ReadLines().Join("");
var diskMap = DiskMap.Create(input);
diskMap.Compress();

Console.WriteLine(diskMap.Checksum);