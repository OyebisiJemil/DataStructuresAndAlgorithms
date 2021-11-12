using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface IStringSolutions
    {
        bool IsUnique(string input);
        bool IsUniqueWithSortedString(string input);
        bool CheckPermutation(string firstString, string secondString);
        bool CheckPermutationWithSortedStrings(string firstString, string secondString);
        bool CheckPermutationWithTwoIdenticalCharacterCount(string firstString, string secondString);
        string URLifyString(string inputString, int stringLength);
        bool IsPalindromPermutation(string inputString);
        bool OneEditAway(string s1, string s2);
        string StringCompression(string stringInput);
        bool BackspaceCompare(string s, string t);
        bool BackspaceCompareOptimized(string s, string t);
        int LongestSubstring(string input);
        int LongestSubstringOptimized(string input);
        bool ValidPalindrom(string s);
        bool ValidPalindromApproach2(string s);
        bool AlmostPalindrome(string s);
    }
}
