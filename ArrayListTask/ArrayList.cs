using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private const double ListFillingLevel = 0.9;

        private T[] items;

        private int modificationsCount;

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }

            set
            {
                CheckIndex(index);
                items[index] = value;
                modificationsCount++;
            }
        }

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Given capacity = {value}, but it must be >= Count ({Count})", nameof(value));
                }

                if (value != items.Length)
                {
                    Array.Resize(ref items, value);
                }
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public ArrayList()
        {
            items = new T[DefaultCapacity];
        }

        public ArrayList(ICollection<T> collection)
        {
            items = new T[collection.Count];

            int i = 0;

            foreach (T e in collection)
            {
                items[i] = e;
                i++;
            }

            Count = collection.Count;
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

            Array.Clear(items, 0, Count);

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

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"ArrayIndex = {arrayIndex}, but it must be >= 0.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException($"{array.Length - arrayIndex} array item(s) available starting from index {arrayIndex}, but there must be at least {Count}.");
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModificationsCount = modificationsCount;

            for (int i = 0; i < Count; i++)
            {
                if (initialModificationsCount != modificationsCount)
                {
                    throw new InvalidOperationException("Item(s) were modified/added/deleted in/to/from a list during iteration");
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
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            Count--;
            items[Count] = default;
            modificationsCount++;
        }

        public void TrimExcess()
        {
            if (Count < ListFillingLevel * items.Length)
            {
                Array.Resize(ref items, Count);
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append('[');

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i] is null ? "<null>" : items[i]).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            return sb.ToString();
        }

        private void IncreaseCapacity()
        {
            int increasedLength = items.Length == 0 ? DefaultCapacity : items.Length * 2;
            Capacity = increasedLength;
        }

        private void CheckIndex(int index)
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Incorrect item index. It is impossible to indexate empty list");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {Count}");
            }
        }
    }
}
