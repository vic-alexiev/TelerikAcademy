namespace JustPacman
{
    class JustPacmanMain
    {
        #region The Entry Point

        static void Main()
        {
            ConsoleManager consoleManager = new ConsoleManager(new Keyboard(), 150);

            consoleManager.Start();
        }

        #endregion
    }
}
