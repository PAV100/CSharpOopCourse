using System;
using System.Collections.Generic;

namespace GraphTask
{
    internal class Graph
    {
        private int[,] AdjacencyMatrix { get; }

        public Graph(int[,] adjacencyMatrix)
        {
            if (adjacencyMatrix is null)
            {
                throw new ArgumentNullException(nameof(adjacencyMatrix), "Adjacency matrix must not be null");
            }

            int verticesCount = adjacencyMatrix.GetLength(0);

            if (verticesCount != adjacencyMatrix.GetLength(1) || verticesCount == 0)
            {
                throw new ArgumentException("Graph must be specified as square array (adjacency matrix) and contain at least one vertex", nameof(adjacencyMatrix));
            }

            AdjacencyMatrix = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    AdjacencyMatrix[i, j] = adjacencyMatrix[i, j];
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through graph vertices using breadth-first traversal
        /// </summary>
        /// <returns>The sequence of graph vertices number values</returns>
        public IEnumerable<int> GetBreadthFirstTraversal()
        {
            bool[] visitedVertices = new bool[AdjacencyMatrix.GetLength(0)];

            for (int i = 0; i < visitedVertices.Length; i++)
            {
                if (visitedVertices[i])
                {
                    continue;
                }

                Queue<int> queue = new();
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int currentVertex = queue.Dequeue();

                    if (visitedVertices[currentVertex])
                    {
                        continue;
                    }

                    visitedVertices[currentVertex] = true;

                    for (int j = 0; j < AdjacencyMatrix.GetLength(0); j++)
                    {
                        if (!visitedVertices[j] && AdjacencyMatrix[currentVertex, j] != 0)
                        {
                            queue.Enqueue(j);
                        }
                    }

                    yield return currentVertex;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through graph vertices using depth-first traversal
        /// </summary>
        /// <returns>The sequence of graph vertices number values</returns>
        public IEnumerable<int> GetDepthFirstTraversal()
        {
            bool[] visitedVertices = new bool[AdjacencyMatrix.GetLength(0)];

            for (int i = 0; i < visitedVertices.Length; i++)
            {
                if (visitedVertices[i])
                {
                    continue;
                }

                Stack<int> stack = new();
                stack.Push(i);

                while (stack.Count > 0)
                {
                    int currentVertex = stack.Pop();

                    if (visitedVertices[currentVertex])
                    {
                        continue;
                    }

                    visitedVertices[currentVertex] = true;

                    for (int j = AdjacencyMatrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (!visitedVertices[j] && AdjacencyMatrix[currentVertex, j] != 0)
                        {
                            stack.Push(j);
                        }
                    }

                    yield return currentVertex;
                }
            }
        }

        public void PrintToConsole()
        {
            int maxEdgeWeightSymbolsCount = 1;

            foreach (int e in AdjacencyMatrix)
            {
                if (maxEdgeWeightSymbolsCount < e.ToString().Length)
                {
                    maxEdgeWeightSymbolsCount = e.ToString().Length;
                }
            }

            int firstColumnSymbolsCount = (AdjacencyMatrix.GetLength(0) - 1).ToString().Length;
            int otherColumnsSymbolsCount = Math.Max(maxEdgeWeightSymbolsCount, (AdjacencyMatrix.GetLength(1) - 1).ToString().Length);

            string firstColumnFormat = "{0," + firstColumnSymbolsCount + "} ";
            string otherColumnsFormat = "{0," + otherColumnsSymbolsCount + "} ";

            Console.Write($"{new string(' ', firstColumnSymbolsCount)} ");

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                Console.Write(otherColumnsFormat, i);
            }

            Console.WriteLine();

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                Console.Write(firstColumnFormat, i);

                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(otherColumnsFormat, AdjacencyMatrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
