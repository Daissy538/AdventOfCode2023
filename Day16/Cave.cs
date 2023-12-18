using System.Text;

namespace Day16
{
    public enum Action
    {
        SplitVertical,
        SplitHorizontal,
        Rigth,
        Left,
        Up,
        Down,
        ForwardSlace,
        BackwardSlace,
        None
    }

    public class Cave
    {
        private List<List<string>> CaveMap = new List<List<string>>();
        private List<List<string>> CaveMapPath = new List<List<string>>();

        private Dictionary<string, Action> StringToDirectionMap = new Dictionary<string, Action>()
        {
            { ">", Action.Rigth},
            { "<", Action.Left},
            { "v", Action.Down },
            { "^", Action.Up},
            { "|", Action.SplitVertical},
            { "-", Action.SplitHorizontal},
            { "\\", Action.BackwardSlace},
            { "/", Action.ForwardSlace},
            { ".", Action.None}
        };

        public List<List<string>> LoadMap(List<string> list)
        {
            foreach (var line in list)
            {
                CaveMap.Add(line.ToCharArray().Select(l => l.ToString()).ToList());
                CaveMapPath.Add(line.ToCharArray().Select(l => ".").ToList());
            }

            return CaveMap;
        }

        public long CountAllLigthedPlaces()
        {
            return CaveMapPath.Sum(c => c.Count(i => i.Equals("#")));
        }

        public long FindTheLargest()
        {
            var allResults = new List<long>();
            for (var top = 0; top < CaveMap[0].Count; top++)
            {
                int[] newRow = [-1, top];
                if (!IsNotOutOfBounce(newRow))
                {
                    UpdateBeam([0, top], newRow);

                    var result = CountAllLigthedPlaces();
                    allResults.Add(result);

                    Console.WriteLine($"Start: 0 {top}, Row Dirrection {newRow[0]} {newRow[1]} Result: {result}");

                    ResetCave();
                }

            }

            for (var bottom = 0; bottom < CaveMap[0].Count; bottom++)
            {
                int[] newRow = [CaveMap.Count, bottom];
                if (!IsNotOutOfBounce(newRow))
                {
                    UpdateBeam([0, bottom], newRow);

                    var result = CountAllLigthedPlaces();
                    allResults.Add(result);

                    Console.WriteLine($"Start: {CaveMap.Count}  {bottom}, Row Dirrection {newRow[0]} {newRow[1]} Result: {result}");

                    ResetCave();
                }

            }

            for (var left = 0; left < CaveMap.Count; left++)
            {
                int[] newRow = [left, -1];
                if (!IsNotOutOfBounce(newRow))
                {
                    UpdateBeam([0, left], newRow);

                    var result = CountAllLigthedPlaces();
                    allResults.Add(result);

                    Console.WriteLine($"Start: {left}  -1, Row Dirrection {newRow[0]} {newRow[1]} Result: {result}");

                    ResetCave();
                }

            }

            for (var rigth = 0; rigth < CaveMap.Count; rigth++)
            {
                int[] newRow = [rigth, CaveMap[0].Count];
                if (!IsNotOutOfBounce(newRow))
                {
                    UpdateBeam([0, rigth], newRow);

                    var result = CountAllLigthedPlaces();
                    allResults.Add(result);

                    Console.WriteLine($"Start: {rigth} {CaveMap[0].Count}, Row Dirrection {newRow[0]} {newRow[1]} Result: {result}");

                    ResetCave();
                }

            }

            return allResults.OrderDescending().First();
        }

