

using System.Collections.Generic;
using System.Xml.Linq;

namespace Day10
{
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
        public int[] Index { get; set; }
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

        public LinkedList<Pipe> LoadAllConnectedPipes(int[] currentLocation)
        {
            var startNode = new Pipe()
            {
                Index = [
                    currentLocation[0],
                    currentLocation[1]
                ],
                Type = pipes[currentLocation[0]][currentLocation[1]]
            };

            ConnectedPipes.AddFirst(startNode);

            LinkedListNode<Pipe> currentNode = ConnectedPipes.First;
            var looping = true;

            while (looping)
            {
                var XPipe1 = currentNode.Value.Index[0];
                var YPipe1 = currentNode.Value.Index[1];

                var XPipe2 = currentNode.Value.Index[0];
                var YPipe2 = currentNode.Value.Index[1];


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
                    case PipeType.StartingPipe:
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
                if (currentNode.Previous != null && !currentNode.Previous.Value.Index.SequenceEqual([XPipe1, YPipe1]))
                {


                    nextPipe = new Pipe()
                    {
                        Index = [
                                 XPipe1,
                            YPipe1,
                        ],
                        Type = pipes[XPipe1][YPipe1],
                    };
                }
                else
                {
                    nextPipe = new Pipe()
                    {
                        Index = [
                            XPipe2,
                            YPipe2,
                        ],
                        Type = pipes[XPipe2][YPipe2],
                    };
                }

                if (nextPipe.Type == PipeType.StartingPipe)
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

        public int[] LoadGround(List<string> list)
        {
            var startLocation = new int[2];
            for(var i = 0; i < list.Count(); i++)
            {
                List<PipeType> pipeRow = (List<PipeType>) list[i].Select((c, j) => {
                    var pipe = pipeMap[c.ToString()];

                    if (pipe.Equals(PipeType.StartingPipe))
                    startLocation = [i,j];

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

        public void LoadNegatives()
        {
            
            for (var i = 0; i < pipes.Count(); i++)
            {
                for(var j = 0; j < pipes[i].Count(); j++)
                {
                    var pipe = pipes[i][j];

                    if (pipe.Equals(PipeType.Ground))
                    {
                        pipesWithNegatives[i].Add(PipeType.OutSideLoop);
                    }
                }
                List<PipeType> pipeRow = (List<PipeType>)pipes[i].Select((c, j) => {
                    
                    if(c == PipeType.Ground)
                    {
                        return 
                    }

                    

                    return pipe;
                }).ToList();


                pipesWithNegatives.Add(pipeRow);
            }

            return startLocation;
        }
    }
}
