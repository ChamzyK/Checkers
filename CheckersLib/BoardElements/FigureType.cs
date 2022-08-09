using CheckersLib.Figures;

namespace CheckersLib.BoardElements
{
    public enum FigureType
    {
        Empty,
        WCheck,
        WQueen,
        BCheck,
        BQueen
    }
    public static class FigureTypeMethods
    {
        public static bool IsWhite(this FigureType figure)
        {
            return figure == FigureType.WCheck || figure == FigureType.WQueen;
        }
        public static bool IsBlack(this FigureType figure)
        {
            return figure == FigureType.BCheck || figure == FigureType.BQueen;
        }
        public static bool IsEmpty(this FigureType figure)
        {
            return figure == FigureType.Empty;
        }

        public static bool IsCheck(this FigureType figure)
        {
            return figure == FigureType.BCheck || figure == FigureType.WCheck;
        }
        public static bool IsQueen(this FigureType figure)
        {
            return figure == FigureType.BQueen || figure == FigureType.WQueen;
        }
        public static Color GetColor(this FigureType figure)
        {
            if (figure.IsWhite())
            {
                return Color.White;
            }
            else if (figure.IsBlack())
            {
                return Color.Black;
            }
            else
            {
                return Color.None;
            }
        }
        internal static Figure GetFigure(this FigureType figureType, Square square)
        {
            var color = figureType.GetColor();

            if (figureType.IsEmpty())
            {
                return new Empty(color, square);
            }
            else if (figureType.IsCheck())
            {
                return new Check(color, square);
            }
            else
            {
               return new Queen(color, square);
            }
        }

    }
}
