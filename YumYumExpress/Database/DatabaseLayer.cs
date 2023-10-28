using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YumYumExpress.Controller;
using YumYumExpress.View;

namespace YumYumExpress.Database
{
    public class DatabaseLayer
    {
        //static List<Restaurant> ls;
        static string CustomerPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Customers.json";
        static string AdminPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Admin.json";
        static string RestaurantPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Restaurants.json";

        public void StoreCustomer(CustomerController customer)
        {

            var CustomerData = File.ReadAllText(CustomerPath);
            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>>(CustomerData);

            CustomerList.Add(customer);

            CustomerData = JsonConvert.SerializeObject(CustomerList);
            File.WriteAllText(CustomerPath, CustomerData);
        }


        //public bool ValidateAdmin(string userid, string password)
        //{
        //    var adminData = File.ReadAllText(AdminPath);
        //    var adminJson = JsonConvert.DeserializeObject<AdminController>(adminData);

        //    if (userid == adminJson.UserId && password == adminJson.Password)
        //    {
        //        Console.WriteLine("Login Successful");
        //        return true;
        //    }

        //    else
        //    {
        //        Console.WriteLine("Email or password Wrong.");
        //        return false;
        //    }

        //}

        //public bool ValidateCustomer(string userid, string password)
        //{
        //    var CustomerData = File.ReadAllText(CustomerPath);
        //    var CustomerJson = JsonConvert.DeserializeObject<List<CustomerController>>(CustomerData);

        //    foreach (var cust in CustomerJson)
        //    {
        //        if (cust.Email == userid && cust.Password == password)
        //        {
        //            Console.WriteLine("Login Successful");
        //            return true;
        //        }

        //    }
        //    Console.WriteLine("Invalid Email or Password.");
        //    return false;
        //}

        public static void StoreRestaurant(RestaurantController restaurant)
        {

            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            var newRest = new RestaurantController()
            {
                Name = restaurant.Name,
                Email = restaurant.Email,
                Password = restaurant.Password,
                ContactNo = restaurant.ContactNo,
                Menu = restaurant.Menu,
                Address = restaurant.Address,
                Discount = restaurant.Discount,
                OpenTiming = restaurant.OpenTiming,
                userType = UserType.Restaurant
            };
            RestaurantList.Add(newRest);
            string RestaurantData1 = JsonConvert.SerializeObject(RestaurantList, Formatting.Indented);
            File.WriteAllText(RestaurantPath, RestaurantData1);
        }

        //public bool ValidateRestaurant(string userid, string password)      
        //{
        //    var RestaurantData = File.ReadAllText(RestaurantPath);

        //    var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

        //    foreach (var rest in RestaurantList)
        //    {
        //        if (rest.Email == userid && rest.Password == password)
        //        {
        //            Console.WriteLine("Login Successful.");
        //            Console.WriteLine("-------------------------------------------");
        //            return true;
        //        }
        //    }
        //    return false;

        //}

        public Object CheckCustomer(string email, string password)
        {
            var CustomerData = File.ReadAllText(CustomerPath);

            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>>(CustomerData);

            foreach(var cust in CustomerList)
            {
                if(cust.Email == email && cust.Password == password)
                    return cust;
            }

            return null;
        }

        public Object CheckRestaurant(string email, string password)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            foreach (var rest in RestaurantList)
            {
                if (rest.Email == email && rest.Password == password)
                    return rest;
            }

            return null;
        }

        public Object CheckAdmin(string email, string password)
        {
            var AdminData = File.ReadAllText(AdminPath);

            var AdminList = JsonConvert.DeserializeObject<List<AdminController>>(AdminData);

            foreach (var admin in AdminList)
            {
                if (admin.UserId == email && admin.Password == password)
                    return admin;
            }

            return null;
        }

        public static void AddRestMenu(string email, string password, List<Product> menu)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            foreach (var rest in RestaurantList)
            {
                if (rest.Email == email && rest.Password == password)
                {
                    if (rest.Menu != null)
                    {
                        rest.Menu.AddRange(menu);
                    }
                    else
                    {
                        rest.Menu = menu;
                    }
                    break;
                }
            }

