using System;

namespace TreeTask
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> left;

        public TreeNode<T> right;

        public T data;

        public TreeNode(T data)
        {
            this.data = data;
        }

        public TreeNode(TreeNode<T> left, TreeNode<T> right, T data)
        {
            this.left = left;
            this.right = right;
            this.data = data;
        }
    }
}
