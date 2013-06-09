using System.Collections.Generic;

namespace PhoneBook
{
    public interface IEntriesManager
    {
        bool TryGetEntries(string name, out List<string> entries);
        bool TryGetEntries(string name, string location, out List<string> entries);
    }
}
