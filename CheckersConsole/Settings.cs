using System;

namespace CheckersConsole
{
    static class Settings
    {
        //Размеры для корректного отображения в консоли
        //не рекомендуется менять значения
        public const int FIELD_HEIGHT = 24; //24
        public const int FIELD_WIDTH = 48; //48
        public const int FIELD_LEFT = 15; //15
        public const int FIELD_TOP = 3; //3
        public const int FIELD_SIZE = 8; //8
        public const int CellHeight = FIELD_HEIGHT / FIELD_SIZE;
        public const int CellWidth = FIELD_WIDTH / FIELD_SIZE;

        //Цвета
        public const ConsoleColor WHITE_CHECKER_COLOR = ConsoleColor.White;
        public const ConsoleColor BLACK_CHECKER_COLOR = ConsoleColor.Black;
        public const ConsoleColor WHITE_CELL_COLOR = ConsoleColor.Gray;
        public const ConsoleColor BLACK_CELL_COLOR = ConsoleColor.DarkBlue;
        public const ConsoleColor SELECT_CHECKER_COLOR = ConsoleColor.DarkGreen;
        public const ConsoleColor SELECT_CELL_COLOR = ConsoleColor.DarkYellow;
        public const ConsoleColor EMPTY_CHECKER_COLOR = BLACK_CELL_COLOR;

        //Обозначения
        public const string CHECKER_NAME = "круг"; //длина должна быть 4
        public const string QUEEN_NAME = "ромб"; //длина должна быть 4
        public const string EMPTY_NAME = "    "; //длина строки должна быть 4
    }
}
