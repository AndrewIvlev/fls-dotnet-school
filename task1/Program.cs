using System;

namespace task1
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            const string pathToFileWithMap = "TestData\\Map7.txt";
            const int maxCountOfLinesInFileMap = 1024;
            
            var stringArrayFromFile = MapFileReader.ReadFromFile(
                Path.Combine(Environment.CurrentDirectory, pathToFileWithMap),
                maxCountOfLinesInFileMap);
            var treasureMap = new TreasureMap(stringArrayFromFile);

            var painter = new MapPainter();
            painter.SetupConsoleWindow(treasureMap.Width + 3, treasureMap.Height + 3);

            painter.DrawMap(treasureMap);

            Console.ReadKey();
        }
    }
}
