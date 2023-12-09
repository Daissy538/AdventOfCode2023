// See https://aka.ms/new-console-template for more information
using Day9;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var predicator = new Predictor();

var result = predicator.TotalPredictionNumber(currentLint);
sw.Stop();


Console.WriteLine($"Answer Day 9 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
var predicator2 = new Predictor();

var result2 = predicator.TotalHistoryNumber(currentLint);
sw2.Stop();


Console.WriteLine($"Answer Day 9 Answer 1: {result2} time: {sw2.ElapsedMilliseconds} ms");
