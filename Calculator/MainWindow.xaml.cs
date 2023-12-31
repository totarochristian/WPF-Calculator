﻿using System;
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
using Calculator.Classes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Enumerator that rapresent the operations that could be done with the calculator
        /// </summary>
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

        /// <summary>
        /// Click event handler of the ac button of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is the ac button</param>
        /// <param name="e"></param>
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        /// <summary>
        /// Click event handler of the negative button of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is the negative button</param>
        /// <param name="e"></param>
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        /// <summary>
        /// Click event handler of the percentage button of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is the percentage button</param>
        /// <param name="e"></param>
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tmpNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tmpNumber))
            {
                tmpNumber = tmpNumber / 100;
                if (lastNumber != 0)
                    tmpNumber *= lastNumber;
                resultLabel.Content = tmpNumber.ToString();
            }
        }

        /// <summary>
        /// Click event handler of all the operations buttons of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is an operation button</param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            //in the if save the value as the last number
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //reset the value in the label
                resultLabel.Content = "0";
                string? operatorCharacter = ((Button)sender).Content.ToString();
                selectedOperator = ConvertCharToOperator(operatorCharacter);
            }
        }

        /// <summary>
        /// Method used to convert a char to the relative operation
        /// </summary>
        /// <param name="value">Special character that rapresent the operation to do</param>
        /// <returns>Operation related to the special character</returns>
        private Operator ConvertCharToOperator(string? value)
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

        /// <summary>
        /// Click event handler of the result button of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is the result button</param>
        /// <param name="e"></param>
        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (selectedOperator != Operator.Error && double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case Operator.Addition:
                        result = SimpleMath.Addition(lastNumber,newNumber);
                        break;
                    case Operator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        /// <summary>
        /// Click event handler of the dot button of the calculator
        /// </summary>
        /// <param name="sender">If correctly setted, the sender is the dot button</param>
        /// <param name="e"></param>
        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            //If not containt the , add it
            if(!resultLabel.Content.ToString().Contains(","))
                resultLabel.Content = $"{resultLabel.Content},";
        }
    }
}
