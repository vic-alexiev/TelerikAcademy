using MobilePhone.Enums;
using System;

namespace MobilePhone
{
    public class Display : ICloneable
    {
        #region Private Fields

        private DisplaySize size;
        private ColorDepth colors;

        #endregion

        #region Properties

        public DisplaySize Size
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
            }
        }

        public ColorDepth Colors
        {
            get
            {
                return colors;
            }
            private set
            {
                colors = value;
            }
        }

        #endregion

        #region Constructors

        public Display(DisplaySize size, ColorDepth colors)
        {
            this.Size = size.Clone();
            this.Colors = colors;
        }

        public Display(int? resolutionWidth, int? resolutionHeight, double? diagonal, ColorDepth colors)
            : this(new DisplaySize(resolutionWidth, resolutionHeight, diagonal), colors)
        {
        }

        public Display(int? resolutionWidth, int? resolutionHeight, ColorDepth colors)
            : this(new DisplaySize(resolutionWidth, resolutionHeight, null), colors)
        {
        }

        public Display(double? diagonal, ColorDepth colors)
            : this(new DisplaySize(null, null, diagonal), colors)
        {
        }

        public Display()
            : this(new DisplaySize(null, null, null), ColorDepth.Unknown)
        {
        }

        #endregion

        #region Public Methods

        // Explicit implementation of ICloneable.Clone()
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Display Clone()
        {
            Display clone = new Display(size, colors);
            return clone;
        }

        public override string ToString()
        {
            return String.Format("{0}\r\nColor depth: {1}", size, ColorsToString(colors));
        }

        #endregion

        #region Private Methods

        private string ColorsToString(ColorDepth colorDepth)
        {
            switch (colorDepth)
            {
                case ColorDepth.Monochrome:
                    return "Monochrome";
                case ColorDepth.Colors256:
                    return "256 colors";
                case ColorDepth.Colors32K:
                    return "32K colors";
                case ColorDepth.Colors65K:
                    return "65K colors";
                case ColorDepth.Colors256K:
                    return "256K colors";
                case ColorDepth.Colors16M:
                    return "16M colors";
                case ColorDepth.Colors1G:
                    return "1G colors";
                case ColorDepth.Colors68G:
                    return "68G colors";
                case ColorDepth.Colors281T:
                    return "281T colors";
                default:
                    return "[no colors specified]";
            }
        }

        #endregion
    }
}
