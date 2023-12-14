

namespace Day11
{
    public class Galaxy
    {
        private List<List<string>> galaxy = new List<List<string>>();
        private Dictionary<int, int[]> markLocations = new Dictionary<int, int[]>();
        private List<int> emptyCol = new List<int>();
        private List<int> emptyRow = new List<int>();

        public long SumOfAllShortestDistance(int emptySpaces)
        {
            var results = new List<long>();
            for(var id = 1; id <= markLocations.Count; id++) {
                for(var nextId = id+1; nextId <= markLocations.Count; nextId++)
                {
                  results.Add(CalculateDitanceBetween(id, nextId, emptySpaces));
                }
            }

            return results.Sum();
        }

        public long CalculateDitanceBetween(int from, int to, int emptySpaces)
        {
            var fromIndex = (int[]) markLocations[from].Clone();
            var toIndex = (int[]) markLocations[to].Clone();

            var amountEmptyRows = emptyRow.Where(r => (r > fromIndex[0] && r < toIndex[0]) || (r < fromIndex[0] && r > toIndex[0])).Count();
            var amountEmptyCols = emptyCol.Where(c => (c > fromIndex[1] && c < toIndex[1]) || (c < fromIndex[1] && c > toIndex[1])).Count();

            var amountRows = amountEmptyRows * emptySpaces - amountEmptyRows;
            var amountCols = amountEmptyCols * emptySpaces - amountEmptyCols;
           

            if (amountRows > 0 && toIndex[0] > fromIndex[0])
            {
                toIndex[0] = toIndex[0] + amountRows;
            }else if ((amountRows > 0 && toIndex[0] < fromIndex[0]))
            {
                fromIndex[0] = fromIndex[0] + amountRows;
            }

            if (amountCols > 0 && toIndex[1] > fromIndex[1])
            {
                toIndex[1] = toIndex[1] + amountCols;
            }
            else if ((amountCols > 0 && toIndex[1] < fromIndex[1]))
            {
                fromIndex[1] = fromIndex[1] + amountCols;
            }

            var rowDiffernce = Math.Abs(toIndex[0] - fromIndex[0]) ;
            var colDifference = Math.Abs(toIndex[1] - fromIndex[1]);

            return rowDiffernce + colDifference;
        }

        public Dictionary<int, int[]> GetAllGalaxies()
        {
            return markLocations;
        }

        public List<List<string>> LoadGalaxy(List<string> list)
        {
            galaxy = new List<List<string>>();
            var ids = 1;

            for (var i = 0; i < list.Count; i++)
            {
                galaxy.Add(list[i].Select(s => s.ToString()).ToList());

                if (list[i].All(c => c.Equals(char.Parse(".")))){
                    emptyRow.Add(i);
                }
            }

            var insertEmptyList = new List<int>();
            for (var col = 0; col < list[0].Count(); col++)
            {
                var hasGalaxy = false;
                for (var row = 0; row < list.Count; row++)
                {
                    var item = list[row][col];
                    if (item.Equals(char.Parse("#")))
                    {
                        hasGalaxy = true;
                    }
                }

                if (!hasGalaxy)
                {
                    emptyCol.Add(col);
                }
            }

            for(var row = 0; row < galaxy.Count; row++)
            {
                for(var col = 0; col < galaxy[row].Count; col++)
                {
                    var item =  galaxy[row][col];
                    if (item.Equals("#"))
                    {
                        item = ids.ToString();                       
                        markLocations.Add(ids, [row, col]);
                        ids++;
                    }
                }
            }

            return galaxy;

        }


    }
}

