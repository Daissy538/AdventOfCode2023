using Day10;

namespace Day10Tests
{
    public class GroundTests
    {
        [Fact]
        public void Load_String_In_To_Day_Grid()
        {
            var list= new List<string>() {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            "....."            
            };

            var ground = new Ground();

            var result = ground.LoadGround(list);

            Assert.NotNull(result);
            Assert.Equal([1,1], result);

        }

        [Fact]
        public void Get_Length_Node_Lope()
        {
            var node6 = new Node()
            {
                Type = PipeType.NorthWestPipe,
                Index = [2,1]
            };

            var node5 = new Node()
            {
                Type = PipeType.VerticalPipe,
                Index = [2, 2]
            };

            var node4 = new Node()
            {
                Type = PipeType.NorthEastPipe,
                Index = [2, 3],
            };

            var node3 = new Node()
            {
                Type = PipeType.SouthEastPipe,
                Index = [1, 3]
            };

            var node2 = new Node()
            {
                Type = PipeType.VerticalPipe,
                Index = [1, 2],
            };

            var start = new Node()
            {
                Type = PipeType.StartingPipe,
                Index = [1, 1],
            };

            start.Previous = node6;
            start.Next = node2;

            node2.Previous = start;
            node2.Next = node3;

            node3.Previous = node2;
            node3.Next = node4;

            node4.Previous = node3;
            node4.Next = node5;

            node5.Previous = node4;
            node5.Next = node6;

            node6.Previous = node5;
            node6.Next = start;

            var result = start.Length();

            Assert.Equal(6, result);

        }

        [Fact]
        public void Node_Already_Exist()
        {

            var node2 = new Node()
            {
                Type = PipeType.VerticalPipe,
                Index = [1, 2],
            };

            var start = new Node()
            {
                Type = PipeType.StartingPipe,
                Index = [1, 1],
            };

            start.Next = node2;

            node2.Previous = start;

            var expected = new int[] { 1,2};
            var result = start.NodeAlreadyExist(expected);

            Assert.Equal(expected, result.Index);

        }


        [Fact]
        public void Generate_Pipes()
        {
            var list = new List<string>() {
                    ".....",
                    ".S-7.",
                    ".|.|.",
                    ".L-J.",
                    "....."
                    };


            var ground = new Ground();
            var start = ground.LoadGround(list);
            var startNode = ground.LoadAllConnectedPipes(start, null);

            Assert.Equal(PipeType.StartingPipe, startNode.Type);
            Assert.Equal(7, startNode.Length());
        }


        /*        [Fact]
                public void Get_Longest_Path()
                {
                    var list = new List<string>() {
                    ".....",
                    ".S-7.",
                    ".|.|.",
                    ".L-J.",
                    "....."
                    };


                    var ground = new Ground();


                    ground.LoadGround(list);
                    ground.MapAllConnectedPipes([1, 1]);
                    var result = ground.GetLongestPath(1,1);

                    Assert.Equal(4, result);
                }*/
    }
}