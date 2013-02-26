using MobilePhone.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class Gsm
    {
        #region Private Fields

        private MobilePhoneManufacturer manufacturer;
        private Battery battery;
        private Display display;
        private string brand;
        private decimal? price;
        private string owner;
        private List<Call> callHistory;

        private static Gsm iPhone4S;

        #endregion

        #region Properties

        public MobilePhoneManufacturer Manufacturer
        {
            get
            {
                return manufacturer;
            }
            private set
            {
                if (value == MobilePhoneManufacturer.Unknown)
                {
                    throw new MobilePhoneException("No manufacturer specified.");
                }
                manufacturer = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return battery;
            }
            private set
            {
                if (value != null)
                {
                    battery = value.Clone();
                }
                else
                {
                    battery = new Battery();
                }
            }
        }

        public Display Display
        {
            get
            {
                return display;
            }
            private set
            {
                if (value != null)
                {
                    display = value.Clone();
                }
                else
                {
                    display = new Display();
                }
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new MobilePhoneException("The mobile phone brand should not be empty.");
                }
                brand = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value.HasValue && value.Value <= 0.0M)
                {
                    throw new MobilePhoneException("The price must be a positive number.");
                }
                price = value;
            }
        }

        public string Owner
        {
            get
            {
                return owner;
            }
            private set
            {
                if (value == null)
                {
                    owner = "[no owner specified]";
                }
                else
                {
                    owner = value;
                }
            }
        }

        public static Gsm IPhone4S
        {
            get
            {
                return iPhone4S;
            }
            private set
            {
                iPhone4S = value;
            }
        }

        #endregion

        #region Constructors

        static Gsm()
        {
            IPhone4S = new Gsm(
                MobilePhoneManufacturer.Apple,
                new Battery(BatteryType.LiPoly, "5.3 Wh", 200, 0, 8, 0),
                new Display(640, 960, 3.5, ColorDepth.Colors16M),
                "Apple iPhone 4S",
                380,
                null);
        }

        public Gsm(MobilePhoneManufacturer manufacturer, Battery battery, Display display, string brand, decimal? price, string owner)
        {
            this.Manufacturer = manufacturer;
            this.Battery = battery;
            this.Display = display;
            this.Brand = brand;
            this.Price = price;
            this.Owner = owner;
            this.callHistory = new List<Call>();
        }

        public Gsm(MobilePhoneManufacturer manufacturer, Battery battery, Display display, string brand, decimal? price)
            : this(manufacturer, battery, display, brand, price, null)
        {
        }

        public Gsm(MobilePhoneManufacturer manufacturer, Battery battery, Display display, string brand)
            : this(manufacturer, battery, display, brand, null, null)
        {
        }

        public Gsm(MobilePhoneManufacturer manufacturer, Battery battery, string brand)
            : this(manufacturer, battery, null, brand, null, null)
        {
        }

        public Gsm(MobilePhoneManufacturer manufacturer, Display display, string brand)
            : this(manufacturer, null, display, brand, null, null)
        {
        }

        public Gsm(MobilePhoneManufacturer manufacturer, string brand)
            : this(manufacturer, null, null, brand, null, null)
        {
        }

        #endregion

        #region Public Methods

        public void AddCallToHistory(int year, int month, int day, int hour, int minute, string dialledNumber, int duration)
        {
            DateTime date = new DateTime(year, month, day, hour, minute, 0);
            Call call = new Call(date, dialledNumber, duration);
            this.callHistory.Add(call);
        }

        public int DeleteCallFromHistory(int year, int month, int day, int hour, int minute, string dialledNumber)
        {
            DateTime date = new DateTime(year, month, day, hour, minute, 0);
            int callsRemoved = this.callHistory.RemoveAll(c => c.Date == date && c.DialledNumber == dialledNumber);
            return callsRemoved;
        }

        public int DeleteLongestCallFromHistory()
        {
            int longestDuration = this.callHistory.Max(c => c.Duration);
            int callsRemoved = this.callHistory.RemoveAll(c => c.Duration == longestDuration);
            return callsRemoved;
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public string GetCallHistory()
        {
            StringBuilder callHistoryBuilder = new StringBuilder();

            foreach (Call call in callHistory)
            {
                callHistoryBuilder.AppendFormat("{0}\r\n", call);
            }

            return callHistoryBuilder.ToString();
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            int totalSeconds = 0;

            foreach (Call call in callHistory)
            {
                totalSeconds += call.Duration;
            }

            decimal totalMinutes = totalSeconds / 60.0M;

            return totalMinutes * pricePerMinute;
        }

        public override string ToString()
        {
            return String.Format("Brand: {0}\r\n" +
                "Manufacturer: {1}\r\n" +
                "Battery:\r\n{2}\r\n" +
                "Display:\r\n{3}\r\n" +
                "Price: {4}\r\n" +
                "Owner: {5}",
                brand,
                ManufacturerToString(manufacturer),
                battery == null ? "[no battery specified]" : battery.ToString(),
                display == null ? "[no display specified]" : display.ToString(),
                price.HasValue ? price.Value.ToString("C2", CultureInfo.GetCultureInfo("en-US")) : "[no price specified]",
                owner);
        }

        #endregion

        #region Private Methods

        private string ManufacturerToString(MobilePhoneManufacturer mobilePhoneManufacturer)
        {
            switch (mobilePhoneManufacturer)
            {
                case MobilePhoneManufacturer.Alcatel:
                    return "Alcatel";
                case MobilePhoneManufacturer.Apple:
                    return "Apple";
                case MobilePhoneManufacturer.BlackBerry:
                    return "BlackBerry";
                case MobilePhoneManufacturer.Htc:
                    return "HTC";
                case MobilePhoneManufacturer.Microsoft:
                    return "Microsoft";
                case MobilePhoneManufacturer.Motorola:
                    return "Motorola";
                case MobilePhoneManufacturer.Nokia:
                    return "Nokia";
                case MobilePhoneManufacturer.Samsung:
                    return "Samsung";
                case MobilePhoneManufacturer.Siemens:
                    return "Siemens";
                case MobilePhoneManufacturer.SonyEricsson:
                    return "Sony Ericsson";
                default:
                    return "[no manufacturer specified]";
            }
        }

        #endregion
    }
}
