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

            try
            {
                using StreamReader reader = new StreamReader(inputFilePath);
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        fileLinesList.Add(currentLine);
                    }
                }

                Console.WriteLine($"Here are list items that consist of file {inputFilePath} lines:");
                Console.WriteLine(string.Join(Environment.NewLine, fileLinesList));
            }
            catch (Exception)
            {
                Console.WriteLine($"Directory or file {inputFilePath} open or read error!");
            }

            // Part2: delete all even numbers from a list
            List<int> integerNumbersList1 = new List<int> { 0, 0, 1, 1, 2, 2, 3, 4, 5, 6, 7, 8, 999, 10, 11, 122, 13, 14, 1515, 16, 17, 180, 19 };

            Console.WriteLine();
            Console.WriteLine("Here is unprocessed list:");
            Console.WriteLine(string.Join(", ", integerNumbersList1));

            for (int i = integerNumbersList1.Count - 1; i >= 0; i--)
            {
                if (integerNumbersList1[i] % 2 == 0)
                {
                    integerNumbersList1.RemoveAt(i);
                }
            }

            Console.WriteLine("Here is list without even numbers:");
            Console.WriteLine(string.Join(", ", integerNumbersList1));

            // Part3: create new list, containing numbers from given one but without repeating numbers
            List<int> integerNumbersList2 = new List<int> { 1, 5, 2, 1, 3, 5, 1, 10, 4, 1, 1, 0, 2, 3, 10, 0 };
            List<int> distinctIntegerNumbersList2 = new List<int>(integerNumbersList2.Count);

            Console.WriteLine();
            Console.WriteLine("Here is unprocessed list:");
            Console.WriteLine(string.Join(", ", integerNumbersList2));

            foreach (int e in integerNumbersList2)
            {
                if (!distinctIntegerNumbersList2.Contains(e))
                {
                    distinctIntegerNumbersList2.Add(e);
                }
            }

            Console.WriteLine("Here is new list without repeating numbers:");
            Console.WriteLine(string.Join(", ", distinctIntegerNumbersList2));
        }
    }
}