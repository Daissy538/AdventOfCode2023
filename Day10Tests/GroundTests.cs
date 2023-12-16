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
            var result = ground.LoadAllConnectedPipes(start);

            Assert.Equal(8, result.Count);
        }


       [Fact]
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
            var start = ground.LoadGround(list);
            var startNode = ground.LoadAllConnectedPipes(start);

            var result = ground.GetLongestPath();

            Assert.Equal(4, result);
        }
    }
}