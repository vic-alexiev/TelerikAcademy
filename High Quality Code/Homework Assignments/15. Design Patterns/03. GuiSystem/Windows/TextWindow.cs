using System;

namespace GuiSystem.Windows
{
    public class TextWindow : BaseWindow
    {
        private string text;

        public TextWindow(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("text");
            }

            this.text = text;
        }

        protected override void DrawWindowSpecific()
        {
            this.Implementation.DrawTextBox(this.text, true);
        }
    }
}