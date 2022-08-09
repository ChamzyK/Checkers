using CheckersLib.BoardElements;

namespace CheckersLib.Figures
{
    internal abstract class Figure
    {
        internal Square Square { get; set; }
        internal Location Position
        {
            get
            {
                return Square.Position;
            }
            set
            {

                var figure = Board[Position.X, Position.Y].Figure;
                Board[Position.X, Position.Y].Figure = Board[value.X, value.Y].Figure;
                Board[value.X, value.Y].Figure = figure;

                Square = Board[value.X, value.Y];
            }
        }
        internal Color Color { get; }
        internal Board Board 
        { 
            get
            {
                return Square.Board;
            }
        }
        internal abstract FigureType Type { get; private protected set; }
        protected Figure(Color color, Square square)
        {
            Color = color;
            Square = square;
        }
        internal abstract bool CanAttack();
        internal abstract bool CanMove();
        internal abstract bool IsAttack(Location position);
        internal abstract bool IsMove(Location position);

        internal MoveType TryChangePosition(Location end)
        {

            if (IsMove(end) && !IsMustAttack())
            {
                Move(end);
                return DefineMove();
            }
            else if (IsAttack(end))
            {
                Attack(end);
                return DefineAttack();
            }

            return MoveType.Cancel;
        }

        private MoveType DefineMove()
        {
            return TryTransformation() ? MoveType.MoveTransformation : MoveType.Move;
        }
        private MoveType DefineAttack()
        {
            if (TryTransformation())
            {
                return CanAttack() ? MoveType.AttackTransformationWithContinue : MoveType.AttackTransformation;
            }
            else
            {
                return CanAttack() ? MoveType.AttackWithContinue : MoveType.Attack;
            }
        }
        private void Move(Location end)
        {
            Position = end;
        }
        private void Attack(Location end)
        {
            int signX = Board.GetSign(Position.X, end.X);
            int signY = Board.GetSign(Position.Y, end.Y);
            var attacked = GetAttacked(Position, signX, signY).Position;

            Move(end);
            DeleteAttacked(attacked);
        }
        private void DeleteAttacked(Location attacked)
        {
            var attackedSquare = Board[attacked.X, attacked.Y];
            attackedSquare.Figure = new Empty(Color.None, attackedSquare);
        }
        protected Figure GetAttacked(Location begin, int signX, int signY)
        {
            Figure figure = null;

            while (Board.InLocate(begin.X + signX, begin.Y + signY))
            {
                begin.X += signX;
                begin.Y += signY;
                if (!IsEmpty(begin.X, begin.Y))
                {
                    figure = Board[begin.X, begin.Y].Figure;
                    break;
                }
            }
            return figure;
        }
        private bool IsMustAttack()
        {
            var figures = Board.Figures;

            for (int i = 0; i < figures.Length; i++)
            {
                if (IsFriend(figures[i]) && figures[i].CanAttack())
                {
                    return true;
                }
            }
            return false;
        }
        protected bool IsEmpty(int x, int y)
        {
            return Board.InLocate(x, y) && Board[x, y].Figure is Empty;
        }
        protected bool IsFriend(Figure figure)
        {
            return figure.Color == Color;
        }
        protected bool IsEnemy(int x, int y)
        {
            return Board.InLocate(x, y) && 
                   IsEnemy(Board[x, y].Figure);
        }
        protected bool IsEnemy(Figure figure)
        {
            return figure.Color != Color.None && 
                   figure.Color != Color;
        }
        private bool TryTransformation()
        {
            if (this is Check && IsTransformation(Position))
            {
                Transform(Position);
                return true;
            }
            return false;
        }
        private bool IsTransformation(Location position)
        {
            return Color == Color.White ? position.Y == 0 : position.Y == Board.Size - 1;
        }
        private void Transform(Location position)
        {
            var transformSquare = Board[position.X, position.Y];
            transformSquare.Figure = new Queen(Color, transformSquare);
        }
    }
}
