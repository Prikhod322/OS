using System.Diagnostics;
using System;
using System.IO;

namespace OS
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >=1)
            {
                FileInfo fi = new FileInfo(args[0]);

                Console.WriteLine($"Full path:\t\t{ fi.FullName}");
                Console.WriteLine($"Creation Time:\t\t{ fi.CreationTime}");
                Console.WriteLine($"Last Access Time:\t{ fi.LastAccessTime}");
                Console.WriteLine($"Last Write Time:\t{ fi.LastWriteTime}");
                Console.WriteLine($"Size (Bytes):\t\t{ fi.Length}");
                Console.WriteLine($"Is Read Only:\t\t{ fi.IsReadOnly}");

                if (args.Length == 2 && args[1] == "--open")
                {
                    Process.Start( new ProcessStartInfo($"{args[0]}" ) { UseShellExecute = true });
                }
            }
        }
    }
}
