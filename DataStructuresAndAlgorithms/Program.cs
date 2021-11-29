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
            ITreeSolutions _treeSolutions = new TreeSolutions();
            TreeNode rootNode = new TreeNode(3);
            rootNode.LeftNode = new TreeNode(9);
            rootNode.RightNode = new TreeNode(20);
            rootNode.RightNode.LeftNode = new TreeNode(15);
            rootNode.RightNode.RightNode = new TreeNode(7);
            //rootNode.LeftNode.LeftNode.LeftNode = new TreeNode(20);
            //rootNode.LeftNode.LeftNode.RightNode = new TreeNode(34);
            //rootNode.LeftNode.LeftNode.LeftNode.LeftNode = new TreeNode(10);
            //rootNode.LeftNode.LeftNode.LeftNode.LeftNode.LeftNode = new TreeNode(5);
            //rootNode.LeftNode = new TreeNode(4);
            //rootNode.RightNode = new TreeNode(20);
            //rootNode.LeftNode.LeftNode = new TreeNode(1);
            //rootNode.LeftNode.RightNode = new TreeNode(6);
            //rootNode.RightNode.LeftNode = new TreeNode(15);
            //rootNode.RightNode.RightNode = new TreeNode(170);


            //_treeSolutions.DepthFirstSearchPreOrder(rootNode);

            //Console.WriteLine();

            //_treeSolutions.DepthFirstSearchInOrder(rootNode);

            //Console.WriteLine();

            _treeSolutions.DepthFirstSearchPostOrder(rootNode);
            int counter = 0;
            int result = _treeSolutions.MaximumDepthOfBinaryTree(rootNode, counter);
            int anotherResult = result;

            Console.ReadKey();
        }
    }
}
