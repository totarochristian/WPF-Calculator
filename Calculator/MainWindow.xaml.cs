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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;

        /// <summary>
        /// Constructor of the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event handler of all the numerical buttons of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is a buttons with a numeric value</param>
        /// <param name="e"></param>
        private void NumericalButton_Click(object sender, RoutedEventArgs e)
        {
            double numericalValue = 0;
            if(sender.GetType() == typeof(Button) && double.TryParse(((Button)sender).Content.ToString(),out numericalValue))
            {
                if (resultLabel.Content.ToString() == "0")
                    resultLabel.Content = numericalValue.ToString();
                else
                    resultLabel.Content = $"{resultLabel.Content}{numericalValue}";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }
    }
}
