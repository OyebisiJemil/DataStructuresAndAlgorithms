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
    }
}
