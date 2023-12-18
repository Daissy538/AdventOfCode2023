using Day16;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var cave = new Cave();
cave.LoadMap(currentLint);
cave.UpdateBeam(new int[] {0,0}, new int[] {0, -1});
var result = cave.CountAllLigthedPlaces();
sw.Stop();


Console.WriteLine($"Answer Day 16 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
var cave2 = new Cave();
cave2.LoadMap(currentLint);
var result2 = cave2.FindTheLargest();
sw2.Stop();


Console.WriteLine($"Answer Day 16 Answer 2: {result2} time: {sw2.ElapsedMilliseconds} ms");