using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TelerikAcademyControls
{
    public partial class AnalogClock : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TimeZoneId = TimeZoneInfo.Local.Id;
                this.ClockSize = 200;
            }
        }

        public int ClockSize
        {
            get
            {
                return Convert.ToInt32(ViewState["ClockSize"]);
            }
            set
            {
                ViewState["ClockSize"] = value;
            }
        }

        public string TimeZoneId
        {
            get
            {
                return Convert.ToString(ViewState["TimeZoneId"]);
            }
            set
            {
                ViewState["TimeZoneId"] = value;
            }
        }

        public byte[] DrawClockFace(out DateTime destinationZoneNow)
        {
            string destinationTimeZoneId = Convert.ToString(ViewState["TimeZoneId"]);
            destinationZoneNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, destinationTimeZoneId);

            int hour = destinationZoneNow.Hour;
            int minute = destinationZoneNow.Minute;
            int second = destinationZoneNow.Second;

            using (Bitmap bitmap = new Bitmap(this.ClockSize, this.ClockSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.RoyalBlue, 2))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        // draw the circle
                        graphics.DrawEllipse(pen, 0, 0, this.ClockSize - 1, this.ClockSize - 1);

                        // draw the second hand
                        double secondHandMainAngle = (second % 60) * (2 * Math.PI / 60);
                        double secondHandTailAngle = Math.PI + secondHandMainAngle;

                        int secondHandMainLength = this.ClockSize * 48 / 100;
                        int secondHandTailLength = this.ClockSize * 12 / 100;

                        int x1 = this.ClockSize / 2;
                        int y1 = this.ClockSize / 2;
                        int x2 = (int)(x1 + secondHandMainLength * Math.Sin(secondHandMainAngle));
                        int y2 = (int)(y1 - secondHandMainLength * Math.Cos(secondHandMainAngle));
                        int x3 = (int)(x1 + secondHandTailLength * Math.Sin(secondHandTailAngle));
                        int y3 = (int)(y1 - secondHandTailLength * Math.Cos(secondHandTailAngle));

                        pen.Brush = Brushes.Red;
                        pen.Width = 1;
                        graphics.DrawLine(pen, x3, y3, x2, y2);

                        // draw the minute hand
                        double minuteHandAngle = (minute % 60) * (2 * Math.PI / 60);
                        int minuteHandLength = this.ClockSize * 42 / 100;
                        x2 = (int)(x1 + minuteHandLength * Math.Sin(minuteHandAngle));
                        y2 = (int)(y1 - minuteHandLength * Math.Cos(minuteHandAngle));

                        pen.Brush = Brushes.Black;
                        pen.Width = 4;
                        graphics.DrawLine(pen, x1, y1, x2, y2);

                        // draw the hour hand
                        double hourHandAngle = (hour % 12) * (2 * Math.PI / 12) + (minute % 60) * (2 * Math.PI / (60 * 12));
                        int hourHandLength = this.ClockSize * 32 / 100;
                        x2 = (int)(x1 + hourHandLength * Math.Sin(hourHandAngle));
                        y2 = (int)(y1 - hourHandLength * Math.Cos(hourHandAngle));

                        pen.Brush = Brushes.Black;
                        pen.Width = 4;
                        graphics.DrawLine(pen, x1, y1, x2, y2);

                        ImageConverter converter = new ImageConverter();
                        return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
                    }
                }
            }
        }
    }
}