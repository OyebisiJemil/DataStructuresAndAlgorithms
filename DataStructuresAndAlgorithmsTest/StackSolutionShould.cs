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
    }
}
