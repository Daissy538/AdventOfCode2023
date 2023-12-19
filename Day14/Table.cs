using System.Collections.Generic;
using System.Text;

namespace Day14
{
    public class Table
    {
        private List<List<string>> table = new List<List<string>>();

        public void LoadTable(List<string> list)
        {
            foreach (var line in list)
            {
                table.Add(line.ToCharArray().Select(l => l.ToString()).ToList());
            }

            Console.WriteLine();
            Print();
        }

        public long Spin(int times)
        {
            var totals = new List<long>();

            var run = true;
            var turn = 1;
            while(run)
            {
                TilteNorth();
                TilteWest();
                TilteSouth();
                TilteEast();

                var score = TotalScore();
                totals.Add(score);
                Console.WriteLine($"Turn: {turn} Score: {score}");

                var isPowerOf = (times % turn) == 0;
                if (isPowerOf && totals.Count > 10) { 
                    var currentValue = totals[turn-1];
                    var previousValueIndex = -1;
                    for(int i = turn-2; i > 0; i--)
                    {
                        if (currentValue == totals[i])
                        {
                            previousValueIndex = i;
                            break;
                        }                        
                    }

                    var length = turn - previousValueIndex;
                    if (previousValueIndex-length-length > 0)
                    {
                        var subList = totals.GetRange(previousValueIndex, length);
                        var subList2 = totals.GetRange(previousValueIndex-(length-1), length);
                        var subList3 = totals.GetRange(previousValueIndex - (length -1 + length - 1), length);

                        if (subList.SequenceEqual(subList2) && subList3.SequenceEqual(subList3))
                        {
                            run = false;
                        }
                    }
                }
                turn++;
            }
            return totals.Last();
        }

        public void TilteNorth()
        {
            for (int i = 0; i < table[0].Count; i++)
            {
                UpdateColNorth(i);
            }
        }

        public void TilteEast()
        {
            for (int i = 0; i < table.Count; i++)
            {
                UpdateRowEast(i);
            }

        }

        public void TilteWest()
        {
            for (int i = 0; i < table.Count; i++)
            {
                UpdateRowWest(i);
            }
        }

        public void TilteSouth()
        {
            for (int i = 0; i < table[0].Count; i++)
            {
                UpdateColSouth(i);
            }
        }

        public long TotalScore() { 
            var scores = new List<long>();
            for(int i = 0;i < table[0].Count; i++)
            {
                var amount = table.Count - i;
                scores.Add(table[i].Count(t => t.Equals("O")) * amount);
            }

            return scores.Sum();
        }

        public void UpdateRowWest(int row)
        {
            var stones = new List<int>();
            var cubes = new List<int>();

            for (int col = 0; col < table[0].Count; col++)
            {
                switch (table[row][col])
                {
                    case "#":
                        cubes.Add(col);
                        break;
                    case "O":
                        stones.Add(col);
                        break;
                };
            }

            for (int i = 0; i < cubes.Count; i++)
            {
                var nextCube = i < cubes.Count - 1 ? cubes[i + 1] : table.Count;
                var subStones = stones.FindAll(s => s > cubes[i] && s < nextCube);
                stones = stones.FindAll(s => s < cubes[i] || s > nextCube);

                for (int col = 0; col < subStones.Count; col++)
                {
                    var currentCol = subStones[col];
                    table[row][currentCol] = ".";
                    table[row][cubes[i]+1+col] = "O";
                }
            }

            for (int col = 0; col < stones.Count; col++)
            {
                var currentCol = stones[col];
                table[row][currentCol] = ".";
                table[row][col] = "O";
            }
        }


        public void UpdateRowEast(int row)
        {
            var stones = new List<int>();
            var cubes = new List<int>();

            for (int col = 0; col < table.Count; col++)
            {
                switch (table[row][col])
                {
                    case "#":
                        cubes.Add(col);
                        break;
                    case "O":
                        stones.Add(col);
                        break;
                };
            }

            stones = stones.OrderDescending().ToList();
            //Als er een cube is
            for (int i = cubes.Count - 1; i >= 0; i--)
            {
                var nextCube = i > 0 ? cubes[i - 1] : -1;
                var subStones = stones.FindAll(s => s < cubes[i] && s > nextCube);
                stones = stones.FindAll(s => s > cubes[i] || s < nextCube);

                for (int col = 0; col < subStones.Count; col++)
                {
                    var currentCow = subStones[col];
                    table[row][currentCow] = ".";

                    table[row][cubes[i] - 1 - col] = "O";
                }
            }

            //Als er geen cubes zijn zet alles zo ver mogelijk naar achter
            for (int col = 0; col < stones.Count; col++)
            {
                var currentCol = stones[col];
                table[row][currentCol] = ".";

                table[row][table[0].Count - 1 - col] = "O";
            }
        }

        public void UpdateColNorth(int col)
        {
            var stones = new List<int>();
            var cubes = new List<int>();

            for(int row = 0; row < table.Count; row++)
            {
                switch(table[row][col])
                {
                    case "#": cubes.Add(row);
                            break;
                    case "O": stones.Add(row);
                             break;
                };
            }

            //Als er een cube is
            for(int i = 0; i < cubes.Count; i++)
            {
                var nextCube = i < cubes.Count-1 ? cubes[i + 1] : table.Count;
                var subStones = stones.FindAll(s => s > cubes[i] && s < nextCube);
                stones = stones.FindAll(s => s < cubes[i] || s > nextCube);

                for (int row = 0; row < subStones.Count; row++)
                {
                    var currentRow = subStones[row];
                    table[currentRow][col] = ".";
                    table[cubes[i]+1+row][col] = "O";
                }
            }

            //Als er geen cubes zijn zet alles zo ver mogelijk naar voren
            for (int row = 0; row < stones.Count; row++)
            {
                var currentRow = stones[row];
                table[currentRow][col] = ".";
                table[row][col] = "O";
            }
        }

        public void UpdateColSouth(int col)
        {
            var stones = new List<int>();
            var cubes = new List<int>();

            for (int row = 0; row < table.Count; row++)
            {
                switch (table[row][col])
                {
                    case "#":
                        cubes.Add(row);
                        break;
                    case "O":
                        stones.Add(row);
                        break;
                };
            }
            stones = stones.OrderDescending().ToList();

            //Als er een cube is
            for (int i = cubes.Count-1; i >= 0; i--)
            {
                var nextCube = i > 0 ? cubes[i - 1] : -1;
                var subStones = stones.FindAll(s => s < cubes[i] && s > nextCube);
                stones = stones.FindAll(s => s > cubes[i] || s < nextCube);

                for (int row = 0; row < subStones.Count; row++)
                {
                    var currentRow = subStones[row];
                    table[currentRow][col] = ".";

                    table[cubes[i] - 1 - row][col] = "O";

                }
            }

            //Als er geen cubes zijn zet alles zo ver mogelijk naar achter
            for (int row = 0; row < stones.Count; row++)
            {
                var currentRow = stones[row];
                table[currentRow][col] = ".";

                table[table.Count - 1 - row][col] = "O";

            }
        }

        private void Print()
        {
            foreach (var row in table)
            {
                var stringBuilder = new StringBuilder();
                foreach (var l in row)
                {
                    stringBuilder.Append(l.ToString());
                }

                Console.WriteLine(stringBuilder.ToString());
            }
        }

    }
}
