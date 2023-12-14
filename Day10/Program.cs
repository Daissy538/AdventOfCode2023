// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
sw.Stop();


Console.WriteLine($"Answer Day 110 Answer 1:  time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
sw2.Stop();


Console.WriteLine($"Answer Day 9 Answer 1:  time: {sw2.ElapsedMilliseconds} ms");
