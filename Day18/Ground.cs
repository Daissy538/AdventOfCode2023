using System.Collections.Generic;
using System.Drawing;

namespace Day18
{
    //To low 13237
    //To low 39097
    //

    public class Ground
    {
        private List<Tuple<long, long>> ground = new List<Tuple<long, long>>();

        public double Dig(List<string> list)
        {
            var startIndex = new Tuple<long, long>(0, 0);
            ground.Add(startIndex);

            var steps = 0;
            var currentIndex = startIndex;
            for(var row = 0; row < list.Count; row++)
            {    
                var values = list[row].Split(" ");
                var direction = values[0];
                var length = values[1];
                var color = values[2];

                currentIndex = AddNewDirections(currentIndex, int.Parse(length), direction);
                steps += int.Parse(length);
            }

           return PicksTheorem(ground, steps);
        }

        public double Dig2(List<string> list)
        {
            var startIndex = new Tuple<long, long>(0, 0);
            ground.Add(startIndex);

            var steps = 0L;
            var currentIndex = startIndex;
            for (var row = 0; row < list.Count; row++)
            {
                var values = list[row].Split(" ");
                var color = values[2];

                color = color.Replace(" ", "")
                    .Replace("(", "")
                    .Replace(")", "");
                var hex = color.Substring(1, color.Length-2);
                var length = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                var direction = color.Replace(" ","").Substring(color.Length-1, 1);

                currentIndex = AddNewDirections(currentIndex, length, direction);
                steps += length;
            }

            return PicksTheorem(ground, steps);
        }

        public double PicksTheorem(List<Tuple<long, long>> corners, long steps)
        {
            var totals = new List<long>();

            for (var row = 0; row < corners.Count()-1; row++)
            {
                var current = corners[row];
                var next = corners[row + 1];

                var left = current.Item2 * next.Item1;
                var rigth = current.Item1 * next.Item2;

                totals.Add(left - rigth);
            }
            
            double area = totals.Sum() /2;

            return area + (steps/ 2) +1;
        }

        private Tuple<long, long> AddNewDirections(Tuple<long,long> index, int length, string direction)
        {
            var lastIndex = new Tuple<long, long>(index.Item1, index.Item2);
            switch (direction)
            {
                case "R" or "0":
                    lastIndex = new Tuple<long, long>(index.Item1, index.Item2 + length);
                    break;
                case "L" or "2":
                    lastIndex = new Tuple<long, long>(index.Item1, index.Item2 - length);
                    break;
                case "U" or "3":
                    lastIndex = new Tuple<long, long>(index.Item1 - length, index.Item2);
                    break;
                case "D" or "1":
                    lastIndex = new Tuple<long, long>(index.Item1 + length, index.Item2);
                    break;
            }
            
            ground.Add(lastIndex);
            return lastIndex;
        }
    }
}
