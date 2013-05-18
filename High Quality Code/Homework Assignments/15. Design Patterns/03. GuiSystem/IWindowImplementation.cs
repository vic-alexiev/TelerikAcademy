namespace GuiSystem
{
    public interface IWindowImplementation
    {
        void DrawBorders();

        void DrawTextBox(string text, bool multiline);

        void DrawPicture(string picture);

        void DrawButton(string buttonText);
    }
}