using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class StackSolutions : IStackSolutions
    {
        public bool ValidParentheses(string s)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add('{','}');
            hashtable.Add('[', ']');
            hashtable.Add('(', ')');

            Stack<char> stack = new Stack<char>();
            for(int i =0; i<s.Length; i++)
            {
               bool leftBracket = IsLeftBracket(s[i]);
                if (leftBracket)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0) return false;

                    var topOfTheStack = stack.Pop();
                    bool openAndClose = OpenAndClose(topOfTheStack, s[i]);
                    if (!openAndClose)
                        return false;
                }
            }
            return stack.Count == 0;
        }

        bool IsLeftBracket(char c)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add('{', '}');
            hashtable.Add('[', ']');
            hashtable.Add('(', ')');
            if (hashtable.ContainsKey(c))
            {
                return true;
            }
            return false;
        }

        bool OpenAndClose(char open, char close)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add('{', '}');
            hashtable.Add('[', ']');
            hashtable.Add('(', ')');

            var value = hashtable[open];
            return value.ToString() == close.ToString();
        }
    }
}
