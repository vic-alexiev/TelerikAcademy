using System;
using System.IO;
using System.Text;

namespace Events
{
    /// <summary>
    /// A class which represents an event (conference, meeting, lunch, etc.).
    /// </summary>
    public class Event : IComparable
    {
        #region Private Fields

        private DateTime dateAndTime;
        private string title;
        private string location;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the date and time of the event.
        /// </summary>
        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            private set { dateAndTime = value; }
        }

        /// <summary>
        /// Gets the title of the event.
        /// </summary>
        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        /// <summary>
        /// Gets the location of the event.
        /// </summary>
        public string Location
        {
            get { return location; }
            private set { location = value; }
        }

        #endregion

        #region Constructors

        public Event(DateTime dateAndTime, string title, string location)
        {
            this.DateAndTime = dateAndTime;
            this.Title = title;
            this.Location = location;
        }

        #endregion

        #region Public Methods

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Event other = obj as Event;
            if (other != null)
            {
                int byDateAndTime = this.DateAndTime.CompareTo(other.DateAndTime);
                int byTitle = this.Title.CompareTo(other.Title);
                int byLocation = this.Location.CompareTo(other.Location);

                if (byDateAndTime == 0)
                {
                    if (byTitle == 0)
                    {
                        return byLocation;
                    }
                    else
                    {
                        return byTitle;
                    }
                }
                else
                {
                    return byDateAndTime;
                }
            }
            else
            {
                throw new ArgumentException("Object is not an Event.");
            }
        }

        /// <summary>
        /// Returns event data in the following format:
        /// {Date and Time} | {Title} [| {Location}]
        /// </summary>
        /// <returns>The event data as a string.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(this.DateAndTime.ToString("yyyy-MM-ddTHH:mm:ss"));

            stringBuilder.Append(" | " + this.Title);

            if (!String.IsNullOrWhiteSpace(this.Location))
            {
                stringBuilder.Append(" | " + this.Location);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
