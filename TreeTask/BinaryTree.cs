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

        public int Contain(T data)
        {
            return 0;
        }

        public bool DeleteFirstOccurence(T data)
        {
            return false;
        }

        public T[] BreadthFirstTraversal()
        {
            return null;
        }

        public T[] DepthFirstTraversal()
        {
            return null;
        }

        public T[] DepthFirstTraversalRecursive()
        {
            return null;
        }

        public override string ToString()
        {
            if (count == 0)
            {
                return "";
            }

            List<string> treePrintout = new(GetTreeHeight() + 1);

            for (int i = 0; i < treePrintout.Capacity; i++)
            {
                treePrintout.Insert(0, "");
            }

            GetTreeLevelPrintout(treePrintout, root);

            StringBuilder sb = new StringBuilder();

            foreach (string s in treePrintout)
            {
                sb.Append(s).Append(Environment.NewLine);
            }

            return sb.ToString();
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
                    AppendLowerLevelLines(treePrintout, nodeLevel + 2);
                }
            }

            string rightChildData = null;
            int rightChildCentralSymbolIndex = 0;

            if (node.right is not null)
            {
                rightChildData = GetTreeLevelPrintout(treePrintout, node.right, nodeLevel + 1, out rightChildCentralSymbolIndex);
            }

            string parentLine;
            string childrenLine;
            string thisNodeData = node.data is null ? "<null>" : node.data.ToString();

            FormParentAndChildrenLines(thisNodeData, leftChildData, leftChildCenteralSymbolIndex, rightChildData, rightChildCentralSymbolIndex, out parentLine, out centralSymbolIndex, out childrenLine);

            if (nodeLevel == 0)
            {
                treePrintout[0] = parentLine;
            }

            treePrintout[nodeLevel + 1] = treePrintout[nodeLevel + 1] + childrenLine;

            int emptySymbolsCounty = rightChildData is null ? 0 : childrenLine.IndexOf(rightChildData);

            if (node.left is null && rightChildData is not null && emptySymbolsCounty != 0)
            {
                // TODO: check here
                MoveEndSymbols(treePrintout, nodeLevel + 1, rightChildData.Length + 1, emptySymbolsCounty);
            }

            //Console.WriteLine($"lvl={nodeLevel} par=\"{parentLine}\" chl=\"{childrenLine}\" chl.len={childrenLine.Length}");            

            return parentLine;
        }

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
            //return Math.Max(leftChildHeight, rightChildHeight);
        }

        private string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> root)
        {
            if (root is null)
            {
                // TODO:
                throw new ArgumentNullException();
            }

            if (!this.root.Equals(root))
            {
                // TODO:
                throw new ArgumentException();
            }

            return GetTreeLevelPrintout(treePrintout, root, 0, out int i);
        }

        public static void FormParentAndChildrenLines(string thisNodeData, string leftChildData, int leftChildCentralSymbolIndex, string rightChildData, int rightChildCentralSymbolIndex, out string thisNodeLine, out int thisNodeCentralSymbolIndex, out string childrenLine)
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

        private void AppendLowerLevelLines(List<string> treePrintout, int nodeLevel)
        {
            if (treePrintout.Count <= nodeLevel)
            {
                throw new NotImplementedException();
            }

            for (int i = nodeLevel + 1; i < treePrintout.Count; i++)
            {
                if (treePrintout[i].Length < treePrintout[nodeLevel].Length)
                {
                    treePrintout[i] = treePrintout[i] + new string(' ', treePrintout[nodeLevel].Length - treePrintout[i].Length);
                }
            }
        }

        private void ShiftLowerLevelLines(List<string> treePrintout, int nodeLevel)
        {
            if (treePrintout.Count <= nodeLevel)
            {
                throw new NotImplementedException();
            }

            for (int i = nodeLevel + 1; i < treePrintout.Count; i++)
            {
                if (treePrintout[i].Length < treePrintout[nodeLevel].Length)
                {
                    treePrintout[i] = new string(' ', treePrintout[nodeLevel].Length - treePrintout[i].Length) + treePrintout[i];
                }
            }
        }

        // TODO: check here
        private void MoveEndSymbols(List<string> treePrintout, int nodeLevel, int endSymbolsCount, int movePositionsCount)
        {
            if (treePrintout.Count <= nodeLevel)
            {
                throw new NotImplementedException();
            }

            int insertSymbolIndex = treePrintout[nodeLevel + 1].Length - 0 - endSymbolsCount;

            for (int i = nodeLevel + 1; i < treePrintout.Count; i++)
            {
                treePrintout[i] = treePrintout[i].Insert(insertSymbolIndex, new string(' ', movePositionsCount));
            }
        }

        private void AlignLowerLevelLines(List<string> treePrintout)
        {
            int maxLengthNodeIndex = 0;

            for (int i = 0; i < treePrintout.Count; i++)
            {
                if (treePrintout[i].Length > treePrintout[maxLengthNodeIndex].Length)
                {
                    maxLengthNodeIndex = i;
                }
            }

            for (int i = maxLengthNodeIndex + 1; i < treePrintout.Count; i++)
            {
                treePrintout[i] = treePrintout[i] + new string(' ', treePrintout[maxLengthNodeIndex].Length - treePrintout[i].Length);
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
