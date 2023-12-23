using Day13;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();
Stopwatch sw = new Stopwatch();
sw.Start();
var mirror = new Mirror();
var result = mirror.FindAllMirrors(currentLint);
sw.Stop();


Console.WriteLine($"Answer Day 15 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
Console.WriteLine(currentLint[0].Count());
sw2.Start();
var mirror2 = new Mirror();
var result2 = mirror2.FindAllMirrors2(currentLint);
sw2.Stop();


Console.WriteLine($"Answer Day 15 Answer 2: {result2} time: {sw2.ElapsedMilliseconds} ms");
