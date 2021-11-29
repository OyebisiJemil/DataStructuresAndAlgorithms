using System;
using Xunit;
using Moq;
using DataStructuresAndAlgorithms;

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
            TreeNode rootNode = new TreeNode(9);
            rootNode.LeftNode = new TreeNode(4);
            rootNode.RightNode = new TreeNode(20);
            rootNode.LeftNode.LeftNode = new TreeNode(1);
            rootNode.LeftNode.RightNode = new TreeNode(6);
            rootNode.RightNode.LeftNode = new TreeNode(15);
            rootNode.RightNode.RightNode = new TreeNode(170);
          

            _treeSolutions.DepthFirstSearchPreOrder(rootNode);

            //Assert.Equal(expectedValue, maximumArea);
        }
    }
}
