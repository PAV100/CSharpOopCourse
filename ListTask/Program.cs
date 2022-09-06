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

            list.AddFirstItem(10);
            list.AddFirstItem(9);
            list.AddFirstItem(8);

            Console.WriteLine(list.GetItem(0));
            Console.WriteLine(list.GetItem(1));
            Console.WriteLine(list.GetItem(2));

            Console.WriteLine(list.SetItem(0, 18));
            Console.WriteLine(list.GetItem(0));


            Console.WriteLine($"First: {list.Head.Data.ToString()}, Count: {list.Count}");

            Console.WriteLine(list.GetFirstItem());


            //List<int> pp = new List<int>() { 1, 5, 6 };
            //pp.Add(15);
            //Console.WriteLine(pp[0]);
        }
    }
}
