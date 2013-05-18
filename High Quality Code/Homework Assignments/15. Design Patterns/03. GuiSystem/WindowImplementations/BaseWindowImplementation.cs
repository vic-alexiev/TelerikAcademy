using System;

namespace GuiSystem.WindowImplementations
{
    internal class BaseWindowImplementation : IWindowImplementation
    {
        public void DrawBorders()
        {
            Console.WriteLine("Drawing the borders of the window ({0})", this.GetType());
        }

        public void DrawTextBox(string text, bool multiline)
        {
            string isMultiline = string.Empty;
            if (multiline)
            {
                isMultiline = "multiline ";
            }

            Console.WriteLine("Drawing a {0}text box, containing '{1}'", isMultiline, text);
        }

        public void DrawPicture(string picture)
        {
            Console.WriteLine("Showing the picture '{0}'", picture);
        }

        public void DrawButton(string buttonText)
        {
            Console.WriteLine("Drawing a button called '{0}'", buttonText);
        }
    }
}
