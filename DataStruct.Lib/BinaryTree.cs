using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public sealed class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public IComparable Data { get; private set; }

        public TreeNode(IComparable data)
        {
            Data = data;
        }

    }

    public class BinaryTree
    {
        public int Count { get; set; }

        public TreeNode Root { get; private set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public void Add(IComparable data)
        {
            if (Root == null)
                Root = new TreeNode(data);
            else
                InternalAdd(data, Root);

            Count++;

        }

        private void InternalAdd(IComparable data, TreeNode node)
        {
            if (node.Data.CompareTo(data) > 0)
            {
                //Left
                if (node.Left == null)
                    node.Left = new TreeNode(data);
                else
                    InternalAdd(data, node.Left);
            }
            else
            {
                // Right
                if (node.Right == null)
                    node.Right = new TreeNode(data);
                else
                    InternalAdd(data, node.Right);
            }
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public bool Contains(IComparable data)
        {
            return ContainsInternal(data, Root);
            
        }

        private bool ContainsInternal(IComparable data, TreeNode root)
        {
            var compareResult = root.Data.CompareTo(data);
            if (compareResult == 0)
                return true;
            else if(compareResult > 0)
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

        //public ICloneable[]ToArray()
        //{
            
        //}
    }
}
