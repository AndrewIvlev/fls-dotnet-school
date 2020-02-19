using System;

namespace task1
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            const string PathToFileWithMap = "TestData\\Map7.txt";
            const int MaxCountOfLinesInFileMap = 1024;
            
            var stringArrayFromFile = MapFileReader.ReadFromFile(
                Path.Combine(Environment.CurrentDirectory, PathToFileWithMap),
                MaxCountOfLinesInFileMap);
            var treasureMap = new TreasureMap(stringArrayFromFile);

            var console = new ConsoleWrapper();
            console.SetupConsoleWindow(treasureMap.Width, treasureMap.Height);

            //console.ShowTreasureMap(treasureMap.ToString());
        }
    }
}
