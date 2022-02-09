using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithmsTest
{
    public class TreeSolutionShould
    {
        ITreeSolutions _treeSolutions;
        public TreeSolutionShould()
        {
            _treeSolutions = new TreeSolutions();
        }

        [Fact]
        public void DepthFirstSearchPreOrder_WithTestCase_Runs()
        {
            TreeNode treeNode = new TreeNode(6);
            treeNode.LeftNode = new TreeNode(3);
            treeNode.RightNode = new TreeNode(5);
            treeNode.RightNode.RightNode = new TreeNode(4);
            treeNode.LeftNode.LeftNode = new TreeNode(2);
            treeNode.LeftNode.RightNode = new TreeNode(5);
            treeNode.LeftNode.RightNode.LeftNode = new TreeNode(7);
            treeNode.LeftNode.RightNode.RightNode = new TreeNode(4);


           var result = _treeSolutions.PreOrderTraversal(treeNode);

            //Assert.Equal(expectedValue, maximumArea);
        }

        [Fact]
        public void BuildTree_WithTestCase_Runs()
        {
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };
            var result =  _treeSolutions.BuildTree(inorder, postorder);

            //Assert.Equal(expectedValue, maximumArea);
        }

        [Fact]
        public void SortedListToTree_WithTestCase_Runs()
        {
            Node node = new Node(-10);
            node.next = new Node(-3);
            node.next.next = new Node(0);
            node.next.next.next = new Node(5);
            node.next.next.next.next = new Node(9);
            var result = _treeSolutions.SortedListToBST(node);

            //Assert.Equal(expectedValue, maximumArea);
        }
        
        [Fact]
        public void PrintLongestPath()
        {
            TreeNode treeNode = new TreeNode(4);
            treeNode.LeftNode = new TreeNode(3);
            treeNode.RightNode = new TreeNode(6);
            treeNode.RightNode.LeftNode = new TreeNode(5);
            treeNode.RightNode.RightNode = new TreeNode(7);
            treeNode.LeftNode.LeftNode = new TreeNode(8);
            treeNode.LeftNode.RightNode = new TreeNode(9);
            treeNode.LeftNode.LeftNode.LeftNode = new TreeNode(10);
            treeNode.LeftNode.LeftNode.RightNode = new TreeNode(11);
            treeNode.RightNode.LeftNode = new TreeNode(5);

            List<int> expectedResult = new List<int>() { 4, 6, 7 };

            var actualResult = _treeSolutions.PrintLongestPath(treeNode);

            Assert.Equal(expectedResult, actualResult);

        }       
    
        [Fact]
        public void PreorderTraversalIterative()
        {
            TreeNode treeNode = new TreeNode(6);
            treeNode.LeftNode = new TreeNode(3);
            treeNode.RightNode = new TreeNode(5);
            treeNode.RightNode.RightNode = new TreeNode(4);
            treeNode.LeftNode.LeftNode = new TreeNode(2);
            treeNode.LeftNode.RightNode = new TreeNode(5);
            treeNode.LeftNode.RightNode.LeftNode = new TreeNode(7);
            treeNode.LeftNode.RightNode.RightNode = new TreeNode(4);


            var result = _treeSolutions.PreOrderTraversalIteration(treeNode);
        }
    
    }
}
