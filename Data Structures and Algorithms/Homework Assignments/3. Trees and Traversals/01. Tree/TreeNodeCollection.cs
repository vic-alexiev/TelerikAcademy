using System.Collections.Generic;

public class TreeNodeCollection<T> : List<TreeNode<T>>
{
    public TreeNode<T> Parent { get; set; }

    public TreeNodeCollection(TreeNode<T> parent)
    {
        this.Parent = parent;
    }

    public new TreeNode<T> Add(TreeNode<T> item)
    {
        base.Add(item);
        item.Parent = this.Parent;
        return item;
    }

    public TreeNode<T> Add(T data)
    {
        TreeNode<T> newNode = new TreeNode<T>(data);
        return this.Add(newNode);
    }
}
