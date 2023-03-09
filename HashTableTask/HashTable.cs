using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using ArrayListTask;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private const int DefaultHashTableLength = 5;

        private readonly ArrayList<T>[] lists;

        private int modificationsCount;

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public HashTable()
        {
            lists = new ArrayList<T>[DefaultHashTableLength];
        }

        public HashTable(int hashTableLength)
        {
            if (hashTableLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hashTableLength), $"Hashtable length = {hashTableLength}, but it must be > 0");
            }

            lists = new ArrayList<T>[hashTableLength];
        }

        public void Add(T item)
        {
            int index = GetIndexViaHashCode(item);

            if (lists[index] is null)
            {
                lists[index] = new ArrayList<T>(new[] { item });
            }
            else
            {
                lists[index].Add(item);
            }

            Count++;
            modificationsCount++;
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(lists, 0, lists.Length);

            Count = 0;
            modificationsCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndexViaHashCode(item);

            if (lists[index] is null)
            {
                return false;
            }

            return lists[index].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array must not be null");
            }

            if (Count > array.Length)
            {

                throw new ArgumentException($"Array length = {array.Length}. It must be >= {Count}", nameof(array));
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(array) + ", " + nameof(arrayIndex), $"Incorrect index. It is impossible to copy {Count} list item(s) to an array starting from index {arrayIndex}.");
            }

            int previousListsLength = 0;

            foreach (ArrayList<T> list in lists)
            {
                if (list is null)
                {
                    continue;
                }

                list.CopyTo(array, arrayIndex + previousListsLength);
                previousListsLength += list.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modificationsCountInitialValue = modificationsCount;

            foreach (ArrayList<T> list in lists)
            {
                if (list is null)
                {
                    continue;
                }

                foreach (T item in list)
                {
                    if (modificationsCountInitialValue != modificationsCount)
                    {
                        throw new InvalidOperationException("Item(s) were added/deleted to/from a hashtable during iteration");
                    }

                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            int index = GetIndexViaHashCode(item);

            if (lists[index] is null)
            {
                return false;
            }

            if (lists[index].Remove(item))
            {
                Count--;
                modificationsCount++;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("hashTableLength = ").Append(lists.Length);
            sb.Append(", count = ").Append(Count);
            sb.Append(", isReadOnly = ").Append(IsReadOnly).Append(Environment.NewLine);

            for (int i = 0; i < lists.Length; i++)
            {
                sb.Append($"{i,3}").Append(": [");
                sb.Append(lists[i] is null ? "<null>" : lists[i]).Append(']').Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private int GetIndexViaHashCode(T item)
        {
            int itemHashCode = item is null ? 0 : item.GetHashCode();

            return Math.Abs(itemHashCode % lists.Length);
        }
    }
}
