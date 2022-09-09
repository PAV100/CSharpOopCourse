namespace ListTask
{
    internal class ListItem<T>
    {
        public ListItem<T> Next { get; set; }

        public T Data { get; set; }

        public ListItem()
        {
            Next = default;
            Data = default;
        }

        public ListItem(T data)
        {
            Next = default;
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}