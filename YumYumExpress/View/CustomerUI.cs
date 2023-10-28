using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Database;

namespace YumYumExpress.View
{
    public class CustomerUI : User
    {
        DatabaseLayer d = new DatabaseLayer();
        public int TotalOrders { get; set; }
        public int CustomerId { get; set; }
        public List<Orders> LastOrders = new List<Orders>();
        UserType UserType { get; set; }
        public int GetTotalOrders(string email)
        {
            return DatabaseLayer.GetOrderCount(email);
        }

        public void BrowseRestaurants(string email)
        {
            var RestaurantList = d.Browse();
            int count = 1;
            foreach(var rest in RestaurantList) {
                Console.WriteLine("*****************************************");
                Console.WriteLine(count+". Name "+ rest.Name);
                Console.WriteLine("   Address "+rest.Address);
                Console.WriteLine("   Contact Number "+rest.ContactNo);
                Console.WriteLine("   Open Timing "+rest.OpenTiming);
                Console.WriteLine("   Discount "+rest.Discount);
                count++;
            }
        stepRestMenu:
            Console.WriteLine("Enter the Restaurant number you would like to order from: ");
            int RestInput = Convert.ToInt32(Console.ReadLine());

            Restaurant restaurant = new Restaurant();
        
            try
            {   
                
                var order = restaurant.BrowseMenu(RestInput);
                d.AddOrderToCustomer(email, order);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Enter a valid input.");
                goto stepRestMenu;
            }
            
            

        }

        public void Functions(string email, string password)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Hello Customer. Welcome to Yum Yum Express.");
            stepCustomer:
            Console.WriteLine("You can do the following operations: -");
            Console.WriteLine("1. Get Total Orders.\n" +
                "2. Start Ordering.");
            int CustInput = Convert.ToInt32(Console.ReadLine());

            switch(CustInput)
            {
                case 1:
                    Console.WriteLine(GetTotalOrders(email)); 
                    break;
                case 2:

                    BrowseRestaurants(email); break;
                default:
                    Console.WriteLine("Enter a valid input.");
                    goto stepCustomer;
            }
        }

    }
}
