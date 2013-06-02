using System;
using System.IO;
using System.Text;

internal class DirectoryTreeBuilder
{
    //private static readonly string RootPath = Environment.GetEnvironmentVariable("windir");
    private static readonly string RootPath = "../../";

    private static StringBuilder log = new StringBuilder();

    /// <summary>
    /// The original source code can be found at
    /// http://msdn.microsoft.com/en-us/library/bb513869.aspx
    /// </summary>
    /// <param name="root">The directory being traversed.</param>
    private static void BuildDirectoryTree(TreeNode<FileSystemInfo> rootNode)
    {
        DirectoryInfo root = (DirectoryInfo)rootNode.Data;

        FileInfo[] files = null;
        DirectoryInfo[] subdirectories = null;

        // First, process all the files directly under this folder 
        try
        {
            files = root.GetFiles();
        }
        // This is thrown if even one of the files requires permissions greater 
        // than the application provides. 
        catch (UnauthorizedAccessException uaex)
        {
            // This code just writes out the message and continues to recurse. 
            // You may decide to do something different here. For example, you 
            // can try to elevate your privileges and access the file again.
            log.AppendLine(uaex.Message);
        }

        catch (DirectoryNotFoundException dnfex)
        {
            log.AppendLine(dnfex.Message);
        }

        if (files != null)
        {
            foreach (FileInfo file in files)
            {
                // In this example, we only access the existing file. If we 
                // want to open, delete or modify the file, then 
                // a try-catch block is required here to handle the case 
                // where the file has been deleted since the call to WalkDirectoryTree().
                rootNode.Nodes.Add(file);
            }

            // Now find all the subdirectories under this directory.
            subdirectories = root.GetDirectories();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                TreeNode<FileSystemInfo> childNode = rootNode.Nodes.Add(subdirectory);
                // Resursive call for each subdirectory.
                BuildDirectoryTree(childNode);
            }
        }
    }

    private static void Run()
    {
        DirectoryInfo rootDirectory = new DirectoryInfo(RootPath);

        Tree<FileSystemInfo> directoryTree = new Tree<FileSystemInfo>(rootDirectory);

        BuildDirectoryTree(directoryTree.Root);

        foreach (var parentNode in directoryTree.Root.Filter(fi => fi is DirectoryInfo))
        {
            long totalFileSize = parentNode.Accumulate(
                0L,
                (acc, fi) => acc + (fi as FileInfo).Length,
                fi => fi is FileInfo);

            Console.WriteLine(
                "Total size of files under \"{0}\": {1:N} bytes",
                parentNode.Data.FullName,
                totalFileSize);
        }

        Console.WriteLine(directoryTree);

        Console.WriteLine("Log messages:{0}{1}", Environment.NewLine, log);

        // A manifest file has been created where the highest available execution level
        // has been requested (<requestedExecutionLevel  level="highestAvailable" uiAccess="false" />).
        // Because of the privileges elevation (to avoid the UnauthorizedAccessException where possible), 
        // the application starts in another console window which should be prevented from
        // closing when the program finishes.
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey();
    }

    public static void RunWithOutputRedirected(string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            Console.SetOut(writer);
            Run();
        }
    }

    private static void Main()
    {
        //RunWithOutputRedirected("../../Resources/DirectoryTreeContents.txt");
        Run();
    }
}
