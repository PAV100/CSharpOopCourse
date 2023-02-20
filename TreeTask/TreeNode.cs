using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTask
{
    internal class TreeNode<T>
    {
        public TreeNode<T> left;

        public TreeNode<T> right;

        public T data;

        //public bool IsLeaf { get; }

        public TreeNode(T data)
        {
            this.data = data;
            //IsLeaf = true;
        }

        public TreeNode(TreeNode<T> left, TreeNode<T> right, T data)
        {
            this.left = left;
            this.right = right;
            this.data = data;

            //IsLeaf = this.left is null && this.right is null;
        }
    }
}
