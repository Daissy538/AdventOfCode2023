using Day16;

namespace Day16Tests
{
    public class CaveTests
    {
        [Fact]
        public void Read_Map()
        {
            var list = new List<string>()
            {
                ".|...\\....",
                "|.-.\\.....",
                ".....|-...",
                "........|.",
                "..........",
                ".........\\",
                "..../.\\\\..",
                ".-.-/..|..",
                ".|....-|.\\",
                "..//.|...."
            };

            var cave = new Cave();
            var result = cave.LoadMap(list);

            Assert.Equal(10, result.Count);
            Assert.Equal(10, result[0].Count);
        }
    }
}