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

namespace ChineseRemainderTheorem
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
            var tmpa = tbA.Text.Split(' ');
            var tmpr = tbR.Text.Split(' ');

            if (tmpr.Length != tmpa.Length)
            {
                MessageBox.Show("Not ravnye dliny");
                return;
            }

            int size = tmpr.Length;
            int[] A = new int[size];
            int[] R = new int[size];

            for (int i = 0; i < tmpa.Length; ++i)
                A[i] = int.Parse(tmpa[i]);

            for (int i = 0; i < tmpr.Length; ++i)
                R[i] = int.Parse(tmpr[i]);

            SystemSolytion ss = new SystemSolytion();
            int res;
            try
            {
                res = (int)ss.Solve(R.ToList(), A.ToList());
                tbResult.Text = res.ToString();
            }
            catch (Exception)
            {
                tbResult.Text = "No solytion";
            }
        }
    }
}
