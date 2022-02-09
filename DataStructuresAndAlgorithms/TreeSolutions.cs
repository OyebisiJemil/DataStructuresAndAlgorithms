using System;
using System.Collections;
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

        public List<int> PreOrderTraversal(TreeNode rootNode)
        {
            List<int> result = new List<int>();
            return  PreorderTraversal(rootNode, result);
        }

        public List<int> PreOrderTraversalIteration(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();

            stack.Push(root);

            while(stack.Count > 0)
            {
                var node = stack.Pop();

                result.Add(node.Value);

                if (node.RightNode != null) stack.Push(node.RightNode);
                if (node.LeftNode != null) stack.Push(node.LeftNode);
            }

            return result;
        }

      

        private List<int> PreorderTraversal(TreeNode node, List<int> list)
        {            
            if(node != null)
            {
                //output the node value
                list.Add(node.Value);
                //Recall PreorderTraversal with left node
                PreorderTraversal(node.LeftNode, list);

                //Recall PreorderTraversal with right node
                PreorderTraversal(node.RightNode, list);
            }
            return list;
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

        public IList<IList<int>> LevelOrderBinaryTree(TreeNode root)
        {
            if (root == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<IList<int>> resultList = new List<IList<int>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                List<int> list = new List<int>();
                int level = queue.Count;
                int counter = 0;
                while(counter < level)
                {
                    var node = queue.Dequeue();
                    list.Add(node.Value);

                    AddLeft(node, queue);
                    AddRight(node, queue);

                    counter++;
                }
                resultList.Add(list);
            }
            return resultList;
        }

        private void AddLeft(TreeNode node, Queue<TreeNode> queue)
        {
            if (node.LeftNode != null) queue.Enqueue(node.LeftNode);
        }
        private void AddRight(TreeNode node, Queue<TreeNode> queue)
        {
            if (node.RightNode != null) queue.Enqueue(node.RightNode);
        }

        List<List<int>> ITreeSolutions.LevelOrderBinaryTree(TreeNode root)
        {
            throw new NotImplementedException();
        }

        public IList<int> RightSideView(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<int> result = new List<int>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int level = queue.Count;
                int count = 0;
                int lastValue = 0;

                while(level != count)
                {
                    var node = queue.Dequeue();
                    lastValue = node.Value;
                    if (node.LeftNode != null) queue.Enqueue(node.LeftNode);
                    if (node.RightNode != null) queue.Enqueue(node.RightNode);
                    count++;
                }
                result.Add(lastValue);
            }

            return result;
        }

        public IList<int> RightSideViewDFS(TreeNode root)
        {
            int level = 0;
            HashSet<int> levelLookup = new HashSet<int>();
            List<int> result = new List<int>();

            return RightSideViewDFSearch(root, level, levelLookup, result);
        }

        private IList<int> RightSideViewDFSearch(TreeNode root, int level, HashSet<int> levelLookup, List<int> result)
        {
            if (!levelLookup.Contains(level))
            {
                result.Add(root.Value);
                levelLookup.Add(level);
            }
            level++;

           if(root.RightNode != null)  RightSideViewDFSearch(root.RightNode, level, levelLookup, result);
           if(root.LeftNode != null)  RightSideViewDFSearch(root.LeftNode, level, levelLookup, result);

            return result;
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0) return null;

            int rootValue = postorder[postorder.Length - 1];// GetRootFromPostOrder(postorder, inorder)
            Hashtable postorderLookup = new Hashtable();
            for (int i = 0; i < postorder.Length; i++)
            {
                postorderLookup.Add(postorder[i], i);
            }

            return Recurse(rootValue, postorderLookup, inorder, postorder);
        }

        TreeNode Recurse(int rootValue, Hashtable postorder, int[] inorder, int[] postorderArray)
        {
            if (inorder.Length == 0) return null;

            TreeNode root = new TreeNode(rootValue);

            int mid = GetMiddleValueIndex(inorder, rootValue);

            int[] leftInorder = GetLeftInorder(inorder, mid);
            int[] rightInorder = GetRightInorder(inorder, mid);

            int leftRootValue = GetRootFromPostOrder(postorder, leftInorder, postorderArray);
            int rightRootValue = GetRootFromPostOrder(postorder, rightInorder, postorderArray);

            root.LeftNode = Recurse(leftRootValue, postorder, leftInorder, postorderArray);
            root.RightNode = Recurse(rightRootValue, postorder, rightInorder, postorderArray);

            return root;
        }


        int GetRootFromPostOrder(Hashtable postorder, int[] inorder, int[] postorderArray)
        {

            int largerIndex = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                int indexInPostOrder = (int)postorder[inorder[i]];             
                largerIndex = Math.Max(largerIndex, indexInPostOrder);
            }
            return postorderArray[largerIndex];
        }
        private int GetMiddleValueIndex(int[] inorder, int val)
        {
            for (int pointer = 0; pointer < inorder.Length; pointer++)
            {
                if (inorder[pointer] == val)
                {
                    return pointer;
                }
            }

            return 0;
        }

        private int[] GetLeftInorder(int[] inorder, int mid)
        {
            List<int> result = new List<int>();

            for (int pointer = 0; pointer < mid; pointer++)
            {
                result.Add(inorder[pointer]);
            }
            return result.ToArray();
        }

        private int[] GetRightInorder(int[] inorder, int mid)
        {
            List<int> result = new List<int>();

            for (int pointer = mid + 1; pointer < inorder.Length; pointer++)
            {
                result.Add(inorder[pointer]);
            }
            return result.ToArray();
        }

        public TreeNode SortedListToBST(Node head)
        {
            int[] nums = ListToArray(head);

            return Recurse(nums);
        }

        TreeNode Recurse(int[] nums)
        {

            if (nums == null || nums.Length == 0) return null;

            int left = 0;
            int right = nums.Length - 1;
            int mid = (left + right) / 2;

            int[] leftNums = GetLeftNums(nums, mid);
            int[] rightNums = GetRightNums(nums, mid);

            TreeNode root = new TreeNode(nums[mid]);

            root.LeftNode = Recurse(leftNums);
            root.RightNode = Recurse(rightNums);

            return root;

        }

        int[] GetLeftNums(int[] nums, int mid)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < mid; i++)
            {
                result.Add(nums[i]);
            }
            return result.ToArray();
        }

        int[] GetRightNums(int[] nums, int mid)
        {
            List<int> result = new List<int>();

            for (int i = mid + 1; i < nums.Length; i++)
            {
                result.Add(nums[i]);
            }
            return result.ToArray();
        }
        int[] ListToArray(Node head)
        {
            List<int> result = new List<int>();
            while (head != null)
            {
                result.Add(head.value);

                head = head.next;
            }
            return result.ToArray();
        }
        public List<int> PrintLongestPath(TreeNode root)
        {
            if (root == null) return null;

            //find the longest path from the left

            List<int> leftLongest = PrintLongestPath(root.LeftNode);

            //find the longest path from the right

            List<int> rightLongest = PrintLongestPath(root.RightNode);
            // compare the longest between left and right list

            if (rightLongest.Count > leftLongest.Count)
                rightLongest.Add(root.Value);
            else
                leftLongest.Add(root.Value);

            if (rightLongest.Count > leftLongest.Count)
                return rightLongest;
            else
                return leftLongest;
            //append the current node to it
        }
        
    }
}
