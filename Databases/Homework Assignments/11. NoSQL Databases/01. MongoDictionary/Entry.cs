using MongoDB.Bson;

public class Entry
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Translation { get; set; }

    public override string ToString()
    {
        return string.Format("(Entry: {0}, Translation: {1})", this.Name, this.Translation);
    }
}
