namespace CheckersLib.BoardElements
{
    public enum EndType
    {
        None, //Игра не закончена
        Standoff, //Ничья
        WhiteWinner,
        BlackWinner
    }

    public static class EndTypeMethods
    {
        public static string GetString(this EndType endType)
        {
            if (endType == EndType.WhiteWinner)
            {
                return "Победа белых!";
            }
            else if (endType == EndType.BlackWinner)
            {
                return "Победа черных!";
            }
            else if(endType == EndType.Standoff)
            {
                return "Ничья";
            }
            else
            {
                return "Игра не закончена";
            }
        }
    }
}
