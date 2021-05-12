using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface ILinkedListSolutions
    {
        Node RemoveDuplicateFromSortedList(Node head);
        Node RemoveDuplicateFromUnsortedList(Node head);
        Node RemoveDuplicateFromUnsortedWithHashSet(Node head);
    }
}
