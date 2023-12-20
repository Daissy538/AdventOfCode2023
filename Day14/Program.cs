using Day14;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var table = new Table();
table.LoadTable(currentLint);
table.TilteNorth();
var result = table.TotalScore();
sw.Stop();


Console.WriteLine($"Answer Day 14 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
Console.WriteLine(currentLint[0].Count());
sw2.Start();
var table2 = new Table();
table2.LoadTable(currentLint);
var result2 = table2.Spin(1000000000);
sw2.Stop();


Console.WriteLine($"Answer Day 14 Answer 2: {result2} time: {sw2.ElapsedMilliseconds} ms");