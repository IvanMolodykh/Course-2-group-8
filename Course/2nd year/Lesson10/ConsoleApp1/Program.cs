using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
public class FileOperations
{
    public static void Main(string[] args)
    {
        public void WriteToFile(string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(content);
            }
            Console.ReadKey();
        }

        // Метод для чтения строк из файла
        public string ReadFromFile()
        {
            return File.Exists(filePath) ? File.ReadAllText(filePath) : "Файл не найден.";
        }

        // Метод для записи в файл в формате Markdown
        public void WriteToMarkdown(string title, string content)
        {
            string markdownContent = $"# {title}\\n\\n{content}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(markdownContent);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();

            // Запись в файл обычного текста
            fileService.WriteToFile("Привет, мир!");

            // Чтение из файла
            Console.WriteLine(fileService.ReadFromFile());

            // Запись в файл в формате Markdown
            fileService.WriteToMarkdown("Заголовок", "Это содержание в формате Markdown.");
            Console.WriteLine(fileService.ReadFromFile());
        }

}