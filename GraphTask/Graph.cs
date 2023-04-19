using System;
using System.Collections.Generic;

namespace GraphTask
{
    internal class Graph
    {
        private readonly int[,] adjacencyMatrix;

        public Graph(int[,] adjacencyMatrix)
        {
            if (adjacencyMatrix is null)
            {
                throw new ArgumentNullException(nameof(adjacencyMatrix), "Adjacency matrix must not be null");
            }

            int verticesCount = adjacencyMatrix.GetLength(0);
            int columnsCount = adjacencyMatrix.GetLength(1);

            if (verticesCount != columnsCount)
            {
                throw new ArgumentException($"Adjacency matrix size is {verticesCount} x {columnsCount}, but it must be square", nameof(adjacencyMatrix));
            }

            if (verticesCount == 0)
            {
                throw new ArgumentException("Adjacency matrix is empty, but it must contain at least one vertex", nameof(adjacencyMatrix));
            }

            this.adjacencyMatrix = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    this.adjacencyMatrix[i, j] = adjacencyMatrix[i, j];
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through graph vertices using breadth-first traversal
        /// </summary>
        /// <returns>The sequence of graph vertices number values</returns>
        public IEnumerable<int> BreadthFirstTraversal()
        {
            bool[] visitedVertices = new bool[adjacencyMatrix.GetLength(0)];

            Queue<int> queue = new();

            for (int i = 0; i < visitedVertices.Length; i++)
            {
                if (visitedVertices[i])
                {
                    continue;
                }

                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int currentVertex = queue.Dequeue();

                    if (visitedVertices[currentVertex])
                    {
                        continue;
                    }

                    visitedVertices[currentVertex] = true;

                    for (int j = 0; j < adjacencyMatrix.GetLength(0); j++)
                    {
                        if (!visitedVertices[j] && adjacencyMatrix[currentVertex, j] != 0)
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
        public IEnumerable<int> DepthFirstTraversal()
        {
            bool[] visitedVertices = new bool[adjacencyMatrix.GetLength(0)];

            Stack<int> stack = new();

            for (int i = 0; i < visitedVertices.Length; i++)
            {
                if (visitedVertices[i])
                {
                    continue;
                }

                stack.Push(i);

                while (stack.Count > 0)
                {
                    int currentVertex = stack.Pop();

                    if (visitedVertices[currentVertex])
                    {
                        continue;
                    }

                    visitedVertices[currentVertex] = true;

                    for (int j = adjacencyMatrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (!visitedVertices[j] && adjacencyMatrix[currentVertex, j] != 0)
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

            foreach (int e in adjacencyMatrix)
            {
                if (maxEdgeWeightSymbolsCount < e.ToString().Length)
                {
                    maxEdgeWeightSymbolsCount = e.ToString().Length;
                }
            }

            int firstColumnSymbolsCount = (adjacencyMatrix.GetLength(0) - 1).ToString().Length;
            int otherColumnsSymbolsCount = Math.Max(maxEdgeWeightSymbolsCount, (adjacencyMatrix.GetLength(1) - 1).ToString().Length);

            string firstColumnFormat = "{0," + firstColumnSymbolsCount + "} ";
            string otherColumnsFormat = "{0," + otherColumnsSymbolsCount + "} ";

            Console.Write($"{new string(' ', firstColumnSymbolsCount)} ");

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                Console.Write(otherColumnsFormat, i);
            }

            Console.WriteLine();

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                Console.Write(firstColumnFormat, i);

                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(otherColumnsFormat, adjacencyMatrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
