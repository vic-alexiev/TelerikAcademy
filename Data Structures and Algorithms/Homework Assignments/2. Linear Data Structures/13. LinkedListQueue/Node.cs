using System.Collections;
using System.Collections.Generic;

internal class Node<T> : IEnumerable<Node<T>>
{
    // Data or a reference to data
    public T Data { get; set; }

    // A reference to the next node
    public Node<T> NextNode { get; set; }

    public Node(T data)
    {
        this.Data = data;
        this.NextNode = null;
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> currentNode = this;

        do
        {
            Node<T> returnNode = currentNode;
            currentNode = currentNode.NextNode;
            yield return returnNode;
        }
        while (currentNode != null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Node<T>>)this).GetEnumerator();
    }
}
