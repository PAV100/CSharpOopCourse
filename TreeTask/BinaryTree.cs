using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public BinaryTree()
        {
        }

        public BinaryTree(T data)
        {
            root = new TreeNode<T>(data);
            count = 1;
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
                if (currentNode.data.CompareTo(data) > 0)
                {
                    if (currentNode.left is not null)
                    {
                        currentNode = currentNode.left;
                        continue;
                    }

                    currentNode.left = new TreeNode<T>(data);
                    break;
                }
                else
                {
                    if (currentNode.right is not null)
                    {
                        currentNode = currentNode.right;
                        continue;
                    }

                    currentNode.right = new TreeNode<T>(data);
                    break;
                }
            }

            count++;
        }

        /// <summary>
        /// Checks if the treee contains a given "data" value
        /// </summary>
        /// <returns> true if contains</returns>
        /// 
        public bool Contains(T data)
        {
            return GetNodeAndParent(data, out var parent) is not null;
        }

        private TreeNode<T> GetNodeAndParent(T data, out TreeNode<T> parent)
        {
            var treeEnumerator = GetDepthFirstTraversalEnumerator();

            parent = null;
            var currentNode = root;

            while (currentNode is not null)
            {
                if (currentNode.data.Equals(data))
                {
                    return currentNode;
                }

                if (currentNode.data.CompareTo(data) > 0)
                {
                    if (currentNode.left is not null)
                    {
                        parent = currentNode;
                        currentNode = currentNode.left;
                        continue;
                    }

                    return default;
                }

                if (currentNode.right is not null)
                {
                    parent = currentNode;
                    currentNode = currentNode.right;
                    continue;
                }

                return default;
            }

            return default;
        }

        /// <summary>
        /// Deletes a node with first occurrence of given "data" value from the tree
        /// First occurrence is determined by ???
        /// </summary>
        /// <returns> true if a node was deleted from the tree</returns>
        public bool DeleteFirstOccurrence(T data)
        {
            var nodeToDelete = GetNodeAndParent(data, out var nodeToDeleteParent);

            if (nodeToDelete is null) // no occurrence
            {
                return false;
            }

            if (nodeToDeleteParent is null && nodeToDelete.left is null && nodeToDelete.right is null) // only root
            {
                root = null;
                nodeToDelete = default;
                count--;
                return true;
            }

            if (nodeToDelete.left is null && nodeToDelete.right is null) // a leaf
            {
                if (nodeToDeleteParent.left is not null && nodeToDeleteParent.left.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.left = null;
                    nodeToDelete = default;
                    count--;
                    return true;
                }

                if (nodeToDeleteParent.right is not null && nodeToDeleteParent.right.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.right = null;
                    nodeToDelete = default;
                    count--;
                    return true;
                }
            }

            if (nodeToDelete.left is not null && nodeToDelete.right is null) // single child (left)
            {
                if (nodeToDeleteParent.left is not null && nodeToDeleteParent.left.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.left = nodeToDelete.left;
                    nodeToDelete = default;
                    count--;
                    return true;
                }

                if (nodeToDeleteParent.right is not null && nodeToDeleteParent.right.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.right = nodeToDelete.left;
                    nodeToDelete = default;
                    count--;
                    return true;
                }
            }

            if (nodeToDelete.left is null && nodeToDelete.right is not null) // single child (right)
            {
                if (nodeToDeleteParent.left is not null && nodeToDeleteParent.left.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.left = nodeToDelete.right;
                    nodeToDelete = default;
                    count--;
                    return true;
                }

                if (nodeToDeleteParent.right is not null && nodeToDeleteParent.right.Equals(nodeToDelete))
                {
                    nodeToDeleteParent.right = nodeToDelete.right;
                    nodeToDelete = default;
                    count--;
                    return true;
                }
            }

            if (nodeToDelete.left is not null && nodeToDelete.right is not null) // both children
            {
            }



            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using breadth-first traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        public IEnumerator<T> GetBreadthFirstTraversalEnumerator()
        {
            Queue<TreeNode<T>> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                if (currentNode.left is not null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right is not null)
                {
                    queue.Enqueue(currentNode.right);
                }

                yield return currentNode.data;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through binary tree nodes using depth-first traversal
        /// </summary>
        /// <returns>tree node data field value</returns>
        public IEnumerator<T> GetDepthFirstTraversalEnumerator()
        {
            Stack<TreeNode<T>> stack = new();

            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                if (currentNode.right is not null)
                {
                    stack.Push(currentNode.right);
                }

                if (currentNode.left is not null)
                {
                    stack.Push(currentNode.left);
                }

                yield return currentNode.data;
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
        public IEnumerator<T> GetDepthFirstTraversalRecursiveEnumerator(TreeNode<T> node)
        {
            yield return node.data;

            if (node.left is not null)
            {
                var leftChildEnumerator = GetDepthFirstTraversalRecursiveEnumerator(node.left);

                //foreach (var e in leftChildEnumerator) // does not work
                //{
                //    yield return leftChildEnumerator.Current;
                //}

                while (leftChildEnumerator.MoveNext())
                {
                    yield return leftChildEnumerator.Current;
                }
            }

            if (node.right is not null)
            {
                var rightChildEnumerator = GetDepthFirstTraversalRecursiveEnumerator(node.right);

                while (rightChildEnumerator.MoveNext())
                {
                    yield return rightChildEnumerator.Current;
                }
            }
        }

        /// <summary>
        /// Returns an array containing binary tree nodes using breadth-first traversal
        /// </summary>
        /// <returns>tree node data field values array</returns>
        [Obsolete]
        public T[] BreadthFirstTraversal()
        {
            if (count == 0)
            {
                return Array.Empty<T>();
            }

            if (count == 1)
            {
                return new T[] { root.data };
            }

            T[] treeNodes = new T[count];
            int index = 0;

            Queue<TreeNode<T>> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                treeNodes[index] = currentNode.data;
                index++;

                if (currentNode.left is not null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right is not null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }

            return treeNodes;
        }

        /// <summary>
        /// Returns an array containing binary tree nodes using depth-first traversal
        /// </summary>
        /// <returns>tree node data field values array</returns>
        [Obsolete]
        public T[] DepthFirstTraversal()
        {
            if (count == 0)
            {
                return Array.Empty<T>();
            }

            if (count == 1)
            {
                return new T[] { root.data };
            }

            T[] treeNodes = new T[count];
            int index = 0;

            Stack<TreeNode<T>> stack = new();

            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                treeNodes[index] = currentNode.data;
                index++;

                if (currentNode.right is not null)
                {
                    stack.Push(currentNode.right);
                }

                if (currentNode.left is not null)
                {
                    stack.Push(currentNode.left);
                }
            }

            return treeNodes;
        }

        /// <summary>
        /// Returns an array containing binary tree nodes using depth-first recursive traversal
        /// </summary>
        /// <returns>tree node data field values array</returns>
        [Obsolete]
        public T[] DepthFirstTraversalRecursive()
        {
            if (count == 0)
            {
                return Array.Empty<T>();
            }

            if (count == 1)
            {
                return new T[] { root.data };
            }

            T[] treeNodes = new T[count];
            int index = 0;

            DepthFirstTraversalRecursive(treeNodes, root, ref index);

            return treeNodes;
        }

        private void DepthFirstTraversalRecursive(T[] treeNodes, TreeNode<T> node, ref int index)
        {
            treeNodes[index] = node.data;
            index++;

            if (node.left is not null)
            {
                DepthFirstTraversalRecursive(treeNodes, node.left, ref index);
            }

            if (node.right is not null)
            {
                DepthFirstTraversalRecursive(treeNodes, node.right, ref index);
            }
        }

        /// <summary>
        /// Returns a binary tree structure
        /// </summary>
        /// <returns>a string with line separators</returns>
        public override string ToString()
        {
            if (count == 0)
            {
                return "<empty>";
            }

            if (count == 1)
            {
                return root.data.ToString();
            }

            List<string> treePrintout = new(GetTreeHeight() + 1);

            for (int i = 0; i < treePrintout.Capacity; i++)
            {
                treePrintout.Insert(0, "");
            }

            GetTreeLevelPrintout(treePrintout);

            treePrintout.RemoveAt(treePrintout.Count - 1);

            StringBuilder sb = new StringBuilder();

            foreach (string s in treePrintout)
            {
                sb.Append(s).Append(Environment.NewLine);
            }

            sb.Remove(sb.Length - Environment.NewLine.Length, Environment.NewLine.Length);

            return sb.ToString();
        }

        private string GetTreeLevelPrintout(List<string> treePrintout)
        {
            return GetTreeLevelPrintout(treePrintout, root, 0, out int centralSymbolIndex);
        }

        private string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> node, int nodeLevel, out int centralSymbolIndex)
        {
            if (node is null)
            {
                centralSymbolIndex = 0;
                return "";
            }

            string leftChildData = null;
            int leftChildCenteralSymbolIndex = 0;

            if (node.left is not null)
            {
                leftChildData = GetTreeLevelPrintout(treePrintout, node.left, nodeLevel + 1, out leftChildCenteralSymbolIndex);

                if (node.right is not null)
                {
                    AppendSpacesToLowerLevelLines(treePrintout, nodeLevel + 2);
                }
            }

            string rightChildData = null;
            int rightChildCentralSymbolIndex = 0;

            if (node.right is not null)
            {
                rightChildData = GetTreeLevelPrintout(treePrintout, node.right, nodeLevel + 1, out rightChildCentralSymbolIndex);
            }

            string thisLine;
            string childrenLine;
            string thisNodeData;

            if (node.data is null)
            {
                thisNodeData = "<null>";
            }
            else if (node.data.ToString().Equals(""))
            {
                thisNodeData = "<empty>";
            }
            else
            {
                thisNodeData = node.data.ToString();
            }

            FormThisAndChildrenLines(thisNodeData, leftChildData, leftChildCenteralSymbolIndex, rightChildData, rightChildCentralSymbolIndex, out thisLine, out centralSymbolIndex, out childrenLine);

            if (nodeLevel == 0)
            {
                treePrintout[0] = thisLine;
            }

            treePrintout[nodeLevel + 1] = treePrintout[nodeLevel + 1] + childrenLine;

            int emptySymbolsCount = rightChildData is null ? 0 : childrenLine.IndexOf(rightChildData);

            if (node.left is null && rightChildData is not null && emptySymbolsCount != 0)
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

        private int GetTreeHeight(TreeNode<T> node, int nodeLevel)
        {

            int leftChildHeight = 0;

            if (node.left is not null)
            {
                leftChildHeight = GetTreeHeight(node.left, nodeLevel + 1);
            }

            int rightChildHeight = 0;

            if (node.right is not null)
            {
                rightChildHeight = GetTreeHeight(node.right, nodeLevel + 1);
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

            int childCapPlaceholdersCount;
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
                    childCapPlaceholdersCount = childrenInternalSymbolsCount - thisNodeData.Length;
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
                    treePrintout[i] = treePrintout[i] + new string(' ', treePrintout[nodeLevel].Length - treePrintout[i].Length);
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