        public int UpdateBeam(int[] beamIndex, int[] previousIndex)
        {
            if (!IsNotOutOfBounce(beamIndex))
            {
                return 0;
            }else if (AlreadyLigthed(beamIndex))
            {
                return 0;
            }

            var previousPirection = GetDirection(beamIndex, previousIndex);

            var currentValue = CaveMap[beamIndex[0]][beamIndex[1]];
            var currentAction = StringToDirectionMap[currentValue];

            SetCaveMapping(beamIndex);

            int[] newIndex;
            switch((previousPirection, currentAction))
            {
                case (Action.Up, Action.None):
                case (Action.Down, Action.None):
                case (Action.Left, Action.None):
                case (Action.Rigth, Action.None):
                case (Action.Up, Action.SplitVertical):
                case (Action.Down, Action.SplitVertical):
                case (Action.Left, Action.SplitHorizontal):
                case (Action.Rigth, Action.SplitHorizontal):
                    newIndex = GetNewIndex(beamIndex, previousPirection);
                    UpdateBeam(newIndex, beamIndex);
                    break;
                case (Action.Up, Action.ForwardSlace):
                case (Action.Down, Action.BackwardSlace):
                    newIndex = GetNewIndex(beamIndex, Action.Rigth);
                    UpdateBeam(newIndex, beamIndex);
                    break;
                case (Action.Down, Action.ForwardSlace):
                case (Action.Up, Action.BackwardSlace):
                    newIndex = GetNewIndex(beamIndex, Action.Left);
                    UpdateBeam(newIndex, beamIndex);
                    break;
                case (Action.Rigth, Action.ForwardSlace):
                case (Action.Left, Action.BackwardSlace):
                    newIndex = GetNewIndex(beamIndex, Action.Up);
                    UpdateBeam(newIndex, beamIndex);
                    break;
                case (Action.Left, Action.ForwardSlace):
                case (Action.Rigth, Action.BackwardSlace):
                    newIndex = GetNewIndex(beamIndex, Action.Down);
                    UpdateBeam(newIndex, beamIndex);
                    break;
                case (Action.Left, Action.SplitVertical):
                case (Action.Rigth, Action.SplitVertical):
                    var upIndex = GetNewIndex(beamIndex, Action.Up);
                    var downIndex = GetNewIndex(beamIndex, Action.Down);

                    UpdateBeam(upIndex, beamIndex);
                    UpdateBeam(downIndex, beamIndex);
                    break;
                case (Action.Up, Action.SplitHorizontal):
                case (Action.Down, Action.SplitHorizontal):
                    var leftIndex = GetNewIndex(beamIndex, Action.Left);
                    var rigthIndex = GetNewIndex(beamIndex, Action.Rigth);

                    UpdateBeam(leftIndex, beamIndex);
                    UpdateBeam(rigthIndex, beamIndex);
                    break;
            }

            return 1;

        }

        private void ResetCave()
        {
            foreach (var item in CaveMapPath)
            {
                for(var i = 0; i < item.Count; i++)
                {
                    item[i] = ".";
                }
            }
        }

        private bool AlreadyLigthed(int[] beamIndex)
        {
            var ligthend = CaveMapPath[beamIndex[0]][beamIndex[1]];
            var currentValue = CaveMap[beamIndex[0]][beamIndex[1]];

            return ligthend.Equals("#") && (currentValue.Equals("-") || currentValue.Equals("|"));
        }

        private Action GetDirection(int[] index, int[] previousIndex)
        {
            var rowDiffernce = index[0] - previousIndex[0];
            var colDiffernce = index[1] - previousIndex[1];

            if(rowDiffernce == 1)
            {
                return Action.Down;
            }else if(rowDiffernce == -1)
            {
                return Action.Up;
            }else if(colDiffernce == 1)
            {
                return Action.Rigth;
            }else if(colDiffernce == -1)
            {
                return Action.Left;
            }

            return Action.None;
        }

        private void SetCaveMapping(int[] index)
        {
            try
            {
                CaveMapPath[index[0]][index[1]] = "#";
            }catch(Exception e)
            {
                
            }

        }
        
        private int[] GetNewIndex(int[] currentIndex, Action direction)
        {
            return direction switch
            {
                Action.Rigth => [currentIndex[0], currentIndex[1] + 1],
                Action.Left => [currentIndex[0], currentIndex[1] - 1],
                Action.Up => [currentIndex[0] - 1, currentIndex[1]],
                Action.Down => [currentIndex[0] + 1, currentIndex[1]],
                _ => currentIndex
            };
        }

        private bool IsNotOutOfBounce(int[] index)
        {
           return index[0] >= 0 && index[1] >= 0 && index[0] < CaveMap.Count && index[1] < CaveMap[0].Count;
        }        private void PrintCave() {
            foreach (var row in CaveMap)
            {
                var stringBuilder = new StringBuilder();
                foreach (var l in row)
                {
                    stringBuilder.Append(l.ToString());
                }

                Console.WriteLine(stringBuilder.ToString());
            }

            foreach (var row in CaveMapPath)
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
