// See https://aka.ms/new-console-template for more information

using Day10;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var ground = new Ground();
var startNode = ground.LoadGround(currentLint);
ground.LoadAllConnectedPipes(startNode);
var result = ground.GetLongestPath();
sw.Stop();


Console.WriteLine($"Answer Day 10 Answer 1: {result} time: {sw.ElapsedMilliseconds} ms");


Stopwatch sw2 = new Stopwatch();
sw2.Start();
var ground2 = new Ground();
var startNode2 = ground2.LoadGround(currentLint);
ground.LoadAllConnectedPipes(startNode);
var result2 = ground.FindTheNests();
sw2.Stop();


Console.WriteLine($"Answer Day 10 Answer 1: {result2} time: {sw2.ElapsedMilliseconds} ms");
