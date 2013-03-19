using System;

namespace JustPacman
{
    public interface IInputDevice
    {
        event EventHandler LeftArrowKeyPressed;

        event EventHandler RightArrowKeyPressed;

        event EventHandler UpArrowKeyPressed;

        event EventHandler DownArrowKeyPressed;

        void ProcessInput();
    }
}
