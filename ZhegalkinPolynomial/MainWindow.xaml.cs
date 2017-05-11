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

namespace ZhegalkinPolynomialDemo
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

        private void Calculate_OnClick(object sender, RoutedEventArgs e)
        {
            List<int> vector;
            try
            {
                vector = ConvertToValuesVector(tbVec.Text);
            }
            catch (Exception)
            {
                return;
            }

            var polynomial = ZhegalkinPolynomial.ConstructPolynomial(vector);
            tbRes.Text = polynomial;
        }

        private List<int> ConvertToValuesVector(string vec)
        {
            var vectorString = vec.Split(' ');
            var vector = new List<int>();
            foreach (var s in vectorString)
            {
                int current;
                if (Int32.TryParse(s, out current))
                    vector.Add(current);
                else
                    throw new ArgumentException();
            }
            return vector;
        }
    }
}