            RestaurantData = JsonConvert.SerializeObject(RestaurantList);
            File.WriteAllText(RestaurantPath, RestaurantData);
        }

        public static void ChangeRestDiscount(string email, string password, int discount) {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            foreach(var rest in RestaurantList)
            {
                if(rest.Email == email && rest.Password == password)
                {
                    rest.Discount = discount;
                    break;
                }
            }

            RestaurantData = JsonConvert.SerializeObject(RestaurantList);
            File.WriteAllText(RestaurantPath, RestaurantData);

        }

        public List<RestaurantController> Browse() {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            return RestaurantList;
        }

        public List<Product> RestaurantMenu(int count)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);
            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            var ReqRestaurant = RestaurantList[count-1];

            return ReqRestaurant.Menu;           
        }

        public RestaurantController GetRestaurant(int id) {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            return RestaurantList[id - 1];
        }
        public static Product GetProduct(RestaurantController rest,int id)
        {
            return rest.Menu[id - 1];
        }

        public void AddOrderToRestaurant(RestaurantController rest,Orders order)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);
            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            foreach(var r in RestaurantList)
            {
                if(r.Email == rest.Email)
                {
                    r.LastOrders.Add(order);
                    break;
                }
            }

            RestaurantData = JsonConvert.SerializeObject(RestaurantList);
            File.WriteAllText(RestaurantPath, RestaurantData);
        }

        public static string generateId()

        {

            StringBuilder builder = new StringBuilder();

            Enumerable

               .Range(65, 26)

                .Select(e => ((char)e).ToString())

                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))

                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))

                .OrderBy(e => Guid.NewGuid())

                .Take(11)

                .ToList().ForEach(e => builder.Append(e));

            string id = builder.ToString();


            return id;

        }

        public void AddOrderToCustomer(string email, Orders order)
        {
            
            var CustomerData = File.ReadAllText(CustomerPath);
            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>> (CustomerData);

            foreach(var cust in CustomerList)
            {
                if(cust.Email == email)
                {
                    cust.TotalOrders++;
                    cust.LastOrders.Add(order);
                    break;
                }
            }

            CustomerData = JsonConvert.SerializeObject(CustomerList);
            File.WriteAllText(CustomerPath, CustomerData);
        }

        public static int GetOrderCount(string email)
        {
            var CustomerData = File.ReadAllText (CustomerPath);
            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>> (CustomerData);
            
            foreach(var cust in CustomerList)
            {
                if(cust.Email == email)
                {
                    return cust.TotalOrders;
                }
            }

            return -1;
        }

        public static void ViewAllRestaurants()
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

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
        public static void ViewAllCustomers()
        {
            var CustomerData = File.ReadAllText(CustomerPath);

            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>>(CustomerData);

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

        public static void RemoveRestaurant(string email)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);
            var RestaurantList = JsonConvert.DeserializeObject<List<RestaurantController>>(RestaurantData);

            foreach (var rest in RestaurantList)
            {
                if (rest.Email == email)
                {
                    RestaurantList.Remove(rest);
                    RestaurantData = JsonConvert.SerializeObject(RestaurantList, Formatting.Indented);
                    File.WriteAllText(RestaurantPath, RestaurantData);
                    return;
                }
            }

            Console.WriteLine("No such Restaurant Found.");

        }

        public static void RemoveCustomers(string email)
        {
            var CustomerData = File.ReadAllText(CustomerPath);
            var CustomerList = JsonConvert.DeserializeObject<List<CustomerController>>(CustomerData);

            foreach (var rest in CustomerList)
            {
                if (rest.Email == email)
                {
                    CustomerList.Remove(rest);
                    CustomerData = JsonConvert.SerializeObject(CustomerList, Formatting.Indented);
                    File.WriteAllText(CustomerPath, CustomerData);
                    return;
                }
            }

            Console.WriteLine("No such Restaurant Found.");
        }
    }
}
