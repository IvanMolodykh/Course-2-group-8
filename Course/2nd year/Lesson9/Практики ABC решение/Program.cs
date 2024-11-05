using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики_ABC_решение
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Introduce()
        {
            Console.WriteLine($"Привет, мое имя {Name}");
        }
    }
    public class PersonB : Person
    {
        public PersonB(string name, int age) : base(name, age)
        {
        }

        public void SetAge(int newAge)
        {
            if (newAge >= 0)
            {
                Age = newAge;
            }
            else
            {
                Console.WriteLine("Возраст не может быть отрицательным.");
            }
        }
    }

    public class Employee : Person
    {
        public string Position;

        public Employee(string name, int age, string position) : base(name, age)
        {
            Position = position;
        }
    }
    //Основная часть программы
    public class Program
    {
        public static void Main(string[] args)
        {
            //Практика А
            Person person1 = new Person("Иван", 30);
            person1.Introduce();

            Person[] people = new Person[]
            {
                new Person("Анна", 25),
                new Person("Петр", 40),
                new Person("Мария", 28)
            };

            foreach (Person person in people)
            {
                person.Introduce();
            }
            //Практика В
            PersonB personB = new PersonB("Василий", 20);
            personB.SetAge(25); 
            personB.SetAge(-5); 
            Console.WriteLine($"Возраст Василия: {personB.Age}");
            
            //Практика С
            Employee employee1 = new Employee("Сергей", 35, "Программист");
            Console.WriteLine($"Имя: {employee1.Name}, Возраст: {employee1.Age}, Должность: {employee1.Position}");
            Console.ReadKey();
        }
    }
}