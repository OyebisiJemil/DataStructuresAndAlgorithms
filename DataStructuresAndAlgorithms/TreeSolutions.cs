using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class TreeSolutions : ITreeSolutions
    {
        public void DepthFirstSearchInOrder(TreeNode root)
        {
            InorderTraversal(root);
        }

        public void DepthFirstSearchPreOrder(TreeNode rootNode)
        {
            PreorderTraversal(rootNode);
        }

        private void PreorderTraversal(TreeNode node)
        {            
            if(node != null)
            {
                //output the node value
                Console.Write(node.Value +",");
                //Recall PreorderTraversal with left node
                PreorderTraversal(node.LeftNode);

                //Recall PreorderTraversal with right node
                PreorderTraversal(node.RightNode);
            }           
        }

        private void InorderTraversal(TreeNode node)
        {
            if(node != null)
            {
                InorderTraversal(node.LeftNode);
                Console.Write(node.Value + ",");
                InorderTraversal(node.RightNode);
            }
        }

        public void DepthFirstSearchPostOrder(TreeNode root)
        {
            PostorderTraversal(root);
        }

        private void PostorderTraversal(TreeNode node)
        {
            if(node != null)
            {
                PostorderTraversal(node.LeftNode);
                PostorderTraversal(node.RightNode);
                Console.Write(node.Value + ",");
            }
        }

        public int MaximumDepthOfBinaryTree(TreeNode root, int currentDepth)
        {
            // 1st basecase
            if (root == null) return currentDepth;

            // What to do on each node
            currentDepth++;

            //get for the left node
            int currentLeftDepth = MaximumDepthOfBinaryTree(root.LeftNode, currentDepth);
            int currentRightDepth = MaximumDepthOfBinaryTree(root.RightNode, currentDepth);

            return Math.Max(currentLeftDepth, currentRightDepth);
        }

        int MaximumDepth(TreeNode root, int currentDepth)
        {
            if (root == null) return currentDepth;

            currentDepth++;

            int currentLeftDepth = MaximumDepth(root, currentDepth);
            int currentRightDepth = MaximumDepth(root, currentDepth);

            return Math.Max(currentLeftDepth, currentRightDepth);
        }

        public IList<int> BreadthFirstSearch(TreeNode root)
        {
            List<int> result = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode.Value);

                if(currentNode.LeftNode != null) queue.Enqueue(currentNode.LeftNode);

                if (currentNode.RightNode != null) queue.Enqueue(currentNode.RightNode);
            }

            return result;
        }
    }
}
