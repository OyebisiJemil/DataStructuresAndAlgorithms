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
            int[] arrayA = { 1, 3, 2, 6,-1, 4, 1, 8, 2 };

            List<double> result = OptimizedAverageSubArray(arrayA, 5);

            Console.ReadKey();
        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            string lastSide = "right";

            if (root == null) return result;

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int level = queue.Count;
                int count = 0;
                IList<int> localResult = new List<int>();

                while (level != count)
                {
                    TreeNode node = queue.Dequeue();
                    localResult.Add(node.Value);

                    if (lastSide == "right")
                    {
                        if (node.RightNode != null) queue.Enqueue(node.RightNode);
                        if (node.LeftNode != null) queue.Enqueue(node.LeftNode);
                        count++;
                        if (level == count) lastSide = "left";
                    }
                    else
                    {
                        if (node.LeftNode != null) queue.Enqueue(node.LeftNode);
                        if (node.RightNode != null) queue.Enqueue(node.RightNode);
                        count++;
                        if (level == count) lastSide = "right";
                    }
                }

                result.Add(localResult);
            }
            return result;
        }

        public static bool IsValidBST(TreeNode root)
        {
            return IsBST(root, int.MinValue, int.MaxValue);
        }
        static int FindMinimum(TreeNode root)
        {
            //if (root == null) return int.MinValue;

            int result = root.Value;
            int leftResult = 0;
            int rightResult = 0;
            if (root.LeftNode != null)
                leftResult = FindMinimum(root.LeftNode);
            else return result;

            if (root.RightNode != null)
                rightResult = FindMinimum(root.RightNode);
            else return result;

            result = Math.Min(leftResult, result);
            result = Math.Min(rightResult, result);

            return result;
        }

        static int FindMaximum(TreeNode root, int maximum)
        {
            if (root == null) return maximum;
      
            int max = Math.Max(root.Value, maximum);
            if (root.LeftNode != null)
               return  FindMaximum(root.LeftNode, max);

            if (root.RightNode != null)
               return  FindMaximum(root.RightNode, max);



            return max;
        }

        static bool IsSubtreeLesser(TreeNode root, int maximum)
        {
            if (root == null) return true;

            //root less than maximum
            bool rootLessThanMaximum = root.Value < maximum;

            //left subtree less than maximum
            bool leftSubtreeLessThanMaximum = IsSubtreeLesser(root.LeftNode, maximum);

            // right subtree less than maximum 
            bool rightSubtreeLessThanMaximum = IsSubtreeLesser(root.RightNode, maximum);

            if (rootLessThanMaximum && leftSubtreeLessThanMaximum && rightSubtreeLessThanMaximum) return true;
            else return false;
        }

        static bool IsSubtreeGreater(TreeNode root, int minimum)
        {
            if (root == null) return true;

            //root greater than minimum
            bool rootGreterThanMinimum = root.Value > minimum;

            // left subtree greater than minimum
            bool leftSubtreeGreaterThanMinimum = IsSubtreeGreater(root.LeftNode, minimum);

            //right subtree greater than minimum

            bool rightSubtreeGreaterThanMinimimum = IsSubtreeGreater(root.RightNode, minimum);

            if (rootGreterThanMinimum && leftSubtreeGreaterThanMinimum && rightSubtreeGreaterThanMinimimum) return true;
            else return false;
        }

        static bool IsBST(TreeNode root, int min, int max)
        {
            if (root == null) return true;
            if (root.Value < min || root.Value >= max) return false;

            return IsBST(root.LeftNode, min, root.Value) && IsBST(root.RightNode, root.Value, max);
        }

        static int FindMax(TreeNode root, int maxCount)
        {
            if (root == null) return maxCount;

            //staying on this node
            maxCount++;

            //move to the left
            int leftMaximum = FindMax(root.LeftNode, maxCount);

            //move to the right
            int rightMaximum = FindMax(root.RightNode, maxCount);

            return Math.Max(leftMaximum, rightMaximum);
        }

        static int FindMin(TreeNode root, int maxCount)
        {
            if (root == null) return maxCount;

            //staying on this node
            maxCount++;

            //move to the left
            int leftMaximum = FindMin(root.LeftNode, maxCount);

            //move to the right
            int rightMaximum = FindMin(root.RightNode, maxCount);

            return Math.Min(leftMaximum, rightMaximum);
        }

        static int BinarySearch(int toFind)
        {
            int[] list = { 5, 9, 17, 23, 25, 45, 59, 63, 71, 89 };
            int result = 0;
            int left = 0;
            int right = list.Length - 1;
            int middle = (left + right) / 2;

            while(left <= right)
            {
                if (toFind == list[middle])
                    return middle;
                else if (toFind < list[middle])
                    right = middle - 1;
                else
                    left = middle + 1;

                middle = (left + right) / 2;
            }

            return result;
        }
        

        static void QuickSort(int[] elements, int lowerBownd, int upperBound)
        {
            if(lowerBownd < upperBound)
            {
                int pivotFinalIndex = Partition(elements, lowerBownd, upperBound);
                QuickSort(elements, lowerBownd, pivotFinalIndex - 1);
                QuickSort(elements, pivotFinalIndex + 1, upperBound);
            }
        }
        static int Partition(int[] elements, int lowerBownd, int upperBound)
        {

            int pivot = elements[lowerBownd];

            int start = lowerBownd;
            int end = upperBound;
            while(start < end)
            {
                while(!(start > upperBound) && elements[start] <= pivot)
                {
                    start++;
                }
                while(elements[end] > pivot)
                {
                    end--;
                }
                if(start < end)
                    Swap(elements, start, end);
            }
            Swap(elements, lowerBownd, end);
            return end;
        }

        private static void Swap(int[] elements, int start, int end)
        {
            int temp = elements[start];
            elements[start] = elements[end];
            elements[end] = temp;
        }

        private static List<int> MergeTwoArrays(int[] arrayA, int[] arrayB)
        {
            int i = 0;
            int j = 0;
            //int[] result = new int[arrayA.Length + arrayB.Length];
            List<int> list = new List<int>();


            while(i < arrayA.Length)
            {
                if(j < arrayB.Length )
                {
                    if (arrayA[i] < arrayB[j])
                    {
                        list.Add(arrayA[i]);
                        i++;
                    }
                    else
                    {
                        list.Add(arrayB[j]);
                        j++;
                    }
                }
                else
                {
                    list.Add(arrayA[i]);
                    i++;
                }
               
            }

            return list;
        }
        
        private static List<double> AvgOfSubArrays(int[] elements, int k)
        {
            List<double> output = new List<double>();
            for(int i = 0; i<k; i++)
            {
                double sum = 0;
                double average = 0.0;
                for(int j = i; j < i+ k; j++)
                {
                    sum = sum + elements[j];
                }
                average = sum / k;
                output.Add(average);               

            }
            return output;
        }

        private static List<double> OptimizedAverageSubArray(int[] element, int k)
        {
            List<double> output = new List<double>();
            double sum = 0;
            double average = 0;

            for (int i = 0; i < element.Length; i++)
            {
                sum = sum + element[i];// add next element
                if (i >= k-1)
                {
                    average = sum / k;
                    output.Add(average);

                    int j = i - (k-1); //get index to remove from window
                    sum = sum - element[j]; // removing element from the window                    
                }
               
            }
            return output;
        }
    }
}
