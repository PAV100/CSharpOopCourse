using System;
using System.Collections.Generic;

namespace TreeTask
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates functionality of BinaryTree<T> class...");
            Console.WriteLine();

            Console.WriteLine("1. Generate binary tree with random nodes using Insert() method");
            BinaryTree<int> bt = new(50);

            Random randomNumberGenerator = new Random();

            for (int i = 1; i < 31; i++)
            {
                int randomNumber = randomNumberGenerator.Next(0, 100 + 1);
                bt.Insert(randomNumber);
            }            

            Console.WriteLine(bt.ToString());
            Console.WriteLine();

            Console.WriteLine("2. Method DepthFirstTraversalRecursive() uses depth-first recursive traversal and returns tree's nodes as an array");
            Console.WriteLine($"[{String.Join(",", bt.DepthFirstTraversalRecursive())}]");
            Console.WriteLine();

            Console.WriteLine("3. Method DepthFirstTraversal() uses depth-first traversal and returns tree's nodes as an array");
            Console.WriteLine($"[{String.Join(",", bt.DepthFirstTraversal())}]");
            Console.WriteLine();

            Console.WriteLine("4. Method BreadthFirstTraversal() uses breadth-first traversal and returns tree's nodes as an array");
            Console.WriteLine($"[{String.Join(",", bt.BreadthFirstTraversal())}]");
            Console.WriteLine();

            Console.WriteLine("5. Three IEnumerators created:");
            IEnumerator<int> btDftrEnumerator = bt.GetDepthFirstTraversalRecursiveEnumerator();
            IEnumerator<int> btDftEnumerator = bt.GetDepthFirstTraversalEnumerator();
            IEnumerator<int> btBftEnumerator = bt.GetBreadthFirstTraversalEnumerator();

            Console.WriteLine("DepthFirstTraversalRecursiveEnumerator():");
            while (btDftrEnumerator.MoveNext())
            {
                Console.Write($"{btDftrEnumerator.Current} ");
            }
            Console.WriteLine();

            Console.WriteLine("DepthFirstTraversalEnumerator():");
            while (btDftEnumerator.MoveNext())
            {
                Console.Write($"{btDftEnumerator.Current} ");
            }
            Console.WriteLine();

            Console.WriteLine("BreadthFirstTraversalEnumerator():");
            while (btBftEnumerator.MoveNext())
            {
                Console.Write($"{btBftEnumerator.Current} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("6. Method Contains() checks the tree for given value. Enter a value or press Enter to terminate: ");
            int value;
            string messageString;

            try
            {
                value = Convert.ToInt32(Console.ReadLine());
                messageString = bt.Contains(value) == false ? "does not contain" : "contains";
                Console.WriteLine($"The tree {messageString} a value {value}.");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }

            Console.WriteLine("7. Method DeleteFirstOccurrence() checks the tree for given value and deletes it if finds.");
            var cursorPositiont = Console.GetCursorPosition();
            Console.WriteLine(bt.ToString());
            int treeHeight = bt.GetTreeHeight();

            while (true)
            {
                try
                {
                    Console.Write("Enter a value to delete or press Enter to terminate: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);

                    for (int i = 0; i < treeHeight + 2; i++)
                    {
                        Console.WriteLine(new string(' ', 80));
                    }

                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);

                    messageString = bt.DeleteFirstOccurrence(value) == false ? "is not found in" : "was deleted from";
                    Console.WriteLine(bt.ToString());

                    Console.WriteLine($"A value {value} {messageString} the tree.");
                }
                catch (Exception e)
                {
                    break;
                }
            }
        }
    }
}
