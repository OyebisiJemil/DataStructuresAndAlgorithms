using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;

namespace DataStructuresAndAlgorithmsTest
{
    public class StringSolutionShould
    {
        IStringSolutions _stringSolutions;
        public StringSolutionShould()
        {
            _stringSolutions = new StringSolutions();
        }

        [Fact]
        public void IsUnique_WithCharacterMoreThan28_ReturnFalse()
        {
            string inputString = new string('*', 130);
            var result = _stringSolutions.IsUnique(inputString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abbcd")]
        public void IsUnique_WithNonUniqueString_ReturnsFalse(string inputString)
        {
            var result = _stringSolutions.IsUnique(inputString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd")]
        public void IsUnique_WithUniqueString_ReturnTrue(string inputString)
        {
            var result = _stringSolutions.IsUnique(inputString);

            Assert.True(result);
        }

        [Fact]
        public void IsUniqueWithSortedString_WithCharacterMoreThan28_ReturnFalse()
        {
            string inputString = new string('*', 130);
            var result = _stringSolutions.IsUniqueWithSortedString(inputString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd","bacde")]
        public void CheckPermutation_With2StringsOfVaryingLenght_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutation(firstString, secondString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd", "bacd")]
        public void CheckPermutation_With2ValidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutation(firstString, secondString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("abcd", "bace")]
        public void CheckPermutation_With2InvalidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutation(firstString, secondString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd", "bacde")]
        public void CheckPermutationWithSortedStrings_With2StringsOfVaryingLenght_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithSortedStrings(firstString, secondString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd", "bacd")]
        public void CheckPermutationWithSortedStrings_With2ValidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithSortedStrings(firstString, secondString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("abcd", "bace")]
        public void CheckPermutationWithSortedStrings_With2InvalidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithSortedStrings(firstString, secondString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd", "bacde")]
        public void CheckPermutationWithTwoIdenticalCharacterCount_With2StringsOfVaryingLenght_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithTwoIdenticalCharacterCount(firstString, secondString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("abcd", "bacd")]
        public void CheckPermutationWithTwoIdenticalCharacterCount_With2ValidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithTwoIdenticalCharacterCount(firstString, secondString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("abcd", "bace")]
        public void CheckPermutationWithTwoIdenticalCharacterCount_With2InvalidStrings_ReturnFalse(string firstString, string secondString)
        {
            var result = _stringSolutions.CheckPermutationWithTwoIdenticalCharacterCount(firstString, secondString);

            Assert.False(result);
        }

    }
}
