namespace ListTask
{
    internal class ListItem<T>
    {
        public ListItem<T> Next { get; set; }

        public T Data { get; set; }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Next = next;
            Data = data;
        }
    }
}