using Day2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Retrieve_Number_For_Valid_Game()
        {
            var gameString = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

            var game = new Game();       

            var result = game.validateGame(gameString);

            result.Should().Be(2);
        }

        [Fact]
        public void Game_Retrieve_0_For_Invalid_Game()
        {
            var gameString = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

            var game = new Game();

            var result = game.validateGame(gameString);

            result.Should().Be(0);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        public void Retrieve_Total_Power_For_Game(string gameString, int expectedPower)
        {
            var game = new Game();

            var result = game.CalculateGamePower(gameString);

            result.Should().Be(expectedPower);
        }
    }
}
