using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class MyQueue
    {
        private Stack<int> output = new Stack<int>();
        public MyQueue()
        {

        }

        public void Push(int x)
        {
            var input = new Stack<int>();
            while (output.Count != 0)
            {
                input.Push(output.Pop());
            }
            output.Push(x);
            while (input.Count != 0)
            {
                output.Push(input.Pop());
            }
        }

        public int Pop()
        {
            return output.Pop();
        }

        public int Peek()
        {
            return output.Peek();
        }

        public bool Empty()
        {
            return !output.Any();
        }
    }
}
