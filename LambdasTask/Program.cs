using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdasTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates...");
            Console.WriteLine();

            List<Person> persons = new()
            {
                new("Ivan", 25),
                new("Sergey", 35),
                new("Petr", 45),
                new("Ilya", 45),
                new("Anna", 17),
                new("Olga", 30),
                new("Svetlana", 54),
                new("Ivan", 32),
                new("Oleg", 16),
                new("Anna", 34),
            };

            Console.WriteLine("Initial names list state:");
            Console.WriteLine(string.Join(", ", persons));
            Console.WriteLine();

            Console.WriteLine("1. Unique names list");
            var list1 = persons
                .Select(x => x.Name)
                .Distinct();
            Console.WriteLine(string.Join(", ", list1));
            Console.WriteLine();

            Console.WriteLine("2. Unique names list formatted output");
            Console.WriteLine("Names: " + string.Join(", ", list1));
            Console.WriteLine();

            Console.WriteLine("3. List of people younger than 18, calculate their average age");
            var list2 = persons
                .Where(x => x.Age < 18)
                .Select(x => x.Name);
            Console.WriteLine(string.Join(", ", list2));
            Console.Write("Average age: ");
            var age = persons
                .Where(x => x.Age < 18)
                .Select(x => x.Age)
                .Average();
            Console.WriteLine(age);
            Console.WriteLine();

            Console.WriteLine("4. Getting dictionary[key: name, value: average age]");
            var dict2 = persons
                .GroupBy(x => x.Name, x => x.Age)
                .ToDictionary(x => x.Key, x => x.Average());
            Console.WriteLine(string.Join(", ", dict2));
            Console.WriteLine();

            Console.WriteLine("5. Getting people between 20 and 45, printing their names to console in the age descending order");
            var list3 = persons
                .Where(x => (x.Age >= 20 && x.Age <= 45))
                .OrderByDescending(x => x.Age)
                .Select(x=>x.Name);
            Console.WriteLine(string.Join(", ", list3));
            Console.WriteLine();
        }
    }
}
