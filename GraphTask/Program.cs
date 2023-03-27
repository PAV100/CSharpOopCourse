using System;

namespace GraphTask
{
    internal class Program
    {
        static void Main()
        {
            const int GraphVerticesCount = 20;

            Console.WriteLine("Program demonstrates graph traversal algorithms");
            Console.WriteLine();

            bool[] visited1 = new bool[GraphVerticesCount];
            int[,] graph1 = new int[GraphVerticesCount, GraphVerticesCount];
            GenerateGraph(graph1);
            PrintGraphToConsole(graph1);
            Console.WriteLine();

             
            bool[] visited2 = new bool[6];
            int[,] graph2 =
            {
                { 0, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };
            PrintGraphToConsole(graph2);


        }

        static void PrintGraphToConsole(int[,] graph)
        {
            int maxEdgeWeightSymbolsCount = 1;

            foreach (int e in graph)
            {
                if (maxEdgeWeightSymbolsCount < e.ToString().Length)
                {
                    maxEdgeWeightSymbolsCount = e.ToString().Length;
                }
            }

            int firstColumnSymbolsCount = (graph.GetLength(0) - 1).ToString().Length;
            int otherColumnsSymbolsCount = Math.Max(maxEdgeWeightSymbolsCount, (graph.GetLength(1) - 1).ToString().Length);

            string firstColumnFormat = "{0," + firstColumnSymbolsCount + "} ";
            string otherColumnsFormat = "{0," + otherColumnsSymbolsCount + "} ";

            Console.Write($"{new string(' ', firstColumnSymbolsCount)} ");

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write(otherColumnsFormat, i);
            }

            Console.WriteLine();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write(firstColumnFormat, i);

                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(otherColumnsFormat, graph[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void GenerateGraph(int[,] graph)
        {
            Random randomNumberGenerator = new Random();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = i + 1; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = graph[j, i] = randomNumberGenerator.Next(0, 1 + 1);
                }
            }
        }
    }
}
