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
    }
}
