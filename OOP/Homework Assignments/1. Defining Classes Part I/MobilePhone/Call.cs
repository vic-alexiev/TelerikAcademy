using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        #region Private Fields

        private DateTime date;
        private string dialledNumber;
        private int duration; // in seconds

        #endregion

        #region Properties

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public string DialledNumber
        {
            get
            {
                return dialledNumber;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new MobilePhoneException("Dialled number cannot be empty.");
                }
                dialledNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new MobilePhoneException("Call duration (in seconds) must be a positive integer.");
                }
                duration = value;
            }
        }

        #endregion

        #region Constructors

        public Call(DateTime date, string dialledNumber, int duration)
        {
            this.Date = date;
            this.DialledNumber = dialledNumber;
            this.Duration = duration;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return String.Format("Dialled number: {0}\r\nDate: {1:dd-MM-yyyy, HH:mm}\r\nDuration: {2} seconds",
                dialledNumber, date, duration);
        }

        #endregion
    }
}
