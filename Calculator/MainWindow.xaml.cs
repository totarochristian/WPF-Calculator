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
        public enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Error
        }

        double lastNumber, result;
        Operator selectedOperator;

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

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            //in the if save the value as the last number
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //reset the value in the label
                resultLabel.Content = "0";
            }
        }

        private Operator ConvertCharToOperator(string value)
        {
            switch (value)
            {
                case "+": return Operator.Addition;
                case "*": return Operator.Multiplication;
                case "-": return Operator.Subtraction;
                case "/": return Operator.Division;
            }
            return Operator.Error;
        }
    }
}
