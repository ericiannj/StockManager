using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    class Ebook : Product, IStock
    {
        public string author;
        private int sales;

        public Ebook(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
         }

        public void AddInput()
        {
            Console.WriteLine("It's not possible to add. The digital product already exists.");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Add sale of ebook {name}");
            Console.WriteLine("Type the quantity of ebooks sold: ");
            int input = int.Parse(Console.ReadLine());
            sales += input;
            Console.WriteLine("Purchased ebooks.");
            Console.ReadLine();
        }

        public void display()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Sales: {sales}");
            Console.WriteLine("=========================");
        }
    }
}
