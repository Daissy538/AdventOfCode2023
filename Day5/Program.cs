// See https://aka.ms/new-console-template for more information
using Day5;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToList();
var mapping = new Mapping();
var almanac = new Almanac();

var result = almanac.ProcessFile(currentLint);


Console.WriteLine("Answer Day 5 Answer 1: " + result);

var currentLint2 = File.ReadLines(path).ToList();
var mapping2 = new Mapping();
var almanac2 = new Almanac();

var result2 = almanac.ProcessFile2(currentLint);


Console.WriteLine("Answer Day 5 Answer 2: " + result2);