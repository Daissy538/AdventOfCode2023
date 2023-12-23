using Day13;

namespace Day13Tests
{
    public class MirrorTests
    {
        [Fact]
        public void Find_Vertical_Mirror2()
        {
            var list = new List<string>()
           {
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#"
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindMirror2(list);

            Assert.Equal(100, leftAmount);
        }

        [Fact]
        public void Find_Vertical_Mirror2_With_Swap()
        {
            var list = new List<string>()
           {
                "#.##..##.",
                "..#.##.#.",
                "##..#...#",
                "##...#..#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#."
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindMirror2(list);

            Assert.Equal(300, leftAmount);
        }

        [Fact]
        public void Find_Horizontal_Mirror2()
        {
            var list = new List<string>()
           {
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#."
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindMirror2(list);

            Assert.Equal(300, leftAmount);
        }

        [Fact]
        public void Find_Vertical_Mirror()
        {
           var list = new List<string>()
           {
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#"
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindMirror(list);

            Assert.Equal(400, leftAmount);
        }

        [Fact]
        public void Find_Horizontal_Mirror()
        {
            var list = new List<string>()
           {
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#."
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindMirror(list);

            Assert.Equal(5, leftAmount);
        }

        [Fact]
        public void Find_All_Mirror()
        {
            var list = new List<string>()
           {
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
                " ",
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#"
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindAllMirrors(list);

            Assert.Equal(405, leftAmount);
        }

        [Fact]
        public void Find_All_Mirror_With_Multi_Mirror()
        {
            var list = new List<string>()
           {
                "#..#..#.###",
                "###....####",
                "##..##.#.#.",
                "##..##.#.#.",
                "###....####",
                "#..#..#.###",
                "##.##..##.#",
                "#...#.....#",
                "...##.###.#",
                "####.#.##..",
                ".#.###.#...",
                "####..#...#",
                "#.#.#####..",
                "#.#.#####..",
                "####..#....",
                ".#.###.#...",
                "####.#.##..",
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindAllMirrors(list);

            Assert.Equal(300, leftAmount);
        }

        [Fact]
        public void Find_All_Mirror_10()
        {
            var list = new List<string>()
           {
                "#########..##",
                ".####..#.##.#",
                ".#..#....##..",
                "..##..#.#..#.",
                ".......#.##.#",
                ".####.#.#..#.",
                "..##...#....#",
                "......#..##..",
                "#...###..##..",
           };

            var mirror = new Mirror();
            var leftAmount = mirror.FindAllMirrors(list);

            Assert.Equal(10, leftAmount);
        }
    }
}