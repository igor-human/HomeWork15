using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    internal class Calculator
    {
        // Метод для сложения
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Метод для вычитания
        public double Sub(double a, double b)
        {
            return a - b;
        }

        // Метод для умножения
        public double Mul(double a, double b)
        {
            return a * b;
        }

        // Метод для деления с проверкой на деление на ноль
        public double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль.");
            }
            return a / b;
        }
    }
}
