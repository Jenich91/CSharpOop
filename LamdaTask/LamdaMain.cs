using System;
using System.Collections.Generic;
using System.Linq;

namespace LamdaTask
{
    class LamdaMain
    {
        static void Main(string[] args)
        {
            // А) получить список уникальных имен
            var persons = new List<Person>()
            {
                new Person("Иван", 34),
                new Person("Иван", 13),
                new Person("Дарья", 34),
                new Person("Пётр", 34),
                new Person("Дарья", 14),
            };

            var uniqNameList = persons.Select(person => person.name).Distinct().ToList();

            // Б) вывести список уникальных имен
            Console.WriteLine("Имена: " + string.Join(", ", uniqNameList.Select(name => name)) + ".");

            // В) получить список людей младше 18, посчитать для них средний возраст

            var underagePersonList = persons.Where(person => person.age < 18)
                                            .Select(person => person.name)
                                            .ToList();

            double averageAge = persons.Select(person => person.age).Where(age => age < 18).Average();

            Console.WriteLine("Cписок людей младше 18: " + string.Join(", ", underagePersonList.Select(name => name)) + ".");
            Console.WriteLine("Средний возраст: " + averageAge);

















            //Г) при помощи группировки получить Map, в котором ключи –
            //имена, а значения –средний возраст

            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль
            //их имена в порядке убывания возраста
        }
    }
}