using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

class DownloadFile
{
    static void Main()
    {
        Console.Write("Enter a URL to download from: ");
        string url = Console.ReadLine();

        WebClient webClient = null;

        try
        {
            string fileName = Path.GetFileName(url);

            if (!String.IsNullOrWhiteSpace(fileName))
            {
                string destination = Path.Combine(Application.StartupPath, fileName);

                webClient = new WebClient();

                Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, url);

                // Download the Web resource and save it into the current filesystem folder.
                webClient.DownloadFile(url, destination);

                Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, url);
                Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
            }
            else
            {
                Console.WriteLine("No valid web resource specified.");
            }
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (WebException we)
        {
            Console.WriteLine(we.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        finally
        {
            if (webClient != null)
            {
                webClient.Dispose();
            }
        }
    }
}
