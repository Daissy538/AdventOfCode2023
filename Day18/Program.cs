using Day18;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var ground = new Ground();
var result = ground.Dig(currentLint);
sw.Stop();


Console.WriteLine($"Answer Day 18 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
sw2.Stop();


Console.WriteLine($"Answer Day 18 Answer 2:  time: {sw2.ElapsedMilliseconds} ms");

