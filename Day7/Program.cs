// See https://aka.ms/new-console-template for more information

using Day7;
using System.Diagnostics;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

Stopwatch sw = new Stopwatch();
sw.Start();
var cardGame = new CardGame();

var result = cardGame.TotalWinnings(currentLint);
sw.Stop();


Console.WriteLine($"Answer Day 7 Answer 1: { result } time: { sw.ElapsedMilliseconds }");