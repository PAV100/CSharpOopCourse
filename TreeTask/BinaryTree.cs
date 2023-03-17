using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    public class BinaryTree<T>
    {
        private TreeNode<T> root;

        public int Count { get; private set; }

        public IComparer<T> Comparer { get; }

        public BinaryTree(T data)
        {
            root = new TreeNode<T>(data);
            Count = 1;
        }

        public BinaryTree(IComparer<T> comparer, T data)
        {
            root = new TreeNode<T>(data);
            Count = 1;
            Comparer = comparer;
        }

        private int Compare(T data1, T data2)
        {
            if (Comparer is not null)
            {
                return Comparer.Compare(data1, data2);
            }

            if (data1 is null && data2 is null)
            {
                return 0;
            }

            if (data1 is null)
            {
                return -1;
            }

            if (data2 is null)
            {
                return 1;
            }

            IComparable<T> comparableData1 = data1 as IComparable<T>;

            if (comparableData1 is null) // casting and comparing is impossible
            {
                throw new ArgumentException($"The values: {data1} {data2} can not be compared. Use comparable types or constructor with comparator.", nameof(data1) + ", " + nameof(data2));
            }

            return comparableData1.CompareTo(data2);
        }

        /// <summary>
        /// Inserts new node into the tree and fills it with "data" value
        /// </summary>
        /// <returns>nothing</returns>
        public void Insert(T data)
        {
            TreeNode<T> currentNode = root;

            while (true)
            {
                if (Compare(currentNode.Data, data) > 0)
                {
                    if (currentNode.Left is not null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }

                    currentNode.Left = new TreeNode<T>(data);
                    break;
                }
                else
                {
                    if (currentNode.Right is not null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }

                    currentNode.Right = new TreeNode<T>(data);
                    break;
                }
            }

            Count++;
        }

        /// <summary>
        /// Checks if the treee contains a given "data" value
        /// </summary>
        /// <returns> true if contains</returns>
        /// 
        public bool Contains(T data)
        {
            return GetNodeAndParentByData(data).node is not null;
        }

        // private TreeNode<T> GetNodeAndParentByData(T data, out TreeNode<T> parent)
        private (TreeNode<T> node, TreeNode<T> parentNode) GetNodeAndParentByData(T data)
        {
            (TreeNode<T> node, TreeNode<T> parentNode) nodeAndParent = (root, null);

            while (nodeAndParent.node is not null)
            {
                int compareResult = Compare(nodeAndParent.node.Data, data);

                if (compareResult == 0)
                {
                    return nodeAndParent;
                }

                if (compareResult > 0)
                {
                    if (nodeAndParent.node.Left is not null)
                    {
                        nodeAndParent = (nodeAndParent.node.Left, nodeAndParent.node);
                        continue;
                    }

                    return (null, null);
                }

                if (nodeAndParent.node.Right is not null)
                {
                    nodeAndParent = (nodeAndParent.node.Right, nodeAndParent.node);
                    continue;
                }

                return (null, null);
            }

            return (null, null);
        }

        /// <summary>
        /// Deletes a node with first occurrence of given "data" value from the tree.        
        /// </summary>
        /// <returns> true if a node was deleted from the tree</returns>
        public bool DeleteFirstOccurrence(T data)
        {
            var nodeAndParentToDelete = GetNodeAndParentByData(data);

            if (nodeAndParentToDelete.node is null) // no occurrence
            {
                return false;
            }

            if (nodeAndParentToDelete.node.Left is null && nodeAndParentToDelete.node.Right is null) // a leaf (including only root)
            {
                SetNewChild(nodeAndParentToDelete.parentNode, nodeAndParentToDelete.node, default);
                Count--;
                return true;
            }

            if (nodeAndParentToDelete.node.Right is null) // node with left subtree
            {
                SetNewChild(nodeAndParentToDelete.parentNode, nodeAndParentToDelete.node, nodeAndParentToDelete.node.Left);
                Count--;
                return true;
            }

            if (nodeAndParentToDelete.node.Left is null) // node with right subtree
            {
                SetNewChild(nodeAndParentToDelete.parentNode, nodeAndParentToDelete.node, nodeAndParentToDelete.node.Right);
                Count--;
                return true;
            }

            // both children
            var mostLeftNodeAndParent = GetMostLeftNodeAndParentFromRightSubtree(nodeAndParentToDelete.node);

            mostLeftNodeAndParent.node.Left = nodeAndParentToDelete.node.Left;

            SetNewChild(nodeAndParentToDelete.parentNode, nodeAndParentToDelete.node, mostLeftNodeAndParent.node);

            if (nodeAndParentToDelete.node.Right != mostLeftNodeAndParent.node) // If most left node is not right child of node to delete
            {
                var mostLeftNodeRightChild = mostLeftNodeAndParent.node.Right;
                mostLeftNodeAndParent.node.Right = nodeAndParentToDelete.node.Right;
                SetNewChild(mostLeftNodeAndParent.parentNode, mostLeftNodeAndParent.node, mostLeftNodeRightChild);
            }

            Count--;
            return true;
        }

        private static bool IsLeftChild(TreeNode<T> parentNode, TreeNode<T> node)
        {
            if (node is null || parentNode is null)
            {
                return false;
            }

            return node == parentNode.Left;
        }

        private static bool IsRightChild(TreeNode<T> parentNode, TreeNode<T> node)
        {
            if (node is null || parentNode is null)
            {
                return false;
            }

            return node == parentNode.Right;
        }

        private bool SetNewChild(TreeNode<T> parent, TreeNode<T> currentChild, TreeNode<T> newChild)
        {
            if (parent is null && root == currentChild)
            {
                root = newChild;
                return true;
            }

            if (IsLeftChild(parent, currentChild))
            {
                parent.Left = newChild;
                return true;
            }

            if (IsRightChild(parent, currentChild))
            {
                parent.Right = newChild;
                return true;
            }

            return false;
        }

        private static (TreeNode<T> node, TreeNode<T> parentNode) GetMostLeftNodeAndParentFromRightSubtree(TreeNode<T> node)
        {
            (TreeNode<T> node, TreeNode<T> parentNode) mostLeftNodeAndParent = (null, null);

            if (node is null || node.Right is null)
            {
                return mostLeftNodeAndParent;
            }

            mostLeftNodeAndParent = (node.Right, node);

            while (mostLeftNodeAndParent.node.Left is not null)
            {
                mostLeftNodeAndParent = (mostLeftNodeAndParent.node.Left, mostLeftNodeAndParent.node);
            }

            return mostLeftNodeAndParent;
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using breadth-first traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        public IEnumerator<T> GetBreadthFirstTraversalEnumerator()
        {
            if (root is null)
            {
                yield break;
            }

            Queue<TreeNode<T>> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                if (currentNode.Left is not null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right is not null)
                {
                    queue.Enqueue(currentNode.Right);
                }

                yield return currentNode.Data;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using depth-first traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        public IEnumerator<T> GetDepthFirstTraversalEnumerator()
        {
            if (root is null)
            {
                yield break;
            }

            Stack<TreeNode<T>> stack = new();

            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                if (currentNode.Right is not null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left is not null)
                {
                    stack.Push(currentNode.Left);
                }

                yield return currentNode.Data;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using breadth-first recursive traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        public IEnumerator<T> GetDepthFirstTraversalRecursiveEnumerator()
        {
            return GetDepthFirstTraversalRecursiveEnumerator(root);
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using breadth-first recursive traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        private static IEnumerator<T> GetDepthFirstTraversalRecursiveEnumerator(TreeNode<T> node)
        {
            if (node is null)
            {
                yield break;
            }

            yield return node.Data;

            if (node.Left is not null)
            {
                var leftChildEnumerator = GetDepthFirstTraversalRecursiveEnumerator(node.Left);

                //foreach (var e in leftChildEnumerator) // does not work
                //{
                //    yield return leftChildEnumerator.Current;
                //}

                while (leftChildEnumerator.MoveNext())
                {
                    yield return leftChildEnumerator.Current;
                }
            }

            if (node.Right is not null)
            {
                var rightChildEnumerator = GetDepthFirstTraversalRecursiveEnumerator(node.Right);

                while (rightChildEnumerator.MoveNext())
                {
                    yield return rightChildEnumerator.Current;
                }
            }
        }

        /// <summary>
        /// Returns a binary tree structure
        /// </summary>
        /// <returns>a string with line separators</returns>
        public override string ToString()
        {
            if (Count == 0)
            {
                return "<empty>";
            }

            if (Count == 1)
            {
                return root.Data.ToString();
            }

            List<string> treePrintout = new(GetTreeHeight() + 1);

            for (int i = 0; i < treePrintout.Capacity; i++)
            {
                treePrintout.Insert(0, "");
            }

            GetTreeLevelPrintout(treePrintout);

            treePrintout.RemoveAt(treePrintout.Count - 1);

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, treePrintout));

            return sb.ToString();
        }

        private string GetTreeLevelPrintout(List<string> treePrintout)
        {
            return GetTreeLevelPrintout(treePrintout, root, 0, out int centralSymbolIndex);
        }

        private static string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> node, int nodeLevel, out int centralSymbolIndex)
        {
            if (node is null)
            {
                centralSymbolIndex = 0;
                return "";
            }

            string leftChildData = null;
            int leftChildCentralSymbolIndex = 0;

            if (node.Left is not null)
            {
                leftChildData = GetTreeLevelPrintout(treePrintout, node.Left, nodeLevel + 1, out leftChildCentralSymbolIndex);

                if (node.Right is not null)
                {
                    AppendSpacesToLowerLevelLines(treePrintout, nodeLevel + 2);
                }
            }

            string rightChildData = null;
            int rightChildCentralSymbolIndex = 0;

            if (node.Right is not null)
            {
                rightChildData = GetTreeLevelPrintout(treePrintout, node.Right, nodeLevel + 1, out rightChildCentralSymbolIndex);
            }

            string thisLine;
            string childrenLine;
            string thisNodeData;

            if (node.Data is null)
            {
                thisNodeData = "<null>";
            }
            else if (node.Data.ToString().Equals(""))
            {
                thisNodeData = "<empty>";
            }
            else
            {
                thisNodeData = node.Data.ToString();
            }

            FormThisAndChildrenLines(thisNodeData, leftChildData, leftChildCentralSymbolIndex, rightChildData, rightChildCentralSymbolIndex, out thisLine, out centralSymbolIndex, out childrenLine);

            if (nodeLevel == 0)
            {
                treePrintout[0] = thisLine;
            }

            treePrintout[nodeLevel + 1] += childrenLine;

            int emptySymbolsCount = rightChildData is null ? 0 : childrenLine.IndexOf(rightChildData);

            if (node.Left is null && rightChildData is not null && emptySymbolsCount != 0)
            {
                InsertSpacesToLowerLevelLines(treePrintout, nodeLevel + 1, rightChildData.Length + 1, emptySymbolsCount);
            }

            return thisLine;
        }

        /// <summary>
        /// Returns a number of tree levels (tree height)
        /// </summary>
        /// <returns>an integer number of tree levels </returns>
        public int GetTreeHeight()
        {
            return GetTreeHeight(root, 0) + 1;
        }

        private static int GetTreeHeight(TreeNode<T> node, int nodeLevel)
        {
            if (node is null)
            {
                return 0;
            }

            int leftChildHeight = 0;

            if (node.Left is not null)
            {
                leftChildHeight = GetTreeHeight(node.Left, nodeLevel + 1);
            }

            int rightChildHeight = 0;

            if (node.Right is not null)
            {
                rightChildHeight = GetTreeHeight(node.Right, nodeLevel + 1);
            }

            return Math.Max(nodeLevel, Math.Max(leftChildHeight, rightChildHeight));
        }

        private static void FormThisAndChildrenLines(string thisNodeData,
            string leftChildData, int leftChildCentralSymbolIndex,
            string rightChildData, int rightChildCentralSymbolIndex,
            out string thisNodeLine, out int thisNodeCentralSymbolIndex, out string childrenLine)
        {
            thisNodeLine = "";
            childrenLine = "";

            string leftChildCap = "┌";
            string childCapPlaceholder = "─";
            string rightChildCap = "┐";
            string childrenDelimiter = " ";

            //int childCapPlaceholdersCount;
            int childCapPlaceholdersCountToLeftFromThis = 0;
            int childCapPlaceholdersCountToRightFromThis;
            int childrenDelimitersCount;
            int childrenInternalSymbolsCount;

            int leftChildSymbolsCountToLeftFromCentralSymbol = GetSymbolsCountToLeftFromIndex(leftChildData, leftChildCentralSymbolIndex);
            int leftChildSymbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromIndex(leftChildData, leftChildCentralSymbolIndex);
            int rightChildSymbolsCountToLeftFromCentralSymbol = GetSymbolsCountToLeftFromIndex(rightChildData, rightChildCentralSymbolIndex);
            int rightChildSymbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromIndex(rightChildData, rightChildCentralSymbolIndex);

            thisNodeCentralSymbolIndex = 0;

            if (leftChildData is null && rightChildData is null)
            {
                thisNodeLine = thisNodeData;
                thisNodeCentralSymbolIndex = GetCentralSymbolIndex(thisNodeData);
                childrenLine = new string(' ', thisNodeData.Length) + childrenDelimiter;
                return;
            }

            if (leftChildData is not null && rightChildData is not null)
            {
                childrenInternalSymbolsCount = leftChildSymbolsCountToRightFromCentralSymbol + childrenDelimiter.Length + rightChildSymbolsCountToLeftFromCentralSymbol;

                if (thisNodeData.Length >= childrenInternalSymbolsCount)
                {
                    thisNodeLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol)
                        + leftChildCap
                        + thisNodeData
                        + rightChildCap
                        + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    childrenDelimitersCount = thisNodeData.Length - leftChildSymbolsCountToRightFromCentralSymbol - rightChildSymbolsCountToLeftFromCentralSymbol;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenDelimitersCount) + rightChildData + childrenDelimiter;
                }
                else // thisNodeData.Length < [sum of children]
                {
                    int childCapPlaceholdersCount = childrenInternalSymbolsCount - thisNodeData.Length;
                    childCapPlaceholdersCountToRightFromThis = childCapPlaceholdersCount / 2;
                    childCapPlaceholdersCountToLeftFromThis = childCapPlaceholdersCount - childCapPlaceholdersCountToRightFromThis;
                    thisNodeLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol)
                        + leftChildCap
                        + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromThis)
                        + thisNodeData
                        + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromThis)
                        + rightChildCap
                        + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    childrenLine = leftChildData + childrenDelimiter + rightChildData + childrenDelimiter;
                }

                thisNodeCentralSymbolIndex = leftChildSymbolsCountToLeftFromCentralSymbol
                    + leftChildCap.Length
                    + childCapPlaceholdersCountToLeftFromThis
                    + GetCentralSymbolIndex(thisNodeData);
                return;
            }

            if (leftChildData is null && rightChildData is not null)
            {
                childrenInternalSymbolsCount = rightChildSymbolsCountToLeftFromCentralSymbol;

                if (thisNodeData.Length >= childrenInternalSymbolsCount)
                {
                    thisNodeLine = thisNodeData
                        + rightChildCap
                        + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    childrenDelimitersCount = thisNodeData.Length - rightChildSymbolsCountToLeftFromCentralSymbol;
                    childrenLine = new string(childrenDelimiter[0], childrenDelimitersCount) + rightChildData + childrenDelimiter;
                }
                else // thisNodeData.Length < [sum of children]
                {
                    childCapPlaceholdersCountToRightFromThis = childrenInternalSymbolsCount - thisNodeData.Length;
                    thisNodeLine = thisNodeData
                        + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromThis)
                        + rightChildCap
                        + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    childrenLine = rightChildData + childrenDelimiter;
                }

                thisNodeCentralSymbolIndex = GetCentralSymbolIndex(thisNodeData);
                return;
            }

            if (leftChildData is not null && rightChildData is null)
            {
                childrenInternalSymbolsCount = leftChildSymbolsCountToRightFromCentralSymbol;

                if (thisNodeData.Length >= childrenInternalSymbolsCount)
                {
                    thisNodeLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol)
                        + leftChildCap
                        + thisNodeData;

                    childrenDelimitersCount = thisNodeData.Length - leftChildSymbolsCountToRightFromCentralSymbol;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenDelimitersCount) + childrenDelimiter;
                }
                else // thisNodeData.Length < [sum of children]
                {
                    childCapPlaceholdersCountToLeftFromThis = childrenInternalSymbolsCount - thisNodeData.Length;
                    thisNodeLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol)
                        + leftChildCap
                        + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromThis)
                        + thisNodeData;

                    childrenLine = leftChildData + new string(' ', thisNodeLine.Length - leftChildData.Length) + childrenDelimiter;
                }

                thisNodeCentralSymbolIndex = leftChildSymbolsCountToLeftFromCentralSymbol
                    + leftChildCap.Length
                    + childCapPlaceholdersCountToLeftFromThis
                    + GetCentralSymbolIndex(thisNodeData);
                return;
            }
        }

        private static void AppendSpacesToLowerLevelLines(List<string> treePrintout, int nodeLevel)
        {
            if (treePrintout.Count <= nodeLevel)
            {
                throw new ArgumentOutOfRangeException(nameof(nodeLevel), $"nodeLevel = {nodeLevel}, but it must be >= 0 and < {treePrintout.Count}");
            }

            for (int i = nodeLevel + 1; i < treePrintout.Count; i++)
            {
                if (treePrintout[i].Length < treePrintout[nodeLevel].Length)
                {
                    treePrintout[i] += new string(' ', treePrintout[nodeLevel].Length - treePrintout[i].Length);
                }
            }
        }

        private static void InsertSpacesToLowerLevelLines(List<string> treePrintout, int nodeLevel, int endSymbolsCount, int movePositionsCount)
        {
            if (treePrintout.Count <= nodeLevel)
            {
                throw new ArgumentOutOfRangeException(nameof(nodeLevel), $"nodeLevel = {nodeLevel}, but it must be >= 0 and < {treePrintout.Count}");
            }

            int insertSymbolIndex = treePrintout[nodeLevel + 1].Length - endSymbolsCount;

            for (int i = nodeLevel + 1; i < treePrintout.Count; i++)
            {
                treePrintout[i] = treePrintout[i].Insert(insertSymbolIndex, new string(' ', movePositionsCount));
            }
        }

        private static int GetCentralSymbolIndex(string data)
        {
            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) / 2;
        }

        private static int GetSymbolsCountToLeftFromIndex(string data, int index)
        {
            return index;
        }

        private static int GetSymbolsCountToRightFromIndex(string data, int index)
        {
            if (data is null)
            {
                return 0;
            }

            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) - index;
        }
    }
}
