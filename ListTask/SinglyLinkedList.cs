using System;
using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        public ListItem<T> Head { get; private set; }

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(T data)
        {
            Head = new ListItem<T>(data);
            Count = 1;
        }

        public SinglyLinkedList(SinglyLinkedList<T> list)
        {
            Count = list.Count;

            if (Count == 0)
            {
                return;
            }

            Head = new ListItem<T>(list.Head.Data);

            ListItem<T> previousItemCopy = Head;

            int i = 0;

            for (ListItem<T> current = list.Head.Next; current != null; current = current.Next, i++)
            {
                ListItem<T> itemCopy = new ListItem<T>(current.Data);

                previousItemCopy.Next = itemCopy;
                previousItemCopy = itemCopy;
            }
        }

        /// <summary>
        /// Gets a value of Data autoproperty of first list item 
        /// </summary>        
        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not get an item");
            }

            return Get(0);
        }

        /// <summary>
        /// Gets a value of Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// </summary>        
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            return GetItem(index).Data;
        }

        /// <summary>
        /// Sets a value into Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// Returns previous Data autoproperty value
        /// </summary>        
        public T Set(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            ListItem<T> current = GetItem(index);

            T tempData = current.Data;
            current.Data = data;

            return tempData;
        }

        /// <summary>
        /// Adds a list item in beginning of a list
        /// </summary>        
        public void InsertFirst(T data)
        {
            Insert(0, data);
        }

        /// <summary>
        /// Adds a new list item addressed by index = [0 ... Count - 1]
        /// Previous item at given index and all other items with greater indexes are shifted right
        /// </summary>        
        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and <= {Count}");
            }

            if (index == 0)
            {
                Head = new ListItem<T>(data, Head);
            }
            else
            {
                ListItem<T> previousItem = GetItem(index - 1);
                previousItem.Next = new ListItem<T>(data, previousItem.Next);
            }

            Count++;
        }

        /// <summary>
        /// Deletes first item of list
        /// Returns deleted item Data autoproperty value
        /// </summary>        
        public T DeleteFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not delete an item");
            }

            return Delete(0);
        }

        /// <summary>
        /// Deletes an item of list addressed by item index = [0 ... Count - 1]
        /// Returns deleted item Data autoproperty value
        /// </summary>        
        public T Delete(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            T deletedData;

            if (index == 0)
            {
                deletedData = Head.Data;
                Head = Head.Next;
            }
            else
            {
                ListItem<T> previousItem = GetItem(index - 1);
                deletedData = previousItem.Next.Data;
                previousItem.Next = previousItem.Next.Next;
            }

            Count--;
            return deletedData;
        }

        /// <summary>
        /// Deletes first sutable item of list if its Data value equals to given value
        /// Returns true if an item has been deleted
        /// </summary>        
        public bool DeleteByData(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            for (ListItem<T> previous = Head; previous.Next != null; previous = previous.Next)
            {
                if (previous.Next.Data.Equals(data))
                {
                    previous.Next = previous.Next.Next;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Reverses list
        /// </summary>        
        public SinglyLinkedList<T> Reverse()
        {
            if (Count < 2)
            {
                return this;
            }

            int i = 0;

            for (ListItem<T> current = Head, previous = null, next;
                current != null;
                previous = current, current = next, i++)
            {
                next = current.Next;
                current.Next = previous;

                if (i == Count - 1)
                {
                    Head = current;
                }
            }

            return this;
        }

        /// <summary>
        /// Creates new list and copies Data to it
        /// </summary>        
        public SinglyLinkedList<T> Copy()
        {
            return new SinglyLinkedList<T>(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append($"Head = {Head}, ");
            //sb.Append($"Count = {Count}, items = [");
            sb.Append("items = [");

            if (Count == 0)
            {
                sb.Append("  ");
            }

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                sb.Append(p.Data).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }

        private ListItem<T> GetItem(int index)
        {
            int i = 0;

            for (ListItem<T> current = Head; current != null; current = current.Next, i++)
            {
                if (i == index)
                {
                    return current;
                }
            }

            return null;
        }
    }
}