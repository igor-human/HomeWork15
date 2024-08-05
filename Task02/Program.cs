using System;
using System.Linq;

namespace WorkerExample
{
    // Определение структуры Worker
    public struct Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int YearOfJoining { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine($"Введите данные для работника {i + 1}:");

                Console.Write("Фамилия и инициалы: ");
                string name = Console.ReadLine();

                Console.Write("Название занимаемой должности: ");
                string position = Console.ReadLine();

                int yearOfJoining;
                while (true)
                {
                    Console.Write("Год поступления на работу: ");
                    string yearInput = Console.ReadLine();
                    try
                    {
                        yearOfJoining = int.Parse(yearInput);
                        if (yearOfJoining < 1900 || yearOfJoining > DateTime.Now.Year)
                        {
                            throw new ArgumentOutOfRangeException("Год должен быть в диапазоне от 1900 до текущего года.");
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: Введите год в правильном формате.");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }

                workers[i] = new Worker { Name = name, Position = position, YearOfJoining = yearOfJoining };
            }

            // Сортировка массива по фамилии и инициалам
            Array.Sort(workers, (w1, w2) => w1.Name.CompareTo(w2.Name));

            Console.Write("Введите значение стажа работы: ");
            int experience;
            while (!int.TryParse(Console.ReadLine(), out experience))
            {
                Console.WriteLine("Ошибка: Введите значение стажа в правильном формате.");
            }

            // Вывод работников со стажем работы превышающим введенное значение
            Console.WriteLine("Работники со стажем работы больше {0} лет:", experience);
            bool found = false;
            foreach (var worker in workers)
            {
                int workerExperience = DateTime.Now.Year - worker.YearOfJoining;
                if (workerExperience > experience)
                {
                    Console.WriteLine($"Фамилия и инициалы: {worker.Name}, Должность: {worker.Position}, Год поступления: {worker.YearOfJoining}, Стаж: {workerExperience} лет");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Нет работников с указанным стажем работы.");
            }
        }
    }
}

