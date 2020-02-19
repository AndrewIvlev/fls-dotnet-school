using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task1
{
    public static class MapFileReader
    {
        public static List<string> ReadFromFile(string filePath, int maxCountLines)
        {
            var map = new List<string>();
            var i = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                if (i++ <= maxCountLines)
                {
                    map.Add(line);
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
