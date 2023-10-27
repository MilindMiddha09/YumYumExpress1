using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YumYumExpress.Controller;

namespace YumYumExpress.View
{
    public class Restaurant : User
    {
        public string OpenTiming { get; set; }
        public int Discount { get; set; }

        public List<Product> Menu = new List<Product>();

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
            //Console.WriteLine(menu[0].ProductName);
            var RestaurantPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Restaurants.json";
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(RestaurantData);

            foreach (var rest in RestaurantList)
            {
                if (rest.Email == email && rest.Password == password)
                {
                    if (rest.Menu != null)
                    {
                        rest.Menu.AddRange(newMenu);
                    }
                    else
                    {
                        rest.Menu = newMenu;
                    }
                    break;
                }
            }

            RestaurantData = JsonConvert.SerializeObject(RestaurantList);
            File.WriteAllText(RestaurantPath, RestaurantData);

        }

        public static void ChangeDiscount()
        {
            //this.Discount = discount;
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
                    ChangeDiscount();
                    break;

                default:
                    Console.WriteLine("Enter a valid Input.");
                    goto stepRestaurant;
            }
        }

    }
}
