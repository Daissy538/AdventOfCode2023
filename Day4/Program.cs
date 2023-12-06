// See https://aka.ms/new-console-template for more information
using Day4;

string path = "puzzle_input.txt";


using (StreamReader sr = File.OpenText(path))
{
    var lotery = new Lotery();
    var sum = 0;
    foreach (var line in File.ReadLines(path))
    {
        var result = lotery.CheckWinningNumbers(line);
        sum += result;
    }

    Console.WriteLine("Answer Day 4 Answer 1: " + sum);

}

using (StreamReader sr = File.OpenText(path))
{
    var lotery = new Lotery();
    var result = lotery.GetAllMyCards(File.ReadLines(path).ToList());

    var sum = result.Sum(c => c.Value);

    Console.WriteLine("Answer Day 4 Answer 2: " + sum);

}