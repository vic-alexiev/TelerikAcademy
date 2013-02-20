using System;

namespace MobilePhone
{
    public class BatteryLife
    {
        #region Private Fields

        private int? hours;
        private int? minutes;

        #endregion

        #region Properties

        public int? Hours
        {
            get
            {
                return hours;
            }
            private set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new MobilePhoneException("Battery life hours should be a positive integer.");
                }
                hours = value;
            }
        }

        public int? Minutes
        {
            get
            {
                return minutes;
            }
            private set
            {
                if (value.HasValue && value.Value < 0)
                {
                    throw new MobilePhoneException("Battery life minutes should be a non-negative integer.");
                }
                minutes = value;
            }
        }

        #endregion

        #region Constructors

        public BatteryLife(int? hours, int? minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (!hours.HasValue && !minutes.HasValue)
            {
                return "[no battery life specified]";
            }

            if (minutes.Value == 0)
            {
                return String.Format("Up to {0} h", hours.Value);
            }

            return String.Format("Up to {0} h {1} min", hours.Value, minutes.Value);
        }

        #endregion
    }
}
