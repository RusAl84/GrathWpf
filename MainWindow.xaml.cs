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

namespace GrathWpf
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

        private double func(double x)
        {
            return (x * x * x - x) / (x * x + 1);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double shag = 0.5;
            int count = (int)((Convert.ToInt32(bTB.Text) - Convert.ToInt32(aTB.Text)) / shag)+1;
            double[] dataX = new double[count];
            double[] dataY = new double[count] ;

            int ind = 0;
            for (double z= Convert.ToDouble(aTB.Text);z<= Convert.ToDouble(bTB.Text); z += shag)
            {
                dataX[ind] = z;
                dataY[ind] = func(z);
                ind++;
            }

            WpfPlot1.Plot.AddScatter(dataX, dataY);
            WpfPlot1.Refresh();

            double min = Convert.ToDouble(aTB.Text);

            for (int i = 0; i < count; i++)
                if (min > dataY[i])
                    min = dataY[i];
            rTB.Text = min.ToString();

        }
    }
}
