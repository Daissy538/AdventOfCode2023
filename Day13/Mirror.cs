using System.Collections.Generic;
using System.Text;

namespace Day13
{
    //To low        400
    //To low      31411
    //Not Correct 31925
    //To high     33231

    // part 2
    // To high    38664
    // To high    36676



    public class Mirror
    {
        public long FindAllMirrors2(List<string> list)
        {
            List<List<string>> lists = AbstractAllLists(list);

            var sum = 0L;
            foreach (var item in lists)
            {
                var total = FindMirror2(item);
                sum += total;
            }

            return sum;
        }

        public long FindMirror2(List<string> list)
        {
            char[][] grid = list.Select(l => l.ToCharArray()).ToArray();

            var hasMirrorRows = new List<Tuple<int, int>>();
            var hasMirrorCols = new List<Tuple<int, int>>();

            Console.WriteLine();
            foreach (var item in grid)
            {
                var stringBuilder = new StringBuilder();
                item.ToList().ForEach(i => stringBuilder.Append(i.ToString()));

                Console.WriteLine(stringBuilder.ToString());
            }

            var gridRowChanged = FindRowMatches(grid, hasMirrorRows);
            foreach (var hasMirrorRow in hasMirrorRows)
            {
                if (CheckAllMirrosRow(grid, hasMirrorRow))
                {
                    Console.WriteLine($"Result: {(hasMirrorRow.Item1 + 1) * 100}");
                    return (hasMirrorRow.Item1 + 1) * 100;
                }
            }

            var gridColChanged = FindColMatches(grid, hasMirrorCols);

            foreach (var hasMirrorCol in hasMirrorCols)
            {
                if (CheckAllMirrosCol(grid, hasMirrorCol))
                {
                    Console.WriteLine($"Result: {hasMirrorCol.Item1 + 1}");
                    return hasMirrorCol.Item1 + 1;
                }
            }

            if(hasMirrorCols.Count > 0 && hasMirrorRows.Count > 0)
            {
                Console.WriteLine($"To many mirrors. Col mirror {hasMirrorCols.Count} row mirrors: {hasMirrorRows.Count}");
            }

            Console.WriteLine($"Result: 0");
            return 0;
        }

