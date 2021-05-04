using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    //It's necessary to create other classes because this one is just the parent
    abstract class Product
    {
        public string name;
        public float price;
    }
}
