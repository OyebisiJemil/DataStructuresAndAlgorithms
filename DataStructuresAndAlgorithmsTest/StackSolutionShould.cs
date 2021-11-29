using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;

namespace DataStructuresAndAlgorithmsTest
{
    public class StackSolutionShould
    {
        IStackSolutions _stackSolutions;

        public StackSolutionShould()
        {
            _stackSolutions = new StackSolutions();
        }

        [Theory]
        [InlineData(("]"))]
        public void ValidParenthese_ValidString_ReturnsTrue(string s)
        {
            var actualResult = _stackSolutions.ValidParentheses(s);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData(("))(("))]
        public void MinimumBracketToRemove_ValidString_ReturnsTrue(string s)
        {
            string expectedResult = "";
            var actualResult = _stackSolutions.MinimumBracketToRemove(s);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData((4))]
        public void Factoria_GivenX_ReturnsResult(int x)
        {
            int expectedResult = 24;
            var actualResult = _stackSolutions.Factoria(x);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData((4))]
        public void TailFactoria_GivenX_ReturnsResult(int x)
        {
            int expectedResult = 24;
            int totalResultSoFar = 1;
            var actualResult = _stackSolutions.TailFactoria(x, totalResultSoFar = 1);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
