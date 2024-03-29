﻿using ArrayListTask;
using System;
using System.Collections.Generic;
using TreeTask.Comparers;

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

            var cursorPosition = Console.GetCursorPosition();

            Console.WriteLine(bt);
            Console.WriteLine();

            int value;
            string messageString;
            int treeHeight;

            while (true)
            {
                try
                {
                    Console.Write("You also may insert nodes manually. Enter a value to insert or press Enter to continue: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    bt.Insert(value);
                    treeHeight = bt.GetTreeHeight();

                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

                    for (int i = 0; i < treeHeight + 2; i++)
                    {
                        Console.WriteLine(new string(' ', 120));
                    }

                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

                    messageString = $"A value {value} was inserted into the tree";
                    Console.WriteLine(bt);

                    Console.WriteLine(messageString);
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine("2. Three IEnumerators created:");
            IEnumerable<int> btDftrEnumerator = bt.GetDepthFirstTraversalRecursiveEnumerator();
            IEnumerable<int> btDftEnumerator = bt.GetDepthFirstTraversalEnumerator();
            IEnumerable<int> btBftEnumerator = bt.GetBreadthFirstTraversalEnumerator();

            Console.WriteLine("DepthFirstTraversalRecursiveEnumerator():");

            foreach (int e in btDftrEnumerator)
            {
                Console.Write($"{e} ");
            }            

            Console.WriteLine();

            Console.WriteLine("DepthFirstTraversalEnumerator():");

            foreach (int e in btDftEnumerator)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();

            Console.WriteLine("BreadthFirstTraversalEnumerator():");

            foreach (int e in btBftEnumerator)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            cursorPosition = Console.GetCursorPosition();

            while (true)
            {
                try
                {
                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
                    Console.WriteLine(new string(' ', 120));
                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

                    Console.Write("3. Method Contains() checks the tree for given value. Enter a value or press Enter to continue: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    messageString = bt.Contains(value) ? "contains" : "does not contain";

                    Console.Write(new string(' ', 120));
                    Console.CursorLeft = 0;
                    Console.WriteLine($"The tree {messageString} a value {value}.");
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("4. Method DeleteFirstOccurrence() checks the tree for given value and deletes it if finds.");
            cursorPosition = Console.GetCursorPosition();
            Console.WriteLine(bt);
            treeHeight = bt.GetTreeHeight();

            while (true)
            {
                try
                {
                    Console.Write("Enter a value to delete or press Enter to continue: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

                    for (int i = 0; i < treeHeight + 2; i++)
                    {
                        Console.WriteLine(new string(' ', 80));
                    }

                    Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

                    messageString = bt.DeleteFirstOccurrence(value) ? "was deleted from" : "is not found in";
                    Console.WriteLine(bt);

                    Console.WriteLine($"A value {value} {messageString} the tree.");
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine($"5. The tree has {bt.Count} node(s), tree height is {bt.GetTreeHeight()} level(s).");
            Console.WriteLine();

            Console.WriteLine("6. Generate binary tree of tuple nodes using Insert() method");
            BinaryTree<(int, int)> bt2 = new((10, 20));
            bt2.Insert((5, 15));
            bt2.Insert((10, 15));
            bt2.Insert((15, 15));
            bt2.Insert((5, 20));
            bt2.Insert((10, 20));
            bt2.Insert((15, 20));
            bt2.Insert((5, 25));
            bt2.Insert((10, 25));
            bt2.Insert((15, 25));
            Console.WriteLine(bt2);
            Console.WriteLine();

            Console.WriteLine("7. Generate binary tree of some only comparer comparable nodes using Insert() method");
            BinaryTree<ArrayList<int>> bt3 = new(new ArrayListCountComparer<int>(), new ArrayList<int>(collection: new[] { 0, 5, 10, 15, 20 }));
            bt3.Insert(new ArrayList<int>(collection: new[] { 10, 20, 30 }));
            bt3.Insert(null);
            bt3.Insert(new ArrayList<int>(collection: new[] { 100, 200 }));
            bt3.Insert(new ArrayList<int>(collection: new[] { 5, 6, 7, 8, 9, 10 }));
            bt3.Insert(new ArrayList<int>(collection: new[] { 0, 0, 0 }));
            bt3.Insert(new ArrayList<int>(capacity: 20));
            bt3.Insert(new ArrayList<int>(collection: new[] { 110 }));
            bt3.Insert(new ArrayList<int>(collection: new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            bt3.Insert(null);
            bt3.Insert(new ArrayList<int>(capacity: 7));
            Console.WriteLine(bt3);
        }
    }
}
