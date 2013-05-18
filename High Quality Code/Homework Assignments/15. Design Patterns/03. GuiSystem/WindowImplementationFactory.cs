using GuiSystem.WindowImplementations;
using System.Configuration;
using System.Diagnostics;

namespace GuiSystem
{
    internal static class WindowImplementationFactory
    {
        private const string LinuxKey = "LINUX";
        private const string MacOSXKey = "MACOSX";
        private const string WindowsKey = "WINDOWS";

        public static IWindowImplementation CreateWindowImplementation()
        {
            // here we check for the configuration settings of the application
            // and choose the right implementation
            // typically we want a window implementation for the current OS

            IWindowImplementation result;

            try
            {
                string value = GetConfigurationValue();
                result = ChooseImplementation(value);
            }
            catch (ConfigurationErrorsException ex)
            {
                // log the exception somewhere
                Debug.WriteLine(ex.ToString());
                result = new LinuxWindowImplementation();
            }

            Debug.Assert(result != null, "Implementation is null.");
            return result;
        }

        private static string GetConfigurationValue()
        {
            string value = ConfigurationManager.AppSettings["os"];

            if (value == null)
            {
                value = LinuxKey;
            }

            return value;
        }

        private static IWindowImplementation ChooseImplementation(string value)
        {
            IWindowImplementation result;

            if (value != null)
            {
                value = value.ToUpper();
            }

            switch (value)
            {
                case (LinuxKey):
                    result = new LinuxWindowImplementation();
                    break;
                case (WindowsKey):
                    result = new MSWindowsWindowImplementation();
                    break;
                case (MacOSXKey):
                    result = new MacOSXWindowImplementation();
                    break;
                default:
                    Debug.WriteLine(
                        "Couldn't find appropriate window implementation, switching to Linux window implementation.");
                    result = new LinuxWindowImplementation();
                    break;
            }

            return result;
        }
    }
}