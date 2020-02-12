using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    public class ConsoleWrapper
    {
        private string defaultTheme =
@"0123456789012345678901234567890123456789
1                                      #
2                                      #
3                                      #
4                                      #
5                                      #
6                                      #
7                                      #
8                                      #
9                                      #
0                                      #
1                                      #
2                                      #
3                                      #
4                                      #
5                                      #
6                                      #
7                                      #
8                                      #
9#######################################";

        public void SetupConsoleWindow(int rows, int columns)
        {
            // Статический метод WriteLine системного класса Console выводит строку в консоль
            Console.WriteLine("Hello world!");

            // У консольного окна есть размер самого окна и размер буфера
            // Их можно установить так:
            Console.SetWindowSize(columns, rows);
            Console.SetBufferSize(columns + 1, rows + 1); // задаём буфер с запасом, чтобы избежать нежелательной прокрутки окна
            // Убираем курсор, если он не нужен
            Console.CursorVisible = false;

            // Мы можем поменять цвет фона и символов
            Console.ForegroundColor = System.ConsoleColor.DarkGray;
            Console.BackgroundColor = System.ConsoleColor.White;
            // Установленные цвета влияют на то, как будут выводится символы в консоль
            // после установки цветов, но не меняют её текущий вид

            // Метод .Clear очищает консоль и заполняет её фон выбранным цветом.
            Console.Clear();

            // Мы можем выводить строку на экран, без перевода курсора на следующую строку методом Write
            Console.SetCursorPosition(0, 0); // Так можно задать позицию курсора - с этого места начнётся
                                             // вывод на консоль следующей командой .Write**
            Console.Write(screenshot);

            // Статические методы класса Math могут пригодится для решения первого задания.
            // Так можно округлить число с плавающей точкой до целого по правилам арифметического округления.
            int x = (int)Math.Round(1.3 * 15); // x == 20
        }
    }
}
