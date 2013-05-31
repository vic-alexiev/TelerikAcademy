using System.Collections;
using System.Collections.Generic;

internal class SinglyLinkedNode<T> : IEnumerable<SinglyLinkedNode<T>>
{
    // Data or a reference to data
    public T Data { get; set; }

    // A reference to the next node
    public SinglyLinkedNode<T> NextNode { get; set; }

    public SinglyLinkedNode(T data)
    {
        this.Data = data;
        this.NextNode = null;
    }

    public IEnumerator<SinglyLinkedNode<T>> GetEnumerator()
    {
        SinglyLinkedNode<T> currentNode = this;

        do
        {
            SinglyLinkedNode<T> returnNode = currentNode;
            currentNode = currentNode.NextNode;
            yield return returnNode;
        }
        while (currentNode != null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<SinglyLinkedNode<T>>)this).GetEnumerator();
    }
}
