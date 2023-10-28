using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YumYumExpress.Controller;
using YumYumExpress.Database;

namespace YumYumExpress.View
{
    public class Admin
    {
        

        public static void AddRestaurant()
        {
            var restaurant = new Controller.RestaurantController();
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
            

            RestaurantController.StoreRestaurant(restaurant);
        }

        public static void Functions(string password)
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
                    AdminController.ViewAllRestaurants();
                    break;

                case 2:
                    AdminController.ViewAllCustomers();
                    break;

                case 3:
                    //Delete restaurant.
                    Console.WriteLine("Enter the email address of the Restaurant you would like to remove: ");
                    string delEmail = Console.ReadLine();

                stepDelRest:
                    Console.WriteLine("Enter your password to confirm");
                    if (Console.ReadLine() == password)
                        AdminController.RemoveRestaurant(delEmail) ;
                    else
                    {
                        Console.WriteLine("Incorrect Password");
                        goto stepDelRest;
                    }

                    break;

                case 4:
                    //Delete Customer.
                    Console.WriteLine("Enter the email address of the Customer you would like to remove: ");
                    delEmail = Console.ReadLine();

                stepDelCust:
                    Console.WriteLine("Enter your password to confirm");
                    if (Console.ReadLine() == password)
                        AdminController.RemoveCustomers(delEmail);
                    else
                    {
                        Console.WriteLine("Incorrect Password");
                        goto stepDelCust;
                    }
                    break;
                case 5:
                    Admin.AddRestaurant();
                    break;

                default:
                    Console.WriteLine("Please Enter a valid Input.");
                    goto stepAdminFunctions;
                
            }

        }
    }
}
