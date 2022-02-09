using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;

namespace DataStructuresAndAlgorithmsTest
{
    public class ArraySolutionShould
    {
        IArraySolutions _arraySolutions;

        public ArraySolutionShould()
        {
            _arraySolutions = new ArraySolutions();
        }

        [Fact]
        public void GetMaximumWaterContainer_WithTestCase_Runs()
        {
            int[] heights = new int[] { 4, 8, 1, 2, 3, 9 };
            int expectedValue = 32;

            var maximumArea = _arraySolutions.GetMaximumWaterContainer(heights);

            Assert.Equal(expectedValue, maximumArea);
        }

        [Fact]
        public void GetTrappedRainWater_WithTestCase_Runs()
        {
            int[] heights = new int[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
            int expectedValue = 8;
            var totalTrappedWater = _arraySolutions.GetTrappedRainWater(heights);

            Assert.Equal(expectedValue, totalTrappedWater);
        }

        [Fact]
        public void GetTrappedRainWaterOptimized_WithTestCase_Runs()
        {
            int[] heights = new int[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
            int expectedValue = 8;
            var totalTrappedWater = _arraySolutions.GetTrappedRainWaterOptimized(heights);

            Assert.Equal(expectedValue, totalTrappedWater);
        }

        [Fact]
        public void GetElement_WithTestCase_Runs()
        {
            int[] elements = { 1, 2, 3, 4, 4, 5 };

            var actualResult = _arraySolutions.GetElement(elements, 3);

            Assert.Equal(2, actualResult);
        }

        [Fact]
        public void BinarySearch_WithTestCase_Runs()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6, 7};

            var actualResult = _arraySolutions.BinarySearch(elements, 3);

            Assert.Equal(2, actualResult);
        }

        [Fact]
        public void SearchRange_WithTestCase_Runs()
        {
            int[] elements = { 1, 3, 3, 5, 5, 5, 8, 9 };

            var actualResult = _arraySolutions.SearchRange(elements,8);

            //Assert.Equal(2, actualResult);
        }

        [Fact]
        public void SearchRangeLinear_WithTestCase_Runs()
        {
            int[] elements = { 1, 3, 5, 5, 5, 5, 28, 37, 42 };

            var actualResult = _arraySolutions.SearchRangeLinear(elements, 5);

            //Assert.Equal(2, actualResult);
        }

        [Fact]
        public void KthLargestEelement_Returns_Result()
        {
            int[] elements = { 3,7,2,8,1,9,4,5,6 };
            int expectedResult = 6;

            var actualResult = _arraySolutions.KthLargestEelement(elements, 4);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetStartAndEndOfTarget_Returns_Result()
        {
            int[] elements = { 1,3,3,5,5,5,8,9 };
            //int expectedResult = 5;

            var actualResult = _arraySolutions.GetStartAndEndOfTarget(elements, 5);

           // Assert.Equal(expectedResult, actualResult);
        }
    }
}
