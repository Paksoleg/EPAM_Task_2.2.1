using System;
using System.Threading;

namespace Game
{
    class Programm
    {
        public static void Main(String[] agrs)
        {
            // начинаем игру
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            // Отображаемый символ тела персонажа
            char ch = '*';
            bool gameLive = true;
            ConsoleKeyInfo consoleKey; // Нажатая клавиша
            // начальная позиция и ограничение
            int x = 0, y = 2; 
            int dx = 1, dy = 0;
            int consoleWidthLimit = 79;
            int consoleHeightLimit = 24;
            // Очищает фон перед исполнением цикла 
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            //  задержка движения
            int delayInMillisecs = 50;
            do 
            {         
                ConsoleColor cc = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Arrows move up/down/right/left. 't' trail.  'c' clear  'esc' quit.");
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = cc;

                // если нажата какая-то клавиша.Проверка на нажатие клавиши
                if (Console.KeyAvailable)
                {
                    // какую клавишу нажимаем
                    consoleKey = Console.ReadKey(true);
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.T:
                            break;
                        case ConsoleKey.C:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Clear();
                            break;
                        case ConsoleKey.UpArrow: //вверх
                            dx = 0;
                            dy = -1;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ConsoleKey.DownArrow: // вниз
                            dx = 0;
                            dy = 1;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ConsoleKey.LeftArrow: //влево
                            dx = -1;
                            dy = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ConsoleKey.RightArrow: //вправо
                            dx = 1;
                            dy = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case ConsoleKey.Escape: //Выйти
                            gameLive = false;
                            break;
                    }
                }
                // расчитываем новую позицию после очистки
                x += dx;
                if (x > consoleWidthLimit)
                    x = 0;
                if (x < 0)
                    x = consoleWidthLimit;

                y += dy;
                if (y > consoleHeightLimit)
                    y = 2; 
                if (y < 2)
                    y = consoleHeightLimit;
           
                Console.SetCursorPosition(x, y);
                Console.Write(ch);
               //задержка
                Thread.Sleep(delayInMillisecs);
            } while (gameLive);
        }
    }
}
