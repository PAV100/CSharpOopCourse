using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public ListItem<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        //public SinglyLinkedList<T>();
    }
}
