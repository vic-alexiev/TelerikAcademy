using System;
using System.IO;
using System.Text;

namespace Events
{
    public class Event : IComparable
    {
        #region Private Fields

        private DateTime dateAndTime;
        private string title;
        private string location;

        #endregion

        #region Properties

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            private set { dateAndTime = value; }
        }

        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

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
