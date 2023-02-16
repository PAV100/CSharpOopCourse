using System;
using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(T data)
        {
            head = new ListItem<T>(data);
            Count = 1;
        }

        public SinglyLinkedList(SinglyLinkedList<T> list)
        {
            Count = list.Count;

            if (Count == 0)
            {
                return;
            }

            head = new ListItem<T>(list.head.Data);

            ListItem<T> previousItemCopy = head;

            for (ListItem<T> currentItem = list.head.Next; currentItem != null; currentItem = currentItem.Next)
            {
                previousItemCopy.Next = new ListItem<T>(currentItem.Data);
                previousItemCopy = previousItemCopy.Next;
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

            return head.Data;
        }

        /// <summary>
        /// Gets a value of Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// </summary>        
        public T Get(int index)
        {
            if (IsIndexLtZeroOrGeCount(index))
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
            if (IsIndexLtZeroOrGeCount(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            ListItem<T> currentItem = GetItem(index);

            T previousData = currentItem.Data;
            currentItem.Data = data;

            return previousData;
        }

        /// <summary>
        /// Adds a list item in beginning of a list
        /// </summary>        
        public void InsertFirst(T data)
        {
            head = new ListItem<T>(data, head);
            Count++;
        }

        /// <summary>
        /// Adds a new list item addressed by index = [0 ... Count - 1]
        /// Previous item at given index and all other items with greater indexes are shifted right
        /// </summary>        
        public void Insert(int index, T data)
        {
            if (IsIndexLtZeroOrGtCount(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and <= {Count}");
            }

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            ListItem<T> previousItem = GetItem(index - 1);
            previousItem.Next = new ListItem<T>(data, previousItem.Next);
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

            T deletedData = head.Data;
            head = head.Next;
            Count--;
            return deletedData;
        }

        /// <summary>
        /// Deletes an item of list addressed by item index = [0 ... Count - 1]
        /// Returns deleted item Data autoproperty value
        /// </summary>        
        public T Delete(int index)
        {
            if (IsIndexLtZeroOrGeCount(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            if (index == 0)
            {
                return DeleteFirst();
            }

            ListItem<T> previousItem = GetItem(index - 1);
            T deletedData = previousItem.Next.Data;
            previousItem.Next = previousItem.Next.Next;
            Count--;
            return deletedData;
        }

        /// <summary>
        /// Deletes first suitable item of list if its Data value equals to given value
        /// Returns true if an item has been deleted
        /// </summary>        
        public bool DeleteByData(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            if (head.Data is null && data is null || head.Data is not null && head.Data.Equals(data))
            {
                head = head.Next;
                Count--;
                return true;
            }

            for (ListItem<T> previousItem = head; previousItem.Next != null; previousItem = previousItem.Next)
            {
                if (previousItem.Next.Data is null && data is null || previousItem.Next.Data is not null && previousItem.Next.Data.Equals(data))
                {
                    previousItem.Next = previousItem.Next.Next;
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

            for (ListItem<T> currentItem = head, previous = null, next;
                currentItem != null;
                previous = currentItem, currentItem = next, i++)
            {
                next = currentItem.Next;
                currentItem.Next = previous;

                if (i == Count - 1)
                {
                    head = currentItem;
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
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();
                        
            sb.Append("[");
            
            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                sb.Append(p.Data is null ? "<null>" : p.Data).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            sb.Append($" Count = {Count}");

            return sb.ToString();
        }

        private ListItem<T> GetItem(int index)
        {
            int i = 0;

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next, i++)
            {
                if (i == index)
                {
                    return currentItem;
                }
            }

            return null;
        }

        private bool IsIndexLtZeroOrGeCount(int index)
        {
            return index < 0 || index >= Count;
        }

        private bool IsIndexLtZeroOrGtCount(int index)
        {
            return index < 0 || index > Count;
        }
    }
}