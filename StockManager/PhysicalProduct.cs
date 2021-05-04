using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    //Allows to save data in a file
    [System.Serializable]
    class PhysicalProduct : Product, IStock
    {
        public float shipment;
        private int stock;

        public PhysicalProduct(string name, float price, float shipment)
        {
            this.name = name;
            this.price = price;
            this.shipment = shipment;
        }

        public void AddInput()
        {
            Console.WriteLine($"Add new product {name}");
            Console.WriteLine("Type the quantity of the product input: ");
            int input = int.Parse(Console.ReadLine());
            stock += input;
            Console.WriteLine("Input Registered.");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Add Product Output {name}");
            Console.WriteLine("Type the quantity of the product output: ");
            int input = int.Parse(Console.ReadLine());
            stock -= input;
            Console.WriteLine("Output Registered.");
            Console.ReadLine();
        }

        public void display()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Shipment: {shipment}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine("=========================");
        }
    }
}
