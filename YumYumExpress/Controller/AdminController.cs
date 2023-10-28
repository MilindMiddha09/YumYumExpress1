using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Database;

namespace YumYumExpress.Controller
{
    public class AdminController
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public static void ViewAllRestaurants()
        {
            DatabaseLayer.ViewAllRestaurants();
        }

        public static void ViewAllCustomers()
        {
            DatabaseLayer.ViewAllCustomers();
        }

        public static void RemoveRestaurant(string delEmail)
        {
            DatabaseLayer.RemoveRestaurant(delEmail);
        }

        public static void RemoveCustomers(string delEmail)
        {
            DatabaseLayer.RemoveCustomers(delEmail);
        }
    }
}
