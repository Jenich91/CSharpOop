using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTask
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Item<T> Head { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Count++;
        }

        public int GetListSize()
        {
            return Count;
        }

        public T GetFirstValue()
        {
            return Head.Data;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
                }

                Item<T> currentItem = Head;

                for (int i = 0; i < index; i++)
                {
                    if (currentItem.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    currentItem = currentItem.Next;
                }

                return currentItem.Data;
            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
                }

                Item<T> currentItem = Head;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.Next;
                }

                SetReturn(index, currentItem);

                currentItem.Data = value;
            }
        }

        private static T SetReturn(int index, Item<T> currentItem)
        {
            return currentItem.Data;
        }

        public T Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
            }

            if (index == 0)
            {
                return RemoveFirst();

            }
            else
            {
                Item<T> currentItem = Head, previosItem = null;
                T oldValue = default;

                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        previosItem.Next = currentItem.Next;
                        oldValue = currentItem.Data;

                        Count--;
                    }

                    if (currentItem != null)
                    {
                        previosItem = currentItem; // сдвиг позиции
                        currentItem = currentItem.Next;
                    }
                }

                return oldValue;
            }

        }

        public void InsertFirst(T data)
        {
            var newitem = new Item<T>(data, Head);
            Head = newitem;

            Count++;
        }

        public void Insert(T data, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
            }

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            Item<T> currentItem = Head, previosItem = null;
            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    var newItem = new Item<T>(data, previosItem.Next); // вставка, установка ссылок
                    previosItem.Next = newItem;

                    Count++;
                    return;
                }

                if (currentItem != null)
                {
                    previosItem = currentItem; // сдвиг позиции
                    currentItem = currentItem.Next;
                }
            }
        }

        public bool RemoveByValue(T data)
        {
            int indexCount = 0;
            for (Item<T> item = Head; item != null; item = item.Next, indexCount++)
            {
                if (item.Data.Equals(data))
                {
                    Remove(indexCount);
                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()
        {
            T oldValue = Head.Data;
            Head = Head.Next;
            Count--;

            return oldValue;
        }

        public void Reverse()
        {
            Item<T> previous = null;
            Item<T> current = Head;

            while (current != null)
            {
                Item<T> next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }

            Head = previous;
        }

        public void CopyTo(LinkedList<T> anotherList)
        {
            if (anotherList == null)
            {
                throw new ArgumentNullException("Аргумент " + nameof(anotherList) + " имеет значение null");
            }

            for (Item<T> item = Head; item != null; item = item.Next)
            {
                anotherList.Insert(item.Data, anotherList.Count);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}