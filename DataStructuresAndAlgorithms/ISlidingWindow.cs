using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface ISlidingWindow
    {
        /// <summary>
        /// Given an array of elements, this method finds the average of all subarrays of K
        /// continguos elements in the array
        /// This method uses sliding winodw to solve the problem in O(n) time complexity
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        List<double> AverageOfAllSubArray(int[] elements, int k);

        /// <summary>
        /// Given an array of elements, this method finds the average of all subarrays of K
        /// continguos elements in the array
        /// This method uses bruteforce to solve the roblem in O(n2) time complexity
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        List<double> AverageOfAllSubArrayBruteForce(int[] elements, int k);

        /// <summary>
        /// Given an array of elements, this method finds the maximum sum of any contiguous
        /// subarray of size k using bruteforce abroach and this gives us O(n*k) time complexity
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        int MaximumSumSubArraySizeKBruteForce(int[] elements, int k);

        /// <summary>
        /// Given an array of elements, this method finds the maximum sum of any contiguous
        /// subarray of size k with an optimized aproach and this gives us O(n) time complexity
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        int MaximumSumSubArraySizeKOptimized(int[] elements, int k);

        /// <summary>
        /// Given an array of elements and a positive number S, this method finds the length
        /// of the smallest contiguous subarray whose sum is greater than or equal to S
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        int SmallestSubarrayWithGreaterSum(int[] elements, int s);
    }
}
