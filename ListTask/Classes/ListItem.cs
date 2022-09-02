using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    internal class ListItem<T>
    {
        public ListItem<T> Next { get; set; }

        public T Data { get; set; }

        public ListItem()
        {
            Next = null;
            Data = default;
        }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}