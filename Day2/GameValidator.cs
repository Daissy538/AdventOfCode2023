using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class GameValidator
    {
        private readonly CubeSet gameCubeSet;

        public GameValidator(int Red, int Green, int Blue)
        {
            gameCubeSet = new CubeSet
            {
                Red = Red,
                Green = Green,
                Blue = Blue
            };
        }

        public bool IsValid(string game)
        {
            var cubeSets = game.Split(';');

            var result = true;

            foreach (var cubeSetString in cubeSets)
            {
               var cubeSet = CubeSet.Build(cubeSetString);
                if (!gameCubeSet.CanFit(cubeSet))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
