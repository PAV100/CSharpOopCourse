using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTask
{
    internal class BinaryTree<T>
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

            List<string> treePrintout = new();

            GetTreeLevelPrintout(treePrintout, root);

            StringBuilder sb = new StringBuilder();

            foreach (string s in treePrintout)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        private string GetTreeLevelPrintout(List<string> treePrintout, TreeNode<T> node, int nodeLevel)
        {
            string leftLineMargin = "";

            string leftLineBorder = "[";
            string rightLineBorder = "]";

            string leftChildCap = "┌";
            string childCapPlaceholder = "─";
            string rightChildCap = "┐";

            string leftChildBorder = "(";
            string childrenDelimiter = " ";
            string rightChildBorder = ")";

            // Check and create an empty string for level nodeLevel
            if (treePrintout.Count <= nodeLevel)
            {
                treePrintout.Insert(nodeLevel, "");
            }

            // if no children - stop recursion
            if (node.left is null && node.right is null)
            {
                string nodeData = node.data.ToString();
                //treePrintout[nodeLevel] += nodeData;
                ////treePrintout[nodeLevel] += rightLineBorder;
                return nodeData;
            }

            // Create an empty string for level nodeLevel + 1
            treePrintout.Insert(nodeLevel + 1, "");

            string left = "";

            // Only left child
            if (node.left is not null)
            {
                left = GetTreeLevelPrintout(treePrintout, node.left, nodeLevel + 1);
            }

            string right = "";

            // Only right child
            if (node.right is not null)
            {
                right = GetTreeLevelPrintout(treePrintout, node.right, nodeLevel + 1);
            }



            if (node.left is not null && node.right is null)
            {
                treePrintout[nodeLevel] = node.data.ToString() + Environment.NewLine;
                return treePrintout[nodeLevel + 1] += leftChildBorder + left + rightChildBorder;
            }

            if (node.right is not null && node.left is null)
            {
                treePrintout[nodeLevel] = node.data.ToString() + Environment.NewLine;
                return treePrintout[nodeLevel + 1] += leftChildBorder + right + rightChildBorder;
            }

            treePrintout[nodeLevel] = node.data.ToString() + Environment.NewLine;
            return treePrintout[nodeLevel + 1] += leftChildBorder + left + childrenDelimiter + right + rightChildBorder;
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

        private int GetCentralIndex(T data)
        {
            int dataLength = data.ToString().Length;
            return dataLength < 1 ? 0 : (dataLength - 1) / 2;
        }
    }
}
