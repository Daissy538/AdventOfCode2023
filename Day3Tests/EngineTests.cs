using Day3;
using FluentAssertions;

namespace Day3Tests
{
    public class EngineTests
    {
        [Theory]
        [InlineData(".*35..633.", new int[] { 35 })]
        [InlineData("..35.*633.", new int[] { 633 })]
        [InlineData(".*35.*633.", new int[] { 35, 633 })]
        public void Retrieve_Number_That_Has_Symbole_On_The_Left_Side (string lineWithNumbers, int[] expectedResult)
        {
            var engine = new Engine();
            var result = engine.RetrieveValidPartNumbers(lineWithNumbers, null, null);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("..35*.633", new int[] { 35 })]
        [InlineData("..35..633*", new int[] { 633 })]
        [InlineData("..35*.633*", new int[] { 35, 633 })]
        public void Retrieve_Numbers_That_Has_Symbole_On_The_Rigth_Side(string lineWithNumbers, int[] expectedResult)
        {
            var engine = new Engine();
            var result = engine.RetrieveValidPartNumbers(lineWithNumbers, null, null);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("..35..633", ".*.......", null, new int[] { 35 })]
        [InlineData("..35..633", null, "......#..", new int[] { 633 })]
        [InlineData("..35..633", "..*...$..", null, new int[] { 35, 633 })]
        public void Retrieve_Numbers_That_Surounding_Symbol(string lineWithNumbers, string? previousLine,string? nextLine, int[] expectedResult)
        {
            var engine = new Engine();

            var result = engine.RetrieveValidPartNumbers(lineWithNumbers, previousLine, nextLine);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData(".*.......",".35..633", ".35..633", new int[] { 1225 })]
        [InlineData("...*.....", "...$35.633", ".35*...633", new int[] { 1225 })]
        [InlineData(".......*.", "..35..633", "..35..633", new int[] { 400689 })]
        [InlineData("..*..*.......", "......913", "..35..340", new int[] { 310420 })]
        [InlineData(".*35..633", "..35*.633", null, new int[] { 1225 })]
        [InlineData("..35*.633", "..35..633", null, new int[] { 1225 })]
        [InlineData("..35*.633", null, "..35..633", new int[] { 1225 })]
        [InlineData("..35.*633&", "..35..633.", null, new int[] { 400689 })]
        [InlineData("..35..633*", "..35..633.", null, new int[] { 400689 })]
        [InlineData("....*..", ".633.633", null, new int[] { 400689 })]
        [InlineData(".../*&..", "342........", ".633.633", new int[] { 400689 })]
        [InlineData("....*..", null, "=633/633", new int[] { 400689 })]
        [InlineData("..633*633", null, null, new int[] { 400689 })]
        public void Cal_Gear_Ratio(string currentLine, string? previousLine, string? nextLine, int[] expectedResult)
        {
            {
                var engine = new Engine();

                var result = engine.CalGearRatio(currentLine, previousLine, nextLine);

                result.Should().BeEquivalentTo(expectedResult);
            }
        }

    }
}