using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ip_validator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        //private void txtNetworkOctet_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    int MaxNumberOfCharactersSpecifiedForTextBox = int.Parse(((TextBox)sender).MaxLength.ToString());

        //    if (((TextBox)sender).Text.Length > MaxNumberOfCharactersSpecifiedForTextBox)
        //    {
        //        ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).Text.Length - 1);
        //    }
        //}

    }
}