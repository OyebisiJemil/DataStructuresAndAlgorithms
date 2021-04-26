using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class StringSolutions : IStringSolutions
    {
        /// <summary>
        /// This is implemented assuming the string is not case sensitive
        /// the time complexity is O(n)
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public bool CheckPermutation(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
                return false;
            return GetSumOfStringCharacters(firstString.ToLower())
                  .Equals(GetSumOfStringCharacters(secondString.ToLower()));
        }

        public bool CheckPermutationWithSortedStrings(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
                return false;
            return SortArrayOfString(firstString)
                  .Equals(SortArrayOfString(secondString));
        }

        public bool CheckPermutationWithTwoIdenticalCharacterCount(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length)
                return false;
            int[] letters = new int[128];
            for(int counter = 0; counter < firstString.Length; counter++)
            {
                int value = firstString[counter];
                letters[value]++;
            }

            for(int counter = 0; counter < secondString.Length; counter++)
            {
                int value = secondString[counter];
                letters[value]--;
                if(letters[value] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPalindromPermutation(string inputString)
        {
            int[] charCounts = new int[128];
            for(int i = 0; i<inputString.Length; i++)
            {
                int asciiValue = inputString[i];
                charCounts[asciiValue]++;
            }

            int characterOccurence = GetOddCount(charCounts);

            return characterOccurence <= 1;
        }

        /// <summary>
        /// time complexity for this algorithm is O(n)
        /// but we can as well say, it is O(1) since the for loop will never iterate through more than 128 characters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsUnique(string input)
        {
            if (input.Length > 128)
                return false;
            bool[] charSet = new bool[128];

            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i];
                bool characterFound = CharacterFound(charSet, value);
                if (characterFound)
                {
                    return false;
                }
                charSet[value] = true;
            }
            return true;
        }

        /// <summary>
        /// Here we can sort the string to get O(n log n) time and then linerly check the string 
        /// for neighboring characters that are identical 
        /// Though we need to be careful because many sorting algorithm take up extra space
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsUniqueWithSortedString(string input)
        {
            if (input.Length > 128)
                return false;
            return true;
        }

        /// <summary>
        /// Time complexity for this is O(n), because we loop through the array visit each character once
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="stringLength"></param>
        /// <returns></returns>
        public string URLifyString(string inputString, int stringLength)
        {
            //Jemil oyebisi gg
            //j e m i l  o y
            char[] charArray = inputString.Trim().ToCharArray();
            StringBuilder stringOutput = new StringBuilder();
            for(int counter = 0; counter < stringLength; counter++)
            {
                if(charArray[counter] == ' ')
                {
                    stringOutput.Append("%20");
                }
                else
                {
                    stringOutput.Append(charArray[counter]);
                }
            }
            return stringOutput.ToString();
        }

        private bool CharacterFound(bool[] characterSet, int value)
        {
            return characterSet[value];
        }

        private int GetSumOfStringCharacters(string input)
        {
            int sum = 0;
            for(int counter = 0; counter<input.Length; counter++)
            {
                sum += input[counter];
            }
            return sum;
        }

        private string SortArrayOfString(string stringInput)
        {
            char[] content = stringInput.ToCharArray();
            Array.Sort(content);
            return content.ToString();
        }
        private int GetOddCount(int[] charCounts)
        {
            int oddCharacterOccurence = 0;
            for (int i = 0; i < 128; i++)
            {
                oddCharacterOccurence += charCounts[i] % 2;
            }
            return oddCharacterOccurence;
        }
    }
}
