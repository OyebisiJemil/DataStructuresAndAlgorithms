using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface IArraySolutions
    {
        int GetMaximumWaterContainer(int[] heights);
        int GetTrappedRainWater(int[] heights);
        int GetTrappedRainWaterOptimized(int[] height);
    }
}
