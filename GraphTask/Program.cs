using System;
using System.Collections;
using System.Collections.Generic;

namespace GraphTask
{
    internal class Program
    {
        static void Main()
        {
            const int GraphVerticesCount = 25;

            Console.WriteLine("Program demonstrates graph traversal algorithms");
            Console.WriteLine();

            int[,] graph1 = new int[GraphVerticesCount, GraphVerticesCount];
            GenerateGraph(graph1);

            Console.WriteLine("1. \"Big\" graph with random edges");
            PrintGraphToConsole(graph1);

            Console.Write("Breadth first traversal: ");
            foreach (int e in GetBreadthFirstTraversalEnumerator(graph1))
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();

            Console.Write("Depth first traversal  : ");
            foreach (int e in GetDepthFirstTraversalEnumerator(graph1))
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();

            Console.WriteLine();

            int[,] graph2 =
            {
                { 0, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine("2. \"Small\" graph with manually set edges");
            PrintGraphToConsole(graph2);

            Console.Write("Breadth first traversal: ");
            foreach (int e in GetBreadthFirstTraversalEnumerator(graph2))
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();

            Console.Write("Depth first traversal  : ");
            foreach (int e in GetDepthFirstTraversalEnumerator(graph2))
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns an enumerator that iterates through graph vertices using breadth-first traversal
        /// </summary>
        /// <returns>The sequence of graph vertices number values</returns>
        public static IEnumerable GetBreadthFirstTraversalEnumerator(int[,] graphAdjacencyMatrix)
        {
            if (graphAdjacencyMatrix is null)
            {
                yield break;
            }

            if (graphAdjacencyMatrix.Rank != 2 || graphAdjacencyMatrix.GetLength(0) != graphAdjacencyMatrix.GetLength(1))
            {
                throw new ArgumentException("Graph must be specified as 2D square array (adjacency matrix)", nameof(graphAdjacencyMatrix));
            }

            if (graphAdjacencyMatrix.GetLength(0) == 0)
            {
                yield break;
            }

            bool[] visitedVertices = new bool[graphAdjacencyMatrix.GetLength(0)];

            while (true)
            {
                int firstUnvisitedVertex = GetFirstUnvisitedVertex(visitedVertices);

                if (firstUnvisitedVertex != -1)
                {
                    Queue<int> queue = new();
                    queue.Enqueue(firstUnvisitedVertex);

                    while (queue.Count > 0)
                    {
                        int currentVertex = queue.Dequeue();

                        if (visitedVertices[currentVertex])
                        {
                            continue;
                        }

                        visitedVertices[currentVertex] = true;

                        for (int i = 0; i < graphAdjacencyMatrix.GetLength(0); i++)
                        {
                            if (visitedVertices[i])
                            {
                                continue;
                            }

                            if (graphAdjacencyMatrix[currentVertex, i] != 0)
                            {
                                queue.Enqueue(i);
                            }
                        }

                        yield return currentVertex;
                    }
                }
                else
                {
                    yield break;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through graph vertices using depth-first traversal
        /// </summary>
        /// <returns>The sequence of graph vertices number values</returns>
        public static IEnumerable GetDepthFirstTraversalEnumerator(int[,] graphAdjacencyMatrix)
        {
            if (graphAdjacencyMatrix is null)
            {
                yield break;
            }

            if (graphAdjacencyMatrix.Rank != 2 || graphAdjacencyMatrix.GetLength(0) != graphAdjacencyMatrix.GetLength(1))
            {
                throw new ArgumentException("Graph must be specified as 2D square array (adjacency matrix)", nameof(graphAdjacencyMatrix));
            }

            if (graphAdjacencyMatrix.GetLength(0) == 0)
            {
                yield break;
            }

            bool[] visitedVertices = new bool[graphAdjacencyMatrix.GetLength(0)];

            while (true)
            {
                int firstUnvisitedVertex = GetFirstUnvisitedVertex(visitedVertices);

                if (firstUnvisitedVertex != -1)
                {
                    Stack<int> stack = new();
                    stack.Push(firstUnvisitedVertex);

                    while (stack.Count > 0)
                    {
                        int currentVertex = stack.Pop();

                        if (visitedVertices[currentVertex])
                        {
                            continue;
                        }

                        visitedVertices[currentVertex] = true;

                        for (int i = graphAdjacencyMatrix.GetLength(0) - 1; i >= 0; i--)
                        {
                            if (visitedVertices[i])
                            {
                                continue;
                            }

                            if (graphAdjacencyMatrix[currentVertex, i] != 0)
                            {
                                stack.Push(i);
                            }
                        }

                        yield return currentVertex;
                    }
                }
                else
                {
                    yield break;
                }
            }
        }

        public static int GetFirstUnvisitedVertex(bool[] visitedVertices)
        {
            for (int i = 0; i < visitedVertices.Length; i++)
            {
                if (!visitedVertices[i])
                {
                    return i;
                }
            }

            return -1;
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
