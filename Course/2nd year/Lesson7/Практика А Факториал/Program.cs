using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_А_Факториал
{
    internal class Program
    {
        public class Factorial
        {
            public static long F(int n) => n < 0 ? throw new ArgumentException() : n == 0 ? 1 : n * F(n - 1);

            public static void Main(string[] args)
            {
                Console.Write("Введите число: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                    Console.WriteLine($"Факториал: {F(n)}");
                else
                    Console.WriteLine("Ошибка ввода.");
            }
        }
    }
}
