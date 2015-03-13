using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace JSONProductReports
{
    public class MongoDBManager<T>
    {
        private readonly string connectionString;
        private readonly MongoClient client;
        private readonly MongoServer server;

        public MongoDBManager()
        {
            this.connectionString = "mongodb://localhost";
            this.client = new MongoClient(connectionString);
            this.server = client.GetServer();
        }

        public void InsertInMongoDB(ICollection<T> jsonObjects, string databaseName)
        {
            var database = server.GetDatabase(databaseName);
            var collection = database.GetCollection(databaseName);

            foreach (var obj in jsonObjects)
            {
                collection.Insert(obj);
            }
        }

        public void ExportMongoDB(string databaseName)
        {
            var database = server.GetDatabase(databaseName);
            var collection = database.GetCollection(databaseName);

            var allEntries = collection.FindAll();
            foreach (var entry in allEntries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
