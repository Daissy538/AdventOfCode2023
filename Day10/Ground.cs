

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
        StartingPipe
    }

    public class Node
    {
        public int[] Index {  get; set; }
        public PipeType Type { get; set; }
        public Node Previous { get; set; }
        public Node? Next { get; set; }

        public Node? NodeAlreadyExist(int[] index) {

            if (Next == null) return Index.SequenceEqual(index) ? this : null;

            return Index.SequenceEqual(index)? this : Next?.NodeAlreadyExist(index);
        }

        public long Length()
        {
            if (Next == null) return 1;
            if(Next.Type == PipeType.StartingPipe)
            {
                return 1;
            }

            return this.Next.Length() + 1;
        }
    }

    public class Ground
    {
        private List<List<PipeType>> pipes = new List<List<PipeType>>();
        private Node? ConnectedPipes;
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

        public Node? LoadAllConnectedPipes(int[] currentLocation, Node? existingTree)
        {

            if (currentLocation[0] < 0 || currentLocation[1] < 0)
            {
                return null;
            }

            var existingNode = existingTree.NodeAlreadyExist([
                 currentLocation[0],
                 currentLocation[1]
            ]);

            if (existingNode != null)
            {
                return existingNode;
            }

            var node = new Node()
            {
                Index = [
                    currentLocation[0],
                    currentLocation[1]
                    ],
                Type = pipes[currentLocation[0]][currentLocation[1]]
            };

            var XPipe1 = node.Index[0];
            var YPipe1 = node.Index[1];

            var XPipe2 = node.Index[0];
            var YPipe2 = node.Index[1];


            switch (node.Type)
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
                    YPipe2--;
                    break;
                case PipeType.NorthWestPipe:
                    XPipe1--;
                    YPipe2++;
                    break;
                case PipeType.SouthEastPipe:
                case PipeType.StartingPipe:
                    YPipe1++;
                    XPipe2++;
                    break;
                case PipeType.SouthWestPipe:
                    YPipe1--;
                    XPipe2++;
                    break;
                case PipeType.Ground:
                    return null;
            }
            
            if(node.Type == PipeType.StartingPipe)
            {
                existingTree = node;
            }

            node.Next = LoadAllConnectedPipes([XPipe1, YPipe1], existingTree);
            node.Next = LoadAllConnectedPipes([XPipe2, YPipe2], existingTree);

            if (node.Next != null)
            {
                node.Next.Previous = node;
            }

            return node;
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
    }
}
