using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    internal class ListItem<T>
    {
        private T data;

        private ListItem<T> next;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public ListItem<T> Next
        {
            get { return Next; }
            set { Next = value; }
        }

        public ListItem()
        {
            next = null;
        }

        public ListItem(T data)
        {
            this.data = data;
            next = null;
        }

        public ListItem(T data, ListItem<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
