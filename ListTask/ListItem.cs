using System;

namespace ListTask
{
    public class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> Next { get; set; }

        public ListItem(T data)
        {
            IsArgumentNotNull(data);

            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            IsArgumentNotNull(data);

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