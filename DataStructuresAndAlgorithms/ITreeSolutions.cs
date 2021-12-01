using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public interface ITreeSolutions
    {
        void DepthFirstSearchPreOrder(TreeNode root);
        void DepthFirstSearchInOrder(TreeNode root);
        void DepthFirstSearchPostOrder(TreeNode root);
        int MaximumDepthOfBinaryTree(TreeNode root, int currentDepth);
        IList<int> BreadthFirstSearch(TreeNode root);
    }
}
