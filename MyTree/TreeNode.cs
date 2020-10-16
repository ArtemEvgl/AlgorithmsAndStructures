using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    class TreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public TreeNode(TNode value)
        {
            Value = value;         
        }

        public TNode Value { get; }
        public TreeNode<TNode> Left { get; internal set; }
        public TreeNode<TNode> Right { get; internal set; }
        public int CompareTo(TNode other)
        {
            return this.CompareTo(other);
        }
    }
}
