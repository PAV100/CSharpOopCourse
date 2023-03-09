using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private const double listFillingLevel = 0.9;

        private T[] items;

        private int modificationsCount;


        public T this[int index]
        {
            get
            {
                CheckIndexForIndexer(index);
                return items[index];
            }

            set
            {
                CheckIndexForIndexer(index);
                items[index] = value;
            }
        }

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Capacity must be >= Count ({Count})", nameof(value));
                }

                if (value != items.Length)
                {
                    Array.Resize(ref items, value);
                }
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public ArrayList()
        {
            items = new T[DefaultCapacity];
        }

        [Obsolete]
        public ArrayList(T item)
        {
            items = new T[DefaultCapacity];
            items[0] = item;
            Count = 1;
        }

        public ArrayList(ICollection<T> items)
        {
            this.items = new T[items.Count];

            foreach (T e in items)
            {
                this.items[Count] = e;
                Count++;
            }
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {

                throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity = {capacity}, but it must be >= 0");
            }

            items = new T[capacity];
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(items);

            Count = 0;
            modificationsCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
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

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modificationsCountInitialValue = modificationsCount;

            for (int i = 0; i < Count; i++)
            {
                if (modificationsCountInitialValue != modificationsCount)
                {
                    throw new InvalidOperationException("Item(s) were added/deleted to/from a list during iteration");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and <= {Count}");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;

            Count++;
            modificationsCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index);
            }

            Count--;
            items[Count] = default;
            modificationsCount++;
        }

        public void TrimExcess()
        {
            if (Count < listFillingLevel * items.Length)
            {
                Array.Resize(ref items, Count);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            if (Count == 0)
            {
                sb.Append("  ");
            }

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i]).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            //sb.Append(", capacity = ").Append(items.Length);
            //sb.Append(", count = ").Append(Count);
            //sb.Append(", IsReadOnly = ").Append(IsReadOnly);
            return sb.ToString();
        }

        private void IncreaseCapacity()
        {
            int increasedLength = items.Length == 0 ? DefaultCapacity : items.Length * 2;
            Capacity = increasedLength;
        }

        private void CheckIndexForIndexer(int index)
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Incorrect item index. It is impossible to indexate empty list");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }
        }
    }
}