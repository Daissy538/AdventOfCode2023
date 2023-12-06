// See https://aka.ms/new-console-template for more information

using Day6;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();

var bootRace = new BootRace();

var time = currentLint[0].Replace(" ", "").Split(":").ToList();
var distance = currentLint[1].Replace(" ", "").Split(":").Where(s => !string.IsNullOrEmpty(s)).ToList();

var total  = 1l;
for (var i = 1; i < time.Count(); i++)
{
    total = total * bootRace.AmountOfWaysToWin(long.Parse(time[i]), long.Parse(distance[i]));
}


Console.WriteLine("Answer Day 6 Answer 1: "+ total);