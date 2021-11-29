using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface IStackSolutions
    {
        bool ValidParentheses(string s);
        string MinimumBracketToRemove(string s);
        int Factoria(int x);
        int TailFactoria(int x, int totalSoFar = 1);
    }
}
