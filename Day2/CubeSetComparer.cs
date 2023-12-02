using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class CubeSetComparer()
    {
        public CubeSet GenerateSmallestPossibleCubeSet(CubeSet[] cubeSets)
        {
            var result = new CubeSet();

            foreach (var cubeSet in cubeSets) 
            {
                if (cubeSet.Red >= result.Red)
                {
                    result.Red = cubeSet.Red;
                }
                if (cubeSet.Green >= result.Green)
                {
                    result.Green = cubeSet.Green;
                }
                if (cubeSet.Blue >= result.Blue)
                {
                    result.Blue = cubeSet.Blue;
                }
            }

            return result;
        }
    }
}
