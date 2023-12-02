using Day2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tests
{
    public class CubeSetTests
    {
        [Fact]
        public void Create_A_CubeSet()
        {
            var cubeSet = new CubeSet
            {
                Red = 1,
                Green = 2,
                Blue = 3
            };

            cubeSet.Red.Should().Be(1);
            cubeSet.Green.Should().Be(2);
            cubeSet.Blue.Should().Be(3);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 1, 3 }, new int[] { 1, 2, 3 })]
        public void CubeSet_Fit_Inside_Another_CubeSet(int[] setToCheck, int[] baseSet)
        {
            var cubeSetToCheck = new CubeSet
            {
                Red = setToCheck[0],
                Green = setToCheck[1],
                Blue = setToCheck[2]
            };

            var cubebaseSet = new CubeSet
            {
                Red = baseSet[0],
                Green = baseSet[1],
                Blue = baseSet[2]
            };

            cubebaseSet.CanFit(cubeSetToCheck).Should().BeTrue();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 3, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 2, 3 }, new int[] { 1, 2, 3 })]
        public void CubeSet_Doesnt_Fit_Inside_Another_CubeSet(int[] setToCheck, int[] baseSet)
        {
            var cubeSetToCheck = new CubeSet
            {
                Red = setToCheck[0],
                Green = setToCheck[1],
                Blue = setToCheck[2]
            };

            var cubebaseSet = new CubeSet
            {
                Red = baseSet[0],
                Green = baseSet[1],
                Blue = baseSet[2]
            };

            cubebaseSet.CanFit(cubeSetToCheck).Should().BeFalse();
        }

        [Theory]
        [InlineData("1 red, 2 green, 6 blue", new int[] { 1, 2, 6 })]
        [InlineData("2 green", new int[] { 0, 2, 0 })]
        [InlineData("1 blue, 4 red", new int[] { 4, 0, 1 })]
        public void Map_String_To_CubeSet(string stringCubeSet, int[] result)
        {
            var cubeSetResult = new CubeSet
            {
                Red = result[0],
                Green = result[1],
                Blue = result[2]
            };

            var cubeSet = CubeSet.Build(stringCubeSet);

            cubeSet.Red.Should().Be(cubeSetResult.Red);
            cubeSet.Green.Should().Be(cubeSetResult.Green);
            cubeSet.Blue.Should().Be(cubeSetResult.Blue);
        }

        [Fact]
        public void Retrieve_Power_Of_The_CubeSet()
        {
            var cubeSet = new CubeSet
            {
                Red = 1,
                Green = 2,
                Blue = 3
            };

            var expectedResult = cubeSet.Red * cubeSet.Green * cubeSet.Blue;

            cubeSet.CalculatePower().Should().Be(expectedResult);
        }
    }
}
