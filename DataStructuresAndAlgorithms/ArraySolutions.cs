using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class ArraySolutions : IArraySolutions
    {
        public int GetMaximumWaterContainer(int[] heights)
        {
            int maximumArea = 0, q = heights.Length - 1, p = 0;
            while (p < q)
            {
                int length = Math.Min(heights[p], heights[q]);
                int width = q - p;
                int area = length * width;
                maximumArea = Math.Max(maximumArea, area);

                if (p <= q)
                {
                    p++;
                }
                else
                {
                    q--;
                }
            }
            return maximumArea;
        }

        public int GetTrappedRainWater(int[] heights)
        {
            int totalTrappedInWater = 0, length = heights.Length;

            for(int pointer = 0; pointer<length; pointer++)
            {
                int leftPointer = pointer;
                int rightPointer = pointer;
                int maxLeft = 0, maxRight = 0;

               
                while(leftPointer >= 0)
                {
                    maxLeft = Math.Max(maxLeft, heights[leftPointer]);
                    leftPointer--;
                }

                while(rightPointer < length)
                {
                    maxRight = Math.Max(maxRight, heights[rightPointer]);
                    rightPointer++;
                }

                int currentWater = Math.Min(maxLeft, maxRight) - heights[pointer];
                if(currentWater >= 0)
                {
                    totalTrappedInWater += currentWater;
                }
            }

            return totalTrappedInWater;
        }
        public int GetTrappedRainWaterOptimized(int[] height)
        {
            int totalTrappedinWater = 0, leftPointer = 0, rightPointer = height.Length - 1;
            int maximumLeftValue = 0, maximumRightValue = 0;
            while(leftPointer <rightPointer)
            {
                if(height[leftPointer] <= height[rightPointer])
                {
                    if(maximumLeftValue > height[leftPointer])
                    {
                        int currentTrappedinWater = maximumLeftValue - height[leftPointer];
                        totalTrappedinWater += currentTrappedinWater;
                    }
                    else
                    {
                        maximumLeftValue = height[leftPointer];                        
                    }
                    leftPointer++;
                }
                else
                {
                    if(maximumRightValue > height[rightPointer])
                    {
                        int currentTrappedinWater = maximumRightValue - height[rightPointer];
                        totalTrappedinWater += currentTrappedinWater;
                    }
                    else
                    {
                        maximumRightValue = height[rightPointer];
                    }
                    rightPointer--;
                }
            }
            return totalTrappedinWater;
        }
    }
}
