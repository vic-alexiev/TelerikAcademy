using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

public class MongoDictionary
{
    private MongoCollection<Entry> entriesCollection;

    public MongoDictionary(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        var database = server.GetDatabase(databaseName);
        entriesCollection = database.GetCollection<Entry>(collectionName);
    }

    public ObjectId InsertEntry(string name, string translation)
    {
        var entry = new Entry
        {
            Name = name,
            Translation = translation
        };

        entriesCollection.Insert(entry);
        var id = entry.Id;
        return id;
    }

    public ObjectId InsertEntry(Entry entry)
    {
        entriesCollection.Insert(entry);
        var id = entry.Id;
        return id;
    }

    public Entry FindEntryByName(string name)
    {
        var query = Query<Entry>.EQ(e => e.Name, name);
        var entry = entriesCollection.FindOne(query);

        return entry;
    }

    public string FindTranslationByName(string name)
    {
        var query = Query<Entry>.EQ(e => e.Name, name);
        var entry = entriesCollection.FindOne(query);

        if (entry != null)
        {
            return entry.Translation;
        }

        return null;
    }

    public void UpdateEntryName(string oldName, string newName)
    {
        var query = Query<Entry>.EQ(e => e.Name, oldName);
        var entry = entriesCollection.FindOne(query);

        if (entry != null)
        {
            entry.Name = newName;
            entriesCollection.Save(entry);
        }
    }

    public void UpdateEntryTranslation(string name, string newTranslation)
    {
        var query = Query<Entry>.EQ(e => e.Name, name);
        var update = Update<Entry>.Set(e => e.Translation, newTranslation);
        entriesCollection.Update(query, update);
    }

    public List<Entry> GetAllEntries()
    {
        List<Entry> entriesList = new List<Entry>();
        var entriesCursor = entriesCollection.FindAll();

        foreach (var entry in entriesCursor)
        {
            entriesList.Add(entry);
        }

        return entriesList;
    }
}
