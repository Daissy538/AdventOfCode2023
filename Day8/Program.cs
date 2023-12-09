// See https://aka.ms/new-console-template for more information
using Day8;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var route = new Route();

var directions = string.Concat(currentLint[0], currentLint[1]);

currentLint.RemoveAt(1);
currentLint.RemoveAt(0);

route.CreateNetwork(currentLint.ToArray());
var result = route.Walk(directions.ToList().Select(d => d.ToString()).ToArray());

sw.Stop();


Console.WriteLine($"Answer Day 8 Answer 1: {result} duration: {sw.ElapsedMilliseconds} ms");

var currentLint2 = File.ReadLines(path).ToList();

Stopwatch sw2 = new Stopwatch();
sw2.Start();
var route2 = new Route();

var directions2 = string.Concat(currentLint2[0], currentLint2[1]);

currentLint2.RemoveAt(1);
currentLint2.RemoveAt(0);

route2.CreateNetwork(currentLint2.ToArray());
var result2 = route2.GhostWalk(directions2.ToList().Select(d => d.ToString()).ToArray());

sw2.Stop();


Console.WriteLine($"Answer Day 8 Answer 2: {result2} duration: {sw2.ElapsedMilliseconds} ms");