using System.Windows;
using System.Windows.Controls;

namespace CheckersUI.UserControls
{
    public partial class WelcomeUC : UserControl
    {
        public MainWindow MainWindow { get; }
        public WelcomeUC(MainWindow ownerWin)
        {
            InitializeComponent();
            MainWindow = ownerWin;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Close();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GameUC = new GameUC(MainWindow);
            MainWindow.MainBorder.Child = MainWindow.GameUC;
            ContinueButton.IsEnabled = true;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainBorder.Child = MainWindow.GameUC;
        }
    }
}
