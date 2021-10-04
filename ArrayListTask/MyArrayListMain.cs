using System;

namespace MyListTask
{
    class MyArrayListMain
    {
        static void Main(string[] args)
        {
            var testList1 = new MyArrayList<string>(12)
            {
                "proverka1",
                "proverka2",
                "proverka3",
                "proverka4",
                "proverka5",
                "proverka6",
                "proverka7",
                "proverka8",
                "proverka9",
                "proverka10",
                "proverka11",
                "proverka12"
            };

            testList1.TrimExcess();

            foreach (var item in testList1)
            {
                Console.WriteLine(item);
            }

            testList1.Clear();

            testList1.Add("addTest");
            testList1.Add("addTest2");
            testList1.Add("addTest3");

            testList1[1] = "indexTest";
            Console.WriteLine(testList1[1]);

            Console.WriteLine(testList1.Contains("addTest3"));
            Console.WriteLine(testList1.IndexOf("addTest3"));

            var testList2 = new string[testList1.Capacity];
            testList1.CopyTo(testList2, 0);

            testList1 = new MyArrayList<string>(12)
            {
                "proverka1",
                "proverka2",
                "proverka3",
                "proverka4",
                "proverka5",
                "proverka6",
                "proverka7",
                "proverka8",
                "proverka9",
                "proverka10"
            };

            testList1.Insert(7, "insertTest");

            foreach (var item in testList1)
            {
                Console.WriteLine(item);
            }
        }
    }
}