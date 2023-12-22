using System.Text;

namespace Day13
{
    //To low        400
    //To low      31411
    //Not Correct 31925
    //To high     33231

    public class Mirror
    {
        public long FindAllMirrors(List<string> list)
        {
            var lists = new List<List<string>>();
            for(int i = 0; i < list.Count; i++)
            {
                for(int j= i; j < list.Count; j++)
                {
                    if (list[j].Equals(" ") || list[j].Equals(""))
                    {
                        lists.Add(list.GetRange(i, j - i));
                        i= j;
                        break;
                    }else if (j == list.Count - 1)
                    {
                        lists.Add(list.GetRange(i, j - i + 1));
                        i = j;
                        break;
                    }
                }   
            }

            var sum = 0L;
            foreach (var item in lists)
            {
                var total = FindMirror(item);
                Console.WriteLine(" ");
                foreach(var i in item)
                {
                    Console.WriteLine(i.ToString());
                }       
                Console.WriteLine($"total:{total}");

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
    }
}
