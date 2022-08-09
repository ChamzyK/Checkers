using System;

namespace CheckersConsole
{
    static class ConsoleKeyMethods
    {
        public static bool IsArrowKey(this ConsoleKey key)
        {
            return key == ConsoleKey.UpArrow ||
                   key == ConsoleKey.DownArrow ||
                   key == ConsoleKey.RightArrow ||
                   key == ConsoleKey.LeftArrow;
        }
        public static (int X, int Y) GetDirection(this ConsoleKey arrowKey)
        {
            if (arrowKey.IsHorizontal())
            {
                return (arrowKey == ConsoleKey.RightArrow ? 1 : -1, 0);
            }
            else if(arrowKey.IsVertical())
            {
                return (0, arrowKey == ConsoleKey.UpArrow ? -1 : 1);
            }
            throw new Exception("Клавиша не является направляющей");
        }
        public static bool IsHorizontal(this ConsoleKey arrowKey)
        {
            return arrowKey == ConsoleKey.RightArrow || arrowKey == ConsoleKey.LeftArrow;
        }
        public static bool IsVertical(this ConsoleKey arrowKey)
        {
            return arrowKey == ConsoleKey.UpArrow || arrowKey == ConsoleKey.DownArrow;
        }
    }
}
