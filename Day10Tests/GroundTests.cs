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
            Assert.Equal(new (1,1), result);

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

        [Fact]
        public void Get_Amount_Of_Encloused_Titles_Small()
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
            var result = ground.FindTheNests();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Get_Amount_Of_Encloused_Titles()
        {
            var list = new List<string>() {
                    "...........",
                    ".S-------7.",
                    ".|F-----7|.",
                    ".||.....||.",
                    ".||.....||.",
                    ".|L-7.F-J|.",
                    ".|..|.|..|.",
                    ".L--J.L--J.",
                    "..........."
                    };

            var ground = new Ground();
            var start = ground.LoadGround(list);
            var startNode = ground.LoadAllConnectedPipes(start);
            var result = ground.FindTheNests();

            Assert.Equal(4, result);

        }

        [Fact]
        public void Get_Amount_Of_Encloused_Large()
        {
            var list = new List<string>() {
                    ".F----7F7F7F7F-7....",
                    ".|F--7||||||||FJ....",
                    ".||.FJ||||||||L7....",
                    "FJL7L7LJLJ||LJ.L-7..",
                    "L--J.L7...LJS7F-7L7.",
                    "....F-J..F7FJ|L7L7L7",
                    "....L7.F7||L7|.L7L7|",
                    ".....|FJLJ|FJ|F7|.LJ",
                    "....FJL-7.||.||||...",
                    "....L---J.LJ.LJLJ..."
                    };

            var ground = new Ground();
            var start = ground.LoadGround(list);
            var startNode = ground.LoadAllConnectedPipes(start);
            var result = ground.FindTheNests();

            Assert.Equal(8, result);

        }

        [Fact]
        public void Get_Amount_Of_Encloused_Large2()
        {
            var list = new List<string>() {
                    "FF7FSF7F7F7F7F7F---7",
                    "L|LJ||||||||||||F--J",
                    "FL-7LJLJ||||||LJL-77",
                    "F--JF--7||LJLJ7F7FJ-",
                    "L---JF-JLJ.||-FJLJJ7",
                    "|F|F-JF---7F7-L7L|7|",
                    "|FFJF7L7F-JF7|JL---7",
                    "7-L-JL7||F7|L7F-7F7|",
                    "L.L7LFJ|||||FJL7||LJ",
                    "L7JLJL-JLJLJL--JLJ.L"
                    };

            var ground = new Ground();
            var start = ground.LoadGround(list);
            var startNode = ground.LoadAllConnectedPipes(start);
            var result = ground.FindTheNests();

            Assert.Equal(10, result);

        }
    }
}