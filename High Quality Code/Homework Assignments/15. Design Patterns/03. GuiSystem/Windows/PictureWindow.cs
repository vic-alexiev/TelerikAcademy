using System;

namespace GuiSystem.Windows
{
    public class PictureWindow : BaseWindow
    {
        private string picture;

        public PictureWindow(string picture)
        {
            if (string.IsNullOrWhiteSpace(picture))
            {
                throw new ArgumentException("picture");
            }

            this.picture = picture;
        }

        protected override void DrawWindowSpecific()
        {
            this.Implementation.DrawPicture(this.picture);
        }
    }
}