using System;

namespace MobilePhone
{
    public class DisplaySize : ICloneable
    {
        #region Private Fields

        private int? resolutionWidth;
        private int? resolutionHeight;
        private double? diagonal;

        #endregion

        #region Properties

        public int? ResolutionWidth
        {
            get
            {
                return resolutionWidth;
            }
            private set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new MobilePhoneException("Resolution width should be a positive integer.");
                }
                resolutionWidth = value;
            }
        }

        public int? ResolutionHeight
        {
            get
            {
                return resolutionHeight;
            }
            private set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new MobilePhoneException("Resolution height should be a positive integer.");
                }
                resolutionHeight = value;
            }
        }

        public double? Diagonal
        {
            get
            {
                return diagonal;
            }
            private set
            {
                if (value.HasValue && value.Value <= 0.0)
                {
                    throw new MobilePhoneException("Diagonal is in inches and should be a positive number.");
                }
                diagonal = value;
            }
        }

        #endregion

        #region Constructors

        public DisplaySize(int? resolutionWidth, int? resolutionHeight, double? diagonal)
        {
            this.ResolutionWidth = resolutionWidth;
            this.ResolutionHeight = resolutionHeight;
            this.Diagonal = diagonal;
        }

        public DisplaySize(int? resolutionWidth, int? resolutionHeight)
            : this(resolutionWidth, resolutionHeight, null)
        {
        }

        public DisplaySize(double? diagonal)
            : this(null, null, diagonal)
        {
        }

        public DisplaySize()
            : this(null, null, null)
        {
        }

        #endregion

        #region Public Methods

        // Explicit implementation of ICloneable.Clone()
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public DisplaySize Clone()
        {
            DisplaySize clone = new DisplaySize(resolutionWidth, resolutionHeight, diagonal);
            return clone;
        }

        public override string ToString()
        {
            if (resolutionWidth.HasValue && resolutionHeight.HasValue && diagonal.HasValue)
            {
                return String.Format("Display size: {0} x {1} pixels, {2} inches", resolutionWidth.Value, resolutionHeight.Value, diagonal.Value);
            }

            if (resolutionWidth.HasValue && resolutionHeight.HasValue)
            {
                return String.Format("Display size: {0} x {1} pixels", resolutionWidth.Value, resolutionHeight.Value);
            }

            if (diagonal.HasValue)
            {
                return String.Format("Display size: {0} inches", diagonal.Value);
            }

            return "[no display size specified]";

        }

        #endregion
    }
}
