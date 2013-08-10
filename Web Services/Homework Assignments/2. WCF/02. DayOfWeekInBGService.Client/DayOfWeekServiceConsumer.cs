using DayOfWeekInBGService.Client.DayOfWeekServiceReference;
using System;
using System.Text;

namespace DayOfWeekInBGService.Client
{
    internal class DayOfWeekServiceConsumer
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DayOfWeekServiceClient dayOfWeekServiceClient = new DayOfWeekServiceClient();
            Console.WriteLine(dayOfWeekServiceClient.GetDayOfWeekAsync(DateTime.Now).Result);
        }
    }
}
