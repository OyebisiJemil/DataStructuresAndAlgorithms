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
            List<int> first = new List<int>() { 100000, 0, 99999, 3, 4, 100000, 0 };

            var res = find_top_k_frequent_elements(first, 2);


            Console.ReadKey();
        }



        public static List<int> find_top_k_frequent_elements(List<int> arr, int k)
        {
            // Write your code here.
            int x = 0;
            Dictionary<int, int> lookup = new Dictionary<int, int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int sum = 0;
                int item = arr[i];

                if (!lookup.ContainsKey(item))
                {
                    for (int j = 0; j < arr.Count; j++)
                    {
                        if (arr[j] == item)
                            sum++;
                    }
                }

                if (sum >= x)
                {
                    lookup.Add(item, sum);
                    x = sum;
                }
            }

            List<int> output = new List<int>();
            foreach (var item in lookup)
            {
                output.Add(item.Key);
            }

        
            output.Reverse();
            return output.Take(k).ToList(); ;
        }


        public static int can_attend_all_meetings(List<List<int>> intervals)
        {
            // Write your code here.
            for (int i = 0; i < intervals.Count - 1; i++)
            {
                List<int> firstMeeting = intervals[i];
                List<int> secondMeeting = intervals[i + 1];

                int firstEndTime = firstMeeting[1];
                int secondBeginTime = secondMeeting[0];

                if (firstEndTime > secondBeginTime)
                    return 0;
            }
            return 1;
        }

        static Node TraverseLinkedList(Node node)
        {
            Node currentNode = new Node(int.MinValue);
            Node head = currentNode;

            while(!(node is null))
            {
                currentNode.next = node;
                node = node.next;
                currentNode = currentNode.next;
            }
            return head.next;
            
        }
        static public Node MergeLinkedList(Node a, Node b)
        {
            if (a == null) return null;
            Node node = new Node(int.MinValue);
            Node head = node;
           
                while(a != null && b != null)
                {
                    if (a.value <= b.value)
                    {
                        node.next = a;
                        a = a.next;
                    }
                    else
                    {
                        node.next = b;
                        b = b.next;
                    }
                    node = node.next;
                }
                if(a != null)
                {
                    node.next = a;         
                }
                else if(b != null)
                {
                    node.next = b;
                }
                
           
            return head;
        }
        public static List<int> pair_sum_sorted_array(List<int> numbers, int target)
        {
            // Write your code here.

            if (numbers == null)
                return new List<int>() { -1, -1 };

            for (int i = 0; i < numbers.Count; i++)
            {
                int compliment = target - numbers[i];
                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numbers[j] == compliment)
                        return new List<int>() { i, j };
                }
            }
            return new List<int>() { -1, -1 };
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

        public static List<int> merge_sort(List<int> arr)
        {
            // Write your code here.
            var result = Helper(arr);
            return result;
        }

        static List<int> Helper(List<int> items)
        {
            if (items.Count <= 1)
                return items;

            List<int> leftResult = new List<int>();
            List<int> rightResult = new List<int>();

            int middle = items.Count / 2;

            leftResult = GetLeftPartition(items, middle);
            rightResult = GetRightPartition(items, middle);

            leftResult = Helper(leftResult);
            rightResult = Helper(rightResult);

            return MyArrayMerge(leftResult.ToArray(), rightResult.ToArray());
        }

        static List<int> GetLeftPartition(List<int> items, int middle)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < middle; i++)
            {
                result.Add(items[i]);
            }
            return result;
        }

        static List<int> GetRightPartition(List<int> items,int middle)
        {
            List<int> result = new List<int>();
            for (int i = middle; i < items.Count; i++)
            {
                result.Add(items[i]);
            }
            return result;
        }

        static List<int> MyArrayMerge(int[] a, int[] b)
        {
            List<int> aux = new List<int>();
            int left = 0;
            int right = 0;
            while(left <= a.Length-1 && right <= b.Length-1)
            {
                if(a[left] < b[right])
                {
                    aux.Add(a[left]);
                    left++;
                }
                else
                {
                    aux.Add(b[right]);
                    right++;
                }
            }
            return aux.ToList();
        }
        static List<int> MyMerge(List<int> a, List<int> b)
        {
            List<int> aux = new List<int>();
            while(a.Count > 0 || b.Count > 0)
            {
                if(a.Count > 0 && b.Count > 0)
                {
                    if (a[0] < b[0])
                    {
                        aux.Add(a[0]);
                        a.RemoveAt(0);
                    }
                    else
                    {
                        aux.Add(b[0]);
                        b.RemoveAt(0);
                    }
                }
                else if(a.Count > 0)
                {
                    aux.Add(a[0]);
                    a.RemoveAt(0);
                }
                else
                {
                    aux.Add(b[0]);
                    b.RemoveAt(0);
                }
            }

            return aux;
        }
        private static List<int> merge(List<int> leftResult, List<int> rightResult)
        {
            List<int> auxiliarySpace = new List<int>();

            while (leftResult.Count > 0 || rightResult.Count > 0)
            {
                if (leftResult.Count > 0 && rightResult.Count > 0)
                {
                    if (leftResult[0] <= rightResult[0])  
                    {
                        auxiliarySpace.Add(leftResult[0]);
                        leftResult.Remove(leftResult[0]);  
                    }
                    else
                    {
                        auxiliarySpace.Add(rightResult[0]);
                        rightResult.Remove(rightResult[0]);
                    }
                }
                else if (leftResult.Count > 0)
                {
                    auxiliarySpace.Add(leftResult[0]);
                    leftResult.Remove(leftResult[0]);
                }
                else if (rightResult.Count > 0)
                {
                    auxiliarySpace.Add(rightResult[0]);

                    rightResult.Remove(rightResult[0]);
                }
            }
            return auxiliarySpace;
        }
        
        private static List<int> ThisMerge(List<int> first, List<int> second)
        {
            List<int> aux = new List<int>();
            int middle = second.Count / 2;

            while(first.Count > 0 && second.Count > 0)
            {
                if(first[0] <= second[0])
                {
                    aux.Add(first[0]);
                    first.RemoveAt(0);
                }
                else
                {
                    aux.Add(second[0]);
                    second.RemoveAt(0);
                }
            }
            if(second.Count > middle)
            {
                aux.Add(second[0]);
                second.RemoveAt(0);
            }
            return aux;
        }
        private static List<int> ThisMergeArray(int[] first, int[] second)
        {
            List<int> aux = new List<int>();
            int left = 0;
            int right = 0;
            int middle = second.Length / 2;

            while (left < first.Length || right < middle)
            {
                if(left < first.Length && right < middle)
                {
                    if (first[left] <= second[right])
                    {
                        aux.Add(first[left]);
                        left++;
                    }
                    else
                    {
                        aux.Add(second[right]);
                        right++;
                    }
                }
                else if(right < middle)
                {
                    aux.Add(second[right]);
                    right++;
                }
                else if(left < first.Length)
                {
                    aux.Add(first[left]);
                    left++;
                }
                
            }
            return aux;
        }


        public static List<char> dutch_flag_sort(List<char> balls)
        {
            // Write your code here.
            char red = 'R';
            char green = 'G';
            int g = 0;
            int b = 0;

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i] == red)
                {
                    Swap(balls, g, i);
                    g++;
                }
            }

            b = g;

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i] == green)
                {
                    Swap(balls, b, i);
                    b++;
                }
            }
            return balls;
        }

        static void Swap(List<char> balls, int left, int right)
        {
            char temp = balls[left];
            balls[left] = balls[right];
            balls[right] = temp;
        }
    }
}
