// This collection of non-binary tree data structures created by Dan Vanderboom.
// Critical Development blog: http://dvanderboom.wordpress.com
// Original Tree<T> blog article: http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/

namespace JustPacman.DataStructures
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  SimpleTree is a root-level alias for SimpleTree and SimpleSubtreeNode.
    /// </summary>
    public class SimpleTree<T> : SimpleTreeNode<T>
    {
        public SimpleTree() { }
    }
}