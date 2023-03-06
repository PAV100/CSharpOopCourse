using System;

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
            list2.InsertFirst(null);
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine("Constructor, creating a copy of a list");
            SinglyLinkedList<string> list3 = new SinglyLinkedList<string>(list2);
            Console.WriteLine($"Name: {nameof(list3)}, {list3}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, Autoproperty Count = {list2.Count}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, Method GetFirst() = {list2.GetFirst()}");
            Console.WriteLine();

            list1.InsertFirst(15);
            list1.InsertFirst(10);
            list1.InsertFirst(5);
            Console.WriteLine("Methods: list1.InsertFirst(15), list1.InsertFirst(10), list1.InsertFirst(5)");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method list1.Get(2) = {list1.Get(2)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method list1.Set(1, 25). Previous Data value = {list1.Set(1, 25)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine("Method: list1.Insert(0, 45)");
            list1.Insert(0, 45);
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine("Method: list1.Insert(list1.Count, 35)");
            list1.Insert(list1.Count, 35);
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.Delete(2). Deleted item Data value = {list1.Delete(2)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteFirst(). Deleted item Data value = {list1.DeleteFirst()}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteByData(35). Item has been deleted = {list1.DeleteByData(35)}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteFirst(). Deleted item Data value = {list1.DeleteFirst()}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Method: list1.DeleteFirst(). Deleted item Data value = {list1.DeleteFirst()}");
            Console.WriteLine($"Name: {nameof(list1)}, {list1}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine($"Method: list2.DeleteByData(\"first\"). Item has been deleted = {list2.DeleteByData("first")}");
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            list2.InsertFirst("a");
            list2.InsertFirst("bb");
            list2.InsertFirst("ccc");
            list2.InsertFirst("dddd");
            list2.InsertFirst("eeeee");
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine("Method: list2.Reverse()");
            list2.Reverse();
            Console.WriteLine($"Name: {nameof(list2)}, {list2}");
            Console.WriteLine();

            Console.WriteLine("Method: list4 = list2.Copy()");
            SinglyLinkedList<string> list4 = list2.Copy();
            Console.WriteLine($"Name: {nameof(list4)}, {list4}");
        }
    }
}
