using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;

namespace DataStructuresAndAlgorithmsTest
{
    public class LinkedListSolutionShould
    {
        ILinkedListSolutions _linkedListSolutions;
        public LinkedListSolutionShould()
        {
            _linkedListSolutions = new LinkedListSolutions();
        }

        [Fact]
        public void RemoveDuplicateFromSortedList_WithHeadNode_ReturnsResult()
        {
            Node headNode = new Node(1);
            headNode.next = new Node(2);
            headNode.next.next = new Node(3);
            headNode.next.next.next = new Node(3);
            headNode.next.next.next.next = new Node(4);
            headNode.next.next.next.next.next = new Node(5);
            headNode.next.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next.next = new Node(6);

            var actualResult = _linkedListSolutions.RemoveDuplicateFromSortedList(headNode);

            Assert.Equal(headNode, actualResult);
        }

        [Fact]
        public void RemoveDuplicateFromSortedList_WithHeadNodeUsingHashSet_ReturnsResult()
        {
            Node headNode = new Node(4);
            headNode.next = new Node(2);
            headNode.next.next = new Node(8);
            headNode.next.next.next = new Node(8);
            headNode.next.next.next.next = new Node(4);
            headNode.next.next.next.next.next = new Node(5);
            headNode.next.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next.next = new Node(6);

            var actualResult = _linkedListSolutions.RemoveDuplicateFromUnsortedWithHashSet(headNode);

            Assert.Equal(headNode, actualResult);
        }

        [Fact]
        public void RemoveDuplicateFromUnsortedList_WithHeadNode_ReturnsResult()
        {
            Node headNode = new Node(10);
            headNode.next = new Node(3);
            headNode.next.next = new Node(3);
            headNode.next.next.next = new Node(2);
            headNode.next.next.next.next = new Node(4);
            headNode.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next.next = new Node(5);

            var actualResult = _linkedListSolutions.RemoveDuplicateFromUnsortedList(headNode);

            Assert.Equal(headNode, actualResult);
        }
    }
}
