using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Classes
{
    /// <summary>
    /// Class that give some baic math operations.
    /// </summary>
    public static class SimpleMath
    {
        /// <summary>
        /// Method used to add two numbers
        /// </summary>
        /// <param name="n1">Number 1 as double</param>
        /// <param name="n2">Number 2 as double</param>
        /// <returns>Double that is the result of the operation executed</returns>
        public static double Addition(double n1, double n2)
        {
            return n1 + n2;
        }

        /// <summary>
        /// Method used to subtract two numbers
        /// </summary>
        /// <param name="n1">Number 1 as double</param>
        /// <param name="n2">Number 2 as double</param>
        /// <returns>Double that is the result of the operation executed</returns>
        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        /// <summary>
        /// Method used to multiply two numbers
        /// </summary>
        /// <param name="n1">Number 1 as double</param>
        /// <param name="n2">Number 2 as double</param>
        /// <returns>Double that is the result of the operation executed</returns>
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        /// <summary>
        /// Method used to divide two numbers
        /// </summary>
        /// <param name="n1">Number 1 as double</param>
        /// <param name="n2">Number 2 as double</param>
        /// <returns>Double that is the result of the operation executed</returns>
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
