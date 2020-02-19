using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task1
{
    public struct Point
    {
        public int X;

        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public struct Line
    {
        public Point Start;

        public Point End;

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }
    }

    public struct Base
    {
        public Point UpperLeft;

        public Point LowerRight;
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

        public Point MaxCoordinateValue { get; set; }

        public int Height => MaxCoordinateValue.X;

        public int Width => MaxCoordinateValue.Y;

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
                        this.Base = this.ParseBaseFromStrings(strArray[i]);
                        break;
                    case WATER:
                        this.Water = this.ParseWaterFromString(strArray[i]);
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

            MaxCoordinateValue = this.GetMaxCoordinateValue(); 
        }

        private Base ParseBaseFromStrings(string str)
        {
            var @base = new Base();

            str = str.Replace(" ", string.Empty);
            @base.UpperLeft.X = int.Parse(this.SubstringBetween(str, '(', ','));
            @base.UpperLeft.Y = int.Parse(this.SubstringBetween(str, ',', ':'));
            @base.LowerRight.X = int.Parse(this.SubstringBetween(str, ':', ',', 0, 1));
            @base.LowerRight.Y = int.Parse(this.SubstringBetween(str, ',', ')', 1, 0));

            return @base;
        }

        private List<Line> ParseWaterFromString(string str)
        {
            var water = new List<Line>();

            str = str.Replace(" ", string.Empty).Replace("-", string.Empty);

            var numberOfLines = str.ToCharArray().Count(ch => ch == '>');

            water.Add(new Line(
                new Point(
                    int.Parse(this.SubstringBetween(str, '(', ',')),
                    int.Parse(this.SubstringBetween(str, ',', '>'))
                    ),
                new Point(
                    int.Parse(this.SubstringBetween(str, '>', ',', 0, 1)),
                    int.Parse(this.SubstringBetween(str, ',', '>', 1, 1))
                    )));

            for (var i = 0; i < numberOfLines - 2; i++)
            {
                water.Add(new Line(
                    new Point(
                        int.Parse(this.SubstringBetween(str, '>', ',', i, i + 1)),
                        int.Parse(this.SubstringBetween(str, ',', '>', i + 1, i + 1))
                        ),
                    new Point(
                        int.Parse(this.SubstringBetween(str, '>', ',', i + 1, i + 2)),
                        int.Parse(this.SubstringBetween(str, ',', '>', i + 2, i + 2)))
                    ));
            }

            water.Add(new Line(
                new Point(
                    int.Parse(this.SubstringBetween(str, '>', ',', numberOfLines - 2, numberOfLines - 1)),
                    int.Parse(this.SubstringBetween(str, ',', '>', numberOfLines - 1, numberOfLines - 1))
                ),
                new Point(
                    int.Parse(this.SubstringBetween(str, '>', ',', numberOfLines - 1, numberOfLines)),
                    int.Parse(this.SubstringBetween(str, ',', ')', numberOfLines))
                )));

            return water;
        }

        private Point ParsePointCoordinateFromString(string str)
        {
            var result = new Point();

            str = str.Replace(" ", string.Empty);
            result.X = int.Parse(this.SubstringBetween(str, '(', ','));
            result.Y = int.Parse(this.SubstringBetween(str, ',', ')'));

            return result;
        }

        private string SubstringBetween(string str, char from, char to, int indexFrom = 0, int indexTo = 0)
        {
            var pFrom = IndexOfCharBySerialNumber(str, from, indexFrom) + 1;

            var pTo = IndexOfCharBySerialNumber(str, to, indexTo);

            return str.Substring(pFrom, pTo - pFrom);
        }

        private int IndexOfCharBySerialNumber(string str, char ch, int serialNumber)
        {
            var counter = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    if (counter == serialNumber)
                    {
                        return i;
                    }

                    counter++;
                }
            }

            return -1;
        }

        public Point GetMaxCoordinateValue()
        {
            var maxBasePoint = this.ArgMax(this.Base.UpperLeft, this.Base.LowerRight);

            var maxBridgeAndTreasurePoint = this.ArgMax(this.Bridge, this.Treasure);

            Point maxInWater = new Point(-1, -1);
            foreach (var line in Water)
            {
                Point tmp;
                tmp = this.ArgMax(line.Start, line.End);
                maxInWater = this.ArgMax(maxInWater, tmp);
            }

            var maxInBaseBridgeTreasure = this.ArgMax(maxBasePoint, maxBridgeAndTreasurePoint);
            var maxCoordinateValue = this.ArgMax(maxInBaseBridgeTreasure, maxInWater);
            return maxCoordinateValue;
        }

        private Point ArgMax(Point a, Point b) => new Point(a.X > b.X ? a.X : b.X, a.Y > b.Y ? a.Y : b.Y);
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
