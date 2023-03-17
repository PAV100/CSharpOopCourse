using System;

namespace ArrayListTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates homemade class of generic list on an array: ArrayList<T> : IList<T>");
            Console.WriteLine();

            Console.WriteLine("1. Constructor without arguments creates empty list");
            ArrayList<int> list1 = new ArrayList<int>();
            Console.WriteLine($"List: {list1}");
            Console.WriteLine();

            Console.WriteLine("2. Add to the list some items with Add() method");
            list1.Add(100);
            list1.Add(200);
            list1.Add(300);
            Console.WriteLine($"List: {list1}");
            Console.WriteLine();

            Console.WriteLine("3. Method Contains() checkes if the list has a given value");
            Console.WriteLine($"List contains 200 == {list1.Contains(200)}");
            Console.WriteLine($"List contains 500 == {list1.Contains(500)}");
            Console.WriteLine();

            Console.WriteLine("4. Lets create an empty array and use CopyTo() method to fill it with the list items");
            int[] array = new int[4];
            Console.WriteLine($"array = [{string.Join(", ", array)}]");
            list1.CopyTo(array, 1);
            Console.WriteLine($"array = [{string.Join(", ", array)}]");
            Console.WriteLine();

            Console.WriteLine("5. List is enumerated by an enumerator");
            foreach (var e in list1)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            Console.WriteLine("6. Method IndexOf() is shown");
            Console.WriteLine($"List: {list1}");
            int value = 300;
            Console.WriteLine($"A value {value} is in the list at index {list1.IndexOf(value)}");
            Console.WriteLine();

            Console.WriteLine("7. Constructor creates a list from a collection");
            ArrayList<int> list2 = new ArrayList<int>(collection: new[] { 90, 80, 70 });
            Console.WriteLine($"List: {list2}");
            Console.WriteLine();

            Console.WriteLine("8. Method Insert() allows to add some items");
            list2.Insert(0, 130);
            list2.Insert(1, 120);
            list2.Insert(2, 110);
            list2.Insert(3, 100);
            Console.WriteLine($"List: {list2}");
            Console.WriteLine();

            value = 80;
            Console.WriteLine($"9. Method Remove() deletes first occurance of an item {value}");
            Console.WriteLine($"Removed = {list2.Remove(value)}, List: {list2}");
            Console.WriteLine();

            value = 1;
            Console.WriteLine($"10. Method RemoveAt() deletes an item at index {value}");
            list2.RemoveAt(1);
            Console.WriteLine($"List: {list2}");
            Console.WriteLine();

            Console.WriteLine("11. Method Clear() deletes all items");
            list2.Clear();
            Console.WriteLine($"List: {list2}");
            Console.WriteLine();

            Console.WriteLine("12. Constructor creates an empty list of given capacity");
            ArrayList<int> list3 = new ArrayList<int>(capacity: 10);
            Console.WriteLine($"List: {list3}");
            Console.WriteLine();

            Console.WriteLine("13. Fill the list up to 80% level and use method TrimExess()");
            list3.Insert(0, 20);
            list3.Insert(0, 19);
            list3.Insert(0, 18);
            list3.Insert(0, 17);
            list3.Insert(0, 16);
            list3.Insert(0, 15);
            list3.Insert(0, 14);
            list3.Insert(0, 13);
            //list3.Insert(0, 12);
            Console.WriteLine($"List: {list3}");
            list3.TrimExcess();
            Console.WriteLine($"List: {list3}");
            Console.WriteLine();

            Console.WriteLine("14. Changing list capacity with Capacity property");
            list3.Capacity = 15;
            Console.WriteLine($"List: {list3}");
            list3.Capacity = 12;
            Console.WriteLine($"List: {list3}");
            Console.WriteLine();
        }
    }
}