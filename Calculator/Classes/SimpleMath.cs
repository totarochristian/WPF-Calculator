using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Classes
{
    public static class SimpleMath
    {
        public static double Addition(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            //If second number is 0, show error and return 0 as result
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported!", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
                
            return n1 / n2;
        }
    }
}
