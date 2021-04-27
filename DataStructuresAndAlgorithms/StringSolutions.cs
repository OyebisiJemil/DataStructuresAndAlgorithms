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

        public bool OneEditAway(string s1, string s2)
        {
            if(s1.Length == s2.Length)
            {
                return EditReplacement(s1, s2);
            }
            else if(s1.Length +1 == s2.Length)
            {
                return EditInsert(s1, s2);
            }
            else if(s1.Length - 1 == s2.Length)
            {
                return EditInsert(s1, s2);
            }
            else
            {
                return false;
            }
        }

        private bool EditReplacement(string s1, string s2)
        {
            for(int i = 0; i<s1.Length; i++)
            {
                if(s1[i] != s2[i])
                {
                    return true;
                }
            }
            return false;
        }

        private bool EditInsert(string s1, string s2)
        {
            int s1_pointer = 0;
            int s2_pointer = 0;

            while (s2_pointer < s2.Length && s1_pointer<s1.Length)
            {
                var v2 = s2[s2_pointer];
                var v1 = s1[s1_pointer];
                if (v2 != v1)
                {
                    if(s1_pointer != s2_pointer)
                    {
                        return false;
                    }
                    s2_pointer++;
                }
                else
                {
                    s1_pointer++;
                    s2_pointer++;
                }
            }
            return true;
        }

        public string StringCompression(string stringInput)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int characterCount = 0;

            for (int i = 0; i<stringInput.Length; i++)
            {
                characterCount++;

                if(i+1 >= stringInput.Length || stringInput[i] != stringInput[i + 1])
                {
                    string value = stringInput[i] + characterCount.ToString();
                    stringBuilder.Append(value);
                    characterCount = 0;
                }

            }
            return stringBuilder.Length >= stringInput.Length ? stringInput : stringBuilder.ToString();
        }
    }
}
