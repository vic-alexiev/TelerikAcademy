using System;

namespace JustPacman
{
    public class Keyboard : IInputDevice
    {
        public event EventHandler LeftArrowKeyPressed;

        public event EventHandler RightArrowKeyPressed;

        public event EventHandler UpArrowKeyPressed;

        public event EventHandler DownArrowKeyPressed;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                // the intercept option should be set to true, the effect being 
                // that the pressed key is not displayed on the console window
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (this.LeftArrowKeyPressed != null)
                    {
                        this.LeftArrowKeyPressed(this, new EventArgs());
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (this.RightArrowKeyPressed != null)
                    {
                        this.RightArrowKeyPressed(this, new EventArgs());
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (this.UpArrowKeyPressed != null)
                    {
                        this.UpArrowKeyPressed(this, new EventArgs());
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (this.DownArrowKeyPressed != null)
                    {
                        this.DownArrowKeyPressed(this, new EventArgs());
                    }
                }
            }
        }
    }
}
