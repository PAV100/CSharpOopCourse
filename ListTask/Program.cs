using System;
using System.Collections.Generic;

namespace ListTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates functionality of SinglyLinkedList class");

            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            Console.WriteLine(list.Count);

            list.AddFirst(10);
            list.AddFirst(9);
            list.AddFirst(8);

            Console.WriteLine(list.Get(0));
            Console.WriteLine(list.Get(1));
            Console.WriteLine(list.Get(2));

            Console.WriteLine(list.Set(0, 18));
            Console.WriteLine(list.Get(0));


            Console.WriteLine($"First: {list.Head.Data.ToString()}, Count: {list.Count}");

            Console.WriteLine(list.GetFirst());


            //List<int> pp = new List<int>() { 1, 5, 6 };
            //pp.Add(15);
            //Console.WriteLine(pp[0]);
        }
    }
}
