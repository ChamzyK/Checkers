namespace CheckersLib.BoardElements
{
    public enum Color
    {
        White,
        None,
        Black
    }

    public static class ColorMethods
    {
        public static FigureType GetChecker(this Color color)
        {
            if (color == Color.Black)
            {
                return FigureType.BCheck;
            }
            else if (color == Color.White)
            {
                return FigureType.WCheck;
            }
            throw new System.Exception("Цвет фигуры был пустой");
        }
    }
}
