using CheckersLib.BoardElements;
using CheckersLib.GameEventArgs;

namespace CheckersLib.Drawing
{
    internal class DrawUser
    {
        private IDraw draw;
        internal IDraw Draw
        {
            private get
            {
                return draw;
            }
            set
            {
                draw = value;
                draw.Board = Board;
                RedrawBoard();
            }
        }
        internal Board Board { get; private set; }
        internal DrawUser(IDraw draw, Board board)
        {
            Board = board;
            Draw = draw;
        }
        internal void RedrawBoard()
        {
            Draw.ClearAll();
            Draw.DrawAll();
            Draw.WriteNames(Board.Names);
        }
        internal void RedrawChange(object sender, MoveEventArgs args)
        {
            if (args.MoveType != MoveType.Cancel)
            {
                var begin = args.Begin;
                var end = args.End;
                RedrawBeginToEnd(begin, end);
            }
        }
        private void RedrawBeginToEnd(Location begin, Location end)
        {
            int signX = Board.GetSign(begin.X, end.X);
            int signY = Board.GetSign(begin.Y, end.Y);

            while (begin.X != end.X + signX)
            {
                Draw.RefreshSquareContent(Board[begin.X, begin.Y]);
                begin.X += signX;
                begin.Y += signY;
            }
        }
        internal void RedrawChange(Location begin)
        {
            int x = begin.X;
            int y = begin.Y;
            Draw.RefreshSquareContent(Board[x, y]);
        }
    }
}
