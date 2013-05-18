namespace GuiSystem.Windows
{
    public abstract class BaseWindow : IWindow
    {
        private IWindowImplementation implementation;

        protected IWindowImplementation Implementation
        {
            get
            {
                return this.implementation;
            }
        }

        protected BaseWindow()
        {
            this.implementation = WindowImplementationFactory.CreateWindowImplementation();
        }

        public void Show()
        {
            this.implementation.DrawBorders();
            this.DrawWindowSpecific();
        }

        protected virtual void DrawWindowSpecific()
        { }
    }
}