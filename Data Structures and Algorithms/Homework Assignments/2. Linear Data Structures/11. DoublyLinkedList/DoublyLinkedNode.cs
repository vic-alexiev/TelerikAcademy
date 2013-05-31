using System.Collections;
using System.Collections.Generic;

internal class DoublyLinkedNode<T> : IEnumerable<DoublyLinkedNode<T>>
{
    // Data or a reference to data
    public T Data { get; set; }

    // A reference to the next node
    public DoublyLinkedNode<T> NextNode { get; set; }

    // A reference to the previous node
    public DoublyLinkedNode<T> PreviousNode { get; set; }

    public DoublyLinkedNode(T data)
    {
        this.Data = data;
        this.NextNode = null;
        this.PreviousNode = null;
    }

    public IEnumerator<DoublyLinkedNode<T>> GetEnumerator()
    {
        DoublyLinkedNode<T> currentNode = this;

        do
        {
            DoublyLinkedNode<T> returnNode = currentNode;
            currentNode = currentNode.NextNode;
            yield return returnNode;
        }
        while (currentNode != null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<DoublyLinkedNode<T>>)this).GetEnumerator();
    }
}
