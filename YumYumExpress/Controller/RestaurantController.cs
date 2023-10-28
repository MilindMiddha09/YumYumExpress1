using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Database;
using YumYumExpress.View;

namespace YumYumExpress.Controller
{
    public class RestaurantController : UserController
    {
        public string OpenTiming { get; set; }
        public int Discount { get; set; }

        public List<Product> Menu = new List<Product>();
        public List<Orders> LastOrders = new List<Orders>();

        public void AddOrderToHistory(RestaurantController controller, Orders newOrder)
        {   
            DatabaseLayer d = new DatabaseLayer();
            d.AddOrderToRestaurant(controller, newOrder);
        }

        public static void StoreRestaurant(RestaurantController restaurant)
        {

            DatabaseLayer.StoreRestaurant(restaurant);
        }
    }
}
