using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class CubeSet()
    {

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public static CubeSet Build(string stringCubeSet)
        {
            var cubeSet = stringCubeSet.Split(',');

            var newCubeSet = new CubeSet();

            foreach (var cube in cubeSet)
            {
                var cubeColors = cube.Split(' ');
                var cubeColor = cubeColors[cubeColors.Length - 1];
                var cubeAmount = cubeColors[cubeColors.Length - 2];

                switch (cubeColor)
                {
                    case "red":
                        newCubeSet.Red = int.Parse(cubeAmount.ToString());
                        break;
                    case "green":
                        newCubeSet.Green = int.Parse(cubeAmount.ToString());
                        break;
                    case "blue":
                        newCubeSet.Blue = int.Parse(cubeAmount.ToString());
                        break;
                }
            }

            return newCubeSet;
        }

        public bool CanFit(CubeSet cubeSet2)
        {
            return Red >= cubeSet2.Red && Green >= cubeSet2.Green && Blue >= cubeSet2.Blue;
        }

        public int CalculatePower()
        {
            return Red * Green * Blue;
        }
    }
}
