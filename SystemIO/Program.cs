using System;
using System.IO;

namespace SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Majevski\Documents\Dev\github\SystemIO\files\file1.txt";
            string targetPath = @"C:\Users\Majevski\Documents\Dev\github\SystemIO\files\file2.txt";
            string[] lines = File.ReadAllLines(sourcePath);
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
