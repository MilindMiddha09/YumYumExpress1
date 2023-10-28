using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Database;
using YumYumExpress.View;

namespace YumYumExpress.Controller
{
    public class OrderController
    {
        public static Product GetOrderProduct(Restaurant rest, int id)
        {
            return DatabaseLayer.GetProduct(rest, id);
        }
    }
}
