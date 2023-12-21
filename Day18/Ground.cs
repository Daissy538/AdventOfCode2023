using System.Drawing;

namespace Day18
{
    //To low 13237
    //To low 39097
    //

    public class Ground
    {
        private List<Tuple<int, int>> ground = new List<Tuple<int, int>>();

        public double Dig(List<string> list)
        {
            var startIndex = new Tuple<int, int>(0, 0);
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
        
        public double PicksTheorem(List<Tuple<int, int>> corners, int steps)
        {
            var totals = new List<int>();

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

        private Tuple<int, int> AddNewDirections(Tuple<int,int> index, int length, string direction)
        {
            var lastIndex = new Tuple<int, int>(index.Item1, index.Item2);
            switch (direction)
            {
                case "R":
                    lastIndex = new Tuple<int, int>(index.Item1, index.Item2 + length);
                    break;
                case "L":
                    lastIndex = new Tuple<int, int>(index.Item1, index.Item2 - length);
                    break;
                case "U":
                    lastIndex = new Tuple<int, int>(index.Item1 - length, index.Item2);
                    break;
                case "D":
                    lastIndex = new Tuple<int, int>(index.Item1 + length, index.Item2);
                    break;
            }
            
            ground.Add(lastIndex);
            return lastIndex;
        }
    }
}
