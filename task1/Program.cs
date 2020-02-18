using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select map, for example 'Map7.txt'");

            MapFileReader.ReadFromFile();
        }
    }
}
