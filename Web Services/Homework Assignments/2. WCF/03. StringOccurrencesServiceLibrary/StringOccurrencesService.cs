using System;
namespace StringOccurrencesServiceLibrary
{
    public class StringOccurrencesService : IStringOccurrencesService
    {
        public int GetOccurrences(string source, string target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source cannot be null.");
            }

            if (target == null)
            {
                throw new ArgumentNullException("target", "target cannot be null.");
            }

            // logic comes here
            int occurrences = 0;
            int sourceIndex = target.IndexOf(source, 0);

            while (sourceIndex >= 0)
            {
                occurrences++;
                sourceIndex = target.IndexOf(source, sourceIndex + 1);
            }

            return occurrences;
        }
    }
}
