using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    public class BinaryTree<T>
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
            if (count == 0)
            {
                root = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 1)
            {
                root.left = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 2)
            {
                root.right = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 3)
            {
                root.left.left = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 4)
            {
                root.left.right = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 5)
            {
                root.right.left = new TreeNode<T>(data);
                count++;
                return;
            }

            if (count == 6)
            {
                root.right.right = new TreeNode<T>(data);
                count++;
                return;
            }
        }

        public int Contain(T data)
        {
            string s = "1";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = "10";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = "100";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = "1000";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = "(1000 ";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = " 1000)";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");
            s = " 10000)";
            Console.WriteLine($"{s} c={GetCentralSymbolIndex(s)} l={GetSymbolsCountToLeftFromCentralSymbol(s)} r={GetSymbolsCountToRightFromCentralSymbol(s)}");

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

            List<string> treePrintout = new();

            GetTreeLevelPrintout(treePrintout, root);

            StringBuilder sb = new StringBuilder();

            foreach (string s in treePrintout)
            {
                sb.Append(s).Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> node, int nodeLevel, out int symbolsCountToLeftFromCentralSymbol, out int symbolsCountToRightFromCentralSymbol)
        {
            if (node is null)
            {
                symbolsCountToLeftFromCentralSymbol = 0;
                symbolsCountToRightFromCentralSymbol = 0;
                return "";
            }

            string leftChildCap = "┌";
            string childCapPlaceholder = "─";
            string rightChildCap = "┐";

            string childrenDelimiter = " ";

            // TODO: check all arguments for null                       

            // Check and create an empty string for level nodeLevel
            if (treePrintout.Count <= nodeLevel)
            {
                treePrintout.Insert(nodeLevel, "");
            }

            string thisNodeData = node.data.ToString() == "" ? "<empty>" : node.data.ToString();

            if (node.left is null && node.right is null) // If no children - stop recursion
            {
                if (nodeLevel == 0)
                {
                    treePrintout[0] = thisNodeData;
                }

                symbolsCountToLeftFromCentralSymbol = GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);
                symbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromCentralSymbol(thisNodeData);
                return thisNodeData;
            }

            if (treePrintout.Count == nodeLevel)
            {
                treePrintout.Insert(nodeLevel + 1, ""); // If there are children - create an empty string for level nodeLevel + 1
            }

            int leftChildSymbolsCountToLeftFromCentralSymbol = 0;
            int leftChildSymbolsCountToRightFromCentralSymbol = 0;
            int rightChildSymbolsCountToLeftFromCentralSymbol = 0;
            int rightChildSymbolsCountToRightFromCentralSymbol = 0;

            string leftChildData = "";

            if (node.left is not null)
            {
                //leftChildData = GetTreeLevelPrintout(treePrintout, node.left, nodeLevel + 1);
                leftChildData = GetTreeLevelPrintout(treePrintout, node.left, nodeLevel + 1, out leftChildSymbolsCountToLeftFromCentralSymbol, out leftChildSymbolsCountToRightFromCentralSymbol);
            }

            string rightChildData = "";

            if (node.right is not null)
            {
                rightChildData = GetTreeLevelPrintout(treePrintout, node.right, nodeLevel + 1, out rightChildSymbolsCountToLeftFromCentralSymbol, out rightChildSymbolsCountToRightFromCentralSymbol);
            }

            // Control stream will be here when method(s) return(s) a child (or children) data

            string childrenLine = "";
            int childrenLineLength;

            string parentLine = "";
            int parentLineLength;
            int childCapPlaceholdersCount;
            int childCapPlaceholdersCountToLeftFromParent;
            int childCapPlaceholdersCountToRightFromParent;

            symbolsCountToLeftFromCentralSymbol = 0;
            symbolsCountToRightFromCentralSymbol = 0;

            if (node.left is not null && node.right is not null)
            {
                childrenLine = leftChildData + childrenDelimiter + rightChildData;
                childrenLineLength = childrenLine.Length;

                parentLineLength = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length
                    + thisNodeData.Length
                    + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length
                    + thisNodeData.Length
                    + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol);
                childCapPlaceholdersCountToLeftFromParent = childCapPlaceholdersCount / 2;
                childCapPlaceholdersCountToRightFromParent = childCapPlaceholdersCount - childCapPlaceholdersCountToLeftFromParent;

                if (childrenLineLength >= parentLineLength)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol) + leftChildCap + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromParent)
                   + thisNodeData
                   + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromParent) + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    symbolsCountToLeftFromCentralSymbol = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + childCapPlaceholdersCountToLeftFromParent
                        + GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);

                    symbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromCentralSymbol(thisNodeData)
                        + childCapPlaceholdersCountToRightFromParent + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;
                }
                else  // if (childrenLineLength < parentLineLength)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol) + leftChildCap + thisNodeData + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    int childrenDelimitersCount = parentLineLength - leftChildData.Length - rightChildData.Length;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenDelimitersCount) + rightChildData;

                    symbolsCountToLeftFromCentralSymbol = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);

                    symbolsCountToRightFromCentralSymbol = GetSymbolsCountToLeftFromCentralSymbol(thisNodeData) + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i] = treePrintout[i].Insert(leftChildData.Length, new string(childrenDelimiter[0], childrenDelimitersCount - 1));
                    }
                }
            }

            if (node.left is not null && node.right is null)
            {
                childrenLine = leftChildData;
                childrenLineLength = childrenLine.Length;

                parentLineLength = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + thisNodeData.Length;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + thisNodeData.Length);
                childCapPlaceholdersCountToLeftFromParent = childCapPlaceholdersCount;

                if (childrenLineLength >= parentLineLength)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol) + leftChildCap + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromParent)
             + thisNodeData;

                    symbolsCountToLeftFromCentralSymbol = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + childCapPlaceholdersCountToLeftFromParent
                        + GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);
                    symbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromCentralSymbol(thisNodeData);
                }
                else  // if (childrenLineLength < parentLineLength)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentralSymbol) + leftChildCap + thisNodeData;

                    int childrenDelimitersCount = parentLineLength - leftChildData.Length;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenDelimitersCount);

                    symbolsCountToLeftFromCentralSymbol = leftChildSymbolsCountToLeftFromCentralSymbol + leftChildCap.Length + GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i] = treePrintout[i].Insert(leftChildData.Length, new string(childrenDelimiter[0], childrenDelimitersCount - 1));
                    }
                }
            }

            if (node.left is null && node.right is not null)
            {
                childrenLine = rightChildData;
                childrenLineLength = childrenLine.Length;

                parentLineLength = thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol);
                childCapPlaceholdersCountToRightFromParent = childCapPlaceholdersCount;

                if (childrenLineLength >= parentLineLength)
                {
                    parentLine = thisNodeData
                  + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromParent) + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    symbolsCountToLeftFromCentralSymbol = GetSymbolsCountToLeftFromCentralSymbol(thisNodeData);
                    symbolsCountToRightFromCentralSymbol = GetSymbolsCountToRightFromCentralSymbol(thisNodeData)
                        + childCapPlaceholdersCountToRightFromParent + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;
                }
                else  // if (childrenLineLength < parentLineLength)
                {
                    parentLine = thisNodeData + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentralSymbol);

                    int childrenDelimitersCount = parentLineLength - rightChildData.Length;
                    childrenLine = new string(childrenDelimiter[0], childrenDelimitersCount) + rightChildData;

                    symbolsCountToRightFromCentralSymbol = GetSymbolsCountToLeftFromCentralSymbol(thisNodeData) + rightChildCap.Length + rightChildSymbolsCountToRightFromCentralSymbol;

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i] = treePrintout[i].Insert(0, new string(childrenDelimiter[0], childrenDelimitersCount - 1));
                    }
                }
            }

            if (nodeLevel == 0)
            {
                treePrintout[nodeLevel] = treePrintout[nodeLevel] + parentLine;
            }

            treePrintout[nodeLevel + 1] = treePrintout[nodeLevel + 1] + childrenLine + childrenDelimiter;

            return parentLine;
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

            return GetTreeLevelPrintout(treePrintout, root, 0, out int l, out int r);
        }

        public int GetCentralSymbolIndex(string data)
        {
            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) / 2;
        }

        public int GetSymbolsCountToLeftFromCentralSymbol(string data)
        {
            return GetCentralSymbolIndex(data);
        }

        public int GetSymbolsCountToRightFromCentralSymbol(string data)
        {
            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) - GetCentralSymbolIndex(data);
        }
    }
}
