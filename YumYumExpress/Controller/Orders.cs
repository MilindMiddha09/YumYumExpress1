using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumExpress.Controller
{
    internal class Orders
    {
        int OrderId { get; set; }
        string OrderBy { get; set; }
        string OrderTo { get; set; }
        int TotalAmount { get; set; }
        DateTime DateOfOrder { get; set; }

        List<Product> OrderedProducts = new List<Product>();
    }
}
