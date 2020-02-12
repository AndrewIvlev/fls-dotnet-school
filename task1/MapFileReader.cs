using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task1
{
    public static class MapFileReader
    {
        public static string[] ReadFromFile(string filePath, int maxCountLines)
        {
            var map = new string[maxCountLines];
            var i = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                if (i <= maxCountLines)
                {
                    map[i] = line;
                }
                else
                {
                    break;
                }
            }

            return map;
        }
    }
}
