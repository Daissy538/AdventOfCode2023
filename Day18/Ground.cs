using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

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

            var currentIndex = startIndex;
            for(var row = 0; row < list.Count; row++)
            {    
                var values = list[row].Split(" ");
                var direction = values[0];
                var length = values[1];
                var color = values[2];

                currentIndex = AddNewDirections(currentIndex, int.Parse(length), direction);
               
            }

            return PicksTheorem(ground);
        }

        public double CalFromMap(List<string> map)
        {
            for(var row = 0; row < map.Count; row++)
            {
                var items = map[row].ToCharArray().Select(c => c.ToString()).ToList();
                for(var col = 0; col < items.Count; col++)
                {
                    if (items[col].Equals("#"))
                    {
                        ground.Add(new Tuple<int, int>(row, col));
                    }     
                }       
            }

            return PicksTheorem(ground);
        }

        public double PicksTheorem(List<Tuple<int, int>> corners)
        {
            var totals = new List<int>();
            var test = corners.Aggregate((current, next) => current.Item2 * next.Item1 - current.Item1 * next.Item2).ToList();

            for (var row = 0; row < corners.Count()-1; row++)
            {
                var current = corners[row];
                var next = corners[row + 1];

                var left = current.Item2 * next.Item1;
                var rigth = current.Item1 * next.Item2;

                totals.Add(left - rigth);
            }
            
            double area = totals.Sum() /2;

            return area + (corners.Count/ 2) +1;
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
