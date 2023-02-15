using System;
using System.Collections.Generic;

using ArrayListTask;

namespace HashTableTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates homemade class of generic hashtable: HashTable<T> : ICollection<T>");
            Console.WriteLine();

            Console.WriteLine("1. Constructor without arguments creates empty hashtable");
            HashTable<double> ht = new();
            Console.WriteLine(ht.ToString());

            Console.WriteLine("2. Add to the hashtable some items with Add() method");
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
            ht.Add(10);
            ht.Add(11);
            ht.Add(12);
            ht.Add(13);
            ht.Add(14);
            Console.WriteLine(ht.ToString());

            Console.WriteLine("3. Method Contains() checkes if the hashtable has a given value");
            double value = 10;
            Console.WriteLine("Hashtable contains {0} = {1}", value, ht.Contains(value));
            value = 19;
            Console.WriteLine("Hashtable contains {0} = {1}", value, ht.Contains(value));
            Console.WriteLine();

            Console.WriteLine("4. Method Clear() deletes all lists in the hashtable");
            ht.Clear();
            Console.WriteLine(ht.ToString());

            Console.WriteLine("5. Constructor creates a hashtable with given length");
            HashTable<string> ht2 = new(8);
            Console.WriteLine(ht2.ToString());
            Console.WriteLine("Lets fill it with some elements");
            ht2.Add("qw1a");
            ht2.Add("we2bb");
            ht2.Add("er3ccc");
            ht2.Add("rt4dddd");
            ht2.Add("ty5eeeee");
            ht2.Add("yu6ffffff");
            ht2.Add("ui7iiiiiii");
            ht2.Add("io8jjjjjjjj");
            ht2.Add("io9kkkkkkkkk");
            ht2.Add("op0pppppppppp");
            Console.WriteLine(ht2.ToString());

            Console.WriteLine("6. Lets create an empty array and use CopyTo() method to fill it with the hashtable items");
            string[] array = new string[10];
            Console.WriteLine("array = [{0}]", string.Join(", ", array));
            ht2.CopyTo(array, 0);
            Console.WriteLine("array = [{0}]", string.Join(", ", array));
            Console.WriteLine();

            Console.WriteLine("7. A hashtable is enumerated by an enumerator");
            IEnumerator<string> hte = ht2.GetEnumerator();
            while (hte.MoveNext())
            {
                Console.WriteLine(hte.Current);
            }
            Console.WriteLine();

            Console.WriteLine("8. Method Remove() deletes an item from the hashtable");
            string s = "qw1a";
            Console.WriteLine(ht2.ToString());
            Console.WriteLine("Remove({0}) = {1}", s, ht2.Remove(s));
            Console.WriteLine(ht2.ToString());
            Console.WriteLine("Remove({0}) = {1}", s, ht2.Remove(s));
            Console.WriteLine(ht2.ToString());

            Console.WriteLine("9. Changing hashtable IsReadOnly property");
            ht2.IsReadOnly = true;
            Console.WriteLine(ht2.ToString());
            //ht2.Clear();
            //Console.WriteLine(ht2.ToString());
        }
    }
}