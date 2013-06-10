using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The original source can be found at:
/// http://www.informit.com/guides/content.aspx?g=dotnet&seqNum=769
/// </summary>
internal class TreeNode
{
    private Dictionary<char, TreeNode> transitions;

    public TreeNode(char c)
        : this(c, -1)
    {
    }

    public TreeNode(char c, int terminal)
    {
        this.Character = c;
        this.Terminal = terminal;
        this.transitions = new Dictionary<char, TreeNode>();
    }

    public char Character { get; private set; }

    /// <summary>
    /// If >= 0, then the index into the SearchStrings array.
    /// </summary>
    public int Terminal { get; set; }

    public bool HasTransitions
    {
        get
        {
            return this.transitions.Count > 0;
        }
    }

    public override string ToString()
    {
        return string.Format("Char='{0}' Terminal={1}", this.Character, this.Terminal);
    }

    public TreeNode AddTransition(char c, int terminal)
    {
        var node = new TreeNode(c, terminal);
        this.transitions.Add(c, node);
        return node;
    }

    public TreeNode GetTransition(char c)
    {
        TreeNode node;
        this.transitions.TryGetValue(c, out node);
        return node;
    }

    public bool TryGetTransition(char c, out TreeNode node)
    {
        return this.transitions.TryGetValue(c, out node);
    }

    public KeyValuePair<char, TreeNode>[] GetTransitions()
    {
        return this.transitions.ToArray();
    }
}
