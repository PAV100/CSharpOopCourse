using System;

namespace GraphTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates graph traversal algorithms");
            Console.WriteLine();

            int[,] adjacencyMatrix =
            {
                { 0, 0, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 1, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Graph graph = new Graph(adjacencyMatrix);

            graph.PrintToConsole();

            Console.Write("Breadth first traversal: ");
            foreach (int e in graph.GetBreadthFirstTraversal())
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();

            Console.Write("Depth first traversal  : ");
            foreach (int e in graph.GetDepthFirstTraversal())
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
        }
    }
}
