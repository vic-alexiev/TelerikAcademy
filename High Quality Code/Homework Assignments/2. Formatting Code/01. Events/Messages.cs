namespace Events
{
    using System;
    using System.Text;

    /// <summary>
    /// Keeps a log of the messages which are created when adding/deleting
    /// <see cref="Event"/>s in an event holder.
    /// </summary>
    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        /// <summary>
        /// Gets all the messages in the log.
        /// </summary>
        public static string Output
        {
            get
            {
                return output.ToString();
            }
        }

        /// <summary>
        /// Add a message "Event added" to the message log.
        /// </summary>
        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        /// <summary>
        /// Add a message to the log which tells the number of deleted events
        /// or "No events found" if no event has been deleted.
        /// </summary>
        /// <param name="count">The number of deleted events.</param>
        public static void EventDeleted(int count)
        {
            if (count == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} event(s) deleted{1}", count, Environment.NewLine);
            }
        }

        /// <summary>
        /// Adds a message to the log saying "No events found".
        /// </summary>
        public static void NoEventsFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        /// <summary>
        /// Adds the string representation of the <see cref="Event"/> object
        /// to the message log.
        /// </summary>
        /// <param name="eventToPrint">The event to print.</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}