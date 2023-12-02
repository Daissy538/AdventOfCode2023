
using System.Collections.Generic;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day1
{
    public class Calculator()
    {
        private readonly string[] stringNumbers = ["One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"];
 

        public int CalculateAmountForString(string text)
        {
            text = text.ToLower();

            var numbers = RetrieveNumbersFromString(text);
            var firstDigit = numbers[0];
            var lastDigit = numbers[numbers.Length-1];

            var result = $"{firstDigit}{ lastDigit}";

           return int.Parse(result); 
        }

        public object CalculateTotal(int[] list)
        {
           return list.Aggregate((x, y) => x + y);
        }

        private int[] RetrieveNumbersFromString(string text)
        {
            var response = new List<int>();

            for(int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    response.Add((int)Char.GetNumericValue(text[i]));
                }
                else
                {
                    for(int j = 1; i+j <= text.Length && j <= 5; j++)
                    {
                        var sub = text.Substring(i, j);

                        if(stringNumbers.Any(x => sub.Equals(x.ToLower())))
                        {
                            var numberInt = ConvertStringsToNumber(sub);
                            if (numberInt != null)
                            {
                                response.Add((int)numberInt);
                                break;
                            }
                        }

                    }

                }
            }

            return [.. response];
        }   

        private int? ConvertStringsToNumber(string text)
        {
            switch(text)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                default:
                    return null;
            }
        }
    }
}