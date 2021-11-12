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

        [Theory]
        [InlineData("Mr John Smith   ", 13)]
        public void URLifyString_ValidString_ReturnExpectedResult(string inputString, int length)
        {
            string expectedResult = "Mr%20John%20Smith";

            string actualResult = _stringSolutions.URLifyString(inputString, length);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("aab")]
        public void IsPalindromPermutation_WithCorrectInput_ReturnTrue(string stringInput)
        {
            var result = _stringSolutions.IsPalindromPermutation(stringInput);

            Assert.True(result);
        }

        [Theory]
        [InlineData("aacb")]
        public void IsPalindromPermutation_WithIncorrectInput_ReturnFalse(string stringInput)
        {
            var result = _stringSolutions.IsPalindromPermutation(stringInput);

            Assert.False(result);
        }

        [Theory]
        [InlineData("pale","pale")]
        public void OneEditAway_WithEqualStringWithoutTheForReplacement_ReturnsFalse(string s1, string s2)
        {
            var result = _stringSolutions.OneEditAway(s1, s2);

            Assert.False(result);
        }

        [Theory]
        [InlineData("pale", "pala")]
        public void OneEditAway_WithEqualStringWithOneReplacement_ReturnsTrue(string s1, string s2)
        {
            var result = _stringSolutions.OneEditAway(s1, s2);

            Assert.True(result);
        }
        [Theory]
        [InlineData("pale", "pal")]
        public void OneEditAway_WithOneInsertionAway_ReturnsTrue(string s1, string s2)
        {
            var result = _stringSolutions.OneEditAway(s1, s2);

            Assert.True(result);
        }

        [Theory]
        [InlineData("pale", "ble")]
        public void OneEditAway_WithMoreThanOneEditAway_ReturnsFalse(string s1, string s2)
        {
            var result = _stringSolutions.OneEditAway(s1, s2);

            Assert.False(result);
        }

        [Theory]
        [InlineData("aabcccccaaa")]
        public void StringCompression_WithValidString_ReturnExpectedResult(string stringInput)
        {
            string expectedResult = "a2b1c5a3";

            var actualResult = _stringSolutions.StringCompression(stringInput);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("ab#z", "az#z")]
        public void BackspaceCompare_WithValidTwoStrings_ReturnsTrue(string s, string t)
        {
            bool actualResult = _stringSolutions.BackspaceCompare(s, t);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("bxj##tw", "bxj###tw")]
        public void BackspaceCompare_WithInValidTwoStrings_ReturnFalse(string s, string t)
        {
            bool actualResult = _stringSolutions.BackspaceCompare(s, t);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("ab#z", "az#z")]

        public void BackspaceCompareOptimized_WithValidTwoStrings_ReturnsTrue(string s, string t)
        {
            bool actualResult = _stringSolutions.BackspaceCompareOptimized(s, t);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("abcbdca")]
        public void LongestSubstring_ValidInput_ReturnResult(string input)
        {
            int expectedResult = 4;
            int actualResult = _stringSolutions.LongestSubstring(input);

            Assert.Equal(expectedResult, actualResult);
        }
        //"abcabcbb"
        [Theory]
        [InlineData("aabaab!bb")]
        public void LongestSubstringOptimized_ValidInput_ReturnResult(string input)
        {
            int expectedResult = 3;
            int actualResult = _stringSolutions.LongestSubstringOptimized(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("a.")]
        public void ValidPalindrom_ValidInputString_ReturnsTrue(string s)
        {
            bool actualResult = _stringSolutions.ValidPalindrom(s);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("ab")]
        public void ValidPalindromApproach2_ValidInputString_ReturnsTrue(string s)
        {
            bool actualResult = _stringSolutions.ValidPalindromApproach2(s);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("abcdefdba")]
        public void AlmostPalindrome_ValidInput_ReturnsTrue(string s)
        {
             var actualResult = _stringSolutions.AlmostPalindrome(s);

            Assert.True(actualResult);
        }
    }
}
