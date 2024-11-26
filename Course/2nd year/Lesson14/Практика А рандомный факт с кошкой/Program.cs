using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Практика_А_рандомный_факт_с_кошкой
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Нажмите 'R', чтобы получить случайный котофакт.");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.R)
                {
                    try
                    {
                        string json = await new HttpClient().GetStringAsync("https://catfact.ninja/fact");
                        Console.WriteLine($"Котофакт: {JsonSerializer.Deserialize<JsonElement>(json).GetProperty("fact").GetString()}");
                    }
                    catch { Console.WriteLine("Ошибка!"); }
                }
            }
        }
    }
        
}
