using System;
using System.Linq;
using Task05;

namespace WorketExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            try
            {
                Console.Write("Введите первое число: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Введите второе число: ");
                double num2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Выберите операцию: +, -, *, /");
                char operation = Console.ReadLine()[0];

                double result = 0;

                switch (operation)
                {
                    case '+':
                        result = calculator.Add(num1, num2);
                        break;
                    case '-':
                        result = calculator.Sub(num1, num2);
                        break;
                    case '*':
                        result = calculator.Mul(num1, num2);
                        break;
                    case '/':
                        result = calculator.Div(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Ошибка: неверная операция.");
                        return;
                }

                Console.WriteLine($"Результат: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введите корректное число.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }


        }


    }



}
