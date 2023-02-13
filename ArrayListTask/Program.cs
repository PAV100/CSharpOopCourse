using System;
using System.Collections;
using System.Collections.Generic;

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
            Console.WriteLine("List: {0}", list1.ToString());
            Console.WriteLine();

            Console.WriteLine("2. Add to the list some items with Add() method");
            list1.Add(100);
            list1.Add(200);
            list1.Add(300);
            Console.WriteLine("List: {0}", list1.ToString());
            Console.WriteLine();

            Console.WriteLine("3. Method Contains() checkes if the list has a given value");
            Console.WriteLine("List contains {0} = {1}", 200, list1.Contains(200));
            Console.WriteLine("List contains {0} = {1}", 500, list1.Contains(500));
            Console.WriteLine();

            Console.WriteLine("4. Lets create an empty array and use CopyTo() method to fill it with the list items");
            int[] array = new int[4];
            Console.WriteLine("array = [{0}]", string.Join(", ", array));
            list1.CopyTo(array, 1);
            Console.WriteLine("array = [{0}]", string.Join(", ", array));
            Console.WriteLine();

            Console.WriteLine("5. Two enumerators created and the list is enumerated by both");
            IEnumerator list1Enumerator = list1.GetEnumerator();
            while (list1Enumerator.MoveNext())
            {
                Console.WriteLine(list1Enumerator.Current);
            }
            Console.WriteLine();

            IEnumerator<int> list1Enumerator2 = list1.GetEnumerator();
            while (list1Enumerator2.MoveNext())
            {
                Console.WriteLine(list1Enumerator2.Current);
            }
            Console.WriteLine();

            Console.WriteLine("6. Method IndexOf() is shown");
            Console.WriteLine("List: {0}", list1.ToString());
            int value = 300;
            Console.WriteLine("A value {0} is in the list at index {1}", value, list1.IndexOf(value));
            Console.WriteLine();

            Console.WriteLine("7. Constructor creates a list with one item");
            ArrayList<int> list2 = new ArrayList<int>(item: 90);
            Console.WriteLine("List: {0}", list2.ToString());
            Console.WriteLine();

            Console.WriteLine("8. Method Insert() allows to add some items");
            list2.Insert(0, 50);
            list2.Insert(1, 60);
            list2.Insert(2, 70);
            list2.Insert(3, 80);
            Console.WriteLine("List: {0}", list2.ToString());
            Console.WriteLine();

            value = 80;
            Console.WriteLine("9. Method Remove() deletes first occurance of an item {0}", value);
            Console.WriteLine("Removed = {0}, List: {1}", list2.Remove(value), list2.ToString());
            Console.WriteLine();

            value = 1;
            Console.WriteLine("10. Method RemoveAt() deletes an item at index {0}", value);
            list2.RemoveAt(1);
            Console.WriteLine("List: {0}", list2.ToString());
            Console.WriteLine();

            Console.WriteLine("11. Method Clear() deletes all items");
            list2.Clear();
            Console.WriteLine("List: {0}", list2.ToString());
            Console.WriteLine();

            Console.WriteLine("12. Constructor creates an empty list of given capacity");
            ArrayList<int> list3 = new ArrayList<int>(capacity: 10);
            Console.WriteLine("List: {0}", list3.ToString());
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
            Console.WriteLine("List: {0}", list3.ToString());
            list3.TrimExcess();
            Console.WriteLine("List: {0}", list3.ToString());
            Console.WriteLine();

            Console.WriteLine("14. Changing list capacity with Capacity property");
            list3.Capacity = 15;
            Console.WriteLine("List: {0}", list3.ToString());
            list3.Capacity = 12;
            Console.WriteLine("List: {0}", list3.ToString());
            Console.WriteLine();

            Console.WriteLine("15. Changing list IsReadOnly property");
            list3.IsReadOnly = true;
            Console.WriteLine("List: {0}", list3.ToString());
            //list3.RemoveAt(0);
        }
    }
}