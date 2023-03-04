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

            /*BinaryTree<string> bt = new("qwerty");
            bt.Insert("b");
            bt.Insert("a");
            bt.Insert("c");
            bt.Insert("d");
            bt.Insert("e");
            bt.Insert("f");
            bt.Insert("g");
            bt.Insert("i");
            bt.Insert("j");
            bt.Insert("k");
            bt.Insert("r");*/

            /*bt.Insert(240);
            bt.Insert(230);
            bt.Insert(220);
            bt.Insert(250);
            bt.Insert(260);
            bt.Insert(270);
            bt.Insert(280);
            bt.Insert(290);*/

            /*bt.Insert(13);
            bt.Insert(40);
            bt.Insert(2);
            bt.Insert(53);
            bt.Insert(70);
            bt.Insert(8);
            bt.Insert(181);
            bt.Insert(327);
            bt.Insert(422);
            bt.Insert(654);
            bt.Insert(718);
            bt.Insert(113);
            bt.Insert(156);
            bt.Insert(413);*/

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

            Console.Write("6. Method Contains() checks the tree for given value. Enter a value: ");
            int value = Convert.ToInt32(Console.ReadLine());
            string messageString = bt.Contains(value) == false ? "does not contain" : "contains";
            Console.WriteLine($"The tree {messageString} a value {value}.");
            Console.WriteLine();

            Console.Write("7. Method DeleteFirstOccurrence() checks the tree for given value and deletes it if finds. Enter a value: ");
            value = Convert.ToInt32(Console.ReadLine());
            messageString = bt.DeleteFirstOccurrence(value) == false ? "is not found in" : "was deleted from";
            Console.WriteLine($"A value {value} {messageString} the tree.");
            Console.WriteLine(bt.ToString());
            Console.WriteLine();



            //var t = Console.GetCursorPosition();
            //Console.SetCursorPosition(t.Left,t.Top);
        }
    }
}
