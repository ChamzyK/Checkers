using CheckersLib.Figures;

namespace CheckersLib.BoardElements
{
    public class Square
    {
        public SquareType Background 
        { 
            get
            {
                if (IsSelected())
                {
                    return SquareType.SelectedBlack;
                }
                else
                {
                    return GetStandardType();
                }
            }
        }
        public FigureType FigureType
        {
            get
            {
                return Figure.Type;
            }
        }
        internal Figure Figure { get; set; }
        public Location Position { get; private set; }
        public Board Board { get;  internal set; }
        public Square(Location position, Board board, FigureType figureType = FigureType.Empty)
        {
            Position = position;
            Board = board;
            Figure = figureType.GetFigure(this);
        }
        private SquareType GetStandardType()
        {
            return (Position.X + Position.Y).IsOdd() ? SquareType.Black : SquareType.White;
        }
        private bool IsSelected()
        {
            return Board.SelectedPosition != null && Board.SelectedPosition == Position;
        }
    }
}
