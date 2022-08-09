using CheckersUI.UserControls;
using System.Windows;
using System.Windows.Input;

namespace CheckersUI
{
    public partial class MainWindow : Window
    {
        public WelcomeUC WelcomeUC { get; }
        public GameUC GameUC { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            WelcomeUC = new WelcomeUC(this);
            MainBorder.Child = WelcomeUC;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
