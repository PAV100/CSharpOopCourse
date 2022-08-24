using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates functionality of List<T> class (list on array)");
            Console.WriteLine();

            // Part1: read all file lines into list
            List<string> fileLinesList = new List<string>();

            string inputFilePath = "..\\..\\..\\input.txt";
            using StreamReader reader = new StreamReader(inputFilePath);
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    fileLinesList.Add(currentLine);
                }
            }

            Console.WriteLine($"Here are list items that consist of file {inputFilePath} lines:");
            Console.WriteLine(string.Join("\n", fileLinesList.ToArray()));

            // Part2: delete all even numbers from a list
            List<int> integerNumbersList1 = new List<int> { 0, 0, 1, 1, 2, 2, 3, 4, 5, 6, 7, 8, 999, 10, 11, 122, 13, 14, 1515, 16, 17, 180, 19 };

            Console.WriteLine();
            Console.WriteLine($"Here are unprocessed list:");
            Console.WriteLine(string.Join(", ", integerNumbersList1.ToArray()));

            for (int i = integerNumbersList1.Count - 1; i >= 0; i--)
            {
                if (integerNumbersList1[i] % 2 == 0)
                {
                    integerNumbersList1.RemoveAt(i);
                }
            }

            Console.WriteLine($"Here are list without even numbers:");
            Console.WriteLine(string.Join(", ", integerNumbersList1.ToArray()));

            // Part3: delete repeating numbers from a list
            List<int> integerNumbersList2 = new List<int> { 1, 5, 2, 1, 3, 5, 1, 10, 4, 1, 1, 0, 2, 3, 10, 0 };
            
            Console.WriteLine();
            Console.WriteLine($"Here are unprocessed list:");
            Console.WriteLine(string.Join(", ", integerNumbersList2.ToArray()));

            for (int i = 0; i < integerNumbersList2.Count; i++)
            {
                while (i != integerNumbersList2.LastIndexOf(integerNumbersList2[i]))
                {
                    integerNumbersList2.RemoveAt(integerNumbersList2.LastIndexOf(integerNumbersList2[i]));
                }
            }

            Console.WriteLine($"Here are list without repeating numbers:");
            Console.WriteLine(string.Join(", ", integerNumbersList2.ToArray()));
        }
    }
}
