using System;

namespace ListTask
{
    class ListMain
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<String>();
            list.Insert("item0", 0);
            list.Insert("item1", 1);
            list.Insert("item2", 2);
            list.Insert("item3", 3);
            list.Insert("item4", 4);
            list.Insert("item5", 5);

            Console.WriteLine(list[3] = "setTest");
            
            //var list2 = new LinkedList<String>();

            //list.CopyTo(list2);

            //foreach (var item in list2)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
