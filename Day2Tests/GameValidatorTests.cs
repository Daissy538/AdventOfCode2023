using Day2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tests
{
    public class GameValidatorTests
    {
        [Theory]
        [InlineData("1 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
        [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
        [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
        public void Game_Is_Valid(string game)
        {
            var gameValidator = new GameValidator(12,13,14);

            var result = gameValidator.IsValid(game);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
        [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
        public void Game_Is_Invalid(string game)
        {
            var gameValidator = new GameValidator(12, 13, 14);

            var result = gameValidator.IsValid(game);

            result.Should().BeFalse();
        }
    }
}
