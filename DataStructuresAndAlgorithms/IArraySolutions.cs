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
        int GetElement(int[] elements, int k);
        int BinarySearch(int[] elements, int elementToSearch);
        int[] SearchRange(int[] nums, int target);
        int[] SearchRangeLinear(int[] nums, int target);
    }
}
