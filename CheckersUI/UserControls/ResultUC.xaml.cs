using CheckersLib.BoardElements;
using System.Windows.Controls;

namespace CheckersUI.UserControls
{
    public partial class ResultUC : UserControl
    {
        public ResultUC(EndType endType)
        {
            InitializeComponent();
            ResultTextBlock.Text = endType.GetString();
        }
    }
}
