using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArrayListTask;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private const int DefaultHashTableLength = 5;

        private ArrayList<T>[] hashTable;

        private int count;

        private int elementsCount;

        private bool isReadOnly;

        private ArrayList<T> this[int index]
        {
            get { return hashTable[index]; }
            set { hashTable[index] = value; }
        }

        int ICollection<T>.Count
        {
            get { return count; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return isReadOnly; }
        }

        public HashTable()
        {
            hashTable = new ArrayList<T>[DefaultHashTableLength];
            //Array.Fill(hashTable, new ArrayList<T>());
            count = DefaultHashTableLength;
        }

        public HashTable(int hashTableLength)
        {
            hashTable = new ArrayList<T>[hashTableLength];
            //Array.Fill(hashTable, new ArrayList<T>());
            count = hashTableLength;
        }

        private int GetIndexViaHashCode(T item)
        {
            return Math.Abs(item.GetHashCode() % hashTable.Length);
        }

        public void Add(T item)
        {
            int index = GetIndexViaHashCode(item);

            if (hashTable[index] is null)
            {
                hashTable[index] = new();
            }

            hashTable[index].Add(item);
            elementsCount++;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("count = ").Append(count);
            sb.Append(", elementsCount = ").Append(elementsCount);
            sb.Append(", IsReadOnly = ").Append(isReadOnly).Append(Environment.NewLine);

            if (count == 0)
            {
                return "";
            }

            for (int i = 0; i < hashTable.Length; i++)
            {
                sb.Append(i).Append(": [");
                sb.Append((hashTable[i] is null ? "null" : hashTable[i].ToString())).Append("]").Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}