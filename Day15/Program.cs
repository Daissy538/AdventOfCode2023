// See https://aka.ms/new-console-template for more information
using Day15;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList()[0];

Stopwatch sw = new Stopwatch();
sw.Start();
var hasher = new Hasher();
var result = hasher.CurrentValue(currentLint);
sw.Stop();


Console.WriteLine($"Answer Day 15 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
var hasher2 = new Hasher();
hasher2.LoadBoxInstructions(currentLint);
var result2 = hasher2.CalculateTotalSumOfPowers();
sw2.Stop();


Console.WriteLine($"Answer Day 10 Answer 1: {result2} time: {sw2.ElapsedMilliseconds} ms");