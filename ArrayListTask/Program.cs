using System;
using System.Collections.Generic;

namespace ArrayListTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            ArrayList<int> list1 = new ArrayList<int>();
            list1[0] = 100;
            int i = list1[0];
            Console.WriteLine("i = {0}", i);

            List<int> list2 = new List<int>();
            list2.Add(0);

        }
    }
}
