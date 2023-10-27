using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YumYumExpress.View;

namespace YumYumExpress.Database
{
    public class DatabaseLayer
    {
        //static List<Restaurant> ls;
        string CustomerPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Customers.json";
        string AdminPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Admin.json";
        string RestaurantPath = @"C:\Users\mmiddha\source\repos\YumYumExpress\YumYumExpress\Data\Restaurants.json";

        public void StoreCustomer(CustomerUI customer)
        {
            
            var CustomerData = File.ReadAllText(CustomerPath);
            var CustomerList = JsonConvert.DeserializeObject<List<CustomerUI>>(CustomerData);

            CustomerList.Add(customer);

            CustomerData = JsonConvert.SerializeObject(CustomerList);
            File.WriteAllText(CustomerPath, CustomerData);
        }


        public bool ValidateAdmin(string userid, string password)
        {
            var adminData = File.ReadAllText(AdminPath);
            var adminJson = JsonConvert.DeserializeObject<Admin>(adminData);

            if (userid == adminJson.UserId && password == adminJson.Password)
            {
                Console.WriteLine("Login Successful");
                return true;
            }

            else
            {
                Console.WriteLine("Email or password Wrong.");
                return false;
            }

        }

        public bool ValidateCustomer(string userid, string password)
        {
            var CustomerData = File.ReadAllText(CustomerPath);
            var CustomerJson = JsonConvert.DeserializeObject<List<CustomerUI>>(CustomerData);

            foreach (var cust in CustomerJson)
            {
                if (cust.Email == userid && cust.Password == password)
                {
                    Console.WriteLine("Login Successful");
                    return true;
                }

            }
            Console.WriteLine("Invalid Email or Password.");
            return false;
        }

        public void StoreRestaurant(Restaurant restaurant)
        {

            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(RestaurantData);

            var newRest = new Restaurant()
            {
                Name = restaurant.Name,
                Email = restaurant.Email,
                Password = restaurant.Password,
                ContactNo = restaurant.ContactNo,
                Menu = restaurant.Menu,
                Address = restaurant.Address,
                Discount = restaurant.Discount,
                OpenTiming = restaurant.OpenTiming,
            };
            RestaurantList.Add(newRest);
            string RestaurantData1 = JsonConvert.SerializeObject(RestaurantList, Formatting.Indented);
            File.WriteAllText(RestaurantPath, RestaurantData1);
        }

        public bool ValidateRestaurant(string userid, string password)
        {
            var RestaurantData = File.ReadAllText(RestaurantPath);

            var RestaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(RestaurantData);

            foreach (var rest in RestaurantList)
            {
                if (rest.Email == userid && rest.Password == password)
                {
                    Console.WriteLine("Login Successful.");
                    Console.WriteLine("-------------------------------------------");
                    return true;
                }
            }
            return false;

        }

        public Object CheckCustomer(string email, string password)
        {
            var CustomerData = File.ReadAllText(CustomerPath);

            var CustomerList = JsonConvert.DeserializeObject<List<CustomerUI>>(CustomerData);

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

            var RestaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(RestaurantData);

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

            List<Admin> AdminList = JsonConvert.DeserializeObject<List<Admin>>(AdminData);

            foreach (var admin in AdminList)
            {
                if (admin.UserId == email && admin.Password == password)
                    return admin;
            }

            return null;
        }
    }
}
