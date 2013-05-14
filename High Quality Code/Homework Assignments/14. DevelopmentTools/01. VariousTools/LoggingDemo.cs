using log4net;
using log4net.Config;
using System;
using System.Reflection;

internal class LoggingDemo
{
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    private static void Main()
    {
        // log4net configuration is placed in the 'App.config' file where
        // a new <log4net> section has been added.
        // Currently two appenders are defined: the first prints the log
        // messages to the console, the second - to the file 'DemoLogger.log'
        // located in the application root directory (\bin\Debug).
        XmlConfigurator.Configure();

        Log.Debug("Debug message");
        Log.Info("Info message");
        Log.Warn("Warning message");
        Log.Error("Error message");
        Log.Fatal("Fatal message");

        try
        {
            throw new InvalidOperationException("An exception occurred.");
        }
        catch (InvalidOperationException ex)
        {
            Log.Error("Error.", ex);
        }
    }
}
