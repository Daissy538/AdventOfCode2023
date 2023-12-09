using Day8;
using Xunit;

namespace Day8Tests
{
    public class RouteTests
    {

        [Fact]
        public void Create_A_Grap_With_Child_Nodes()
        {
            var data = new string[]
            {
                "AAA = (BBB, BBB)", 
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };



            var route = new Route();

           Dictionary<string, string[]> result =  route.CreateNetwork(data);

            Assert.NotNull(result);
            Assert.Equal(["AAA", "BBB", "ZZZ"], result.Keys.ToArray());
            Assert.Equal(["BBB", "BBB"], result["AAA"]);
            Assert.Equal(["AAA", "ZZZ"], result["BBB"]);
            Assert.Equal(["ZZZ", "ZZZ"], result["ZZZ"]);
        }

        [Fact]
        public void Count_Step_Of_Path()
        {
            var data = new string[]
            {
                "AAA = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var direction = new string[]
            {
                "R",
                "L"
            };

            var route = new Route();

            Dictionary<string, string[]> result = route.CreateNetwork(data);
            var steps = route.Walk(direction);

            Assert.Equal(1, steps);
        }

        [Fact]
        public void Count_6_Step_Of_Path()
        {
            var data = new string[]
            {
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var direction = new string[]
            {
                "L",
                "L",
                "R"
            };

            var route = new Route();

            Dictionary<string, string[]> result = route.CreateNetwork(data);
            var steps = route.Walk(direction);

            Assert.Equal(6, steps);
        }

        [Fact]
        public void Count_Steps_With_Multiple_Death_Ends()
        {
            var data = new string[]
            {
                "AAA = (BBB, CCC)",
                "BBB = (DDD, EEE)",
                "CCC = (ZZZ, GGG)",
                "DDD = (DDD, DDD)",
                "EEE = (EEE, EEE)",
                "GGG = (GGG, GGG)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var direction = new string[]
            {
                "R",
                "L"
            };

            var route = new Route();

            Dictionary<string, string[]> result = route.CreateNetwork(data);
            var steps = route.Walk(direction);

            Assert.Equal(2, steps);
        }

        [Fact]
        public void Count_Ghost_Steps_With_Multiple_Death_Ends()
        {
            var data = new string[]
            {
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)",
            };

            var direction = new string[]
            {
                "L",
                "R"
            };

            var route = new Route();

            Dictionary<string, string[]> result = route.CreateNetwork(data);
            var steps = route.GhostWalk(direction);

            Assert.Equal(6, steps);
        }
    }
}