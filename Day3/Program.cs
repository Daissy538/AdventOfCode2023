// See https://aka.ms/new-console-template for more information
using Day3;

string path = "puzzle_input.txt";

var currentLint = File.ReadLines(path).ToArray();

var numbers = new List<int>();
for (int i = 0; i < currentLint.Length; i++)
{
    var enginge = new Engine();
    var previousLine = i > 0 ? currentLint[i-1] : null;
    var nextLine = i < currentLint.Length - 1 ? currentLint[i + 1] : null;

    var repsonse =  enginge.RetrieveValidPartNumbers(currentLint[i], previousLine, nextLine);

    numbers.AddRange(repsonse);
}

Console.WriteLine("Answer Day 2 Answer 1: " + numbers.Sum());

var currentLint2 = File.ReadLines(path).ToArray();

var numbers2 = new List<long>();
for (int i = 0; i < currentLint2.Length; i++)
{
    var enginge = new Engine();
    var previousLine = i > 0 ? currentLint2[i - 1] : null;
    var currentLine = currentLint2[i];
    var nextLine = i < currentLint2.Length - 1 ? currentLint2[i + 1] : null;

    var repsonse = enginge.CalGearRatio(currentLine, previousLine, nextLine);

    numbers2.AddRange(repsonse);
}

Console.WriteLine("Answer Day 2 Answer 2: " + numbers2.Sum());
