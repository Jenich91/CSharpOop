using System;

namespace ListTask
{
    public class SinglyLinkedList
    {
        private ListItem<T> head;
        private int count;

        public SinglyLinkedList()
        {
        }

        public int GetListSize()
        {
            return count;
        }

        public Object GetFirstValue()
        {
            if (count != 0)
            {
                return head.Data;
            }

            return null;
        }

        public Object this[int index]
        {
            get
            {
                if (index < 0 || index > this.count - 1)
                {
                    throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
                }

                ListItem<T> currentItem = head;

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
                if (index < 0 || index > this.count - 1)
                {
                    throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
                }

                ListItem<T> currentItem = head;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Cтарое значение по индексу " + index + ": " + currentItem.Data);

                currentItem.Data = (T)value;
            }
        }

        public void RemoveItem(int index)
        {
            if (index < 0 || index > this.count - 1)
            {
                throw new ArgumentOutOfRangeException("Значение аргумента не соответствует допустимому диапазону значений" + index);
            }

            ListItem<T> currentItem = head;

            if (index == 0)
            {

            }

            for (int i = 0; i < index; i++)
            {
                currentItem = currentItem.Next;
            }

            Console.WriteLine("Значение удаленного элемента по индексу " + index + ": " + currentItem.Data);

            currentItem.Data = (T)value;
        }
    }
}