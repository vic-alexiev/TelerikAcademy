using GuiSystem.Windows;
using System;

namespace GuiSystem
{
    internal class GuiSystemDemo
    {
        private static void UseWindow(IWindow window)
        {
            window.Show();
            Console.WriteLine();
        }

        private static void Main()
        {
            string picture = "telerik-academy.jpg";
            PictureWindow pictureWindow = new PictureWindow(picture);
            UseWindow(pictureWindow);

            string someLongText = "some long text";
            TextWindow textWindow = new TextWindow(someLongText);
            UseWindow(textWindow);

            string question = "How are you, dude?";
            string[] answers = new string[]
            {
                "I feeeeeeeel good...!",
                "Gonna jump around!",
                "Not bad, really!"
            };

            DialogWindow dialogWindow = new DialogWindow(question, answers);
            UseWindow(dialogWindow);
        }
    }
}
