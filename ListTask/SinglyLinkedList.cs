using System;
using System.Text;

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

        public SinglyLinkedList(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data);
            Head = listItem;
            Count = 1;
        }

        public SinglyLinkedList(SinglyLinkedList<T> list)
        {
            Count = list.Count;

            ListItem<T> prevItemCopy = default;

            int i = 0;

            for (ListItem<T> curr = list.Head; curr != null; curr = curr.Next, i++)
            {
                ListItem<T> itemCopy = new ListItem<T>(curr.Data);

                if (i == 0)
                {
                    Head = itemCopy;
                }
                else
                {
                    prevItemCopy.Next = itemCopy;
                }

                prevItemCopy = itemCopy;
            }
        }

        /// <summary>
        /// Gets number of list items 
        /// </summary>        
        public int GetCount()
        {
            return Count;
        }

        /// <summary>
        /// Gets a value of Data autoproperty of first list item 
        /// </summary>        
        public T GetFirstItem()
        {
            return GetItem(0);
        }

        /// <summary>
        /// Gets a value of Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// </summary>        
        public T GetItem(int itemIndex)
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

            for (ListItem<T> curr = Head; curr != null; curr = curr.Next, i++)
            {
                if (i == itemIndex)
                {
                    return curr.Data;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets a value into Data autoproperty of list item addressed by item index = [0 ... Count - 1]
        /// Returns previous Data autoproperty value
        /// </summary>        
        public T SetItem(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Item index = {index}, but it must be >= 0", nameof(index));
            }

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not set any item");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be in range [0; {Count - 1}]");
            }

            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "Data must not be null");
            }

            int i = 0;

            for (ListItem<T> curr = Head; curr != null; curr = curr.Next, i++)
            {
                if (i == index)
                {
                    T tempData = curr.Data;
                    curr.Data = data;
                    return tempData;
                }
            }

            return default;
        }

        /// <summary>
        /// Adds a list item in beginning of a list
        /// </summary>        
        public void InsertFirstItem(T data)
        {
            InsertItem(0, data);
        }

        /// <summary>
        /// Adds a new list item addressed by index = [0 ... Count - 1]
        /// Previous item at given index and all other items with greater indexes are shifted right
        /// </summary>        
        public void InsertItem(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Item index = {index}, but it must be >= 0", nameof(index));
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be in range [0; {Count}]");
            }

            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "Data must not be null");
            }

            if (Count == 0 || index == 0)
            {
                ListItem<T> firstItem = new ListItem<T>(data, Head);
                Head = firstItem;
                Count++;
                return;
            }

            int i = 0;

            for (ListItem<T> curr = Head, prev = null; curr != null; prev = curr, curr = curr.Next, i++)
            {
                if (i == index)
                {
                    ListItem<T> listItem = new ListItem<T>(data, curr);
                    prev.Next = listItem;
                    Count++;
                    return;
                }

                if (i == Count - 1)
                {
                    ListItem<T> listItem = new ListItem<T>(data, null);
                    curr.Next = listItem;
                    Count++;
                    return;
                }
            }
        }

        /// <summary>
        /// Deletes first item of list
        /// Returns deleted item Data autoproperty value
        /// </summary>        
        public T DeleteFirstItem()
        {
            return DeleteItem(0);
        }

        /// <summary>
        /// Deletes an item of list addressed by item index = [0 ... Count - 1]
        /// Returns deleted item Data autoproperty value
        /// </summary>        
        public T DeleteItem(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Item index = {index}, but it must be >= 0", nameof(index));
            }

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not delete any item");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be in range [0; {Count - 1}]");
            }

            int i = 0;

            for (ListItem<T> curr = Head, prev = null; curr != null; prev = curr, curr = curr.Next, i++)
            {
                if (index == 0)
                {
                    Head = curr.Next;
                    Count--;
                    return curr.Data;
                }

                if (i == Count - 1)
                {
                    prev.Next = null;
                    Count--;
                    return curr.Data;
                }

                if (i == index)
                {
                    prev.Next = curr.Next;
                    Count--;
                    return curr.Data;
                }
            }

            return default;
        }

        /// <summary>
        /// Deletes first sutable item of list if its Data value equals to given value
        /// Returns true if an item has been deleted
        /// </summary>        
        public bool DeleteItemByData(T data)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty. Can not delete any item");
            }

            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "Data must not be null");
            }

            int i = 0;

            for (ListItem<T> curr = Head, prev = null; curr != null; prev = curr, curr = curr.Next, i++)
            {
                if (curr.Data.Equals(data))
                {
                    if (i == 0)
                    {
                        Head = curr.Next;
                    }
                    else if (i == Count - 1)
                    {
                        prev.Next = null;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                    }

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

            for (ListItem<T> curr = Head, prev = null, next;
                curr != null;
                prev = curr, curr = next, i++)
            {
                next = curr.Next;
                curr.Next = prev;

                if (i == Count - 1)
                {
                    Head = curr;
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
            sb.Append($"Count = {Count}, items = [");

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
    }
}