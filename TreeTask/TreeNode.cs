namespace TreeTask
{
    internal class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public T Data { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }
    }
}
