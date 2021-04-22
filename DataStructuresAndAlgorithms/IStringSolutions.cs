﻿using System;
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
    }
}
