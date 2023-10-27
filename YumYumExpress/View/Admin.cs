using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YumYumExpress.Database;

namespace YumYumExpress.View
{
    public class Admin
    {
        DatabaseLayer d = new DatabaseLayer();
        public string UserId { get; set; }
        public string Password { get; set; }


        public void ViewAllRestaurants()
        {
            var RestaurantPath = @"C:\Users\mmiddha\source\repos\Udemy_Part3\YumYumExpress\Restaurants.json";

            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonSerializer.Deserialize<List<Restaurant>>(RestaurantData);

            Console.WriteLine("===========================================");
            foreach (var rest in RestaurantList)
            {
                Console.WriteLine("Name: - " + rest.Name);
                Console.WriteLine("Contact Number: - " + rest.ContactNo);
                Console.WriteLine("Address: - " + rest.Address);
                Console.WriteLine("Opening Timings: - " + rest.OpenTiming);
                Console.WriteLine("Discount: - " + rest.Discount);
                Console.WriteLine("===============================================");
            }
        }

        public void ViewAllCustomers()
        {
            var CustomerPath = @"C:\Users\mmiddha\source\repos\Udemy_Part3\YumYumExpress\Customers.json";

            var CustomerData = File.ReadAllText(CustomerPath);

            var CustomerList = JsonSerializer.Deserialize<List<Restaurant>>(CustomerData);

            Console.WriteLine("===========================================");
            foreach (var cust in CustomerList)
            {
                Console.WriteLine("Name: - " + cust.Name);
                Console.WriteLine("Contact Number: - " + cust.ContactNo);
                Console.WriteLine("Address: - " + cust.Address);
                Console.WriteLine("Email: - " + cust.Email);
                Console.WriteLine("===============================================");
            }
        }

        public void RemoveRestaurant()
        {

        }

        public void RemoveCustomers()
        {

        }

        public void AddRestaurant()
        {
            var restaurant = new Restaurant();
            Console.WriteLine("Enter Restaurant Name: ");
            restaurant.Name = Console.ReadLine();

            Console.WriteLine("Enter Email Address: ");
            restaurant.Email = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            restaurant.Password = Console.ReadLine();

            Console.WriteLine("Enter Contact Number");
            restaurant.ContactNo = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter Address: ");
            restaurant.Address = Console.ReadLine();

            Console.WriteLine("Enter the Opening Timings.");
            restaurant.OpenTiming = Console.ReadLine();

            Console.WriteLine("Enter Discount: ");
            restaurant.Discount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(restaurant.Menu);
            //var Prod = new Product("First", 0);
            //var restaurant = new Restaurant()
            //{
            //    Name = name, ContactNo = contactNo,
            //    Email = email, Address = address,
            //    OpenTiming = OpenTimings, Discount = discount,
            //    Menu = new List<Product>()
            //};

            d.StoreRestaurant(restaurant);
        }

        public void Functions()
        {
            stepAdminFunctions:
            Console.WriteLine("=====================================");
            Console.WriteLine("Hello Admin.");
            Console.WriteLine("You can do the following functions: -");
            Console.WriteLine("1. View All Restaurants.\n" +
                "2. View All Customers.\n" +
                "3. Delete a Restaurant.\n" +
                "4. Delete a Customer.\n" +
                "5. Add a Restaurant.");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    ViewAllRestaurants();
                    break;

                case 2:
                    ViewAllCustomers();
                    break;

                case 3:
                    //Delete restaurant.
                    break;

                case 4:
                    //Delete Customer.
                    break;
                case 5:
                    AddRestaurant();
                    break;

                default:
                    Console.WriteLine("Please Enter a valid Input.");
                    goto stepAdminFunctions;
                
            }

        }
    }
}
