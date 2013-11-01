using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || String.IsNullOrEmpty(args[0]) || args[0] == "/?" || args[0] == "?")
            {
                Console.WriteLine("\t\tA command sequence should be entered.\n" +
                                  "\t\tThe allowable characters are R, L, F, B.\n" +
                                  "\t\tThe program prints the final coordinates of the rover,\n" +
                                  "\t\tthe index of the last executed command and then a word\n" +
                                  "\t\t(Yes or No) specifying whether all the commands have\n" +
                                  "\t\tbeen executed successfully.\n");
            }
            else
            {
                try
                {
                    int x;
                    int y;
                    int lastSuccessIndex;
                    bool success = MarsRover.Run(args[0], out x, out y, out lastSuccessIndex);
                    Console.WriteLine("{0} {1} {2} {3}", x, y, lastSuccessIndex, success ? "Yes" : "No");
                }
                catch (InvalidCommandsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
