using CheckersLib.BoardElements;

namespace CheckersLib.Figures
{
    internal class Queen : Figure
    {
        internal override FigureType Type { get; private protected set; }

        internal Queen(Color color, Square square) : base(color, square)
        {
            Type = color == Color.Black ? FigureType.BQueen : FigureType.WQueen;
        }

        internal override bool CanAttack()
        {
            return IsAttackPossible(1, 1) ||
                   IsAttackPossible(1, -1) ||
                   IsAttackPossible(-1, 1) ||
                   IsAttackPossible(-1, -1);
        }
        internal override bool CanMove()
        {
            return IsEmpty(Position.X + 1, Position.Y + 1) ||
                   IsEmpty(Position.X + 1, Position.Y - 1) ||
                   IsEmpty(Position.X - 1, Position.Y + 1) ||
                   IsEmpty(Position.X - 1, Position.Y - 1);
        }
        internal override bool IsAttack(Location position)
        {
            if(OnDiagonal(Position, position))
            {
                var signX = Board.GetSign(Position.X, position.X);
                var signY = Board.GetSign(Position.Y, position.Y);
                var attacked = GetAttacked(Position, signX, signY);
                if(attacked != null)
                {
                    var endX = attacked.Position.X + signX;
                    var endY = attacked.Position.Y + signY;
                    return IsEmptyRoad(new Location(endX, endY), position);
                }
            }
            return false;
        }
        internal override bool IsMove(Location position)
        {
            return OnDiagonal(Position, position) &&
                   IsEmptyRoad(Position, position);
        }
        private bool IsAttackPossible(int signX, int signY)
        {
            var attacked = GetAttacked(Position, signX, signY);
            return IsEmptyAfter(signX, signY, attacked);
        }
        private bool IsEmptyAfter(int signX, int signY, Figure attacked)
        {
            return attacked != null &&
                   IsEnemy(attacked) &&
                   IsEmpty(attacked.Position.X + signX, attacked.Position.Y + signY);
        }
        private bool IsEmptyRoad(Location begin, Location end)
        {
            int signX = Board.GetSign(begin.X, end.X);
            int signY = Board.GetSign(begin.Y, end.Y);

            while (begin.X != end.X)
            {
                begin.X += signX;
                begin.Y += signY;

                if (IsEmpty(begin.X, begin.Y))
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        private bool OnDiagonal(Location begin, Location end)
        {
            return CheckFunc(end.X, end.Y, CalcHeight(begin, tgPlus45)) || 
                   CheckFunc(-end.X, end.Y, CalcHeight(begin, tgMinus45));
        }

        #region Математика
        //Тангенсы при +45 и -45 градусов
        private const int tgPlus45 = 1;
        private const int tgMinus45 = -1;

        /// <summary>
        /// Проверка выполнения уравнения прямой.
        /// </summary>
        /// <param name="x">Значение функции B*X.</param>
        /// <param name="y">Значение функции A*Y.</param>
        /// <param name="c">Значение функции C.</param>
        /// <returns></returns>
        private bool CheckFunc(int x, int y, int c)
        {
            return y == x + c;
        }

        /// <summary>
        /// Вычисляет значение Y в уравнении прямой, при нулевом значении X.
        /// </summary>
        /// <param name="sign">Тангенс угла</param>
        /// <returns></returns>
        private int CalcHeight(Location position, int sign)
        {
            return position.Y - (sign * position.X);
        }
        #endregion
    }
}
