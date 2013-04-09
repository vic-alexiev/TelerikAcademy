using System;
using System.Text;

namespace Events
{
    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static string Output
        {
            get
            {
                return output.ToString();
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        public static void EventDeleted(int count)
        {
            if (count == 0) NoEventsFound();

            else output.AppendFormat("{0} event(s) deleted{1}", count, Environment.NewLine);
        }

        public static void NoEventsFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}