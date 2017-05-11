using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ErythropheneSieveDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalc_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbN.Text == "")
            {
                MessageBox.Show("Enter number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Int64 n;
            try
            {
                n = Int32.Parse(tbN.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("This is not a number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var numbers = ErythropheneSieve.GetFor(n + 1);

            tbResult.Text = "";
            for (int i = 2; i < numbers.Length; ++i)
            {
                if (numbers[i] == 0)
                    tbResult.Text += " " + i;
            }
        }
    }
}
