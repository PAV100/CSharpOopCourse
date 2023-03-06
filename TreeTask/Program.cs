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

            var cursorPositiont = Console.GetCursorPosition();

            Console.WriteLine(bt.ToString());
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

                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);

                    for (int i = 0; i < treeHeight + 2; i++)
                    {
                        Console.WriteLine(new string(' ', 120));
                    }

                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);

                    messageString = $"A value {value} was inserted into the tree";
                    Console.WriteLine(bt.ToString());

                    Console.WriteLine(messageString);
                }
                catch (Exception e)
                {
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine("2. Three IEnumerators created:");
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

            cursorPositiont = Console.GetCursorPosition();

            while (true)
            {
                try
                {
                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);
                    Console.WriteLine(new string(' ', 120));
                    Console.SetCursorPosition(cursorPositiont.Left, cursorPositiont.Top);

                    Console.Write("3. Method Contains() checks the tree for given value. Enter a value or press Enter to continue: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    messageString = bt.Contains(value) == false ? "does not contain" : "contains";

                    Console.Write(new string(' ', 120));
                    Console.CursorLeft = 0;
                    Console.WriteLine($"The tree {messageString} a value {value}.");
                }
                catch (Exception e)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("4. Method DeleteFirstOccurrence() checks the tree for given value and deletes it if finds.");
            cursorPositiont = Console.GetCursorPosition();
            Console.WriteLine(bt.ToString());
            treeHeight = bt.GetTreeHeight();

            while (true)
            {
                try
                {
                    Console.Write("Enter a value to delete or press Enter to continue: ");
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

            Console.WriteLine();

            Console.WriteLine($"5. The tree has {bt.Count} node(s), tree height is {bt.GetTreeHeight()} level(s).");
        }
    }

}