        private bool CheckAllMirrosCol(char[][] grid, Tuple<int, int> hasMirrorCol)
        {
            if (hasMirrorCol != null)
            {
                var isMirrored = true;
                for (int col = hasMirrorCol.Item1 - 1, col2 = hasMirrorCol.Item2 + 1;
                    col >= 0 && col2 < grid[0].Length;
                    col--, col2++)
                {
                    var incorrectValues = new List<int>();
                    for (int row = 0; row < grid.Length; row++)
                    {
                        if (!grid[row][col].Equals(grid[row][col2]))
                        {
                            incorrectValues.Add(row);
                        }
                    }

                    if (incorrectValues.Count == 1)
                    {
                        grid[incorrectValues[0]][col] = grid[incorrectValues[0]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    }else if (incorrectValues.Count == 1)
                    {
                        grid[incorrectValues[0]][col] = grid[incorrectValues[0]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                        grid[incorrectValues[1]][col] = grid[incorrectValues[1]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    }

                    if (incorrectValues.Count > 2)
                    {
                        isMirrored = false;
                    }
                }

                return isMirrored;
            }

            return false;
        }

        private bool CheckAllMirrosRow(char[][] grid, Tuple<int, int> hasMirrorRow)
        {
            if (hasMirrorRow != null)
            {
                var isMirrored = true;
                for (int row = hasMirrorRow.Item1 - 1, row2 = hasMirrorRow.Item2 + 1;
                    row >= 0 && row2 < grid.Length;
                    row--, row2++)
                {
                    var incorrectValues = new List<int>();
                    for (int col = 0; col < grid[row].Length; col++)
                    {
                        if (!grid[row][col].Equals(grid[row2][col]))
                        {
                            incorrectValues.Add(col);
                        }
                    }

                    if (incorrectValues.Count == 1)
                    {
                        grid[row][incorrectValues[0]] = grid[row][incorrectValues[0]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    }
                    else if (incorrectValues.Count == 2)
                    {
                        grid[row][incorrectValues[0]] = grid[row][incorrectValues[0]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                        grid[row][incorrectValues[1]] = grid[row][incorrectValues[1]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");

                    }

                    if (incorrectValues.Count > 2)
                    {
                        isMirrored = false;
                    }
                }

                return isMirrored;
            }

            return false;
        }

        private bool FindColMatches(char[][] grid, List<Tuple<int, int>> hasMirrorCols)
        {
            var gridChanged = false;
            for (int col = 0; col < grid[0].Length-1; col++)
            {
                var incorrectValues = new List<int>();
                for (int row = 0; row < grid.Length; row++)
                {
                    if (!grid[row][col].Equals(grid[row][col+1]))
                    {
                        incorrectValues.Add(row);
                    }
                }

                if (incorrectValues.Count == 1)
                {
                    grid[incorrectValues[0]][col] = grid[incorrectValues[0]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    gridChanged = true;
                }else if (incorrectValues.Count == 1)
                {
                    grid[incorrectValues[0]][col] = grid[incorrectValues[0]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    grid[incorrectValues[1]][col] = grid[incorrectValues[1]][col].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                }

                if (incorrectValues.Count <= 2)
                {
                    hasMirrorCols.Add(new Tuple<int, int>(col, col + 1));
                }
            }

            return gridChanged;
        }

        public long FindAllMirrors(List<string> list)
        {
            List<List<string>> lists = AbstractAllLists(list);

            var sum = 0L;
            foreach (var item in lists)
            {
                var total = FindMirror(item);
                sum += total;
            }

            return sum;
        }

        public long FindMirror(List<string> list)
        {
            List<Tuple<int, int>> hashedRows = list
                .Select((l, index) => new Tuple<int, int>(l.GetHashCode(), index))
                .ToList();

            List<Tuple<int, int>> hasMirrorRows = SearchForMirror(hashedRows);

            List<Tuple<int, int>> hashedCols = new List<Tuple<int, int>>();

            for (var col = 0; col < list[0].Length; col++)
            {
                var stringBuilder = new StringBuilder();
                for (int row = 0; row < list.Count; row++)
                {
                    stringBuilder.Append(list[row][col]);
                }

                hashedCols.Add(new Tuple<int, int>(stringBuilder.ToString().GetHashCode(), col));
            }

            List<Tuple<int, int>> hasMirrorCols = SearchForMirror(hashedCols);

            var sum = 0;
            foreach(var hasMirrorRow in hasMirrorRows)
            {
                if (CheckAllMirros(hashedRows, hasMirrorRow))
                {
                    sum += (hasMirrorRow.Item1 + 1) * 100;
                }
            }

            foreach(var hasMirrorCol in hasMirrorCols)
            {
                if (CheckAllMirros(hashedCols, hasMirrorCol))
                {
                    sum += hasMirrorCol.Item1 + 1;
                }
            }

            return sum;

        }

        private List<List<string>> AbstractAllLists(List<string> list)
        {
            var lists = new List<List<string>>();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j].Equals(" ") || list[j].Equals(""))
                    {
                        lists.Add(list.GetRange(i, j - i));
                        i = j;
                        break;
                    }
                    else if (j == list.Count - 1)
                    {
                        lists.Add(list.GetRange(i, j - i + 1));
                        i = j;
                        break;
                    }
                }
            }

            return lists;
        }

        private List<Tuple<int, int>> SearchForMirror(List<Tuple<int, int>> hashedRows)
        {
            List<Tuple<int, int>> hasMirrorRow = new List<Tuple<int, int>>();
            for (int row = 0; row < hashedRows.Count - 1; row++)
            {
                if (hashedRows[row].Item1.Equals(hashedRows[row + 1].Item1))
                {
                    hasMirrorRow.Add(new Tuple<int, int>(hashedRows[row].Item2, hashedRows[row + 1].Item2));
                }
            }

            return hasMirrorRow;
        }

        private bool CheckAllMirros(List<Tuple<int, int>> hashedRows, Tuple<int, int>? hasMirrorRow)
        {
            if (hasMirrorRow != null)
            {
                var isMirrored= true;
                for (int row = hasMirrorRow.Item1 - 1, row2 = hasMirrorRow.Item2 + 1;
                    row >= 0 && row2 < hashedRows.Count;
                    row--, row2++)
                {
                    if (!hashedRows[row].Item1.Equals(hashedRows[row2].Item1))
                    {
                        isMirrored = false;
                    }
                }

                return isMirrored;
            }

            return false;
        }

        public bool FindRowMatches(char[][] grid, List<Tuple<int, int>> hasMirrorRows)
        {
            var gridChanged = false;
            for (int row = 0; row < grid.Length-1; row++)
            {
                var incorrectValues = new List<int>();
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (!grid[row][col].Equals(grid[row + 1][col]))
                    {
                        incorrectValues.Add(col);
                    }
                }

                if (incorrectValues.Count == 1)
                {
                    grid[row][incorrectValues[0]] = grid[row][incorrectValues[0]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    gridChanged = true;
                }else if (incorrectValues.Count == 2)
                {
                    grid[row][incorrectValues[0]] = grid[row][incorrectValues[0]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                    grid[row][incorrectValues[1]] = grid[row][incorrectValues[1]].Equals(char.Parse(".")) ? char.Parse("#") : char.Parse(".");
                }

                if (incorrectValues.Count <= 2)
                {
                    hasMirrorRows.Add(new Tuple<int, int>(row, row + 1));
                }
            }

            return gridChanged;
        }
    }
}
