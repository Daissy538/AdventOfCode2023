// See https://aka.ms/new-console-template for more information
using Day1;

string path = "puzzle_1_input.txt";

var calculator = new Calculator();

using(StreamReader sr = File.OpenText(path))
{
    var numbers = new List<int>();
    string s;
    while((s = sr.ReadLine()) != null)
    {
        var number = calculator.CalculateAmountForString(s);
        numbers.Add(number);
    }

    var result = calculator.CalculateTotal(numbers.ToArray());

    Console.WriteLine("Answer Day 1 part 1 is: "+result);
}   
