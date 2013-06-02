using System.Diagnostics;

internal class WindowsDirectoryTraversalRunner
{
    private static void Main()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo(WindowsDirectoryTraversal.Location);
        startInfo.Verb = "runas";
        Process.Start(startInfo);
    }
}
