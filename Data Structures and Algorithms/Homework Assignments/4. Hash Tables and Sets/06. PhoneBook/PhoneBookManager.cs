using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook
{
    public class PhoneBookManager : IEntriesManager
    {
        private Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

        public PhoneBookManager(string dataFilePath)
        {
            this.ReadData(dataFilePath);
        }

        public bool TryGetEntries(string name, out List<string> entries)
        {
            return this.phoneBook.TryGetValue(name.ToLower(), out entries);
        }

        public bool TryGetEntries(string name, string location, out List<string> entries)
        {
            return this.TryGetEntries(this.Combine(name, location), out entries);
        }

        private void ReadData(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] recordData = line.Split('|');
                    string personNames = recordData[0].Trim();
                    string location = recordData[1].Trim();

                    string[] names = personNames.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string name in names)
                    {
                        this.AddToPhoneBook(name, line);
                        string nameAndLocation = this.Combine(name, location);
                        this.AddToPhoneBook(nameAndLocation, line);
                    }
                }
            }
        }

        private void AddToPhoneBook(string key, string entry)
        {
            key = key.ToLower();
            List<string> entries;

            if (!this.phoneBook.TryGetValue(key, out entries))
            {
                entries = new List<string>();
                this.phoneBook.Add(key, entries);
            }

            entries.Add(entry);
        }

        private string Combine(string value1, string value2)
        {
            return string.Format("{0}@{1}", value1, value2);
        }
    }
}
