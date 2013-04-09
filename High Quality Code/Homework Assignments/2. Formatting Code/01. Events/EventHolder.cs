using System;
using Wintellect.PowerCollections;

namespace Events
{
    public class EventHolder
    {
        private MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> byDateAndTime = new OrderedBag<Event>();

        /// <summary>
        /// Creates an event and adds it in the list.
        /// </summary>
        /// <param name="dateAndTime"></param>
        /// <param name="title"></param>
        /// <param name="location"></param>
        public void AddEvent(DateTime dateAndTime, string title, string location)
        {
            Event newEvent = new Event(dateAndTime, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDateAndTime.Add(newEvent);
            Messages.EventAdded();
        }

        /// <summary>
        /// Deletes all events that have the specified title.
        /// Performs a case-insensitive search.
        /// </summary>
        /// <param name="titleToDelete"></param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in byTitle[title])
            {
                removed++;
                byDateAndTime.Remove(eventToRemove);
            }
            byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        /// <summary>
        /// Adds in the output events that have the specified timestamp.
        /// </summary>
        /// <param name="dateAndTime"></param>
        /// <param name="count">The number of events to be added.</param>
        public void ListEvents(DateTime dateAndTime, int count)
        {
            OrderedBag<Event>.View eventsToShow = byDateAndTime.RangeFrom(new Event(dateAndTime, String.Empty, String.Empty), true);

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
