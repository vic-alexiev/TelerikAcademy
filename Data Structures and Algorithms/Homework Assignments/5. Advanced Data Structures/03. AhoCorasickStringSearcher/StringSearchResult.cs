public class StringSearchResult
{
    public StringSearchResult(string value, int position)
    {
        this.Value = value;
        this.Position = position;
    }

    public string Value { get; private set; }
    public int Position { get; private set; }
}
