using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XUnitTestDemo
{
    public static class MathOperation
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public static double Divide(double number1, double number2)
        {
            return number1 / number2;
        }

        public static double CustomLogic(double number1, double number2)
        {
            // write your calculation/logic here and then return result
            return 0;
        }
    }
}
