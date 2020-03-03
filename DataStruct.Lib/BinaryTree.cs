using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public sealed class TreeNode<T> where T : IComparable
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public T Data { get; private set; }

        public TreeNode(T data)
        {
            Data = data;
        }

    }

    public class BinaryTree<T> where T : IComparable
    {
        public int Count { get; set; }

        public TreeNode<T> Root { get; private set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public void Add(T data)
        {
            if (Root == null)
                Root = new TreeNode<T>(data);
            else
                InternalAdd(data, Root);

            Count++;

        }

        private void InternalAdd(T data, TreeNode<T> node)
        {
            if (node.Data.CompareTo(data) > 0)
            {
                //Left
                if (node.Left == null)
                    node.Left = new TreeNode<T>(data);
                else
                    InternalAdd(data, node.Left);
            }
            else
            {
                // Right
                if (node.Right == null)
                    node.Right = new TreeNode<T>(data);
                else
                    InternalAdd(data, node.Right);
            }
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            return ContainsInternal(data, Root);

        }

        private bool ContainsInternal(T data, TreeNode<T> root)
        {
            var compareResult = root.Data.CompareTo(data);
            if (compareResult == 0)
                return true;
            else if (compareResult > 0)
            {
                //Left
                if (root.Left == null)
                    return false;
                return ContainsInternal(data, root.Left);
            }
            else
            {
                //Right
                if (root.Right == null)
                    return false;
                return ContainsInternal(data, root.Right);

            }

        }

        public T[] ToArray()
        {
            List<T> list = new List<T>();
            ToArrayInner(list, Root);

            return list.ToArray();
        }

        private void ToArrayInner(List<T> list, TreeNode<T> root)
        {
            if (root.Left != null)  
                ToArrayInner(list, root.Left);
            list.Add(root.Data);
            if (root.Right != null)
                ToArrayInner(list, root.Right);
            

        }
    }
}
