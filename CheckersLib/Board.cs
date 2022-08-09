using CheckersLib.BoardElements;
using CheckersLib.Drawing;
using CheckersLib.Figures;
using CheckersLib.GameEventArgs;
using CheckersLib.Repositories;
using System;
using System.Linq;

namespace CheckersLib
{
    //TODO: Исправить: При продолжающейся атаке, можно убрать выделение и атаковать другой фигурой
    public class Board
    {
        public event EventHandler<EndEventArgs> EndEvent;
        internal event EventHandler<MoveEventArgs> MoveEvent;

        private Square[,] field;
        public Square this[int X, int Y]
        {
            get => field[X, Y];
            internal set => field[X, Y] = value;
        }

        private Color turnColor;
        public Color TurnColor
        {
            get
            {
                return turnColor;
            }
            set
            {
                turnColor = value;
                CheckEnd();
            }
        }

        internal Figure[] Figures
        {
            get
            {
                return field.Cast<Square>().
                             Where(square => !square.FigureType.IsEmpty()).
                             Select(square => square.Figure).
                             ToArray();
            }
        }


        public readonly int Size = 8;
        public (string Name1, string Name2) Names { get; private set; }
        public Location? SelectedPosition { get; internal set; }
        internal DrawUser DrawUser { get; private set; }
        internal IRepository Repo { get; set; }


        public Board(IDraw draw, IRepository repo)
        {
            field = new Square[Size, Size];
            SetField();

            Repo = repo;
            Names = repo.ReadNames();
            DrawUser = new DrawUser(draw, this);

            SubscribeEvents();
        }


        public MoveType TryMove(Location end)
        {
            if (SelectedPosition != null)
            {
                var begin = (Location)SelectedPosition;
                var moveType = this[begin.X, begin.Y].Figure.TryChangePosition(end);
                MoveEvent?.Invoke(this, new MoveEventArgs(moveType, begin, end));
                return moveType;
            }
            return MoveType.Cancel;
        }


        #region Init
        private void SubscribeEvents()
        {
            MoveEvent += ChangeTurnColor;
            MoveEvent += RefreshSelected;
            MoveEvent += DrawUser.RedrawChange;
            EndEvent += EndSave;
        }
        public void SetField(Square[,] squares)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    this[i, j] = squares[i, j] ?? new Square(new Location(i, j), this, FigureType.Empty);
                }
            }
        }
        private void SetField()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    field[i, j] = GetStandardSquare(i, j);
                }
            }
        }
        private Square GetStandardSquare(int x, int y)
        {
            var position = new Location(x, y);
            var figure = GetFigureType(x, y);

            return new Square(position, this, figure);
        }
        private FigureType GetFigureType(int x, int y)
        {
            return IsCheckPlace(x, y) ? GetFigureColor(y).GetChecker() : FigureType.Empty;
        }
        private Color GetFigureColor(int y)
        {
            return IsTop(y) ? Color.Black : Color.White;
        }
        private bool IsCheckPlace(int x, int y)
        {
            return (x + y).IsOdd() && (IsTop(y) || IsBottom(y));
        }
        private bool IsBottom(int y)
        {
            return y > Size / 2;
        }
        private bool IsTop(int y)
        {
            return y < ((Size / 2) - 1);
        }
        public bool InLocate(int x, int y)
        {
            return x < Size && x >= 0 && y < Size && y >= 0;
        }

        /// <summary>
        /// Вычисление местонахождении точки first на доске по отношению к точке second. Если правее(или выше), то возвращаемое
        /// значение равно -1, иначе 1.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        internal int GetSign(int first, int second)
        {
            return first - second > 0 ? -1 : 1;
        }
        #endregion

        #region Select
        public void Unselect()
        {
            var tempLocation = (Location)SelectedPosition;
            SelectedPosition = null;
            DrawUser.RedrawChange(tempLocation);

        }
        public bool TrySelect(Location location)
        {
            if (CanSelect(location))
            {
                Select(location);
                return true;
            }
            return false;
        }
        private void Select(Location location)
        {
            SelectedPosition = location;
            DrawUser.RedrawChange(location);
        }
        private bool CanSelect(Location location)
        {
            if (SelectedPosition == null && InLocate(location.X, location.Y))
            {
                var figure = this[location.X, location.Y].Figure;

                return figure.Color == TurnColor && (figure.CanAttack() || figure.CanMove());
            }
            return false;
        }
        private void RefreshSelected(object sender, MoveEventArgs args)
        {
            if (args.MoveType.IsContinueAttack())
            {
                SelectedPosition = args.End;
            }
            else if (args.MoveType != MoveType.Cancel)
            {
                SelectedPosition = null;
            }
        }
        #endregion

        #region Turn
        private void ChangeTurnColor(object sender, MoveEventArgs args)
        {
            if (args.MoveType != MoveType.Cancel && !args.MoveType.IsContinueAttack())
            {
                TurnSwap();
            }
        }
        private void TurnSwap()
        {
            TurnColor = TurnColor == Color.White ? Color.Black : Color.White;
        }
        #endregion

        #region End
        private void CheckWin(Figure[] figures)
        {
            int wCount = figures.Count(obj => obj.Color == Color.White);
            int bCount = figures.Length - wCount;
            DefineWinner(wCount, bCount);
        }
        private void CheckStandoff(Figure[] figures)
        {
            if (figures.All(figure => !figure.CanAttack() && !figure.CanMove()))
            {
                EndEvent(this, new EndEventArgs(EndType.Standoff));
            }
        }
        private void CheckEnd()
        {
            var figures = Figures;
            CheckWin(figures);
            CheckStandoff(figures);
        }
        private void DefineWinner(int wCount, int bCount)
        {
            if (wCount == 0)
            {
                EndEvent?.Invoke(this, new EndEventArgs(EndType.BlackWinner));
            }
            else if (bCount == 0)
            {
                EndEvent?.Invoke(this, new EndEventArgs(EndType.WhiteWinner));
            }
        }
        private void EndSave(object sender, EndEventArgs e)
        {
            Repo.SaveEndType(e.EndType);
        }
        #endregion
    }
}
