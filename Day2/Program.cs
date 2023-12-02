// See https://aka.ms/new-console-template for more information
using Day2;

string path = "puzzle_input.txt";


using (StreamReader sr = File.OpenText(path))
{
    var game = new Game();
    var sum = 0;
    foreach (var line in File.ReadLines(path))
    {
        var result = game.validateGame(line);
        sum += result;
    }

    Console.WriteLine("Answer Day 2 Answer 1: " + sum);


    var game2 = new Game();
    var sum2 = 0;
    foreach (var line in File.ReadLines(path))
    {
        var result = game2.CalculateGamePower(line);
        sum2 += result;
    }

    Console.WriteLine("Answer Day 2 Answer 1: " + sum2);
}