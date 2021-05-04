using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StockManager
{
    class Program
    {

        static List<IStock> products = new List<IStock>();

        enum Menu { List = 1, Add, Remove, Input, Output, Quit }
        static void Main(string[] args)
        {
            Load();
            bool quitted = false;
            while(quitted == false)
            {
                Console.WriteLine("Stock Manager:");
                Console.WriteLine("1-List\n2-Add\n3-Remove\n4-Input\n5-Output\n6-Quit");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if(opInt > 0 && opInt < 7)
                {
                    Menu choice = (Menu)opInt;

                    switch(choice)
                    {
                        case Menu.List:
                            List();
                            break;
                        case Menu.Add:
                            Register();
                            break;
                        case Menu.Remove:
                            Remove();
                            break;
                        case Menu.Input:
                            Input();
                            break;
                        case Menu.Output:
                            Output();
                            break;
                        case Menu.Quit:
                            quitted = true;
                            break;
                    }
                } else
                {
                    quitted = true;
                }
                Console.Clear();
            }
        }

        static void List()
        {
            Console.WriteLine("Products' List");
            int i = 0;
            foreach(IStock product in products)
            {
                Console.WriteLine("ID: " + i);
                product.display();
                i++;
            }
            Console.ReadLine();
        }

        static void Remove()
        {
            List();
            Console.WriteLine("Type the Product ID: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < products.Count)
            {
                products.RemoveAt(id);
                Save();
            }
        }

        static void Input()
        {
            List();
            Console.WriteLine("Type the Product ID: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddInput();
                Save();
            }
        }

        static void Output()
        {
            List();
            Console.WriteLine("Type the Product ID: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddOutput();
                Save();
            }
        }


        static void Register()
        {
            Console.WriteLine("Product Registration");
            Console.WriteLine("1-Physical Product\n2-Ebook\n3-Course");
            string opStr = Console.ReadLine();
            int choiceInt = int.Parse(opStr);
            switch (choiceInt)
            {
                case 1:
                    PhysicalReg();
                    break;
                case 2:
                    EbookReg();
                    break;
                case 3:
                    CourseReg();
                    break;
            }
        }

        static void PhysicalReg()
        {
            Console.WriteLine("Physical Product Registration: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Shipment: ");
            float shipment = float.Parse(Console.ReadLine());

            PhysicalProduct fp = new PhysicalProduct(name, price, shipment);
            products.Add(fp);
            Save();
        }

        static void EbookReg()
        {
            Console.WriteLine("Ebook Registration: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            Ebook eb = new Ebook(name, price, author);
            products.Add(eb);
            Save();
        }

        static void CourseReg()
        {
            Console.WriteLine("Course Registration: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            Course cs = new Course(name, price, author);
            products.Add(cs);
            Save();
        }

        static void Save()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            //To save in a binary way
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, products);

            stream.Close();
        }

        static void Load()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                products = (List<IStock>)encoder.Deserialize(stream);

                if(products == null)
                {
                    products = new List<IStock>();
                }
            }
            catch(Exception e)
            {
                products = new List<IStock>();
            }

            stream.Close();
        }
    }
}
