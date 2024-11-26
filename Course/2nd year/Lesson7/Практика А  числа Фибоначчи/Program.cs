using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_А__числа_Фибоначчи
{
    internal class Program
    {
                public static long F(int n)
        {
            if (n <= 1) return n;
            return F(n - 1) + F(n - 2);
        }

        public static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"n-ое число Фибоначчи: {F(n)}");
        }
    }
    
}
