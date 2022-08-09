using CheckersLib;
using CheckersLib.GameEventArgs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace CheckersUI.UserControls
{
    public partial class GameUC : UserControl
    {
        public MainWindow MainWindow { get; }
        public Board Board { get; set; }
        public GameUC(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Board = new Board(GameField, new FileRepository());
            Board.EndEvent += Board_EndEvent;
        }

        private void Board_EndEvent(object sender, EndEventArgs e)
        {
            GameField.BoardUI.Effect = new BlurEffect { Radius = 10 };
            var resultUC = new ResultUC(e.EndType);
            Grid.SetColumn(resultUC, 1);
            Grid.SetRow(resultUC, 1);
            GameGrid.Children.Add(resultUC);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainBorder.Child = MainWindow.WelcomeUC;
        }
    }
}
