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

        [Fact]
        public void ReturnKthElement_WithHeadNode_ReturnsResult()
        {
            Node headNode = new Node(10);
            headNode.next = new Node(3);
            headNode.next.next = new Node(3);
            headNode.next.next.next = new Node(2);
            headNode.next.next.next.next = new Node(4);
            headNode.next.next.next.next.next = new Node(11);
            headNode.next.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next.next = new Node(5);

            var expectedResult = 6;

            var actualResult = _linkedListSolutions.ReturnKthElement(headNode,2);

            Assert.Equal(expectedResult, actualResult.value);
        }

        [Fact]
        public void DeleteMiddleNode_WithHeadNode_RemovesTheMiddleNode()
        {
            Node headNode = new Node(10);
            headNode.next = new Node(3);
            headNode.next.next = new Node(5);
            headNode.next.next.next = new Node(2);

            var actualResult = _linkedListSolutions.DeleteMiddleNode(headNode.next);

            Assert.Equal(5, actualResult.value);
        }

        [Fact]
        public void PartitionLinkedList_WithHeadNodeAndXGiven_ReturnsHeadNode()
        {
            Node headNode = new Node(3);
            headNode.next = new Node(5);
            headNode.next.next = new Node(8);
            headNode.next.next.next = new Node(5);
            headNode.next.next.next.next = new Node(10);
            headNode.next.next.next.next.next = new Node(2);
            headNode.next.next.next.next.next.next = new Node(1);



            var actualResult = _linkedListSolutions.PartitionLinkedList(headNode, 5);

            Assert.Equal(headNode, actualResult);
        }
        [Fact]
        public void ReverseLinkedList_WithHeadNode_Works()
        {
            Node headNode = new Node(1);
            headNode.next = new Node(2);
            headNode.next.next = new Node(3);
            headNode.next.next.next = new Node(4);
            headNode.next.next.next.next = new Node(5);

            var actualResult = _linkedListSolutions.ReverseLinkedList(headNode);

            Assert.Equal(5, actualResult.value);
        }

        [Fact]
        public void ReverseBetween_WithHeadNode_Works()
        {
            Node headNode = new Node(1);
            headNode.next = new Node(2);
            headNode.next.next = new Node(3);
            headNode.next.next.next = new Node(4);
            headNode.next.next.next.next = new Node(5);
            headNode.next.next.next.next.next = new Node(6);
            headNode.next.next.next.next.next.next = new Node(7);

            var actualResult = _linkedListSolutions.ReverseBetween(headNode, 1, 1);

            Assert.Equal(1, actualResult.value);
        }
    }
}
