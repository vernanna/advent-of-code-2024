﻿// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using AdventOfCode.Shared;

var result = Input.ReadLines()
    .SelectMany(line => Regex.Matches(line, @"mul\((\d+),(\d+)\)"))
    .Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
    .Sum();
Console.WriteLine(result);