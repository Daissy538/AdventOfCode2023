using System.Text;

namespace Day14
{
    //To High 104634
    //To Low  104618
    //Correct  104619
    public class Table
    {
        private List<List<string>> table = new List<List<string>>();

        public void LoadTable(List<string> list)
        {
            foreach (var line in list)
            {
                table.Add(line.ToCharArray().Select(l => l.ToString()).ToList());
            }
        }

        public long Spin(int times)
        {
            var totals = new HashSet<int>();

            var turn = 1;

            while(turn <= times)
            {
                TilteNorth();
                TilteWest();
                TilteSouth();
                TilteEast();

                var score = TotalScore();
                var postitions = GetGridHash();
                var hash = postitions.GetHashCode();

                Console.WriteLine($"Turn: {turn} Score: {score} Hash: {hash}");
                //Print();

                if (totals.Contains(hash))
                {
                    return score;
                }
                else
                {
                    totals.Add(hash);
                    turn++;
                }

            }

            return 0;
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

        public List<int[]> GetGridHash()
        {
            var positions = new List<int[]>();
       
            for (int row = 0; row < table.Count; row++)
            {
                for(int col = 0; col < table[row].Count; col++)
                {
                    if (table[row][col].Equals("O"))
                    {
                        positions.Add([row, col]);
                    }
                }
            }
            return positions;
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
            Console.WriteLine();
            foreach (var row in table)
            {
                var stringBuilder = new StringBuilder();
                foreach (var l in row)
                {
                    stringBuilder.Append(string.Join("", l));
                }

                Console.WriteLine(stringBuilder.ToString());
            }
        }

        private int GetAmountOfRocks()
        {
            var sum = 0;
            for (int row = 0; row < table.Count; row++)
            {
                sum = sum + table[row].Count(c => c.Equals("O"));
            }

            return sum;
        }

        private int GetAmountOfBlocks()
        {
            var sum = 0;
            for (int row = 0; row < table.Count; row++)
            {
                sum = sum + table[row].Count(c => c.Equals("#"));
            }

            return sum;
        }

    }
}
