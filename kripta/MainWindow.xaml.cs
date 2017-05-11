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

namespace PrimalityTestsDemo
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
            if (tbNumber.Text == "")
            {
                MessageBox.Show("Enter number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Int64 n;
            try
            {
                n = Int32.Parse(tbNumber.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("This is not a number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrimalityTest test = new PrimalityTest();
            bool res = false;
            if (rbFermat.IsChecked.Value)
                res = test.Fermat(n);

            if (rbMillerRabin.IsChecked.Value)
                res = test.MillerRabin(n);

            if (rbSolovayStrassen.IsChecked.Value)
                res = test.SolovayStrassen(n);

            if (res)
                tbResult.Text = "Primary";
            else
                tbResult.Text = "Not primary";
        }
    }
}
