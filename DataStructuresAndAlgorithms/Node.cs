using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
    }
}
