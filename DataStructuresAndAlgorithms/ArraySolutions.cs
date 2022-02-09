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
        public int GetElement(int[] elements, int element)
        {
            int left = 0;
            int right = elements.Length-1;

            while(left < right)
            {
                if (elements[left] == element)
                    return left;
                else
                    if (elements[right] == element)
                    return right;
                left++;
                right--;
            }

            return 0;
        }

        public int BinarySearch(int[] elements, int elementToSearch)
        {
            int leftPointer = 0;
            int rightPointer = elements.Length - 1;
            int middlePointer = (leftPointer + rightPointer) / 2;
            int result = 0;

            while(leftPointer <= rightPointer)
            {
                if (elements[middlePointer] == elementToSearch)
                    return middlePointer;
                else if(elementToSearch < elements[middlePointer])
                    rightPointer = middlePointer - 1;
                else
                    leftPointer = middlePointer + 1;

                middlePointer = (leftPointer + rightPointer) / 2;
            }
            return result;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = { -1, -1 };
            if (nums.Length == 0) return result;

            int firstPosition = TheBinarySearch(nums, 0, nums.Length - 1, target);

            if (firstPosition == -1) return result;

            int startPosition = firstPosition;
            int endPosition = firstPosition;
            int temp1 = 0;
            int temp2 = 0;

            while(startPosition != -1)
            {
                temp1 = startPosition;
                startPosition = TheBinarySearch(nums, 0, startPosition - 1, target);
            }

            startPosition = temp1;

            while(endPosition != -1)
            {
                temp2 = endPosition;
                endPosition = TheBinarySearch(nums, endPosition + 1, nums.Length - 1, target);
            }
            endPosition = temp2;

            result[0] = startPosition;
            result[1] = endPosition;

            return result;
        }

        private int TheBinarySearch(int[] nums, int leftPointer, int rightPointer, int target)
        {
            leftPointer = 0;
            rightPointer = nums.Length - 1;
            int middlePointer = (leftPointer + rightPointer) / 2;
            int result = 0;

            while (leftPointer <= rightPointer)
            {
                if (nums[middlePointer] == target)
                    return middlePointer;
                else if (target < nums[middlePointer])
                    rightPointer = middlePointer - 1;
                else
                    leftPointer = middlePointer + 1;

                middlePointer = (leftPointer + rightPointer) / 2;

            }
            return result;
        }

        public int[] SearchRangeLinear(int[] nums, int target)
        {
            int lowerBound = -1;
            int upperBound = -1;

            for(int pointer = 0; pointer<nums.Length; pointer++)
            {
                if(nums[pointer] == target)
                {
                    if(lowerBound == -1)
                    {
                        lowerBound = pointer;
                    }
                    upperBound = pointer;
                }
            }

            return new int[] { lowerBound, upperBound };
        }

        public int KthLargestEelement(int[] elements, int k)
        {
            int indexToFind = elements.Length - k;
            QuickSort(elements, 0, elements.Length - 1);
            return elements[indexToFind];
        }

        void QuickSort(int[] elements, int left, int right)
        {
            if(left < right)
            {
                int partitionIndex = Partition(elements, left, right);
                QuickSort(elements, left, partitionIndex - 1);
                QuickSort(elements, partitionIndex + 1, right);
            }
        }

        int Partition(int[] elements, int left, int right)
        {
            int i = left;
            int pivot = right;
            int pivotEelement = elements[pivot];

            for(int j = left; j<elements.Length; j++)
            {
                if(elements[j] < pivotEelement)
                {
                    Swap(elements, i, j);
                    i++;
                }
            }
            Swap(elements, i, pivot);
            return i;
        }

        void Swap(int[] elements, int i, int j)
        {
            int temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        public int[] GetStartAndEndOfTarget(int[] elements, int target)
        {
            int[] output = { -1, -1 };

            for(int pointer = 0; pointer<elements.Length; pointer++)
            {
                if(elements[pointer] == target)
                {
                    if(output[0] == -1)
                    {
                        output[0] = pointer;
                        output[1] = pointer;
                    }
                    else
                    {
                        output[1] = pointer;
                    }
                }
            }

            return output;
        }
    }
}
