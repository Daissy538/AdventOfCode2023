
using FluentAssertions;

namespace Day1
{
    public class CalcullationTest
    {
        [Theory]
        [InlineData("12", 12)]
        [InlineData("1a3", 13)]
        [InlineData("a2b35", 25)]
        public void Calculate_The_Amount_Based_On_The_First_And_Last_Digit_In_The_String(string text, int total)
        {
            var calculator = new Calculator();
            var result = calculator.CalculateAmountForString(text);

            result.Should().Be(total);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 6)]
        public void Calculate_The_Total_Amount_For_A_List_Of_Integers(int[] list, int total)
        {       
            var calculator = new Calculator();
            var result = calculator.CalculateTotal(list);

            result.Should().Be(total);
        }

        [Theory]
        [InlineData("oneonevstpxxrjpnine7six", 16)]
        [InlineData("two3fiveckrsjr", 25)]
        [InlineData("mktwonecvqsxhqrjfninethreethreedkllgfxrxrffzvdbqdj2c3", 23)]
        [InlineData("xtwone3four", 24)]
        public void Calculate_The_Amount_Based_On_The_First_And_Last_Digit_In_The_String_With_Text_Digits(string text, int total)
        {
            var calculator = new Calculator();
            var result = calculator.CalculateAmountForString(text);

            result.Should().Be(total);
        }

    }
}
