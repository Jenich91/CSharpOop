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
            Count = 1;
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

                Console.WriteLine("Cтарое значение по индексу " + index + ": " + currentItem.Data);

                currentItem.Data = value;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
            }

            if (index == 0)
            {
                RemoveFirst();
                Count--;
                return;
            }

            Item<T> currentItem = Head;

            for (int i = 0; i < index; i++)
            {
                currentItem = currentItem.Next;
            }

            Console.WriteLine("Значение удаленного элемента по индексу " + index + ": " + currentItem.Data);
        }

        public void InsertFirst(T data)
        {
            var newitem = new Item<T>(data, Head);
            Head = newitem;

            Count++;
        }

        public void Insert(T data, int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
            }

            if (index == 0)
            {
                InsertFirst(data);
            }

            int indexCount = 0;
            for (Item<T> item = Head; indexCount < index; item = item.Next, indexCount++)
            {
                var newItem = new Item<T>(data, item.Next);
                item.Next = newItem;

                Count++;
            }
        }



        public T RemoveFirst()
        {
            T oldValue = Head.Data;

            Head = Head.Next;

            Count--;

            return oldValue;
        }

        public bool RemoveByValue(T data)
        {
            int indexCount = 0;
            for (Item<T> item = Head; item != null; item = item.Next, indexCount++)
            {
                if (item.Data.Equals(data))
                {
                    Remove(indexCount);
                    Count--;
                    return true;
                }
            }

            return false;
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