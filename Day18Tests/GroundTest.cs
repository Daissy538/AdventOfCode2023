using Day18;

namespace Day18Tests
{
    public class GroundTest
    {
        [Fact]
        public void Dig()
        {
            var list = new List<string>()
            {
                "R 6 (#70c710)",
                "D 5 (#0dc571)",
                "L 2 (#5713f0)",
                "D 2 (#d2c081)",
                "R 2 (#59c680)",
                "D 2 (#411b91)",
                "L 5 (#8ceee2)",
                "U 2 (#caa173)",
                "L 1 (#1b58a2)",
                "U 2 (#caa171)",
                "R 2 (#7807d2)",
                "U 3 (#a77fa3)",
                "L 2 (#015232)",
                "U 2 (#7a21e3)"
            };

            var ground = new Ground();

            var cubeMeter = ground.Dig(list);

            Assert.Equal(62, cubeMeter);
        }

        [Fact]
        public void Dig2()
        {
            var list = new List<string>()
            {
                "R 6 (#70c710)",
                "D 5 (#0dc571)",
                "L 2 (#5713f0)",
                "D 2 (#d2c081)",
                "R 2 (#59c680)",
                "D 2 (#411b91)",
                "L 5 (#8ceee2)",
                "U 2 (#caa173)",
                "L 1 (#1b58a2)",
                "U 2 (#caa171)",
                "R 2 (#7807d2)",
                "U 3 (#a77fa3)",
                "L 2 (#015232)",
                "U 2 (#7a21e3)"
            };

            var ground = new Ground();

            var cubeMeter = ground.Dig2(list);

            Assert.Equal(952408144115, cubeMeter);
        }

        [Fact]
        public void Cal_Check_Bigger()
        {
            var list = new List<Tuple<long, long>>()
            {
                new Tuple<long, long>(0,0),
                new Tuple<long, long>(0,6),
                new Tuple<long, long>(5,6),
                new Tuple<long, long>(5,4),
                new Tuple<long, long>(7,4),
                new Tuple<long, long>(7,0),
                new Tuple<long, long>(5,0),
                new Tuple<long, long>(5,2),
                new Tuple<long, long>(2,2),
                new Tuple<long, long>(2,0),
                new Tuple<long, long>(0,0),
            };

            var ground = new Ground();

            var cubeMeter = ground.PicksTheorem(list, 6+5+2+3+4+2+2+3+2+2);

            Assert.Equal(48, cubeMeter);
        }

        [Fact]
        public void Cal_Check_Example()
        {
            var list = new List<Tuple<long, long>>()
            {
                new Tuple<long, long>(0,0),
                new Tuple<long, long>(0,6),
                new Tuple<long, long>(5,6),
                new Tuple<long, long>(5,4),
                new Tuple<long, long>(7,4),
                new Tuple<long, long>(7,6),
                new Tuple<long, long>(9,6),
                new Tuple<long, long>(9,1),
                new Tuple<long, long>(7,1),
                new Tuple<long, long>(7,0),
                new Tuple<long, long>(5,0),
                new Tuple<long, long>(5,2),
                new Tuple<long, long>(2,2),
                new Tuple<long, long>(2,0),
                new Tuple<long, long>(0,0),
            };

            var ground = new Ground();

            var cubeMeter = ground.PicksTheorem(list, 38);

            Assert.Equal(62, cubeMeter);
        }
    }
}