using System;

class BinarySearchTreeDemo
{
    static void Main()
    {
        BinarySearchTree<int> tree1 = new BinarySearchTree<int>();
        tree1.Add(11);
        tree1.Add(35);
        tree1.Add(7);
        tree1.Add(16);
        tree1.Add(23);
        tree1.Add(13);
        tree1.Add(17);

        //tree1.Remove(11);
        //tree1.Remove(7);
        //tree1.Remove(16);
        //tree1.Remove(23);
        //tree1.Remove(13);

        //Console.WriteLine(tree1);
        //Console.WriteLine(tree1.AsString(false));

        BinarySearchTree<int> tree2 = new BinarySearchTree<int>();
        tree2.Add(11);
        tree2.Add(35);
        tree2.Add(7);
        tree2.Add(16);
        tree2.Add(23);
        tree2.Add(13);
        tree2.Add(17);

        Console.WriteLine(tree2);

        BinarySearchTree<int> tree3 = tree2.Clone();

        Console.WriteLine(tree3);
        Console.WriteLine(tree3 == tree2);

        tree2.Remove(23);
        tree2.Add(2323);

        Console.WriteLine(tree2);
        Console.WriteLine(tree3);

        foreach (int item in tree2)
        {
            Console.WriteLine(item);
        }

        //Console.WriteLine(tree2.GetHashCode());
    }
}
