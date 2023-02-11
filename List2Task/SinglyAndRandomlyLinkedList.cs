using System;
using System.Text;

namespace List2Task
{
    internal class SinglyAndRandomlyLinkedList<T>
    {
        public List2Item<T> Head { get; private set; }

        public int Count { get; private set; }

        public SinglyAndRandomlyLinkedList()
        {
        }

        public SinglyAndRandomlyLinkedList(T data)
        {
            Head = new List2Item<T>(data);
            Count = 1;
        }

        public SinglyAndRandomlyLinkedList(SinglyAndRandomlyLinkedList<T> list)
        {
            Count = list.Count;

            if (Count == 0)
            {
                return;
            }

            for (List2Item<T> current = list.Head; current != null; current = current.Next.Next)
            {
                List2Item<T> currentCopy = new List2Item<T>(current.Data, current.Next, current.Random);
                current.Next = currentCopy;
            }

            Head = list.Head.Next;

            for (List2Item<T> current = list.Head; current != null; current = current.Next.Next)
            {
                if (current.Next.Random is not null)
                {
                    current.Next.Random = current.Random.Next;
                }                
            }

            for (List2Item<T> current = list.Head, currentCopy = Head;
            currentCopy != null;
            current = current.Next, currentCopy = currentCopy.Next)
            {
                if (currentCopy.Next is null)
                {
                    current.Next = null;
                    break;
                }

                current.Next = current.Next.Next;
                currentCopy.Next = currentCopy.Next.Next;
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

            List2Item<T> current = GetItem(index);

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
                Head = new List2Item<T>(data, Head);
            }
            else
            {
                List2Item<T> previousItem = GetItem(index - 1);
                previousItem.Next = new List2Item<T>(data, previousItem.Next);
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
                List2Item<T> previousItem = GetItem(index - 1);
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

            for (List2Item<T> previous = Head; previous.Next != null; previous = previous.Next)
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
        public SinglyAndRandomlyLinkedList<T> Reverse()
        {
            if (Count < 2)
            {
                return this;
            }

            int i = 0;

            for (List2Item<T> current = Head, previous = null, next;
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
        public SinglyAndRandomlyLinkedList<T> Copy()
        {
            return new SinglyAndRandomlyLinkedList<T>(this);
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

            for (List2Item<T> p = Head; p != null; p = p.Next)
            {
                sb.Append(p.Data).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }

        public static void RegenerateRandomReferences(SinglyAndRandomlyLinkedList<T> list)
        {
            if (list.Count == 0)
            {
                return;
            }

            ItemReferences[] itemsReferences = new ItemReferences[list.Count + 1];

            int i = 1;

            for (List2Item<T> current = list.Head; current != null; current = current.Next, i++)
            {
                itemsReferences[i].currentItemNumber = i;
                itemsReferences[i].currentItem = current;
            }

            Random randomNumberGenerator = new Random();

            for (List2Item<T> current = list.Head; current != null; current = current.Next)
            {
                int randomNumber = randomNumberGenerator.Next(0, list.Count + 1);
                current.Random = itemsReferences[randomNumber].currentItem;
            }
        }

        public static void Print(SinglyAndRandomlyLinkedList<T> list)
        {
            ItemReferences[] itemsReferences = GetListStructure(list);

            Console.WriteLine("Detailed references and data structure of a list: {0}", list.ToString());
            Console.WriteLine("   Item number                                    Item hash");
            Console.WriteLine("Curr  Next  Rand                 Data    Current       Next     Random");

            foreach (ItemReferences e in itemsReferences)
            {
                Console.WriteLine("{0,4} {1,5} {2,5} {3,20} {4,10} {5,10} {6,10}", e.currentItemNumber, e.nextItemNumber, e.randomItemNumber, e.currentItem is null ? "" : e.currentItem.Data,
                    e.currentItem is null ? "null" : e.currentItem.GetHashCode(), e.nextItem is null ? "null" : e.nextItem.GetHashCode(), e.randomItem is null ? "null" : e.randomItem.GetHashCode());
            }
        }

        private List2Item<T> GetItem(int index)
        {
            int i = 0;

            for (List2Item<T> current = Head; current != null; current = current.Next, i++)
            {
                if (i == index)
                {
                    return current;
                }
            }

            return null;
        }

        public struct ItemReferences
        {
            public int currentItemNumber;
            public int nextItemNumber;
            public int randomItemNumber;
            public List2Item<T> currentItem;
            public List2Item<T> nextItem;
            public List2Item<T> randomItem;
        }

        private static ItemReferences[] GetListStructure(SinglyAndRandomlyLinkedList<T> list)
        {
            ItemReferences[] itemsReferences = new ItemReferences[list.Count + 1];

            itemsReferences[0].nextItemNumber = list.Head is null ? 0 : 1;
            itemsReferences[0].nextItem = list.Head;

            int i = 1;

            for (List2Item<T> current = list.Head; current != null; current = current.Next, i++)
            {
                itemsReferences[i].currentItemNumber = i;
                itemsReferences[i].nextItemNumber = current.Next is null ? 0 : i + 1;

                itemsReferences[i].currentItem = current;
                itemsReferences[i].nextItem = current.Next;
                itemsReferences[i].randomItem = current.Random;
            }

            for (i = 1; i <= list.Count; i++)
            {
                for (int j = 1; j <= list.Count; j++)
                {
                    if (itemsReferences[j].currentItem.Equals(itemsReferences[i].randomItem))
                    {
                        itemsReferences[i].randomItemNumber = j;
                        break;
                    }
                }
            }

            return itemsReferences;
        }
    }
}
