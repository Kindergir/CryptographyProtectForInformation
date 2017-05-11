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

namespace Legendre
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


        private void BtnCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbA.Text == "" || tbP.Text == "")
            {
                MessageBox.Show("Enter numbers", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Int64 a, p;
            try
            {
                a = Int32.Parse(tbA.Text);
                p = Int64.Parse(tbP.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("This is not a number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbRes.Text = SymbolLegendre.Calculate(a, p).ToString();
        }
    }
}
