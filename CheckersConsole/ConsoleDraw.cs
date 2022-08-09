using CheckersLib;
using CheckersLib.BoardElements;
using CheckersLib.Drawing;
using System;

namespace CheckersConsole
{
    class ConsoleDraw : IDraw
    {
        public Board Board { get; set; }

        public void ClearAll()
        {
            Console.Clear();
        }
        public void DrawAll()
        {
            DrawCheckersField();
            WriteCheckers();
        }
        public void RefreshSquareContent(Square square)
        {
            DrawRect(square.Position.X, square.Position.Y);
            WriteChecker(square.Position.X, square.Position.Y);
        }
        public void DrawSelected(int x, int y)
        {
            DrawRect(x, y, Settings.SELECT_CELL_COLOR);
            WriteChecker(x, y);
        }
        public void WriteNames((string name1, string name2) names)
        {
            Console.SetCursorPosition(1, 5);
            Console.Write(names.name1);
            Console.SetCursorPosition(70, 24);
            Console.Write(names.name2);
        }

        private string GetFigureName(FigureType figure)
        {
            var name = Settings.EMPTY_NAME;
            if (figure.IsCheck())
            {
                name = Settings.CHECKER_NAME;
            }
            else if (figure.IsQueen())
            {
                name = Settings.QUEEN_NAME;
            }
            return name;
        }
        private ConsoleColor GetFigureColor(FigureType figure)
        {
            var checkColor = Settings.EMPTY_CHECKER_COLOR;
            if (figure.IsWhite())
            {
                checkColor = Settings.WHITE_CHECKER_COLOR;
            }
            else if (figure.IsBlack())
            {
                checkColor = Settings.BLACK_CHECKER_COLOR;
            }
            return checkColor;
        }
        private ConsoleColor GetSquareColor(SquareType square)
        {
            ConsoleColor rectColor;
            switch (square)
            {
                case SquareType.White:
                    rectColor = Settings.WHITE_CELL_COLOR;
                    break;
                case SquareType.SelectedBlack:
                    rectColor = Settings.SELECT_CHECKER_COLOR;
                    break;
                default:
                    rectColor = Settings.BLACK_CELL_COLOR;
                    break;
            }
            return rectColor;
        }
        private void WriteCheckers()
        {
            for (int i = 0; i < Settings.FIELD_SIZE; i++)
            {
                for (int j = 0; j < Settings.FIELD_SIZE; j++)
                {
                    WriteChecker(i, j);
                }
            }
        }
        private void WriteChecker(int x, int y)
        {
            var fType = Board[x, y].FigureType;
            var (absX, absY) = ConvertToAbsCoordinate(x, y);

            Console.ForegroundColor = GetFigureColor(fType);
            Console.BackgroundColor = GetSquareColor(Board[x, y].Background);

            Console.SetCursorPosition(absX + 1, absY + 1);
            Console.Write(GetFigureName(fType));

            Console.ResetColor();
        }
        private void DrawCheckersField()
        {
            for (int i = 0; i < Settings.FIELD_SIZE; i++)
            {
                for (int j = 0; j < Settings.FIELD_SIZE; j++)
                {
                    var absY = GetAbsY(j) + 1;

                    Write(GetSymbol(j), Settings.FIELD_LEFT - 3, absY);
                    DrawRect(i, j);
                }

                var absX = GetAbsX(i) + 2;
                Write((char)(i + 'A'), absX, Settings.FIELD_TOP - 2);
            }
        }
        private char GetSymbol(int j)
        {
            return Convert.ToChar((j + 1).ToString());
        }
        private void Write(char symbol, int absX, int absY)
        {
            Console.SetCursorPosition(absX, absY);
            Console.Write(symbol);
        }
        private void DrawRect(int x, int y)
        {
            var backgroundColor = GetSquareColor(Board[x, y].Background);

            DrawRect(x, y, backgroundColor);
        }
        private void DrawRect(int x, int y, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;

            var (absX, absY) = ConvertToAbsCoordinate(x, y);

            for (int i = absX; i < Settings.CellWidth + absX; i++)
            {
                for (int j = absY; j < Settings.CellHeight + absY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
        private (int X, int Y) ConvertToAbsCoordinate(int x, int y)
        {
            return (GetAbsX(x), GetAbsY(y));
        }
        private int GetAbsX(int x)
        {
            return Settings.FIELD_LEFT + x * 6;
        }
        private int GetAbsY(int y)
        {
            return Settings.FIELD_TOP + y * 3;
        }
    }
}
