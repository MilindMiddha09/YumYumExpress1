using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Controller;
using YumYumExpress.Database;

namespace YumYumExpress.View
{
    public class Orders
    {
        public string OrderId { get; set; }
        public string OrderTo { get; set; }
        public int TotalAmount { get; set; }
        public DateTime DateOfOrder { get; set; }

        public List<Product> OrderedProducts = new List<Product>();

        public static List<Product> OrderProducts(Restaurant rest, int count)
        {
        StepMenu:
            Console.WriteLine("=================================================================");
            Console.WriteLine("Enter the Products you want to order. (Else type quit to checkout)");
            Console.WriteLine("=================================================================");
            var OrderedItems = new List<Product>();
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "quit")
                        break;

                    int input2 = Convert.ToInt32(input);
                    //Console.WriteLine(input2.GetType());
                    OrderedItems.Add(OrderController.GetOrderProduct(rest, input2));
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Enter a valid input");
                    goto StepMenu;
                }
            }
            //Console.WriteLine(OrderedItems);
            return OrderedItems;
        }
    }
}
