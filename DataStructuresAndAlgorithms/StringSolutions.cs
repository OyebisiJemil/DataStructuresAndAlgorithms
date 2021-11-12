using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool BackspaceCompare(string s, string t)
        {
            bool result = true;
            Stack<char> sStack = MasearchString(s);
            Stack<char> tStack = MasearchString(t);

            if (sStack.Count != tStack.Count)
                return false;

            while(sStack.Count != 0)
            {
                if(sStack.Peek() == tStack.Peek())
                {
                    sStack.Pop();
                    tStack.Pop();
                }
                else
                {
                    return false;
                }
            }
            return result;
        }

        private Stack<char> MasearchString(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int pointer = 0; pointer < s.Length; pointer++)
            {
                char value = s[pointer];
                if (value != '#')
                {
                    stack.Push(value);
                }
                else if (stack.Count != 0)
                {
                    stack.Pop();
                }
            }

            return stack;
        }

        public bool BackspaceCompareOptimized(string s, string t)
        {
            int p = s.Length - 1, q = t.Length - 1;

            while(p >= 0 || q >= 0)
            {
                if(s[p] != '#' || t[q] != '#')
                {
                    if(s[p] != t[q])
                    {
                        return false;
                    }
                    else
                    {
                        p--;
                        q--;
                    }
                }
                else
                {
                    if(s[p] == '#')
                    {
                        int backspace = 2;
                        while(backspace > 0)
                        {
                            p--;
                            backspace--;
                        }
                    }
                    if (t[q] == '#')
                    {
                        int backspace = 2;
                        while (backspace > 0)
                        {
                            q--;
                            backspace--;
                        }
                    }
                }
            }
            return true;
        }

        public int LongestSubstring(string input)
        {
            if(input.Length <= 1)
            {
                return input.Length;
            }
            int longestLength = 0;

            for (int pointer = 0; pointer <input.Length; pointer++)
            {
                HashSet<char> lookup = new HashSet<char>();
                int currentLength = 0;
                for (int qpointer = pointer; qpointer<input.Length; qpointer++)
                {
                    if (!lookup.Contains(input[qpointer]))
                    {
                        lookup.Add(input[qpointer]);
                        currentLength++;
                        longestLength = Math.Max(longestLength, currentLength);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return longestLength;
        }

        public int LongestSubstringOptimized(string input)
        {
            if (input.Length <= 1)
            {
                return input.Length;
            }

            int longestLength = 0;
            int leftPointer = 0;
            int inputLength = input.Length;
            Hashtable lookup = new Hashtable();

            for(int rightPointer = 0; rightPointer<inputLength; rightPointer++)
            {
                var currentCharacter = input[rightPointer];

                var previousSeenCharacter = lookup.ContainsKey(currentCharacter) ? (int)lookup[currentCharacter]: ' ';
                if(previousSeenCharacter != ' ')
                {
                    if (previousSeenCharacter >= leftPointer)
                    {
                        leftPointer = previousSeenCharacter + 1;
                    }
                    lookup[currentCharacter] = rightPointer;
                }
                else
                {
                    lookup[currentCharacter] = rightPointer;
                }
                longestLength = Math.Max(longestLength, rightPointer - leftPointer + 1);
            }
            return longestLength;
        }

        public bool ValidPalindrom(string s)
        {
            s = Regex.Replace(s, @"[^0-9a-zA-Z\._]", "").ToLower();
            s = RemoveSpecialChars(s);
            int average = s.Length / 2;
            int leftPointer = 0;
            int rightPointer = s.Length-1;
            bool result = true;

            while(leftPointer < rightPointer)
            {
                if(!(s[leftPointer] == s[rightPointer]))
                {
                    result = false;
                    return result;
                }
                leftPointer++;
                rightPointer--;
            }
            return result;
        }
        public bool ValidPalindromApproach2(string s)
        {
            s = Regex.Replace(s, @"[^0-9a-zA-Z\._]", "").ToLower();
            s = RemoveSpecialChars(s);
            int average = s.Length / 2;
            int leftPointer = average;
            int rightPointer = average;
            bool result = true;

            while(leftPointer >=0 && rightPointer <= s.Length - 1)
            {
                char leftCharacter = s[leftPointer];
                char rightCharacter = s[rightPointer];
                if (leftCharacter != rightCharacter)
                {
                    return false;
                }
                leftPointer--;
                rightPointer++;
            }
            return true;
        }
        public bool AlmostPalindrome(string s)
        {
            int leftPointer = 0;
            int rightPointer = s.Length - 1;
            while(leftPointer < rightPointer)
            {
                char leftCharacter = s[leftPointer];
                char rightCharacter = s[rightPointer];

                if(leftCharacter != rightCharacter)//there is a conflict
                {
                    string leftOver = s.Remove(leftPointer, 1);
                    string rightOver = s.Remove(rightPointer, 1);

                    bool valid1 = ValidPalindrom(leftOver);
                    bool valid2 = ValidPalindrom(rightOver);

                    if(valid1 || valid2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                leftPointer++;
                rightPointer--;
            }
            return true;
        }

        #region Helper Methods
        public static string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            return str;
        }
        #endregion
    }
}
