
using System.Security.Cryptography.X509Certificates;

namespace Day10
{

    //To high  825

    public enum PipeType
    {
        VerticalPipe,
        HorizontalPipe,
        NorthEastPipe,
        NorthWestPipe,
        SouthWestPipe,
        SouthEastPipe,
        Ground,
        StartingPipe,
        WithinLoop,
        OutSideLoop
    }

    public class Pipe
    {
        public Tuple<int, int> Index { get; set; }
        public PipeType Type { get; set; }
    }

    public class Ground
    {
        private List<List<PipeType>> pipes = new List<List<PipeType>>();
        private List<List<PipeType>> pipesWithNegatives = new List<List<PipeType>>();

        private LinkedList<Pipe> ConnectedPipes = new LinkedList<Pipe>();
        private Dictionary<string, PipeType> pipeMap = new Dictionary<string, PipeType>()
        {
            { "|", PipeType.VerticalPipe },
            { "-", PipeType.HorizontalPipe },
            { "L" , PipeType.NorthEastPipe },
            { "J", PipeType.NorthWestPipe},
            { "7", PipeType.SouthWestPipe },
            { "F", PipeType.SouthEastPipe },
            { ".", PipeType.Ground},
            { "S", PipeType.StartingPipe }
        };

        public LinkedList<Pipe> LoadAllConnectedPipes(Tuple<int, int> currentLocation)
        {
            var startNode = new Pipe()
            {
                Index = new(currentLocation.Item1, currentLocation.Item2),
                Type = pipes[currentLocation.Item1][currentLocation.Item2]
            };

            ConnectedPipes.AddFirst(startNode);

            LinkedListNode<Pipe> currentNode = ConnectedPipes.First;
            var looping = true;

            while (looping)
            {
                var XPipe1 = currentNode.Value.Index.Item1;
                var YPipe1 = currentNode.Value.Index.Item2;

                var XPipe2 = currentNode.Value.Index.Item1;
                var YPipe2 = currentNode.Value.Index.Item2;


                switch (currentNode.Value.Type)
                {
                    case PipeType.VerticalPipe:
                        XPipe1--;
                        XPipe2++;
                        break;
                    case PipeType.HorizontalPipe:
                        YPipe1--;
                        YPipe2++;
                        break;
                    case PipeType.NorthEastPipe:
                        XPipe1--;
                        YPipe2++;
                        break;
                    case PipeType.NorthWestPipe:
                        XPipe1--;
                        YPipe2--;
                        break;
                    case PipeType.SouthEastPipe:
                        XPipe1++;
                        YPipe2++;
                        break;
                    case PipeType.SouthWestPipe:
                        XPipe1++;
                        YPipe2--;
                        break;
                    case PipeType.Ground:
                        looping = false;
                        break;
                }

                Pipe? nextPipe;
                if (currentNode.Previous != null && !currentNode.Previous.Value.Index.Equals(new Tuple<int, int>(XPipe1, YPipe1)))
                {
                    nextPipe = new Pipe()
                    {
                        Index = new(XPipe1, YPipe1),
                        Type = pipes[XPipe1][YPipe1],
                    };
                }
                else
                {
                    nextPipe = new Pipe()
                    {
                        Index = new(XPipe2, YPipe2),
                        Type = pipes[XPipe2][YPipe2],
                    };
                }

                var hasConnection = CheckIfItHasConnection(currentNode.Value.Index, nextPipe.Index, nextPipe.Type);
                if (!hasConnection)
                {
                    looping = false;
                }
                else if (ConnectedPipes.Any(p => p.Index.Item1 == nextPipe.Index.Item1 && p.Index.Item2 == nextPipe.Index.Item2))
                {
                    looping = false;
                }
                else
                {
                    ConnectedPipes.AddAfter(currentNode, nextPipe);
                    currentNode = ConnectedPipes.Find(nextPipe);
                }
            }

            return ConnectedPipes;
        }

