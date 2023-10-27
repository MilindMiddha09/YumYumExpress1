using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumExpress.Controller
{
    public class Product
    {
        public string ProductName;
        public int Price;

        public Product() { }
        public Product(string name, int price)
        {
            ProductName = name;
            Price = price;
        }
    }
}
