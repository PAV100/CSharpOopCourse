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
                new("Anna", 34)
            };

            Console.WriteLine("Initial names list state:");
            Console.WriteLine(string.Join(", ", persons));
            Console.WriteLine();

            Console.WriteLine("1. Unique names list");
            var uniqueNamesList = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();
            Console.WriteLine(string.Join(", ", uniqueNamesList));
            Console.WriteLine();

            Console.WriteLine("2. Unique names list formatted output");
            Console.WriteLine("Names: " + string.Join(", ", uniqueNamesList) + ".");
            Console.WriteLine();

            Console.WriteLine("3. List of people younger than 18, calculate their average age");
            var personsYounger18List = persons
                .Where(p => p.Age < 18)
                .ToList();

            var peopleYounger18List = personsYounger18List
                .Select(p => p.Name)
                .ToList();
            Console.WriteLine(string.Join(", ", peopleYounger18List));

            Console.Write("Average age: ");
            var peopleYounger18AverageAge = personsYounger18List
                .Average(p => p?.Age);
            Console.WriteLine(peopleYounger18AverageAge);
            Console.WriteLine();

            Console.WriteLine("4. Getting dictionary[key: name, value: average age]");
            var keyNameValueAverageAgeDictionary = persons
                .GroupBy(p => p.Name, p => p.Age)
                .ToDictionary(g => g.Key, g => g.Average());
            Console.WriteLine(string.Join(", ", keyNameValueAverageAgeDictionary));
            Console.WriteLine();

            Console.WriteLine("5. Getting people between 20 and 45, printing their names to console in the age descending order");
            var ageFilteredPeopleInAgeDescendingOrderCollection = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(", ", ageFilteredPeopleInAgeDescendingOrderCollection));

            //var ageFilteredPeopleInAgeDescendingOrderList = persons
            //    .Where(p => p.Age >= 20 && p.Age <= 45)
            //    .OrderByDescending(p => p.Age)
            //    .Select(p => p.Name)
            //    .ToList();
            //Console.WriteLine(string.Join(", ", ageFilteredPeopleInAgeDescendingOrderList));
            //Console.WriteLine();
        }
    }
}
