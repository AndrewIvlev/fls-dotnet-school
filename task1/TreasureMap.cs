using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    public struct Point
    {
        public int X;

        public int Y;
    }

    public struct Line
    {
        public Point Start;

        public Point End;
    }

    public struct Base
    {
        public Point UpperLeft;

        public Point LowerDown;
    }

    public class TreasureMap
    {
        private const string BASE = "BASE";

        private const string WATER = "WATER";

        private const string TREASURE = "Treasure";

        private const string BRIDGE = "bridge";

        public Base Base { get; set; }

        public List<Line> Water { get; set; }

        public Point Treasure { get; set; }

        public Point Bridge { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public TreasureMap(List<string> strArray)
        {
            for (var i = 0; i < strArray.Count; i++)
            {
                var curLineAsArray = strArray[i].Split(' ');
                var firstWord = string.IsNullOrEmpty(curLineAsArray[0]) ? "empty" : curLineAsArray[0];
                if (firstWord.Contains('('))
                {
                    firstWord = firstWord.Substring(0, firstWord.IndexOf('('));
                }

                switch (firstWord)
                {
                    case BASE:
                        this.Base = this.ParseBaseFromStrings();
                        break;
                    case WATER:
                        this.Water = this.ParseWaterFromString();
                        break;
                    case TREASURE:
                        this.Treasure = this.ParsePointCoordinateFromString(strArray[i]);
                        break;
                    case BRIDGE:
                        this.Bridge = this.ParsePointCoordinateFromString(strArray[i]);
                        break;
                    default:
                        Console.WriteLine($"Unexpected key word: {firstWord}");
                        break;
                }
            }
        }

        private Base ParseBaseFromStrings()
        {
            return new Base();
        }

        private List<Line> ParseWaterFromString()
        {
            return new List<Line>();
        }

        private Point ParsePointCoordinateFromString(string str)
        {
            var result = new Point();

            str.Trim(' ');
            result.X = int.Parse(this.SubstringBetween(str, "(", ","));
            result.Y = int.Parse(this.SubstringBetween(str, ",", ")"));

            return result;
        }

        public string SubstringBetween(string str, string from, string to)
        {
            var pFrom = str.IndexOf(from) + from.Length;
            var pTo = str.LastIndexOf(to);

            return str.Substring(pFrom, pTo - pFrom);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
