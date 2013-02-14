using System.Collections.Generic;

public class StringByLengthComparer : IComparer<string>
{
    public int Compare(string a, string b)
    {
        return a.Length.CompareTo(b.Length);
    }
}
