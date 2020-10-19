using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAVLTree
{
    class AVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable
    {
        AVLTree<TNode> tree;

        AVLTreeNode<TNode> left;
        AVLTreeNode<TNode> right;

        public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
        {
            Parent = parent;
            Value = value;
            this.tree = tree;
        }

        public TNode Value { get; private set; }
        public AVLTreeNode<TNode> Left { 
            get 
            {
                return left;
            }
            internal set {
                left = value;
                if (left != null)
                {
                    left.Parent = this;
                }
            } 
        }

        public AVLTreeNode<TNode> Right
        {
            get
            {
                return right;
            }
            internal set
            {
                right = value;
                if (right != null)
                {
                    right.Parent = this;
                }
            }
        }

        enum TreeState
        {
            Balanced,
            LeftHeavy,
            RightHeadvy
        }

        private int MaxChildHeight(AVLTreeNode<TNode> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(right));
            }
            return 0;
        }
        public AVLTreeNode<TNode> Parent { get; internal set; }
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
