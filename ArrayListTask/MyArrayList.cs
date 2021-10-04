using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListTask
{
    public class MyArrayList<T> : IList<T>
    {
        private T[] items = new T[10];

        public int Count { get; private set; }

        private int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value > 0)
                {
                    capacity = value;
                }
            }
        }

        public bool IsReadOnly { get; }

        public MyArrayList()
        {
        }

        public MyArrayList(int capacity)
        {
            Capacity = capacity;

            if (capacity >= items.Length)
            {
                IncreaseCapacity();
            }
        }

        public T this[int index]
        {
            get
            {
                IsIndexInRange(index);

                return items[index];
            }

            set
            {
                IsIndexInRange(index);

                items[index] = value;
            }
        }

        public void TrimExcess()
        {
            if (Count < (items.Length * 0.9))
            {
                T[] old = items;
                items = new T[Count];
                Array.Copy(old, items, Count);
                Capacity = items.Length;
            }
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            Count++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        private bool IsIndexInRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс вне границ массива");
            }

            return true;
        }

        private static bool IsArrayNotNull(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Массив имеет значение null");
            }

            return true;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var element in items)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            IsArrayNotNull(items);

            IsIndexInRange(arrayIndex);

            if (Count - arrayIndex > array.Length)
            {
                throw new ArgumentException("Число элементов в исходном массиве больше числа элементов, которые может содержать массив назначения");
            }

            for (int i = 0; i < Count; i++)
            {
                array[i] = items[i];
            }
        }

        public void RemoveAt(int index)
        {
            IsIndexInRange(index);

            if (index < Count)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            --Count;
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                for (int i = IndexOf(item); i < Count; i++)
                {
                    items[i] = items[i + 1];
                }

                --Count;

                return true;
            }

            return false;
        }

        public void Insert(int index, T item)
        {
            IsIndexInRange(index);

            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            Count++;

            Array.Copy(items, index, items, index + 1, Count);
            items[index] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}