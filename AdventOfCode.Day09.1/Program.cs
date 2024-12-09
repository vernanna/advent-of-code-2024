// See https://aka.ms/new-console-template for more information

using AdventOfCode.Day09._1;
using AdventOfCode.Shared;

var input = Input.ReadLines().Join("");
var diskMap = DiskMap.Create(input);
diskMap.Compress();

Console.WriteLine(diskMap.Checksum);