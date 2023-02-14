using System;
using System.Collections.Generic;

using ArrayListTask;

namespace HashTableTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates...");
            Console.WriteLine();

            HashTable<double> ht = new();
            Console.WriteLine(ht.ToString());
            ht.Add(0);
            ht.Add(1);
            ht.Add(2);
            ht.Add(3);
            ht.Add(4);
            ht.Add(5);
            ht.Add(6);
            ht.Add(7);
            ht.Add(8);
            ht.Add(9);
            Console.WriteLine(ht.ToString());

            Console.WriteLine();

            HashTable<string> ht2 = new(8);
            Console.WriteLine(ht2.ToString());
            Console.WriteLine();

            //Console.WriteLine(0.GetHashCode());
                       

        }
    }
}
