﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListTask
{
    public class MyArrayList<T> : IList<T>
    {
        private T[] items = new T[10];
        private int length;

        public int Count
        {
            get
            {
                return length;
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

        public void Add(T obj)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = obj;
            length++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        private bool IsIndexInRange(int index)
        {
            if (index < 0 || index > length - 1)
            {
                throw new IndexOutOfRangeException("index меньше нижней границы массива");
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
            for (int i = 0; i < length - 1; i++)
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
            throw new NotImplementedException();
        }

        public void Clear()
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                items[i] = default;
            }
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
            IsArrayNotNull(array);

            IsIndexInRange(arrayIndex);

            if (length - arrayIndex > array.Length)
            {
                throw new ArgumentException("Число элементов в исходном массиве больше числа элементов, которые может содержать массив назначения");
            }

            Array.Copy(items, array, arrayIndex);
        }

        public void RemoveAt(int index)
        {
            IsIndexInRange(index);

            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            --length;
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                int indexDeletedItem = IndexOf(item);

                for (int i = indexDeletedItem; i < items.Length - 1; i++)
                {
                    items[i] = items[++i];
                }

                --length;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length - 1; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly => throw new NotImplementedException();
    }
}