using System;

namespace ListTask
{
    public class Item<T>
    {
        public T Data { get; set; }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            IsArgumentNotNull(data);

            Data = data;
        }

        public Item(T data, Item<T> next)
        {
            IsArgumentNotNull(data);

            if (next == null)
            {
                throw new ArgumentNullException("Аргумент " + nameof(next) + " имеет значение null");
            }

            Data = data;
            Next = next;
        }

        public bool IsArgumentNotNull(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Аргумент " + nameof(data) + " имеет значение null");
            }

            return true;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}