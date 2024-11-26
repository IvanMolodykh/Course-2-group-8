using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_AB
{
    internal class Program
    {
        public class Person
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public bool isVerified { get; set; }
        }

        public class Order
        {
            public string orderId { get; set; }
            public string customerName { get; set; }
            public double totalPrice { get; set; }
            public List<string> items { get; set; }
        }

        public class DataContainer
        {
            public Person person { get; set; }
            public Order order { get; set; }
        }


        public class Example
        {
            public static void Main(string[] args)
            {
                const string filePath = "1.json";

                try
                {
                    string jsonFromFile = File.ReadAllText(filePath);

                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Crucial for case-insensitive parsing
                    };

                    DataContainer data = JsonConvert.DeserializeObject<DataContainer>(jsonFromFile, options);

                    if (data != null && data.person != null && data.order != null && data.person.name == "Иван Иванов")
                    {
                        Console.WriteLine($"Email: {data.person.email}, ID: {data.person.id}");
                        Console.WriteLine($"\nСписок товаров, которые купила {data.order.customerName}:");
                        foreach (string item in data.order.items)
                        {
                            Console.WriteLine($"- {item}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при обработке данных JSON или пользователь не найден.");
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine($"Ошибка при парсинге JSON: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }
    }
}