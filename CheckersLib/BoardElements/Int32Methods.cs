namespace CheckersLib.BoardElements
{
    static class Int32Methods
    {
        public static bool IsOdd(this int number)
        {
            return (number & 0x1) == 1;
        }
    }
}
