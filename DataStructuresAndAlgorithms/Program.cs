using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringSolutions stringSolutions = new StringSolutions();
            bool result = false;
            Console.WriteLine("Press 1 for string uniqueness");
            Console.WriteLine("Press 2 for check permutation");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Input string value");
                    string stringInput = Console.ReadLine();
                    Console.WriteLine("Press 1 for unique with additional data structure");
                    Console.WriteLine("Press 2 for unique without additional data structure");
                    int a = int.Parse(Console.ReadLine());
                    switch (a)
                    {                        
                        case 1:
                            result = stringSolutions.IsUnique(stringInput);
                            Console.WriteLine("{0}", result);
                            break;
                        case 2:
                            result = stringSolutions.IsUniqueWithSortedString(stringInput);
                            Console.WriteLine("{0}", result);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Input first string");
                    string firstString = Console.ReadLine();
                    Console.WriteLine("Input second string");
                    string secondString = Console.ReadLine();
                    Console.WriteLine("Press 1 for check permutation without sort");
                    Console.WriteLine("Press 2 for check permutation with sorted string");
                    Console.WriteLine("Press 3 for check permutation with two identical character count");
                    int b = int.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            result = stringSolutions.CheckPermutation(firstString, secondString);
                            Console.WriteLine("{0}", result);
                            break;
                        case 2:
                            result = stringSolutions.CheckPermutationWithSortedStrings(firstString, secondString);
                            Console.WriteLine("{0}", result);
                            break;
                        case 3:
                            result = stringSolutions.CheckPermutationWithTwoIdenticalCharacterCount(firstString, secondString);
                            Console.WriteLine("{0}", result);
                            break;
                    }
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
