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
        private const int MaxHashTableLength = int.MaxValue;

        private ArrayList<T>[] hashTable;

        private int count;

        private int modificationsCount;

        private bool isReadOnly;

        private ArrayList<T> this[int index]
        {
            get { return hashTable[index]; }
            set { hashTable[index] = value; }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }

        public HashTable()
        {
            hashTable = new ArrayList<T>[DefaultHashTableLength];
        }

        public HashTable(int hashTableLength)
        {
            if (hashTableLength <= 0 || hashTableLength > MaxHashTableLength)
            {
                throw new ArgumentOutOfRangeException(nameof(hashTableLength), $"Hashtable length = {hashTableLength}, but it must be > 0 and <= {MaxHashTableLength}");
            }

            hashTable = new ArrayList<T>[hashTableLength];
        }

        public void Add(T item)
        {
            if (isReadOnly)
            {
                throw new InvalidOperationException("Hashtable is read only. It is impossible to make changes");
            }

            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "It is impossible to add null");
            }

            int index = GetIndexViaHashCode(item);

            if (hashTable[index] is null)
            {
                hashTable[index] = new(item);
                count++;
                modificationsCount++;
                return;
            }

            if (!hashTable[index].Contains(item))
            {
                hashTable[index].Add(item);
                count++;
                modificationsCount++;
            }
        }

        public void Clear()
        {
            if (isReadOnly)
            {
                throw new InvalidOperationException("Hashtable is read only. It is impossible to make changes");
            }

            for (int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = default;
            }

            count = 0;
            modificationsCount++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] is null)
                {
                    continue;
                }

                if (hashTable[i].Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (count > array.Length - arrayIndex)
            {
                throw new ArgumentException($"Destination array is too short to place {count} hashtable item(s). It must be {count + arrayIndex} element(s) length.", nameof(array) + ", " + nameof(arrayIndex));
            }

            int previousListsLength = 0;

            foreach (ArrayList<T> e in hashTable)
            {
                if (e is null)
                {
                    continue;
                }

                e.CopyTo(array, arrayIndex + previousListsLength);
                previousListsLength = previousListsLength + e.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modificationsCountCopy = modificationsCount;

            foreach (ArrayList<T> e in hashTable)
            {
                if (e is null)
                {
                    continue;
                }

                if (modificationsCountCopy != modificationsCount)
                {
                    throw new InvalidOperationException("Item(s) were added/deleted to/from a hashtable during iteration");
                }

                IEnumerator<T> listEnumerator = e.GetEnumerator();
                
                while (listEnumerator.MoveNext())
                {
                    yield return listEnumerator.Current;
                }
            }            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (isReadOnly)
            {
                throw new InvalidOperationException("Hashtable is read only. It is impossible to make changes");
            }

            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] is null)
                {
                    continue;
                }

                if (hashTable[i].Contains(item))
                {
                    hashTable[i].Remove(item);
                    count--;
                    modificationsCount++;
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("hashTableLength = ").Append(hashTable.Length);
            sb.Append(", count = ").Append(count);
            sb.Append(", isReadOnly = ").Append(isReadOnly).Append(Environment.NewLine);

            if (hashTable.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < hashTable.Length; i++)
            {
                sb.Append($"{i,3}").Append(": [");
                sb.Append((hashTable[i] is null ? "null" : hashTable[i].ToString())).Append("]").Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private int GetIndexViaHashCode(T item)
        {
            return Math.Abs(item.GetHashCode() % hashTable.Length);
        }
    }
}