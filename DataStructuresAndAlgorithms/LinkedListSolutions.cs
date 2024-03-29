﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class LinkedListSolutions:ILinkedListSolutions
    {
       

        /// <summary>
        /// Given a head node of a sorted linked list, this algorithm removes duplicate from the linked list by 
        /// comparing the neighboring nodes
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node RemoveDuplicateFromSortedList(Node head)
        {
            Node currentNode = head;

            //traverse through the linked list and compare every node with the next node until next node is null
            while(currentNode != null && currentNode.next != null)
            {
                if(currentNode.value == currentNode.next.value)
                {
                    currentNode.next = currentNode.next.next;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }
            return head;
        }

        /// <summary>
        /// Given a head node of an unsorted linked list, this algorithm removes duplicate from the linked list
        /// using hashset.
        /// This has a complexsity of O(n) as the algorithm traverse throught all the nodes in the list 
        /// The time complexity to access item from he hashset is O(1)
        /// Therefore, this is the best we can do
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>

        public Node RemoveDuplicateFromUnsortedWithHashSet(Node node)
        {
            HashSet<int> hashSet = new HashSet<int>();
            Node current = node;
            Node previus = null;
            while (current!= null)
            {
                if (hashSet.Contains(current.value))
                {
                    previus.next = current.next;
                }
                else
                {
                    hashSet.Add(current.value);
                    previus = current;
                }
                current = current.next;
            }

            return node;
        }

        /// <summary>
        /// Given a head node of an unsorted linked list, this algorithm removes duplicate from the linked list
        /// by using 2 pointers, for each current node, we traverse through the list using the runner node.
        /// This gives us O(n) square
        /// This is not an optimal solution
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node RemoveDuplicateFromUnsortedList(Node head)
        {
            Node current = head;
            while (current != null)
            {
               Node  runner = current;
                while (runner.next != null)
                {
                    if (current.value == runner.next.value)
                    {
                        runner.next = runner.next.next;
                    }
                    else
                    {
                        runner = runner.next;
                    }
                }
                current = current.next;
            }
            return head;
        }

        public Node ReturnKthElement(Node head, int k)
        {
            Node current = head;
            Node follower = head;

            for (int i = 1; i < k; i++)
            {
                if(current == null)
                {
                    return null;
                }
                current = current.next;
            }

            while (current.next != null)
            {
                current = current.next;
                follower = follower.next;
            }

            return follower;
        }


        /// <summary>
        /// Given a node, this algorithm deletes the node in the middle without affecting the head and the last node
        /// the time complexity for this is O(1)
        /// No head node was given, only the node to be removed was given.
        /// Copying the next node over to the current node would do the job
        /// </summary>
        /// <param name="nodeToDelete"></param>
        /// <returns></returns>
        public Node DeleteMiddleNode(Node nodeToDelete)
        {
            if (nodeToDelete == null || nodeToDelete.next == null)
            {
                return null;
            }

            nodeToDelete.value = nodeToDelete.next.value;
            nodeToDelete.next = nodeToDelete.next.next;
            return nodeToDelete;
        }

        public Node PartitionLinkedList(Node headNode, int x)
        {
            Node LeftListHeadNode = null;
            Node LeftListTailNode = null;
            Node RightListHeadNode = null;
            Node RightListTailNode = null;

            while(headNode != null)
            {
                Node next = headNode.next;
                headNode.next = null;
                if(headNode.value < x)
                {
                    if(LeftListHeadNode == null)
                    {
                        LeftListHeadNode = headNode;
                        LeftListTailNode = LeftListHeadNode;
                    }
                    else
                    {
                        LeftListTailNode.next = headNode;
                        LeftListTailNode = headNode;
                    }
                }
                else
                {
                    if(RightListHeadNode == null)
                    {
                        RightListHeadNode = headNode;
                        RightListTailNode = RightListHeadNode;
                    }
                    else
                    {
                        RightListTailNode.next = headNode;
                        RightListTailNode = headNode;
                    }
                }
                headNode = next;
            }

            LeftListTailNode.next = RightListHeadNode;

            return LeftListHeadNode;
        }

        public Node ReverseLinkedList(Node head)
        {
            Node currentNode = head;
            Node prev = null;

            while(currentNode != null)
            {
                Node next = currentNode.next;
                currentNode.next = prev;
                prev = currentNode;
                currentNode = next;
            }

            return prev;
        }
        public Node ReverseBetween(Node head, int left, int right)
        {
            Node currentNode = head;
            int position = 1;
            Node startNode = head;


            while (position < left)
            {
                startNode = currentNode;
                currentNode = currentNode.next;
                position++;
            }
            Node tailNode = currentNode;
            Node newList = null;
            while (position >= left && position <= right)
            {
                Node next = currentNode.next;
                currentNode.next = newList;
                newList = currentNode;
                currentNode = next;
                position++;
            }

            startNode.next = newList;
            tailNode.next = currentNode;

            if (left > 1)
                return head;
            else
                return newList;
        }
    
    }
}
