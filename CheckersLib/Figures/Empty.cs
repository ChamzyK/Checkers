using CheckersLib.BoardElements;

namespace CheckersLib.Figures
{
    internal class Empty : Figure
    {
        internal Empty(Color color, Square square) : base(color, square)
        {
            Type = FigureType.Empty;
        }

        internal override FigureType Type { get; private protected set; }

        internal override bool CanAttack()
        {
            return false;
        }

        internal override bool CanMove()
        {
            return false;
        }

        internal override bool IsAttack(Location position)
        {
            return false;
        }

        internal override bool IsMove(Location position)
        {
            return false;
        }
    }
}
