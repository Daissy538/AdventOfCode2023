// See https://aka.ms/new-console-template for more information
using Day11;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var galaxy = new Galaxy();

galaxy.LoadGalaxy(currentLint);
var result = galaxy.SumOfAllShortestDistance(10);

sw.Stop();


Console.WriteLine($"Answer Day 11 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");

Stopwatch sw2 = new Stopwatch();
sw2.Start();
var galaxy2 = new Galaxy();

galaxy2.LoadGalaxy(currentLint);
var result2 = galaxy2.SumOfAllShortestDistance(1000000);

sw2.Stop();


Console.WriteLine($"Answer Day 11 Answer 2: {result2} time: {sw2.ElapsedMilliseconds} ms");