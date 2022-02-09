using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithmsTest
{
    public class SlidingWindowShould
    {
        ISlidingWindow _slidingWindow;

        public SlidingWindowShould()
        {
            _slidingWindow = new SlidingWindow();
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5)]
        public void AverageOfAllSubArray(int[] elements, int k)
        {
            List<double> expectedValues = new List<double>();

            var actualResult = _slidingWindow.AverageOfAllSubArray(elements, k);

            Assert.Collection(actualResult,
                item => Assert.Equal(2.2, item),
                item => Assert.Equal(2.8, item),
                item => Assert.Equal(2.4, item),
                item => Assert.Equal(3.6, item),
                item => Assert.Equal(2.8, item));
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5)]
        public void AverageOfAllSubArrayBruteForce(int[] elements, int k)
        {
            List<double> expectedValues = new List<double>();

            var actualResult = _slidingWindow.AverageOfAllSubArrayBruteForce(elements, k);

            Assert.Collection(actualResult,
                item => Assert.Equal(2.2, item),
                item => Assert.Equal(2.8, item),
                item => Assert.Equal(2.4, item),
                item => Assert.Equal(3.6, item),
                item => Assert.Equal(2.8, item));
        }
    }
}
