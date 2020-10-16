using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        TreeNode<T> head;
        int count;

        public void Add(T value)
        {
            if(head == null)
            {
                head = new TreeNode<T>(value);
            } else
            {
                AddTo(head, value);
            }
            count++;
        }

        private void AddTo(TreeNode<T> current, T value)
        {
            if(current.Value.CompareTo(value) > 0)
            {
                if(current.Left == null)
                {
                    current.Left = new TreeNode<T>(value);
                } else
                {
                    AddTo(current.Left, value);
                }
            } else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value);
                }
                else
                {
                    AddTo(current.Right, value);
                }
            }
        }

        public bool Remove(T value)
        {
            TreeNode<T> current;
            TreeNode<T> parent;

            current = FindWithParent(value, out parent);

            if (current == null)
                return false;

            count--;
            if(current.Right == null)
            {
                if (parent == null)
                {
                    head = current;
                }
                else
                {
                    int result = parent.Value.CompareTo(value);
                    if(result > 0)
                    {
                        parent.Left = current.Left;
                    } else if(result < 0) 
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    head = current;
                }
                else
                {
                    int result = parent.Value.CompareTo(value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else
            {
                TreeNode<T> leftMost = current.Right.Left;
                TreeNode<T> leftMostParent = current.Right.Left;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }
                leftMostParent.Left = leftMost.Right;

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    head = leftMost;
                }
                else
                {
                    int result = parent.Value.CompareTo(value);
                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }

            }
            return true;
        }
        public bool Contains(T value)
        {
            TreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private TreeNode<T> FindWithParent(T value, out TreeNode<T> parent)
        {
            parent = null;
            TreeNode<T> current = head;

            while(current != null)
            {
                int result = current.Value.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                } else
                {
                    break;
                }
            }
            return current;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(head);
        }

        private void InOrderTraversal(TreeNode<T> node)
        {
            if(node.Left != null)
            {
                InOrderTraversal(node.Left);
            }

            Console.WriteLine(node.Value);
            if (node.Right!= null)
            {
                InOrderTraversal(node.Right);
            }

        }

        
        public void Clear()
        {
            head = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(head != null)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                TreeNode<T> node = head;

                stack.Push(node);

                bool goLeftNext = true;
                while (stack.Count > 0)
                {
                    if(goLeftNext)
                    {
                        while (node.Left != null)
                        {
                            stack.Push(node);
                            node = node.Left;
                        }
                    }
                }

                yield return node.Value;

                if(node.Right != null)
                {
                    node = node.Right;
                    goLeftNext = true;
                } else
                {
                    node = stack.Pop();
                    goLeftNext = false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
