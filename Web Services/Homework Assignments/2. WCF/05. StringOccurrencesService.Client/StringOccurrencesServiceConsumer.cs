using System;

namespace StringOccurrencesService.Client
{
    internal class StringOccurrencesServiceConsumer
    {
        private static void Main()
        {
            StringOccurrencesServiceClient client = new StringOccurrencesServiceClient();

            try
            {
                int occurrences = client.GetOccurrencesAsync("a", "abracadabra").Result;
                Console.WriteLine(occurrences);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
