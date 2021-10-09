using System;
using System.Collections.Generic;
using System.Linq;

namespace LamdaTask
{
    class LambdaMain
    {
        static void Main(string[] args)
        {
            // А) получить список уникальных имен
            var persons = new List<Person>()
            {
                new Person("Иван", 44),
                new Person("Иван", 19),
                new Person("Дарья", 33),
                new Person("Пётр", 11),
                new Person("Дарья", 74),
            };

            var uniqNameList = persons.Select(person => person.name)
                                      .Distinct()
                                      .ToList();

            // Б) вывести список уникальных имен
            Console.WriteLine("Имена: " + string.Join(", ", uniqNameList.Select(name => name)) + ".");

            // В) получить список людей младше 18, посчитать для них средний возраст
            var underagePersonList = persons.Where(person => person.age < 18)
                                            .Select(person => person.name)
                                            .ToList();

            double averageAge = persons.Average(person => person.age);

            Console.WriteLine("Cписок людей младше 18: " + string.Join(", ", underagePersonList.Select(name => name)) + ".");
            Console.WriteLine("Средний возраст: " + averageAge);

            //Г) при помощи группировки получить Map, в котором ключи –
            //имена, а значения –средний возраст

            Dictionary<string, double> personsByName = persons.GroupBy(person => person.name)
                                                                    .ToDictionary(person => person.Key,
                                                                                  person => person.Average(person => person.age));

            Console.WriteLine("Список людей сгруппированных по имени, и их средний возраст: " + string.Join(", ", personsByName) + ".");

            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль
            //их имена в порядке убывания возраста

            var middleAgePersonList = persons.Where(person => person.age > 20 && person.age < 45)
                                .Select(person => person.name)
                                .ToList();

            Console.WriteLine("Cписок людей возрастом от 20 до 45: " + string.Join(", ", middleAgePersonList.Select(name => name).OrderByDescending(name => name)) + ".");
        }
    }
}