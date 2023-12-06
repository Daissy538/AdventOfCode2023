using Day6;
using FluentAssertions;

namespace Day6Tests
{
    public class BootRaceTests
    {
        [Theory]
        [InlineData(7 ,9, 4)]
        [InlineData(15, 40, 8)]
        [InlineData(30, 200, 9)]
        public void Test1(int time, int distance, int result)
        {
            var bootRace = new BootRace();

            var repsonse = bootRace.AmountOfWaysToWin(time, distance);
            repsonse.Should().Be(result);
        }
    }
}