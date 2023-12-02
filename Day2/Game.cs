using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Game
    {
        private readonly GameValidator gameValidator;
        private readonly CubeSetComparer cubeSetComparer;

        public Game()
        {
           gameValidator = new GameValidator(12, 13, 14);
            cubeSetComparer = new CubeSetComparer();
        }

        public int CalculateGamePower(string gameString)
        {
            var game = gameString.Split(':');

            var cubeSetsString = game[1].Split(';');
            
            var cubeSets = new List<CubeSet>();
         
            foreach (var cubeSetString in cubeSetsString)
            {
                cubeSets.Add(CubeSet.Build(cubeSetString));              
            }

            var smallestCubeSet = cubeSetComparer.GenerateSmallestPossibleCubeSet(cubeSets.ToArray());

            return smallestCubeSet.CalculatePower();
        }

        public int validateGame(string gameString)
        {
           var game = gameString.Split(':');
           var gameNumber = game[0].Split(' ')[1];


            if (gameValidator.IsValid(game[1]))
            {
                return int.Parse(gameNumber.Trim());
            }

            return 0;
        }
    }
}
