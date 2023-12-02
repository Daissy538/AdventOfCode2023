using Day2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tests
{
    public class CubeSetComparerTest
    {
        [Fact]
        public void Get_The_Smallest_Possible_CubeSet()
        {
            var cubeSetComparer = new CubeSetComparer();
            var cubeSets = new CubeSet[]
            {
                CubeSet.Build("3 blue, 4 red"),
                CubeSet.Build("1 red, 2 green, 6 blue"),
                CubeSet.Build("2 green")
            };

            var cubeSet = cubeSetComparer.GenerateSmallestPossibleCubeSet(cubeSets);

            cubeSet.Red.Should().Be(4);
            cubeSet.Green.Should().Be(2);
            cubeSet.Blue.Should().Be(6);
        }

    }
}
