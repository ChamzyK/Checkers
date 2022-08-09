using CheckersLib.BoardElements;
using System;

namespace CheckersLib.Figures
{
    internal class Check : Figure
    {
        /// <summary>
        /// Направление движения атаки, белые шашки ходят только вверх, а черные вниз.
        /// </summary>
        protected int SignY => Color == Color.White ? -1 : 1;

        internal override FigureType Type { get; private protected set; }

        internal Check(Color color, Square square) : base(color, square)
        {
            Type = color == Color.Black ? FigureType.BCheck : FigureType.WCheck;
        }

        internal override bool CanAttack()
        {
            return IsAttack(Position.X - 2, Position.Y + 2) ||
                   IsAttack(Position.X + 2, Position.Y + 2) ||
                   IsAttack(Position.X + 2, Position.Y - 2) ||
                   IsAttack(Position.X - 2, Position.Y - 2);
        }
        internal override bool CanMove()
        {
            return IsEmpty(Position.X - 1, Position.Y + SignY) ||
                   IsEmpty(Position.X + 1, Position.Y + SignY);
        }
        private bool IsAttack(int x, int y)
        {
            return Board.InLocate(x, y) &&
                   IsAttack(Board[x, y].Position);
        }
        internal override bool IsAttack(Location position)
        {
            return IsAttackDistance(position) &&
                   IsEnemyExists(position) &&
                   IsEmpty(position.X, position.Y);
        }
        private bool IsEnemyExists(Location position)
        {
            return IsEnemy(Position.X + GetMid(position.X, Position.X), Position.Y + GetMid(position.Y, Position.Y));
        }
        private int GetMid(int begin, int end)
        {
            return (begin - end) / 2;
        }
        private bool IsAttackDistance(Location position)
        {
            return Math.Abs(position.Y - Position.Y) == 2 &&
                   Math.Abs(position.X - Position.X) == 2;
        }
        internal override bool IsMove(Location position)
        {
            return IsEmpty(position.X, position.Y) &&
                   IsAhead(position) &&
                   IsNear(position);
        }
        private bool IsNear(Location position)
        {
            return Math.Abs(position.X - Position.X) == 1;
        }
        private bool IsAhead(Location position)
        {
            return position.Y == (Position.Y + SignY);
        }
    }
}
