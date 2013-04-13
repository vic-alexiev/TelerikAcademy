namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Represents a collection of <see cref="Event"/> objects.
    /// </summary>
    public class EventHolder
    {
        private MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> byDateAndTime = new OrderedBag<Event>();

        /// <summary>
        /// Creates an event and adds it in the list.
        /// </summary>
        /// <param name="dateAndTime">The event's date and time.</param>
        /// <param name="title">The event's title.</param>
        /// <param name="location">The event's location.</param>
        public void AddEvent(DateTime dateAndTime, string title, string location)
        {
            Event newEvent = new Event(dateAndTime, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDateAndTime.Add(newEvent);
            Messages.EventAdded();
        }

        /// <summary>
        /// Deletes all events that have the specified title.
        /// Performs a case-insensitive search.
        /// </summary>
        /// <param name="titleToDelete">The title to delete.</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDateAndTime.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        /// <summary>
        /// Adds in the output events that have the specified timestamp.
        /// </summary>
        /// <param name="dateAndTime">The date and time of the event.</param>
        /// <param name="count">The number of events to be added.</param>
        public void ListEvents(DateTime dateAndTime, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.byDateAndTime.RangeFrom(new Event(dateAndTime, string.Empty, string.Empty), true);

            int shown = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (shown == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                shown++;
            }

            if (shown == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
