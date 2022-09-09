using System;
using System.Collections.Generic;

namespace ListTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates functionality of SinglyLinkedList class");
            Console.WriteLine();

            Console.WriteLine("Constructor, creating empty list");
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine("Constructor, creating list with one item");
            SinglyLinkedList<string> list2 = new SinglyLinkedList<string>("first");
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine("Constructor, creating a copy of a list");
            SinglyLinkedList<string> list3 = new SinglyLinkedList<string>(list2);
            Console.WriteLine($"Name: {nameof(list3)}, {list3}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, Autoproperty Count = {list2.Count}, Method GetCount() = {list2.GetCount()}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, Method GetFirstItem() = {list2.GetFirstItem()}");
            Console.WriteLine();

            list1.InsertFirstItem(15);
            list1.InsertFirstItem(10);
            list1.InsertFirstItem(5);
            Console.WriteLine("Methods: list1.InsertFirstItem(15), list1.InsertFirstItem(10), list1.InsertFirstItem(5)");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method list1.GetItem(2) = {list1.GetItem(2)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method list1.SetItem(1, 25). Previous Data value = {list1.SetItem(1, 25)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine("Method: list1.InsertItem(list1.Count, 35)");
            list1.InsertItem(list1.Count, 35);
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteItem(2). Deleted item Data value = {list1.DeleteItem(2)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteFirstItem(). Deleted item Data value = {list1.DeleteFirstItem()}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteItemByData(35). Item has been deleted = {list1.DeleteItemByData(35)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine($"Method: list2.DeleteItemByData(\"first\"). Item has been deleted = {list2.DeleteItemByData("first")}");
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            list2.InsertFirstItem("a");
            list2.InsertFirstItem("bb");
            list2.InsertFirstItem("ccc");
            list2.InsertFirstItem("dddd");
            list2.InsertFirstItem("eeeee");
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine($"Method: list2.Reverse().");
            list2.Reverse();
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine($"Method: list4 = list2.Copy()");
            SinglyLinkedList<string> list4 = list2.Copy();
            Console.WriteLine($"Name: {nameof(list4)}, {list4}");
        }
    }
}