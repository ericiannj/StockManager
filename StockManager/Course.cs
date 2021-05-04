using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    class Course : Product, IStock
    {
        public string author;
        private int vacancies;

        public Course(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }

        public void AddInput()
        {
            Console.WriteLine($"Add vacancies in the course {name}");
            Console.WriteLine("Type the quantity of vacancies: ");
            int input = int.Parse(Console.ReadLine());
            vacancies += input;
            Console.WriteLine("Input Registered.");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Fill vacancies of course {name}");
            Console.WriteLine("Type the quantity of vacancies: ");
            int input = int.Parse(Console.ReadLine());
            vacancies -= input;
            Console.WriteLine("Vacancies filled.");
            Console.ReadLine();
        }

        public void display()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Places Left: {vacancies}");
            Console.WriteLine("=========================");
        }
    }
}
