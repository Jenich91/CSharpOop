namespace ListTask
{
    public class SinglyLinkedList
    {
        private ListItem<T> head;
        private int count;

        public SinglyLinkedList()
        {
        }

        public int GetListSize(SinglyLinkedList list)
        {
            return count;
        }

        T GetFirstValue(SinglyLinkedList list)
        {
            if (count != 0)
            {
                return head.Data;
            }

            return null;
        }

        public T this[int index]
        {
            get
            {
                ListItem<T> temp = head;

                int i = 0;
                while (i != index)
                {
                    temp = temp.Next;
                    i++;
                }

                return temp.Data;
            }

            set
            {
                ListItem<T> temp = head;

                int i = 0;
                while (i != index)
                {
                    temp = temp.Next;
                    i++;
                }

                temp.Data = value;
            }
        }
    }
}
