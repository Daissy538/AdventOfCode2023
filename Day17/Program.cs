using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
sw.Stop();


Console.WriteLine($"Answer Day 17 Answer 1:  time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
sw2.Stop();


Console.WriteLine($"Answer Day 17 Answer 2:  time: {sw2.ElapsedMilliseconds} ms");