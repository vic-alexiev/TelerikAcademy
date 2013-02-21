using MobilePhone.Enums;
using System;

namespace MobilePhone
{
    public class Battery : ICloneable
    {
        #region Private Fields

        private string brand;
        private BatteryType type;
        private BatteryLife standByTime;
        private BatteryLife talkTime;

        #endregion

        #region Properties

        public BatteryType Type
        {
            get
            {
                return type;
            }
            private set
            {
                type = value;
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
                brand = value;
            }
        }

        public BatteryLife StandByTime
        {
            get
            {
                return standByTime;
            }
            private set
            {
                standByTime = value;
            }
        }

        public BatteryLife TalkTime
        {
            get
            {
                return talkTime;
            }
            private set
            {
                talkTime = value;
            }
        }

        #endregion

        #region Constructors

        public Battery(BatteryType type, string brand, int? standByHours, int? standByMinutes, int? talkHours, int? talkMinutes)
        {
            this.Type = type;
            this.Brand = brand;
            this.StandByTime = new BatteryLife(standByHours, standByMinutes);
            this.TalkTime = new BatteryLife(talkHours, talkMinutes);
        }

        public Battery(BatteryType type, string brand)
            : this(type, brand, null, null, null, null)
        {
        }

        public Battery(BatteryType type)
            : this(type, null, null, null, null, null)
        {

        }

        public Battery()
            : this(BatteryType.Unknown, null, null, null, null, null)
        {
        }

        #endregion

        #region Public Methods

        // Explicit implementation of ICloneable.Clone()
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Battery Clone()
        {
            Battery clone = new Battery(type, brand, standByTime.Hours, standByTime.Minutes, talkTime.Hours, talkTime.Minutes);
            return clone;
        }

        public override string ToString()
        {
            return String.Format("Type: {0} ({1})\r\nStand-by: {2}\r\nTalk time: {3}",
                BatteryTypeToString(type),
                String.IsNullOrWhiteSpace(brand) ? "[no battery brand specified]" : brand,
                standByTime,
                talkTime);
        }

        #endregion

        #region Private Methods

        private string BatteryTypeToString(BatteryType batteryType)
        {
            switch (batteryType)
            {
                case BatteryType.LiIon:
                    return "Li-Ion battery";
                case BatteryType.LiPoly:
                    return "Li-Poly battery";
                case BatteryType.NiCd:
                    return "NiCd battery";
                case BatteryType.NiMH:
                    return "NiMH battery";
                default:
                    return "[no battery type specified]";
            }
        }

        #endregion
    }
}
