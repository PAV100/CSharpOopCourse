namespace List2Task
{
    internal class List2Item<T>
    {
        public List2Item<T> Next { get; set; }

        public List2Item<T> Random { get; set; }

        public T Data { get; set; }

        public List2Item(T data)
        {
            Data = data;
        }

        public List2Item(T data, List2Item<T> next)
        {
            Next = next;
            Data = data;
        }

        public List2Item(T data, List2Item<T> next, List2Item<T> random)
        {
            Next = next;
            Random = random;
            Data = data;
        }
    }
}
