// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Day5;

string path = "puzzle_input.txt";

Stopwatch sw1 = new Stopwatch();

sw1.Start();

var currentLint = File.ReadLines(path).ToList();
var mapping = new Mapping();
var almanac = new Almanac();

var result = almanac.ProcessFile(currentLint);
sw1.Stop();

Console.WriteLine("Answer Day 5 Answer 1: " + result);

Stopwatch sw2 = new Stopwatch();

sw2.Start();
var currentLint2 = File.ReadLines(path).ToList();
var mapping2 = new Mapping();
var almanac2 = new Almanac();

var result2 = almanac.ProcessFile2(currentLint);
sw2.Stop();

Console.WriteLine("Answer Day 5 Answer 2: " + result2);