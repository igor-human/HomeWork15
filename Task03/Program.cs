using System;
using System.Linq;

namespace WorketExample
{
    //структура Price
    public struct Price
    {
        public string Name { get; set; }
        public string NameStore { get; set; }
        public double PriceGrn { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Price[] prices = new Price[2];

            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Введите данные для товара " + (i + 1) + ": ");
                Console.Write("Название товара:");
                string name = Console.ReadLine();

                Console.Write("Название магазина, где продаётся товар");
                string nameStore = Console.ReadLine();

                double priceGrn;

                while (true)
                {
                    Console.Write("Стоимость тавара в гривнах:");
                    if (double.TryParse(Console.ReadLine(), out priceGrn))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода цены, повторите попытку");
                    }
                }
                prices[i] = new Price { Name = name, PriceGrn = priceGrn, NameStore = nameStore };
            }
            //Сортировака массива
            Array.Sort(prices, (p1, p2) => p1.NameStore.CompareTo(p2.NameStore));

            Console.WriteLine("Введите название магазина для поиска:");
            string searchStore = Console.ReadLine();

            try
            {
                var storeProducts = prices.Where(p => p.NameStore.Equals(searchStore, StringComparison.OrdinalIgnoreCase)).ToArray();

                if (storeProducts.Length == 0)
                {
                    throw new Exception("Магазин не найден.");
                }

                Console.WriteLine($"Товары, продающиеся в магазине {searchStore}:");
                foreach (var price in storeProducts)
                {
                    Console.WriteLine($"Товар: {price.Name}, Стоимость: {price.PriceGrn} грн");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

}
