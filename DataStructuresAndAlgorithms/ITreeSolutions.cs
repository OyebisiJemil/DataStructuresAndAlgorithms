using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface ITreeSolutions
    {
        List<int> PreOrderTraversal(TreeNode root);
        List<int> PreOrderTraversalIteration(TreeNode root);
        void DepthFirstSearchInOrder(TreeNode root);
        void DepthFirstSearchPostOrder(TreeNode root);
        int MaximumDepthOfBinaryTree(TreeNode root, int currentDepth);
        IList<int> BreadthFirstSearch(TreeNode root);
        List<List<int>> LevelOrderBinaryTree(TreeNode root);
        IList<int> RightSideView(TreeNode root);
        IList<int> RightSideViewDFS(TreeNode root);
        TreeNode BuildTree(int[] inorder, int[] postorder);
        TreeNode SortedListToBST(Node head);
        List<int> PrintLongestPath(TreeNode root);
    }
}
