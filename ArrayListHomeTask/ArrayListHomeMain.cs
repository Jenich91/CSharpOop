using System;
using System.Collections;
using System.IO;

namespace ArrayListHomeTask
{
    class ArrayListHomeMain
    {
        static void Main(string[] args)
        {
            // 1.Прочитать в список все строки из файла

            ArrayList list = new ArrayList();

            using StreamReader reader = new StreamReader("..\\..\\..\\Textfile.txt");
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(currentLine);
                }
            }

            Console.WriteLine("Прочитаный фаил содержит: ");

            printArrayList(list);

            // 2.Есть список из целых чисел. Удалить из него все четные числа.

            ArrayList list2 = new ArrayList { 88, 623, 46, 87, 2, 471, 162, 934, 379, 281 };

            for (int i = 0; i < list2.Count; i++)
            {
                if ((int)list2[i] % 2 == 0)
                {
                    list2.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("Список без четных чисел: ");
            printArrayList(list2);

            // 3.Есть список из целых чисел, в нём некоторые числа могут 
            //повторяться.Надо создать новый список, в котором будут
            //элементы первого списка в таком же порядке, но без
            //повторений

            ArrayList list3 = new ArrayList { 61, 70, 70, 61, 39, 88, 31, 8, 8, 39, 65, 69, 8 };
            ArrayList list4 = new ArrayList { list3[0] };

            for (int i = 1; i < list3.Count; i++)
            {
                if (!list4.Contains(list3[i]))
                {
                    list4.Add(list3[i]);
                }
            }

            Console.WriteLine("Список без повторов: ");
            printArrayList(list4);
        }

        private static void printArrayList(ArrayList list)
        {
            foreach (var elem in list)
            {
                Console.Write(elem + " ");
            }

            Console.WriteLine();
        }
    }
}