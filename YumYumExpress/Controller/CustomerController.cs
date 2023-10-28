using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Database;
using YumYumExpress.View;

namespace YumYumExpress.Controller
{
    public class CustomerController : UserController
    {

        DatabaseLayer d = new DatabaseLayer();
        public int TotalOrders { get; set; }
        public string CustomerId { get; set; }
        public List<Orders> LastOrders = new List<Orders>();
        UserType UserType { get; set; }


        public static int GetTotalOrders(string email)
        {
            return DatabaseLayer.GetOrderCount(email);
        }

        public static void UpdateHistory(string email, Orders orders)
        {
            DatabaseLayer d = new DatabaseLayer();
            d.AddOrderToCustomer(email, orders);
        }
        public void StoreCustomer(CustomerController customer)
        {
            DatabaseLayer d = new DatabaseLayer();
            d.StoreCustomer(customer);
        }
    }
}
