using Day11;

namespace Day11Tests
{
    public class GalaxyTests
    {
        [Fact]
        public void Load_Galaxy()
        {
            var list = new List<string>()
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            };

            var galaxy = new Galaxy();

            var test = galaxy.LoadGalaxy(list);

            Assert.Equal(10, test.Count);
            Assert.Equal(10, test[0].Count);
        }

        [Fact]
        public void Get_All_Galaxies()
        {
            var list = new List<string>()
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            };

            var galaxy = new Galaxy();

            galaxy.LoadGalaxy(list);
            var result = galaxy.GetAllGalaxies();

            Assert.Equal(9, result.Count);
        }

        [Theory]
        [InlineData(5, 9, 9)]
        [InlineData(1, 7, 15)]
        [InlineData(3, 6, 17)]
        [InlineData(8, 9, 5)]
        [InlineData(1, 3, 6)]
        [InlineData(4, 5, 8)]
        [InlineData(1, 4, 9)]
        public void Calculate_The_Shortest_Path(int from, int to, int answer)
        {
            var list = new List<string>()
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            };

            var galaxy = new Galaxy();

            galaxy.LoadGalaxy(list);
            var result = galaxy.CalculateDitanceBetween(from,to, 2);

            Assert.Equal(answer, result);
        }

        [Fact]
        public void Calculate_Sum_Of_All_The_Shortest_Path()
        {
            var list = new List<string>()
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            };

            var galaxy = new Galaxy();

            galaxy.LoadGalaxy(list);
            var result = galaxy.SumOfAllShortestDistance(10);

            Assert.Equal(1030, result);
        }
    }
}