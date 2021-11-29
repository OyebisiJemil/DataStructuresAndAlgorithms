using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class TreeNode
    {
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
            this.LeftNode = null;
            this.RightNode = null;
        }
    }
}
