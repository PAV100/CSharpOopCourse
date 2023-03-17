using ArrayListTask;
using System;
using System.Collections.Generic;

namespace TreeTask.Comparers
{
    internal class ArrayListCountComparer<T> : IComparer<ArrayList<T>>
    {
        public int Compare(ArrayList<T> list1, ArrayList<T> list2)
        {
            if (list1 is null && list2 is null)
            {
                return 0;
            }

            if (list1 is null)
            {
                return -1;
            }

            if (list2 is null)
            {
                return 1;
            }

            if (list1.Count < list2.Count)
            {
                return -1;
            }

            if (list1.Count > list2.Count)
            {
                return 1;
            }

            return 0;
        }
    }
}