        public new Tuple<int, int> LoadGround(List<string> list)
        {
            Tuple<int, int> startLocation = new Tuple<int, int>(0, 0);
            for (var i = 0; i < list.Count(); i++)
            {
                List<PipeType> pipeRow = (List<PipeType>)list[i].Select((c, j) => {
                    var pipe = pipeMap[c.ToString()];

                    if (pipe.Equals(PipeType.StartingPipe))
                    {
                        startLocation = new Tuple<int, int>(i, j);

                        var rigth = j + 1 <= list[i].Length - 1 ? CheckIfItHasConnection(startLocation, new Tuple<int, int>(i, j + 1), pipeMap[list[i][j + 1].ToString()]): false;
                        var left = j- 1 >= 0 ? CheckIfItHasConnection(startLocation, new Tuple<int, int>(i, j -1), pipeMap[list[i][j - 1].ToString()]) : false;
                        var up = i - 1 >= 0? CheckIfItHasConnection(startLocation, new Tuple<int, int>(i - 1, j), pipeMap[list[i - 1][j].ToString()]): false;
                        var down = i + 1 <= list.Count-1 ? CheckIfItHasConnection(startLocation, new Tuple<int,int>(i+1,j), pipeMap[list[i + 1][j].ToString()]): false;

                        pipe = ((rigth, left, up, down)) switch
                        {
                            (true, true, false, false) => PipeType.HorizontalPipe,
                            (false, false, true, true) => PipeType.VerticalPipe,
                            (true, false, true, false) => PipeType.NorthEastPipe,
                            (true, false, false, true) => PipeType.SouthEastPipe,
                            (false, true, true, false) => PipeType.NorthWestPipe,
                            (false, true, false, true) => PipeType.SouthWestPipe,
                            _ => throw new NotImplementedException(),
                        };
                    }

                    return pipe;
                }).ToList();


                pipes.Add(pipeRow);
            }

            return startLocation;
        }

        public long GetLongestPath()
        {
            return ConnectedPipes.Count / 2;
        }

        private bool CheckIfItHasConnection(Tuple<int, int> current, Tuple<int, int> nextPipe, PipeType pipe){

            int rowDif = nextPipe.Item1 - current.Item1;
            int colDif = nextPipe.Item2 - current.Item2;

            //1 0 down
            //-1 0 up
            //0 1 rigth
            //0 -1 left

            switch (pipe)
            {
                case PipeType.SouthEastPipe when colDif == 0 && rowDif == -1:
                case PipeType.SouthWestPipe when colDif == 0 && rowDif == -1:
                case PipeType.VerticalPipe when colDif == 0 && rowDif == -1:
                    return true;
                case PipeType.NorthEastPipe when colDif == 0 && rowDif == 1:
                case PipeType.NorthWestPipe when colDif == 0 && rowDif == 1:
                case PipeType.VerticalPipe when colDif == 0 && rowDif == 1:
                    return true;
                case PipeType.SouthWestPipe when rowDif == 0 && colDif == 1:
                case PipeType.NorthWestPipe when rowDif == 0 && colDif == 1:
                case PipeType.HorizontalPipe when rowDif == 0 && colDif == 1:
                    return true;
                case PipeType.NorthEastPipe when rowDif == 0 && colDif == -1:
                case PipeType.SouthEastPipe when rowDif == 0 && colDif == -1:
                case PipeType.HorizontalPipe when rowDif == 0 && colDif == -1:
                    return true;
                default: return false;
            };            
        }

        private List<Tuple<int, int>> corners = new List<Tuple<int, int>>();

        public double FindTheNests()
        {
            foreach (var pipe in ConnectedPipes) {
                switch (pipe.Type)
                {
                    case PipeType.StartingPipe:
                    case PipeType.SouthEastPipe:
                    case PipeType.NorthEastPipe:
                    case PipeType.NorthWestPipe:
                    case PipeType.SouthWestPipe:
                        corners.Add(new Tuple<int, int>(pipe.Index.Item1, pipe.Index.Item2));
                        break;
                }
            }

            corners.Add(corners.First());

            return ShoeLaceCalculation(corners);
        }

        public double ShoeLaceCalculation(List<Tuple<int, int>> corners)
        {
            var totals = new List<int>();

            for (var row = 0; row < corners.Count - 1; row++)
            {
                var current = corners[row];
                var next = corners[row + 1];

                var left = (current.Item2 * next.Item1);
                var rigth = (current.Item1 * next.Item2);

                totals.Add(left - rigth);
            }

            double area = Math.Abs(totals.Sum());

            return (area - ConnectedPipes.Count()) / 2 + 1;
        }


    }
}
