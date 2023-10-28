using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YumYumExpress.Controller;
using YumYumExpress.Database;

namespace YumYumExpress.View
{
    public class Restaurant : User
    {
        
        public string OpenTiming { get; set; }
        public int Discount { get; set; }

        public List<Product> Menu = new List<Product>();
        public List<Orders> LastOrders = new List<Orders>();
        
        public static void AddMenu(string email, string password)
        {
            var newMenu = new List<Product>();
            Console.WriteLine("====Enter exit whenever you want to stop.====");
            //var Prod = new Product();
            while (true)
            {

                Console.WriteLine("Product Name: ");
                var ProdName = Console.ReadLine();

                if (ProdName == "exit")
                {
                    break;
                }

                Console.WriteLine("Product Price: ");
                var ProdPrice = Convert.ToInt32(Console.ReadLine());

                newMenu.Add(new Product() { ProductName = ProdName, Price = ProdPrice });
            }
            
            DatabaseLayer.AddRestMenu(email, password, newMenu);

        }

        public static void ChangeDiscount(string email, string password)
        {
            //this.Discount = discount;
            Console.WriteLine("====================================");
            Console.WriteLine("Enter New Discount.");
            int newDiscount = Convert.ToInt32(Console.ReadLine());

            
            DatabaseLayer.ChangeRestDiscount(email, password, newDiscount);
            
        }

        public static void Functions(string email, string password)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Hello Restaurant Owner.");
            Console.WriteLine("You can do the following operations: -");
            Console.WriteLine("==============================");
            stepRestaurant:
            Console.WriteLine("1. Add Menu.\n" +
                "2. Change Discount.");

            int RestInput = Convert.ToInt32(Console.ReadLine());

            switch(RestInput) {
                case 1:
                    AddMenu(email,password);
                    break;
                case 2:
                    ChangeDiscount(email, password);
                    break;

                default:
                    Console.WriteLine("Enter a valid Input.");
                    goto stepRestaurant;
            }
        }

        public Orders BrowseMenu(int count)
        {
            DatabaseLayer d = new DatabaseLayer();
            var Menu = d.RestaurantMenu(count);

            foreach(var menu in Menu)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Name: "+menu.ProductName+"  Price: "+ menu.Price);
                
            }

            
            List<Product> products = new List<Product>();
            Restaurant rest = d.GetRestaurant(count);
            products = Orders.OrderProducts(rest,count);

            int totalAmount = 0;

            foreach(var prod in products) {
                totalAmount += prod.Price;
            }

            Orders newOrder = new Orders()
            {   
                OrderId = DatabaseLayer.generateId(),
                
                TotalAmount = totalAmount,
                DateOfOrder = DateTime.Now,
                OrderedProducts = products,
                OrderTo = rest.Name,
            };
            
            d.AddOrderToRestaurant(rest,newOrder);
            Console.WriteLine("============================================");
            Console.WriteLine("Order Successful.");
            Console.WriteLine("OrderId: " + newOrder.OrderId);
            Console.WriteLine("Your total amount is "+ newOrder.TotalAmount);

            return newOrder;
        }
    }
}
