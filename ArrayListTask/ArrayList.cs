using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private const int InitialCapacity = 4;

        private T[] items;

        private int capacity;

        private int count;

        private int modificationsCount;

        public T this[int index]
        {
            get
            {
                if (count == 0)
                {
                    throw new InvalidOperationException("List is empty. It is impossible to refer a value");
                }

                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {count}");
                }

                return items[index];
            }

            set
            {
                if (count == 0)
                {
                    throw new InvalidOperationException("List is empty. It is impossible to refer a value");
                }

                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {count}");
                }

                if (IsReadOnly)
                {
                    throw new InvalidOperationException("List is read only. It is impossible to make changes");
                }

                items[index] = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }

            set
            {
                if (IsReadOnly)
                {
                    throw new InvalidOperationException("List is read only. It is impossible to make changes");
                }

                if (value < count)
                {
                    throw new ArgumentException($"Capacity must be >= Count ({count})", nameof(value));
                }

                if (value != capacity)
                {
                    Array.Resize(ref items, value);
                }

                capacity = value;
            }
        }

        int ICollection<T>.Count
        {
            get { return count; }
        }

        public bool IsReadOnly { get; set; }

        public ArrayList()
        {
            items = new T[0];
        }

        public ArrayList(T item)
        {
            items = new T[InitialCapacity];
            capacity = InitialCapacity;
            items[0] = item;
            count = 1;
        }

        public ArrayList(int capacity)
        {
            items = new T[capacity];
            this.capacity = capacity;
        }

        public void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("List is read only. It is impossible to make changes");
            }

            if (count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[count] = item;
            count++;
            modificationsCount++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("List is read only. It is impossible to make changes");
            }

            for (int i = 0; i < count; i++)
            {
                items[i] = default;
            }

            count = 0;
            modificationsCount++;
        }

        public bool Contains(T item)
        {
            foreach (T e in items)
            {
                if (e.Equals(item))
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
                throw new ArgumentException($"Destination array is too short to place {count} list item(s). It must be {count + arrayIndex} element(s) length.", nameof(array) + ", " + nameof(arrayIndex));
            }

            Array.Copy(items, 0, array, arrayIndex, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modificationsCountCopy = modificationsCount;

            for (int i = 0; i < count; i++)
            {
                if (modificationsCountCopy != modificationsCount)
                {
                    throw new InvalidOperationException("Item(s) were added/deleted to/from a list during iteration");
                }

                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            if (count == 0)
            {
                return -1;
            }

            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("List is read only. It is impossible to make changes");
            }

            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and <= {count}");
            }

            if (count >= items.Length)
            {
                IncreaseCapacity();
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;

            count++;
            modificationsCount++;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("List is read only. It is impossible to make changes");
            }

            if (count == 0)
            {
                return false;
            }

            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("List is read only. It is impossible to make changes");
            }

            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Item index = {index}, but it must be >= 0 and < {count}");
            }

            for (int i = index; i < count; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = default;
            count--;
            modificationsCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            double listFillingLevel = 0.9;

            if (count < listFillingLevel * items.Length)
            {
                for (int i = count; i < items.Length; i++)
                {
                    items[i] = default;
                }

                capacity = count;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("items = [");

            if (count == 0)
            {
                sb.Append("  ");
            }

            for (int i = 0; i < count; i++)
            {
                sb.Append(items[i]).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            sb.Append(", capacity = ").Append(capacity);
            sb.Append(", count = ").Append(count);
            sb.Append(", IsReadOnly = ").Append(IsReadOnly);
            return sb.ToString();
        }

        private void IncreaseCapacity()
        {
            int increasedLength = items.Length == 0 ? InitialCapacity : items.Length * 2;

            Array.Resize(ref items, increasedLength);
            capacity = increasedLength;
        }
    }
}