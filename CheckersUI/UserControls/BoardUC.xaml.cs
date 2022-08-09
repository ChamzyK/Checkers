using CheckersLib;
using CheckersLib.BoardElements;
using CheckersLib.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace CheckersUI.UserControls
{
    //TODO: реализовать настройки
    public partial class BoardUC : UserControl, IDraw
    {
        public Board Board { get; set; }
        public Shape[,] SquaresUI { get; private set; }
        public Shape[,] FiguresUI { get; private set; }
        public BoardUC()
        {
            InitializeComponent();
        }

        //Реализация интерфейса
        public void ClearAll()
        {
            BoardUI.Children.Clear();
        }
        public void DrawAll()
        {
            FillSquares();
        }
        public void RefreshSquareContent(Square square)
        {
            var x = square.Position.X;
            var y = square.Position.Y;
            RemoveSquare(x, y);
            FillSquare(x, y);
        }
        private void FillSquares()
        {
            SquaresUI = new Shape[Board.Size, Board.Size];
            FiguresUI = new Shape[Board.Size, Board.Size];

            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    FillSquare(i, j);
                }
            }
        }
        private void FillSquare(int x, int y)
        {
            SquaresUI[x, y] = GetSquareUI(Board[x, y].Background);
            FiguresUI[x, y] = GetFigureUI(Board[x, y].FigureType);

            SetCoords(x, y, 1, SquaresUI[x, y]);
            SetCoords(x, y, 2, FiguresUI[x, y]);

            BoardUI.Children.Add(SquaresUI[x, y]);
            BoardUI.Children.Add(FiguresUI[x, y]);
        }
        private void SetCoords(int x, int y, int z, Shape shape)
        {
            SetXCoord(shape, x);
            SetYCoord(shape, y);
            SetZIndex(shape, z);
        }
        private void RemoveSquare(int x, int y)
        {
            BoardUI.Children.Remove(SquaresUI[x, y]);
            BoardUI.Children.Remove(FiguresUI[x, y]);
        }
        private Shape GetFigureUI(FigureType figureType)
        {
            if (figureType.IsBlack())
            {
                return (Shape)Resources[figureType.IsCheck() ? "BlackCheck" : "BlackQueen"];
            }
            else if (figureType.IsWhite())
            {
                return (Shape)Resources[figureType.IsCheck() ? "WhiteCheck" : "WhiteQueen"];
            }
            var rect = new Rectangle { Opacity = 0 };
            Panel.SetZIndex(rect, 0);
            return rect;
        }
        private Shape GetSquareUI(SquareType squareType)
        {
            if (squareType == SquareType.Black)
            {
                return (Shape)Resources["BlackSquare"];
            }
            else if (squareType == SquareType.White)
            {
                return (Shape)Resources["WhiteSquare"];
            }
            return (Shape)Resources["SelectedSquare"];
        }
        private void SetXCoord(UIElement uIElement, int x)
        {
            Canvas.SetLeft(uIElement, x * 100);
        }
        private void SetYCoord(UIElement uIElement, int y)
        {
            Canvas.SetTop(uIElement, y * 100);
        }
        private void SetZIndex(UIElement uIElement, int z)
        {
            Panel.SetZIndex(uIElement, z);
        }

        private void BoardUI_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var position = GetPostion(e.GetPosition(BoardUI));
            if (Board.SelectedPosition == null)
            {
                Board.TrySelect(position);
            }
            else if (Board.SelectedPosition == position)
            {
                Board.Unselect();
            }
            else
            {
                Board.TryMove(position);
            }
            e.Handled = true;
        }

        private Location GetPostion(Point point)
        {
            return new Location((int)(point.X / 100), (int)(point.Y / 100));
        }

        public void WriteNames((string name1, string name2) names)
        {
            //TODO: реализовать вывод имен
        }
    }
}
