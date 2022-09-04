using System;
using System.Collections.Generic;

namespace ListTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates functionality of SinglyLinkedList class");

            //ListItem<int> item = new ListItem<int>();
            //ListItem<int> item2 = new ListItem<int>(100);
            //ListItem<int> item3 = new ListItem<int>(200, item);

            //Console.WriteLine(item2.Data);

            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            Console.WriteLine(list.Count);

            ListItem<int> item = new ListItem<int>();
            list.Head = item;
            Console.WriteLine(item.Data);

            //LinkedList<int> ll = new LinkedList<int>();
            //LinkedListNode<int> ll2 = new LinkedListNode<int>(5);
        }
    }
}
