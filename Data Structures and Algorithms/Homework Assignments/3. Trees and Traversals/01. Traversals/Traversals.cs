using System;
using System.Collections.Generic;
using System.Text;

internal class Traversals
{
    private static void PrintAllSubtreesThatSumTo(TreeNode<int>[] nodes, int sum)
    {
        foreach (var node in nodes)
        {
            int subtreeSum = node.Accumulate(0, (a, b) => a + b);
            if (subtreeSum == sum)
            {
                Console.WriteLine(node);
            }
        }
    }

    private static void PrintAllPathsThatSumTo(TreeNode<int>[] nodes, int sum)
    {
        foreach (var node in nodes)
        {
            PrintAllPathsThatSumTo(node, sum);
        }
    }

    private static void PrintAllPathsThatSumTo(TreeNode<int> node, int sum)
    {
        TreeNode<int> currentNode = node;
        StringBuilder result = new StringBuilder();

        int currentSum = 0;

        while (currentNode != null)
        {
            currentSum += currentNode.Data;
            result.Insert(0, currentNode.Data + " ");

            if (currentSum == sum)
            {
                result.Length--;
                Console.WriteLine(result);
            }

            currentNode = currentNode.Parent;
        }
    }

    private static TreeNode<T> GetRoot<T>(TreeNode<T>[] nodes)
    {
        // Find the root. By definition that's the node
        // which has no children
        foreach (var node in nodes)
        {
            if (node.Parent == null)
            {
                return node;
            }
        }

        return null;
    }

    private static List<TreeNode<T>> GetLeaves<T>(TreeNode<T>[] nodes)
    {
        List<TreeNode<T>> leaves = new List<TreeNode<T>>();

        // Find all leaf nodes. By definition a leaf node
        // has no children
        foreach (var node in nodes)
        {
            if (node.Nodes.Count == 0)
            {
                leaves.Add(node);
            }
        }

        return leaves;
    }

    private static List<TreeNode<T>> GetInnerNodes<T>(TreeNode<T>[] nodes)
    {
        List<TreeNode<T>> innerNodes = new List<TreeNode<T>>();

        // Find all internal nodes.
        foreach (var node in nodes)
        {
            if (node.Parent != null && node.Nodes.Count > 0)
            {
                innerNodes.Add(node);
            }
        }

        return innerNodes;
    }

    private static void Main()
    {
        int sum = 6;

        string input = Console.ReadLine();
        int n = int.Parse(input);

        TreeNode<int>[] nodes = new TreeNode<int>[n];

        for (int i = 0; i < n; i++)
        {
            nodes[i] = new TreeNode<int>(i);
        }

        for (int i = 1; i < n; i++)
        {
            string edge = Console.ReadLine();
            string[] edgeNodes = edge.Split(' ');
            int parentData = int.Parse(edgeNodes[0]);
            int childData = int.Parse(edgeNodes[1]);

            nodes[parentData].Nodes.Add(nodes[childData]);
        }

        TreeNode<int> root = GetRoot(nodes);
        Console.WriteLine("Root: {0}", root != null ? root.ToString() : "[no root]");

        List<TreeNode<int>> leaves = GetLeaves(nodes);

        Console.WriteLine("Leaf nodes:");

        foreach (var leaf in leaves)
        {
            Console.WriteLine(leaf);
        }

        List<TreeNode<int>> innerNodes = GetInnerNodes(nodes);

        Console.WriteLine("Inner nodes:");

        foreach (var node in innerNodes)
        {
            Console.WriteLine(node);
        }

        var tree = new Tree<int>(root);

        Console.WriteLine("Nodes data (DFS):");

        foreach (var data in tree)
        {
            Console.Write(data + " ");
        }

        Console.WriteLine();

        Console.WriteLine("The tree (DFS):{0}{1}", Environment.NewLine, tree);

        Console.WriteLine("Height: " + tree.GetHeight());

        Console.WriteLine("All downward paths that sum to {0}:", sum);

        PrintAllPathsThatSumTo(nodes, sum);

        Console.WriteLine("Nodes whose subtrees sum to {0}:", sum);

        PrintAllSubtreesThatSumTo(nodes, sum);

        Tree<double> sinTree = tree.Map<double>(i => Math.Sin(i));

        Console.WriteLine("A tree created by applying Math.Sin() to the tree nodes:");

        Console.WriteLine(sinTree);
    }
}
