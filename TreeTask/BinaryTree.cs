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
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = "10";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = "100";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = "1000";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = "(1000 ";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = " 1000)";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");
            s = " 10000)";
            Console.WriteLine($"{s} c={GetCentralIndex(s)} l={GetSymbolsCountToLeftFromCentral(s)} r={GetSymbolsCountToRightFromCentral(s)}");

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

        private string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> node, int nodeLevel)
        {
            if (node is null)
            {
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
                //treePrintout[nodeLevel] = treePrintout[nodeLevel] + thisNodeData + childrenDelimiter;
                return thisNodeData;
            }

            if (treePrintout.Count == nodeLevel)
            {
                treePrintout.Insert(nodeLevel + 1, ""); // If there are children - create an empty string for level nodeLevel + 1
            }

            string leftChildData = "";

            if (node.left is not null)
            {
                leftChildData = GetTreeLevelPrintout(treePrintout, node.left, nodeLevel + 1);
            }

            string rightChildData = "";

            if (node.right is not null)
            {
                rightChildData = GetTreeLevelPrintout(treePrintout, node.right, nodeLevel + 1);
            }

            // Control stream will be here when method(s) return(s) a child (or children) data

            // Get line length of children and this node
            string childrenLine = "";
            int childrenLineLength = 0;
            int leftChildSymbolsCountToLeftFromCentral = 0;
            int leftChildSymbolsCountToRightFromCentral = 0;
            int rightChildSymbolsCountToLeftFromCentral = 0;
            int rightChildSymbolsCountToRightFromCentral = 0;

            string parentLine = "";
            int parentLineLength = 0;
            int childCapPlaceholdersCount = 0;
            int childCapPlaceholdersCountToLeftFromParent = 0;
            int childCapPlaceholdersCountToRightFromParent = 0;

            if (node.left is not null && node.right is not null)
            {
                childrenLine = leftChildData + childrenDelimiter + rightChildData;
                childrenLineLength = childrenLine.Length;

                leftChildSymbolsCountToLeftFromCentral = GetSymbolsCountToLeftFromCentral(leftChildData);
                rightChildSymbolsCountToRightFromCentral = GetSymbolsCountToRightFromCentral(rightChildData);
                parentLineLength = leftChildSymbolsCountToLeftFromCentral + leftChildCap.Length + thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentral;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (leftChildSymbolsCountToLeftFromCentral + leftChildCap.Length + thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentral);
                childCapPlaceholdersCountToLeftFromParent = childCapPlaceholdersCount / 2;
                childCapPlaceholdersCountToRightFromParent = childCapPlaceholdersCount - childCapPlaceholdersCountToLeftFromParent;
            }

            if (node.left is not null && node.right is null)
            {
                childrenLine = leftChildData;
                childrenLineLength = childrenLine.Length;

                leftChildSymbolsCountToLeftFromCentral = GetSymbolsCountToLeftFromCentral(leftChildData);
                parentLineLength = leftChildSymbolsCountToLeftFromCentral + leftChildCap.Length + thisNodeData.Length;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (leftChildSymbolsCountToLeftFromCentral + leftChildCap.Length + thisNodeData.Length);
                childCapPlaceholdersCountToLeftFromParent = childCapPlaceholdersCount;
            }

            if (node.left is null && node.right is not null)
            {
                childrenLine = rightChildData;
                childrenLineLength = childrenLine.Length;

                rightChildSymbolsCountToRightFromCentral = GetSymbolsCountToRightFromCentral(rightChildData);
                parentLineLength = thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentral;

                childCapPlaceholdersCount = Math.Max(parentLineLength, childrenLineLength)
                    - (thisNodeData.Length + rightChildCap.Length + rightChildSymbolsCountToRightFromCentral);
                childCapPlaceholdersCountToRightFromParent = childCapPlaceholdersCount;
            }

            if (childrenLineLength >= parentLineLength)
            {
                leftChildSymbolsCountToRightFromCentral = GetSymbolsCountToRightFromCentral(leftChildData + childrenDelimiter);
                rightChildSymbolsCountToLeftFromCentral = GetSymbolsCountToLeftFromCentral(childrenDelimiter + rightChildData);

                if (node.left is not null && node.right is not null)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentral) + leftChildCap + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromParent)
                    + thisNodeData
                    + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromParent) + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentral);
                }

                if (node.left is not null && node.right is null)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentral) + leftChildCap + new string(childCapPlaceholder[0], childCapPlaceholdersCountToLeftFromParent)
                    + thisNodeData;
                }

                if (node.left is null && node.right is not null)
                {
                    parentLine = thisNodeData
                    + new string(childCapPlaceholder[0], childCapPlaceholdersCountToRightFromParent) + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentral);
                }
            }
            else // if (childrenLineLength < parentLineLength)
            {
                if (node.left is not null && node.right is not null)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentral) + leftChildCap + thisNodeData + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentral);

                    childrenLineLength = parentLineLength - leftChildData.Length - rightChildData.Length;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenLineLength) + rightChildData;

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i].Insert(leftChildData.Length, new string(childrenDelimiter[0], parentLineLength - childrenLineLength - 1));
                    }
                }

                if (node.left is not null && node.right is null)
                {
                    parentLine = new string(' ', leftChildSymbolsCountToLeftFromCentral) + leftChildCap + thisNodeData;

                    childrenLineLength = parentLineLength - leftChildData.Length;
                    childrenLine = leftChildData + new string(childrenDelimiter[0], childrenLineLength);

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i].Insert(leftChildData.Length, new string(childrenDelimiter[0], parentLineLength - childrenLineLength - 1));
                    }
                }

                if (node.left is null && node.right is not null)
                {
                    parentLine = thisNodeData + rightChildCap + new string(' ', rightChildSymbolsCountToRightFromCentral);

                    childrenLineLength = parentLineLength - rightChildData.Length;
                    childrenLine = new string(childrenDelimiter[0], childrenLineLength) + rightChildData;

                    for (int i = nodeLevel + 2; i < treePrintout.Count; i++)
                    {
                        treePrintout[i].Insert(0, new string(childrenDelimiter[0], parentLineLength - childrenLineLength - 1));
                    }
                }
            }

            if (nodeLevel==0)
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

            return GetTreeLevelPrintout(treePrintout, root, 0);
        }

        public int GetCentralIndex(string data)
        {
            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) / 2;
        }

        public int GetSymbolsCountToLeftFromCentral(string data)
        {
            return GetCentralIndex(data);
        }

        public int GetSymbolsCountToRightFromCentral(string data)
        {
            int dataLength = data.Length;
            return dataLength < 1 ? 0 : (dataLength - 1) - GetCentralIndex(data);
        }
    }
}
