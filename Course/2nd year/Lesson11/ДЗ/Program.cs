using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public Dictionary<string, int> Grades { get; set; }
            public Dictionary<string, bool> Attendance { get; set; }

            public Student(string name)
            {
                Name = name;
                Grades = new Dictionary<string, int>();
                Attendance = new Dictionary<string, bool>();
            }

            public void AddGrade()
            {
                Console.Write("Введите предмет: ");
                string subject = Console.ReadLine();

                Console.Write("Введите оценку: ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                {
                    Grades[subject] = grade;
                    Console.WriteLine($"Оценка {grade} по предмету '{subject}' поставлена.");
                }
                else
                {
                    Console.WriteLine("Неккоректный ввод. Оценка не поставлена.");
                }
            }

            public void AddAttendance()
            {
                Console.WriteLine("Введите данные о посещаемости ученика (format: 'data=true/false'):");
                string input = Console.ReadLine();
                var parts = input.Split('=');
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime date))
                {
                    bool wasPresent = parts[1].ToLower() == "true";
                    Attendance[date.ToLongDateString()] = wasPresent;
                    Console.WriteLine("Данные о посещаемости добавлена.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Данные о посещаемости не добавлена.");
                }
            }
        }


        public class StudetnFileService
        {
            public const string FilePath = "students.txt";
            public Dictionary<string, Student> students = new Dictionary<string, Student>();

            public StudetnFileService(Dictionary<string, Student> data)
            {
                students = data;
            }

            public void SaveToFile(string filePath = FilePath)
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var student in students.Values)
                    {
                        string grades = string.Join(";", student.Grades.Select(g => $"{g.Key}:{g.Value}"));
                        string attendance = string.Join(";", student.Attendance.Select(a => $"{a.Key}:{a.Value}"));
                        writer.WriteLine($"{student.Name},{grades},{attendance}");
                    }
                }
            }
            public void LoadFromFile(string filePath = FilePath)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length < 3)
                        {
                            continue; 
                        }

                        var studentName = parts[0];
                        var student = new Student(studentName);

                        var gradesPart = parts[1].Split(':');
                        if (gradesPart.Length == 2 && int.TryParse(gradesPart[1], out int grade))
                        {
                            student.Grades.Add(gradesPart[0], grade);
                        }

                        var attendancePart = parts[2].Split(':');
                        if (attendancePart.Length == 2 && DateTime.TryParse(attendancePart[0], out DateTime date) && bool.TryParse(attendancePart[1], out bool wasPresent))
                        {
                            student.Attendance.Add(date.ToLongDateString(), wasPresent);
                        }

                        students.Add(student.Name, student);
                    }
                }
            }


        }

        class SimpleDB
        {
            private StudetnFileService fileService;
            public SimpleDB()
            {
                fileService = new StudetnFileService(students);
                LoadDB();
            }
            public Dictionary<string, Student> students = new Dictionary<string, Student>();

            public void SaveDB()
            {
               
             
            }

            public void LoadDB()
            {
               

            }
            public void AddStudent(string name)
            {
                
               
            }

            public void RemoveStudent(string name)
            {
               
               
            }

            public void ShowStudentInfo(string name)
            {
              
            
            }

            public Student GetStudent(string name)
            {
                if (students.TryGetValue(name, out var student))
                {
                    return student;
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                    return null;
                }
            }
        }

        class P
        {
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var db = new SimpleDB();
                while (true)
                {
                    Console.WriteLine("\n1. Добавить студента\n2. Показать студента\n3. Удалить студента\n4. Поставить оценку\n5. Добавить  посещаемость \n6 Сохранить  базу данных\n0. Выход");
                    Console.Write("Выбор: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Неправильно,ещё раз.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите имя студента: ");
                            string name = Console.ReadLine();
                            db.AddStudent(name);
                            break;
                        case 2:
                            Console.Write("Введите имя студента (информацию): ");
                            name = Console.ReadLine();
                            db.ShowStudentInfo(name);
                            break;
                        case 3:
                            Console.Write("Введите имя для удаления студента из списка: ");
                            name = Console.ReadLine();
                            db.RemoveStudent(name);
                            break;
                        case 4:
                            Console.Write("Введите имя студкента (оценка): ");
                            name = Console.ReadLine();
                            Student student = db.GetStudent(name);
                            student?.AddGrade();
                            break;
                        case 5:
                            Console.Write("Введите имя студента (посещаемость): ");
                            name = Console.ReadLine();
                            student = db.GetStudent(name);
                            student?.AddAttendance();
                            break;
                        case 6:
                            Console.WriteLine("Сохранено");
                            db.SaveDB();
                            break;

                        case 0:
                            return;
                        default:
                            Console.WriteLine("Неправильно,ещё раз.");
                            break;
                    }
                }
            }
        }
    } 
}
