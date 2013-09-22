using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TelerikAcademyControls
{
    public partial class AnalogClockDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

                this.DropDownListTimeZone.DataSource = timeZones;
                this.DropDownListTimeZone.DataBind();
                this.DropDownListTimeZone.SelectedValue = TimeZoneInfo.Local.Id;
            }
        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            DateTime destinationZoneNow;
            byte[] clockImage = this.UserControlAnalogClock.DrawClockFace(out destinationZoneNow);

            this.ImageClock.ImageUrl = "data:image/bmp;base64," + Convert.ToBase64String(clockImage);

            this.TextBoxTime.Text = destinationZoneNow.ToString("dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
        }

        protected void DropDownListTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UserControlAnalogClock.TimeZoneId = this.DropDownListTimeZone.SelectedValue;
        }
    }
}