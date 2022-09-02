using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        public ListItem<T> Head { get; set; }

        public int Count { get; set; }

        public SinglyLinkedList()
        {
            Head = default;
            Count = default;
        }

        public SinglyLinkedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Capacity = {capacity}, but it must be >= 0", nameof(capacity));
            }

            ListItem<T> pp = default;

            for (int i = 0; i < capacity; i++)
            {
                ListItem<T> p = new ListItem<T>();
                Head = p;
                Count++;
                                
            }

            Head = default;
            Count = default;
        }

        /// <summary>
        /// Gets a value of first list item Data autoproperty
        /// </summary>        
        public T GetFirst()
        {
            return Head.Data;
        }

        /// <summary>
        /// Gets a value of Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// </summary>        
        public T Get(int itemIndex)
        {
            if (itemIndex < 0)
            {
                throw new ArgumentException($"Item index = {itemIndex}, but it must be >= 0", nameof(itemIndex));
            }

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not get any item");
            }

            if (itemIndex >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(itemIndex), $"Item index = {itemIndex}, but it must be in range [0; {Count - 1}]");
            }

            int i = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next, i++)
            {
                if (i == itemIndex)
                {
                    return p.Data;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets a value into Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// Returns previous Data autoproperty value
        /// </summary>        
        public T Set(int itemIndex, T value)
        {
            if (itemIndex < 0)
            {
                throw new ArgumentException($"Item index = {itemIndex}, but it must be >= 0", nameof(itemIndex));
            }

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not set any item");
            }

            if (itemIndex >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(itemIndex), $"Item index = {itemIndex}, but it must be in range [0; {Count - 1}]");
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value), "Value must not be null");
            }

            int i = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next, i++)
            {
                if (i == itemIndex)
                {
                    T tempData = p.Data;
                    p.Data = value;
                    return tempData;
                }
            }

            return default;
        }


        public void AddFirst(T item)
        {
            ListItem<T> p = new ListItem<T>(item, Head);
            Head = p;
            Count++;
        }
    }
}