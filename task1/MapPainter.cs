using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace task1
{
    public class MapPainter
    {
        public void SetupConsoleWindow(int rows = 20, int columns = 40)
        {
            if (rows < 20) rows = 20;
            if (columns < 40) columns = 40;

            Console.SetWindowSize(columns, rows);
            Console.SetBufferSize(columns + 1, rows + 1);
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            this.DrawEdges(rows, columns);
        }

        public void DrawEdges(int rows, int columns)
        {
            for (var i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(i % 10);
            }

            for (var i = 0; i < columns; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(i % 10);
            }

            for (var i = 0; i < columns; i++)
            {
                Console.SetCursorPosition(i, rows - 1);
                Console.Write('#');
            }

            for (var i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(columns - 1, i);
                Console.Write('#');
            }
        }

        public void DrawMap(TreasureMap map)
        {
            this.DrawRectangle(map.Base.UpperLeft, map.Base.LowerRight, '@');

            foreach (var line in map.Water)
            {
                this.DrawLine(line.Start, line.End, '~');
            }

            this.DrawPoint(map.Bridge, '#');

            this.DrawPoint(map.Treasure, '+');
        }

        private void DrawRectangle(Point upperLeft, Point lowerRight, char filler)
        {
            for (var x = upperLeft.X; x < lowerRight.X; x++)
            {
                for (var y = upperLeft.Y; y < lowerRight.Y; y++)
                {
                    this.DrawPoint(new Point(x, y), filler);
                }
            }
        }

        private void DrawLine(Point start, Point end, char filler)
        {
            for (var y = start.Y; y < end.Y; y++)
            {
                var x = (int)Math.Round((decimal) ((y - start.Y) * (end.X - start.X) / (end.Y - start.Y) + start.X));
                this.DrawPoint(new Point(x, y), filler);
            }

            for (var x = start.X; x < end.X; x++)
            {
                var y = (int)Math.Round((decimal) ((x - start.X) * (end.Y - start.Y) / (end.X - start.X) + start.Y));
                this.DrawPoint(new Point(x, y), filler);
            }
        }

        private void DrawPoint(Point p, char filler)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(filler);
        }
    }
}
