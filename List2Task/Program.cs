using System;
using System.Collections.Generic;

namespace List2Task
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates functionality of SinglyAndRandomlyLinkedList class");
            Console.WriteLine();

            Console.WriteLine("Constructor, creating list with one item");
            Console.WriteLine();
            SinglyAndRandomlyLinkedList<int> list1 = new(50);

            Console.WriteLine("Add some items to a list...");
            list1.InsertFirst(45);
            list1.InsertFirst(40);
            list1.InsertFirst(35);
            list1.InsertFirst(30);

            Console.WriteLine($"name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            SinglyAndRandomlyLinkedList<int>.Print(list1);
            Console.WriteLine();

            Console.WriteLine("[Re]generating random references of a list...");
            Console.WriteLine();
            SinglyAndRandomlyLinkedList<int>.RegenerateRandomReferences(list1);

            SinglyAndRandomlyLinkedList<int>.Print(list1);
            Console.WriteLine();

            Console.WriteLine("Constructor, creating list as a copy of list");
            SinglyAndRandomlyLinkedList<int> list2 = new(list1);

            Console.WriteLine($"name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            SinglyAndRandomlyLinkedList<int>.Print(list2);
            Console.WriteLine();

            Console.WriteLine("Copying a list to a new list...");
            SinglyAndRandomlyLinkedList<int> list3 = list2.Copy();

            Console.WriteLine($"name: {nameof(list3)}, {list3}");
            Console.WriteLine();

            SinglyAndRandomlyLinkedList<int>.Print(list3);
        }
    }
}